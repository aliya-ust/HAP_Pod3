using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HealthCareApi.Repositories.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<IEnumerable<Patient>> GetPaginatedPatientsAsync(string searchTerm, int pageNumber, int pageSize);
    }
}