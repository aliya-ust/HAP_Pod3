using HealthCare.Api.Data;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;

namespace HealthCare.Api.Repositories.Impl
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(HealthCareDbContext context) : base(context) { }
    }
}