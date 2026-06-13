using HealthCare.Api;
using HealthCare.Shared;
using HealthCareApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareApi.Repositories.Implementations
{
    [ExcludeFromCodeCoverage]
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(HealthAppDbContext _context) : base(_context)
        {
        }

        public async Task<PagedResult<Patient>> GetPaginatedPatientsAsync(
            string searchTerm,
            int pageNumber,
            int pageSize)
        {
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize > 50 ? 50 : pageSize;

            IQueryable<Patient> query = _context.Patients.Where(p=>p.IsActive);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(p =>
                    p.FullName.ToLower().Contains(searchTerm.ToLower()) || p.PatientId.ToString() == searchTerm);
            }

            
            int totalCount = await query.CountAsync();

           
            query = query.OrderBy(p => p.PatientId);

          
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

         
            return new PagedResult<Patient>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public override async Task DeleteAsync(Patient patient)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient));

            await _context.SaveChangesAsync();
        }
    }
}