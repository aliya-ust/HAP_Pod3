using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Models;
using HealthCare.Api.Data;

namespace HealthCare.Api.Repositories.Implementations
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(HealthCareDbContext context) : base(context) { }
    }
} 