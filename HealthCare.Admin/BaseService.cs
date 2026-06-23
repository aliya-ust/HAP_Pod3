using System.Net.Http.Json;
using HealthCare.Shared;

namespace HealthCare.Admin
{
    public abstract class BaseService
    {
        protected readonly HttpClient _httpClient;

        protected BaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected async Task<ApiResponse<T>> SendGetAsync<T>(string url)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ApiResponse<T>>(url)
                       ?? new ApiResponse<T> { Success = false, Message = "No data returned." };
            }
            catch (Exception ex)
            {
                return new ApiResponse<T> { Success = false, Message = ex.Message };
            }
        }

        protected async Task<ApiResponse<T>> SendPostAsync<T>(string url, object data)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(url, data);
                return await response.Content.ReadFromJsonAsync<ApiResponse<T>>()
                       ?? new ApiResponse<T> { Success = false, Message = "Failed to deserialize." };
            }
            catch (Exception ex)
            {
                return new ApiResponse<T> { Success = false, Message = ex.Message };
            }
        }
    }
}