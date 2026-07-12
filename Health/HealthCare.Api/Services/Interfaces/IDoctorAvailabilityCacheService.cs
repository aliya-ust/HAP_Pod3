using HealthCare.Api.DTOs.Doctor;

namespace HealthCare.Api.Services.Interfaces
{
    public interface IDoctorAvailabilityCacheService
    {
        Task<List<DoctorListDto>?> GetAsync(string specialization, DateOnly date);

        Task SetAsync(
            string specialization,
            DateOnly date,
            List<DoctorListDto> doctors);

        Task RefreshSpecializationAsync(string specialization);

        Task RemoveAsync(string specialization, DateOnly date);

        Task RefreshAsync(string specialization, DateOnly date);
    }
}