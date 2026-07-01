using System.Net.Http.Json;
using HealthCare.Shared;
using HealthCare.Shared.DTOs.Appointment;

namespace HealthCare.Admin.Services
{
    public class AppointmentService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AppointmentService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient Http => _httpClientFactory.CreateClient("AdminPortalAPI");

        public async Task<List<AppointmentReportDto>> GetReportAsync(AppointmentReportFilter filter)
        {
            var queryParams = new List<string>();

            if (filter.FromDate.HasValue)
                queryParams.Add($"FromDate={filter.FromDate.Value:yyyy-MM-dd}");

            if (filter.ToDate.HasValue)
                queryParams.Add($"ToDate={filter.ToDate.Value:yyyy-MM-dd}");

            var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";
            var url = $"api/admin/appointments/report{queryString}";

            var result = await Http.GetFromJsonAsync<ApiResponse<List<AppointmentReportDto>>>(url);
            return result?.Data ?? new List<AppointmentReportDto>();
        }
    }
}