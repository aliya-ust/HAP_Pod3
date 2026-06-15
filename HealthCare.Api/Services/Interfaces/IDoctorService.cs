using HealthCare.Api.Models;

namespace HealthCare.Api.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<Doctor?> GetByIdAsync(int id);
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task AddAsync(Doctor doctor);
        Task UpdateAsync(Doctor doctor);
        Task DeleteAsync(int id);
    }
}
