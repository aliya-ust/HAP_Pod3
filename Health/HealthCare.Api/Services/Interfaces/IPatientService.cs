using HealthCare.Api.Models;

namespace HealthCare.Api.Services.Interfaces
{
    public interface IPatientService
    {
        Task<Patient> GetByIdAsync(int id, CancellationToken ct = default);
        Task<List<Patient>> GetAllAsync(CancellationToken ct = default);
        Task<Patient> CreateAsync(Patient patient, CancellationToken ct = default);
        Task<Patient> UpdateAsync(int id, Patient patient, CancellationToken ct = default);
        Task<Patient> DeleteAsync(Patient patient, CancellationToken ct = default);

        Task<List<Patient>> SearchPatientsByNameAsync(string name, CancellationToken ct = default);
        Task<List<Patient>> GetPatientsByGenderAsync(string gender, CancellationToken ct = default);
    }
}
