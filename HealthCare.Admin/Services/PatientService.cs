using System.Net.Http.Json;
using HealthCare.Shared;
using HealthCare.Shared.DTOs;
using HealthCare.Shared.DTOs.Patient;

namespace HealthCare.Admin.Services
{
    public class PatientService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PatientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient _http => _httpClientFactory.CreateClient("AdminPortalAPI");

        public async Task<PagedResult<PatientListDto>> GetAllAsync(PatientFilter filter)
        {
            var query = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(filter.Search))
                query["Search"] = filter.Search;

            if (filter.HasInsurance.HasValue)
                query["HasInsurance"] = filter.HasInsurance.Value.ToString();

            if (filter.IsActive.HasValue)
                query["IsActive"] = filter.IsActive.Value.ToString();

            query["PageNumber"] = filter.PageNumber.ToString();
            query["PageSize"] = filter.PageSize.ToString();

            var queryString = string.Join("&",
                query.Select(kvp => $"{kvp.Key}={Uri.EscapeDataString(kvp.Value)}"));

            var url = $"api/admin/patients?{queryString}";

            var result = await _http.GetFromJsonAsync<ApiResponse<PagedResult<PatientListDto>>>(url);
            return result?.Data ?? new PagedResult<PatientListDto>();
        }

        public async Task CreateAsync(CreatePatientDto dto)
        {
            await _http.PostAsJsonAsync("api/auth/register/patient", dto);
        }

        public async Task UpdateAsync(int id, UpdatePatientDto dto)
        {
            await _http.PutAsJsonAsync($"api/admin/patients/{id}", dto);
        }

        public async Task UpdateStatusAsync(int id, bool isActive)
        {
            await _http.PatchAsJsonAsync($"api/admin/patients/{id}/status", isActive);
        }

        public async Task DeleteAsync(int id)
        {
            await _http.DeleteAsync($"api/admin/patients/{id}");
        }
    }
}
