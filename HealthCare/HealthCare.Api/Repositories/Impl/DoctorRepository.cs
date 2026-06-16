using HealthCare.Api.Data;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;

namespace HealthCare.Api.Repositories.Impl
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(HealthCareDbContext context) : base(context) { }
    }
}