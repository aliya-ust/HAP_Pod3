using HealthCare.Shared.DTOs;

namespace HealthCare.Api.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardSummaryDto> GetDashboardSummaryAsync();

        Task<DashboardPatientDto> GetPatientDashboardSummaryAsync(int patientId);

        Task<DashboardDoctorDto> GetDoctorDashboardSummaryAsync(int doctorId);
    }
}
