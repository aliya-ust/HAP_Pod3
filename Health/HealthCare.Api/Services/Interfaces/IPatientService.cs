using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Models;

namespace HealthCare.Api.Services.Interfaces
{
    public interface IPatientService
    {
        Task<PatientProfileDto> GetByIdAsync(int id);
        Task<PagedResult<PatientListDto>> GetAllAsync(PatientFilter filter);
        Task AddAsync(CreatePatientDto dto);
        Task UpdateAsync(int id, UpdatePatientDto dto);

        Task UpdateStatusAsync(int id, bool isActive);
        Task DeleteAsync(int id);
    }
}