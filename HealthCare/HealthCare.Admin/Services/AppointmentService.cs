using HealthCare.Api.DTOs.Appointment;
using HealthCare.Shared.DTOs.Appointment;

using System.Net.Http.Json;

namespace HealthCare.Admin.Services
{
    public class AppointmentService
    {
        private readonly HttpClient _httpClient;

        public AppointmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AppointmentReportDto>> GetAppointmentReport(DateTime startDate, DateTime endDate)
        {

            string url =
                $"api/admin/appointments/report?FromDate={startDate:yyyy-MM-dd}&ToDate={endDate:yyyy-MM-dd}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new   InvalidOperationException($"API Error: {(int)response.StatusCode} {response.ReasonPhrase}. {errorContent}");
            }

            var result = await response.Content.ReadFromJsonAsync<List<AppointmentReportDto>>();

            return result ?? new List<AppointmentReportDto>();
        }

        public async Task<AppointmentSummaryDto> GetAppointmentSummaryAsync()
        {

            var response = await _httpClient.GetAsync("api/admin/appointments/summary");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new InvalidOperationException($"API Error: {(int)response.StatusCode} {response.ReasonPhrase}. {errorContent}");
            }

            var result = await response.Content.ReadFromJsonAsync<AppointmentSummaryDto>();

            return result ?? new AppointmentSummaryDto();
        }

        public async Task<AppointmentSummaryDto> GetDashboardAppointmentSummaryAsync()
        {

            var response = await _httpClient.GetAsync("api/admin/appointments/dashboard-summary");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new InvalidOperationException($"API Error: {(int)response.StatusCode} {response.ReasonPhrase}. {errorContent}");
            }

            var result = await response.Content.ReadFromJsonAsync<AppointmentSummaryDto>();

            return result ?? new AppointmentSummaryDto();
        }
    }
}