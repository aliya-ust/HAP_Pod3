using HealthCare.Api.Data;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Api.Repositories.Implementation
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(HealthCareDbContext context)
            : base(context)
        {
        }

        public async Task<List<Patient>> GetPatientsByGenderAsync(
            string gender,
            CancellationToken ct = default)
        {
            return await _context.Set<Patient>()
                .Where(p => p.Gender == gender)
                .ToListAsync(ct);
        }

        public async Task<List<Patient>> SearchPatientsByNameAsync(
            string name,
            CancellationToken ct = default)
        {
            return await _context.Set<Patient>()
                .Where(p => p.FullName.Contains(name))
                .ToListAsync(ct);
        }
    }
}
