using HealthCare.Api;
using HealthCare.Shared;
using HealthCareApi;
using HealthCareApi.Repositories.Implementations;
using HealthCareApi.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareApi.Repositories.Implementations
{
    [ExcludeFromCodeCoverage]
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
        public async Task<PagedResult<vw_PatientHealthHistory>> GetPatientHealthHistoryAsync(
            int patientId,
            int pageNumber,
            int pageSize)
        {
            
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize > 50 ? 50 : pageSize;

            var query = _context.vw_PatientHealthHistory
                .Where(v => v.PatientId == patientId);

           
            int totalCount = await query.CountAsync();

          
            query = query.OrderByDescending(v => v.VisitDate);

         
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

          
            return new PagedResult<vw_PatientHealthHistory>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task AddAsync(HealthRecord record)
        {
            _context.HealthRecords.Add(record);
            await _context.SaveChangesAsync();
        }

        public async Task<HealthRecord> GetByAppointmentIdAsync(int appointmentId)
        {
            return await _context.HealthRecords
                .FirstOrDefaultAsync(h => h.AppointmentId == appointmentId);
        }

        public async Task<IEnumerable<HealthRecord>> GetAllAsync()
        {
            return await _context.HealthRecords
                .OrderByDescending(h => h.VisitDate)
                .ToListAsync();
        }
    }
}