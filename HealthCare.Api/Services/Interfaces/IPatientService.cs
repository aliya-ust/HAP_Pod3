using HealthCare.Api.Models;

namespace HealthCare.Api.Services.Interfaces
{
    public interface IPatientService
    {
        Task<Patient?> GetByIdAsync(int id);
        Task<IEnumerable<Patient>> GetAllAsync();
        Task AddAsync(Patient patient);
        Task UpdateAsync(Patient patient);
        Task DeleteAsync(int id);
    }
}
