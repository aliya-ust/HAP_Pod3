using HealthCare.Api.DTOs.Appointment;
using HealthCare.Shared.DTOs.Appointment;
using HealthCare.Admin.Services;
using System.Net.Http.Json;

namespace HealthCare.Admin.Services
{
    public class AppointmentService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthHeaderService _authHeaderService;

        public AppointmentService(HttpClient httpClient, AuthHeaderService authHeaderService)
        {
            _httpClient = httpClient;
            _authHeaderService = authHeaderService;
        }

        public async Task<List<AppointmentReportDto>> GetAppointmentReport(DateTime startDate, DateTime endDate)
        {
            await _authHeaderService.AddAuthorizationHeaderAsync(_httpClient);

            string url =
                $"api/admin/appointments/report?FromDate={startDate:yyyy-MM-dd}&ToDate={endDate:yyyy-MM-dd}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"API Error: {(int)response.StatusCode} {response.ReasonPhrase}. {errorContent}");
            }

            var result = await response.Content.ReadFromJsonAsync<List<AppointmentReportDto>>();

            return result ?? new List<AppointmentReportDto>();
        }

        public async Task<AppointmentSummaryDto> GetAppointmentSummaryAsync()
        {
            await _authHeaderService.AddAuthorizationHeaderAsync(_httpClient);

            var response = await _httpClient.GetAsync("api/admin/appointments/summary");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"API Error: {(int)response.StatusCode} {response.ReasonPhrase}. {errorContent}");
            }

            var result = await response.Content.ReadFromJsonAsync<AppointmentSummaryDto>();

            return result ?? new AppointmentSummaryDto();
        }

        public async Task<AppointmentSummaryDto> GetDashboardAppointmentSummaryAsync()
        {
            await _authHeaderService.AddAuthorizationHeaderAsync(_httpClient);

            var response = await _httpClient.GetAsync("api/admin/appointments/dashboard-summary");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"API Error: {(int)response.StatusCode} {response.ReasonPhrase}. {errorContent}");
            }

            var result = await response.Content.ReadFromJsonAsync<AppointmentSummaryDto>();

            return result ?? new AppointmentSummaryDto();
        }
    }
}