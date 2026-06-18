using HealthCare.Api.Data;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Api.Repositories.Implementation
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(HealthCareDbContext context) : base(context) { }

        public async Task<Doctor?> GetByUserIdAsync(string userId)
        {
            return await _context.Doctors
                .FirstOrDefaultAsync(p => p.UserId == userId);
        }

        public async Task<List<string>> GetSlots(int doctorId) =>
            await _context.DoctorAvailableSlots
                .Where(s => s.DoctorId == doctorId)
                .Select(s => s.TimeSlot)
                .ToListAsync();
    }
}