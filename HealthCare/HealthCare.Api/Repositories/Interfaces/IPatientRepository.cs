using HealthCare.Api.Models;
using HealthCare.Shared.DTOs.Patient;

namespace HealthCare.Api.Repositories.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        IQueryable<Patient> GetQueryable();
        Task<Patient?> GetByUserIdAsync(string userId);
        Task<PatientSummaryDto> GetSummaryAsync();
    }
}