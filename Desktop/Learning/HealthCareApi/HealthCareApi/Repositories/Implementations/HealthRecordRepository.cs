using HealthCareApi;
using HealthCareApi.Repositories.Implementations;
using HealthCareApi.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareApi.Repositories.Implementations
{
    public class HealthRecordRepository : Repository<HealthRecord>, IHealthRecordRepository
    {
        public HealthRecordRepository(HealthAppDbContext context) : base(context)
        {
        }

        // Check duplicate record
        public async Task<bool> HealthRecordExistsAsync(int appointmentId)
        {
            return await _context.HealthRecords
                .AnyAsync(h => h.AppointmentId == appointmentId);
        }

        // Use VIEW instead of joins
        public async Task<IEnumerable<vw_PatientHealthHistory>> GetPatientHealthHistoryAsync(
            int patientId,
            int pageNumber,
            int pageSize)
        {
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize > 50 ? 50 : pageSize;

            var query = _context.vw_PatientHealthHistory
                .Where(v => v.PatientId == patientId);

            query = query
                .OrderByDescending(v => v.VisitDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return await query.ToListAsync();
        }
    }
}