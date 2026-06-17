using HealthCare.Api.Models;

namespace HealthCare.Api.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<Doctor> GetByIdAsync(int id, CancellationToken ct = default);
        Task<List<Doctor>> GetAllAsync(CancellationToken ct = default);
        Task<Doctor> CreateAsync(Doctor doctor, CancellationToken ct = default);
        Task<Doctor> UpdateAsync(int id, Doctor doctor, CancellationToken ct = default);
        Task<Doctor> DeleteAsync(Doctor doctor, CancellationToken ct = default);

        Task<List<Doctor>> GetDoctorsBySpecializationAsync(string specialization, CancellationToken ct = default);
    }
}
