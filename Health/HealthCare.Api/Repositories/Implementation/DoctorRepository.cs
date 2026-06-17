using HealthCare.Api.Data;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Api.Repositories.Implementation
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(HealthCareDbContext context)
            : base(context)
        {
        }

        public async Task<List<Doctor>> GetDoctorsBySpecializationAsync(
            string specialization,
            CancellationToken ct = default)
        {
            return await _context.Set<Doctor>()
                .Where(d => d.Specialisation == specialization)
                .ToListAsync(ct);
        }
    }
}
