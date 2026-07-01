using System.Net.Http.Json;
using HealthCare.Shared;
using HealthCare.Shared.DTOs.Appointment;
using HealthCare.Shared.DTOs.Doctor;
using HealthCare.Shared.DTOs.Patient;

namespace HealthCare.Admin.Services
{
    public class DashboardService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient _http => _httpClientFactory.CreateClient("AdminPortalAPI");

        public async Task<DoctorSummaryDto> GetDoctorSummaryAsync()
        {
            var result = await _http.GetFromJsonAsync<ApiResponse<DoctorSummaryDto>>(
                "api/admin/doctors/summary");
            return result?.Data ?? new DoctorSummaryDto();
        }

        public async Task<PatientSummaryDto> GetPatientSummaryAsync()
        {
            var result = await _http.GetFromJsonAsync<ApiResponse<PatientSummaryDto>>(
                "api/admin/patients/summary");
            return result?.Data ?? new PatientSummaryDto();
        }

        public async Task<AppointmentSummaryDto> GetAppointmentSummaryAsync()
        {
            var result = await _http.GetFromJsonAsync<ApiResponse<AppointmentSummaryDto>>(
                "api/admin/appointments/summary");
            return result?.Data ?? new AppointmentSummaryDto();
        }
    }
}
