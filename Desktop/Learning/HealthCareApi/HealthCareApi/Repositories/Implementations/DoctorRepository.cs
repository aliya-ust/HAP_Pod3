//using HealthCareApi.Data.Context;
using HealthCareApi.Repositories.Implementations;
using HealthCareApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
//using HealthCareApi.Models;

namespace HealthCareApi.Repositories.Implementations
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(HealthAppDbContext _context) : base(_context)
        {
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync(
            string specialization = null,
            string searchTerm = null,
            bool orderByDescending = false,
            int pageNumber = 1,
            int pageSize = 10)
        {
            // Safety for paging
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize > 50 ? 50 : pageSize;

            // Start the query
            IQueryable<Doctor> query = _context.Doctors.Where(d => d.IsActive == true).AsQueryable();

            // 1. Filter
            if (!string.IsNullOrWhiteSpace(specialization))
            {
                query = query.Where(d => d.Specialisation.ToLower().Contains(specialization.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(d => d.FullName.ToLower().Contains(searchTerm.ToLower()));
            }

            // 2. Order
            query = orderByDescending
                ? query.OrderByDescending(d => d.FullName)
                : query.OrderBy(d => d.FullName);

            // 3. Paginate
            // Skip previous pages and take the specified number of records
            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return await query.ToListAsync();
        }

        public override async Task DeleteAsync(Doctor doctor)
        {
            if (doctor == null)
                throw new ArgumentNullException(nameof(doctor));

            await _context.SaveChangesAsync();
        }
    }
}
