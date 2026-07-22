using System.Net.Http.Json;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Shared.DTOs;

namespace HealthCare.Admin.Services
{
    public class PatientService
    {
        private readonly HttpClient _httpClient;

        public PatientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PagedResult<PatientListDto>> GetPatientsAsync(
            PatientFilter filter)
        {
            var queryParams = new List<string>();

            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                queryParams.Add(
                    $"Search={Uri.EscapeDataString(filter.Search)}");
            }

            if (filter.HasInsurance.HasValue)
            {
                queryParams.Add(
                    $"HasInsurance={filter.HasInsurance.Value.ToString().ToLower()}");
            }

            queryParams.Add($"PageNumber={filter.PageNumber}");
            queryParams.Add($"PageSize={filter.PageSize}");

            var queryString = string.Join("&", queryParams);
            var url = $"api/admin/patients?{queryString}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();

                throw new InvalidOperationException(
                    $"Failed to fetch patients. " +
                    $"Status: {(int)response.StatusCode} " +
                    $"{response.ReasonPhrase}. {error}");
            }

            var result = await response.Content
                .ReadFromJsonAsync<PagedResult<PatientListDto>>();

            return result ?? new PagedResult<PatientListDto>();
        }

        public async Task<bool> UpdatePatientStatusAsync(
            int patientId,
            bool isActive)
        {
            var response = await _httpClient.PatchAsJsonAsync(
                $"api/admin/patients/{patientId}/status",
                isActive);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();

                throw new InvalidOperationException(
                    $"Patient status update failed. " +
                    $"Status: {(int)response.StatusCode} " +
                    $"{response.ReasonPhrase}. {error}");
            }

            return true;
        }

        public async Task<bool> DeletePatientAsync(int patientId)
        {
            var response = await _httpClient.DeleteAsync(
                $"api/admin/patients/{patientId}");

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();

                throw new InvalidOperationException(
                    $"Patient deletion failed. " +
                    $"Status: {(int)response.StatusCode} " +
                    $"{response.ReasonPhrase}. {error}");
            }

            return true;
        }

        public async Task<PatientListDto?> GetPatientByIdAsync(
            int patientId)
        {
            var response = await _httpClient.GetAsync(
                $"api/admin/patients/{patientId}");

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();

                throw new InvalidOperationException(
                    $"Failed to fetch patient. " +
                    $"Status: {(int)response.StatusCode} " +
                    $"{response.ReasonPhrase}. {error}");
            }

            return await response.Content
                .ReadFromJsonAsync<PatientListDto>();
        }
    }
}