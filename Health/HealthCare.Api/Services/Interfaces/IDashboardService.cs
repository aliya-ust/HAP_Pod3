using HealthCare.Shared.DTOs;

namespace HealthCare.Api.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardSummaryDto> GetDashboardSummaryAsync();
    }
}
