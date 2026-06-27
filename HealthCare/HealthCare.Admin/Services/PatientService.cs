
using System.Net.Http.Json;

using HealthCare.Api.DTOs.Patient;
using HealthCare.Shared.DTOs;

namespace HealthCare.Admin.Services
{
    public class PatientService
    {
        private readonly HttpClient _httpClient;

        private readonly AuthHeaderService _authHeaderService;

        public PatientService(HttpClient httpClient, AuthHeaderService authHeaderService)
        {
            _httpClient = httpClient;
            _authHeaderService = authHeaderService;
        } 

        

        public async Task<PagedResult<PatientListDto>> GetPatientsAsync(PatientFilter filter)
        {
            await _authHeaderService.AddAuthorizationHeaderAsync(_httpClient);


            var queryParams = new List<string>();

            // ✅ Search by name
            if (!string.IsNullOrWhiteSpace(filter.Search))
                queryParams.Add($"Search={Uri.EscapeDataString(filter.Search)}");

            // ✅ Insurance filter
            if (filter.HasInsurance.HasValue)
                queryParams.Add($"HasInsurance={filter.HasInsurance.Value.ToString().ToLower()}");

            // ✅ Pagination
            queryParams.Add($"PageNumber={filter.PageNumber}");
            queryParams.Add($"PageSize={filter.PageSize}");

            // ✅ FIX
            var queryString = string.Join("&", queryParams);

            var url = $"api/admin/patients?{queryString}";

            var response = await _httpClient.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exception("Unauthorized");

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception(error);
            }

            var pagedResult = await response.Content.ReadFromJsonAsync<PagedResult<PatientListDto>>();

            return pagedResult ?? new PagedResult<PatientListDto>();
        }
        public async Task<bool> UpdatePatientStatusAsync(int patientId, bool isActive)
        {
            await _authHeaderService.AddAuthorizationHeaderAsync(_httpClient);


            var response = await _httpClient.PatchAsJsonAsync(
                $"api/admin/patients/{patientId}/status", isActive);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePatientAsync(int patientId)
        {
            await _authHeaderService.AddAuthorizationHeaderAsync(_httpClient);


            var response = await _httpClient.DeleteAsync(
                $"api/admin/patients/{patientId}");

            return response.IsSuccessStatusCode;
        }

        public async Task<PatientListDto?> GetPatientByIdAsync(int patientId)
        {
            await _authHeaderService.AddAuthorizationHeaderAsync(_httpClient);


            var response = await _httpClient.GetAsync($"api/admin/patients/{patientId}");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<PatientListDto>();
        }
    }
}
