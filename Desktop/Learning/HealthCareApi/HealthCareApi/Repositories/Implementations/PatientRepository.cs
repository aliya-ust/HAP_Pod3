using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using HealthCareApi.Repositories.Interfaces;

namespace HealthCareApi.Repositories.Implementations
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(HealthAppDbContext _context) : base(_context)
        {
        }

        public async Task<IEnumerable<Patient>> GetPaginatedPatientsAsync(
            string searchTerm,
            int pageNumber,
            int pageSize)
        {
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize > 50 ? 50 : pageSize;

            IQueryable<Patient> query = _context.Patients;
                //.Where(p => p.IsActive);

            // Search by name (case-insensitive)
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(p =>
                    p.FullName.ToLower().Contains(searchTerm.ToLower()));
            }

            // Sorting (optional)
            query = query.OrderBy(p => p.FullName);

            // Pagination
            query = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return await query.ToListAsync();
        }

        public override async Task DeleteAsync(Patient patient)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient));

            await _context.SaveChangesAsync();
        }
    }
}