using HealthCare.Api.Models;

namespace HealthCare.Api.Repositories.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<List<Patient>> GetPatientsByGenderAsync(string gender, CancellationToken ct = default);

        Task<List<Patient>> SearchPatientsByNameAsync(string name, CancellationToken ct = default);
    }
}
