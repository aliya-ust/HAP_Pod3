using HealthCareApi.Data.Context;
using HealthCareApi.Data.Repositories.Interfaces;
using HealthCareApi.Models;
using HealthCareApi.Repositories.Implementations;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareApi.Data.Repositories.Implementations
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private readonly HealthCareDbContext _context;

        public DoctorRepository(HealthCareDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync(
            string specialization = null,
            string searchTerm = null,
            bool orderByDescending = false,
            int pageNumber = 1,
            int pageSize = 10)
        {
            // Start the query
            IQueryable<Doctor> query = _context.Doctors.Where(d => d.IsActive == true).AsQueryable();

            // 1. Filter
            if (!string.IsNullOrWhiteSpace(specialization))
            {
                query = query.Where(d => d.Specialisation.Contains(specialization));
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(d => d.FullName.Contains(searchTerm));
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
            doctor.IsActive = false;

            // We use the base class's UpdateAsync logic or manually update the entry state
            _context.Entry(doctor).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
