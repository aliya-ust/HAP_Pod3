using HealthCare.Api.Models;

namespace HealthCare.Api.Repositories.Interfaces
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Task<List<Doctor>> GetDoctorsBySpecializationAsync(
            string specialization,
            CancellationToken ct = default);
    }
}
