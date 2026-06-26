using HealthCare.Api.Data;
using HealthCare.Shared.DTOs.Patient;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Api.Repositories.Implementations
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(HealthCareDbContext context) : base(context) { }

        public IQueryable<Patient> GetQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<Patient?> GetByUserIdAsync(string userId)
        {
            return await _context.Patients
                .FirstOrDefaultAsync(p => p.UserId == userId);
        }

        public async Task<PatientSummaryDto> GetSummaryAsync()
        {
            var result = await _dbSet
                .GroupBy(p => 1)
                .Select(g => new PatientSummaryDto
                {
                    TotalPatients = g.Count(),
                    ActivePatients = g.Count(p => p.IsActive)
                })
                .FirstOrDefaultAsync();

            return result ?? new PatientSummaryDto();
        }
    }
}