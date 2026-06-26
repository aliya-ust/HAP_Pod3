using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Models;
using HealthCare.Shared.DTOs;
using HealthCare.Shared.DTOs.Patient;

namespace HealthCare.Api.Services.Interfaces
{
    public interface IPatientService
    {
        Task<PatientListDto> GetByIdAsync(int id);
        Task<PagedResult<PatientListDto>> GetAllAsync(PatientFilter filter);
        Task AddAsync(CreatePatientDto dto);
        Task UpdateAsync(int id, UpdatePatientDto dto);
        Task DeleteAsync(int id);
        Task UpdateStatusAsync(int id, bool isActive);
        Task<PatientSummaryDto> GetSummaryAsync();
    }
} 