using HealthCareApi.Data.Context;
using HealthCareApi.Data.Repositories.Interfaces;
using HealthCareApi.Models;
using HealthCareApi.Repositories.Implementations;

namespace HealthCareApi.Data.Repositories.Implementations
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(HealthCareDbContext context) : base(context)
        {
        }
    }
}
