using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Models;

namespace HealthCare.Api.Repositories.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        IQueryable<Patient> GetQueryable();
        Task<Patient?> GetByUserIdAsync(string userId);
        Task<PatientSummaryDto> GetSummaryAsync();
    }
}
