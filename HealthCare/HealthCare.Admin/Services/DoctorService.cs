using System.Net.Http.Json;

using HealthCare.Api.DTOs.Doctor;
using HealthCare.Shared.DTOs;

namespace HealthCare.Admin.Services
{
    public class DoctorService
    {
        private readonly HttpClient _httpClient;


        private readonly AuthHeaderService _authHeaderService;

        public DoctorService(HttpClient httpClient, AuthHeaderService authHeaderService)
        {
            _httpClient = httpClient;
            _authHeaderService = authHeaderService;
        }


        public async Task<PagedResult<DoctorListDto>> GetDoctorsAsync(DoctorFilter filter)
        {
            await _authHeaderService.AddAuthorizationHeaderAsync(_httpClient);

            var queryParams = new List<string>();

            if (!string.IsNullOrWhiteSpace(filter.Search))
                queryParams.Add($"Search={Uri.EscapeDataString(filter.Search)}");

            if (!string.IsNullOrWhiteSpace(filter.Specialisation))
                queryParams.Add($"Specialisation={Uri.EscapeDataString(filter.Specialisation)}");

            if (filter.IsActive.HasValue)
                queryParams.Add($"IsActive={filter.IsActive.Value.ToString().ToLower()}");

            if (!string.IsNullOrWhiteSpace(filter.SortBy))
                queryParams.Add($"SortBy={Uri.EscapeDataString(filter.SortBy)}");

            queryParams.Add($"IsDescending={filter.IsDescending.ToString().ToLower()}");
            queryParams.Add($"PageNumber={filter.PageNumber}");
            queryParams.Add($"PageSize={filter.PageSize}");

            var queryString = string.Join("&", queryParams);

            var url = $"api/admin/doctors?{queryString}";

            var response = await _httpClient.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exception("Unauthorized");

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"API Error: {error}");
            }

            var result = await response.Content.ReadFromJsonAsync<PagedResult<DoctorListDto>>();

            return result ?? new PagedResult<DoctorListDto>();
        }

        public async Task<DoctorListDto?> GetDoctorByIdAsync(int doctorId)
        {
            await _authHeaderService.AddAuthorizationHeaderAsync(_httpClient);
            var response = await _httpClient.GetAsync($"api/admin/doctors/{doctorId}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exception("Unauthorized");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<DoctorListDto>();
        }

        public async Task<bool> UpdateDoctorAsync(int doctorId, UpdateDoctorDto dto)
        {
            await _authHeaderService.AddAuthorizationHeaderAsync(_httpClient);

            var response = await _httpClient.PutAsJsonAsync(
                $"api/admin/doctors/{doctorId}",
                dto);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateDoctorStatusAsync(int doctorId, bool isActive)
        {
            await _authHeaderService.AddAuthorizationHeaderAsync(_httpClient);

            var response = await _httpClient.PatchAsJsonAsync(
                $"api/admin/doctors/{doctorId}/status",
                isActive);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteDoctorAsync(int doctorId)
        {
            await _authHeaderService.AddAuthorizationHeaderAsync(_httpClient);
            var response = await _httpClient.DeleteAsync(
                $"api/admin/doctors/{doctorId}");

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> CreateDoctorAsync(CreateDoctorDto dto)
        {
            await _authHeaderService.AddAuthorizationHeaderAsync(_httpClient);
            var response = await _httpClient.PostAsJsonAsync(
                "api/auth/register/doctor",
                dto);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Registration failed: {error}");
            }

            return true;
        } 
    }
}
