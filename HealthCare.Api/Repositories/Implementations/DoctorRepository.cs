using HealthCare.Api.Data;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Api.Repositories.Implementations
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(HealthCareDbContext context) : base(context) { }

        public async Task<Patient?> GetByUserIdAsync(string userId)
        {
            return await _context.Patients
                .FirstOrDefaultAsync(p => p.UserId == userId);
        }
    }
}
