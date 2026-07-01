using System.Net.Http.Json;
using HealthCare.Shared;
using HealthCare.Shared.DTOs;
using HealthCare.Shared.DTOs.Doctor;

namespace HealthCare.Admin.Services
{
    public class DoctorService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DoctorService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient _http => _httpClientFactory.CreateClient("AdminPortalAPI");

        public async Task<PagedResult<DoctorListDto>> GetAllAsync(DoctorFilter filter)
        {
            var query = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(filter.Search))
                query["Search"] = filter.Search;

            if (!string.IsNullOrWhiteSpace(filter.Specialisation))
                query["Specialisation"] = filter.Specialisation;

            if (filter.IsActive.HasValue)
                query["IsActive"] = filter.IsActive.Value.ToString();

            if (!string.IsNullOrEmpty(filter.SortBy))
                query["SortBy"] = filter.SortBy;

            query["IsDescending"] = filter.IsDescending.ToString();
            query["PageNumber"] = filter.PageNumber.ToString();
            query["PageSize"] = filter.PageSize.ToString();

            var queryString = string.Join("&",
                query.Select(kvp => $"{kvp.Key}={Uri.EscapeDataString(kvp.Value)}"));

            var url = $"api/admin/doctors?{queryString}";

            var result = await _http.GetFromJsonAsync<ApiResponse<PagedResult<DoctorListDto>>>(url);
            return result?.Data ?? new PagedResult<DoctorListDto>();
        }

        public async Task UpdateAsync(int id, UpdateDoctorDto dto)
        {
            var response = await _http.PutAsJsonAsync($"api/admin/doctors/{id}", dto);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<ApiResponse>();
                throw new Exception(error?.Message ?? "Failed to update doctor.");
            }
        }

        public async Task UpdateStatusAsync(int id, bool isActive)
        {
            var response = await _http.PatchAsJsonAsync($"api/admin/doctors/{id}/status", isActive);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<ApiResponse>();
                throw new Exception(error?.Message ?? "Failed to update status.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/admin/doctors/{id}");
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<ApiResponse>();
                throw new Exception(error?.Message ?? "Failed to delete doctor.");
            }
        }

        public async Task CreateAsync(CreateDoctorDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/auth/register/doctor", dto);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<ApiResponse>();
                throw new Exception(error?.Message ?? "Failed to create doctor.");
            }
        }
    }
}
