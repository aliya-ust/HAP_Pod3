using HealthCare.Api.Data;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Api.Repositories.Implementation
{
    public class HealthRecordRepository : Repository<HealthRecord>, IHealthRecordRepository
    {
        public HealthRecordRepository(HealthCareDbContext context)
            : base(context)
        {
        }

        public async Task<HealthRecord?> GetByAppointmentIdAsync(
            int appointmentId,
            CancellationToken ct = default)
        {
            return await _context.Set<HealthRecord>()
                .FirstOrDefaultAsync(
                    h => h.AppointmentId == appointmentId,
                    ct);
        }

        public async Task<List<HealthRecord>> GetByPatientIdAsync(
            int patientId,
            CancellationToken ct = default)
        {
            return await _context.Set<HealthRecord>()
                .Where(h => h.PatientId == patientId)
                .ToListAsync(ct);
        }
    }
}
