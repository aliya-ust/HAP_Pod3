//using HealthCareApi.Models;
using HealthCareApi.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthCareApi.Repositories.Interfaces
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Task<IEnumerable<Doctor>> GetDoctorsAsync(
            string specialization = null,
            string searchTerm = null,
            bool orderByDescending = false,
            int pageNumber = 1,
            int pageSize = 10
        );
    }
}
