//using HealthCareApi.Data.Context;
using HealthCare.Api;
using HealthCare.Shared;
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

        public async Task<PagedResult<Doctor>> GetDoctorsAsync(
            string specialization = null,
            string searchTerm = null,
            bool orderByDescending = true,
            int pageNumber = 1,
            int pageSize = 10)
        {
            // Safety
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize > 50 ? 50 : pageSize;

            // Base Query
            IQueryable<Doctor> query = _context.Doctors
                .Where(d => d.IsActive)
                .AsQueryable();

            // Filter

            bool hasSpecialization = !string.IsNullOrWhiteSpace(specialization);
            bool hasSearchTerm = !string.IsNullOrWhiteSpace(searchTerm);

            if (hasSearchTerm)
            {
                query = query.Where(d =>
                    d.Specialisation.ToLower().Contains(specialization.ToLower()));
            }
            else if (hasSpecialization)
            {
                query = query.Where(d =>
                    d.FullName.ToLower().Contains(searchTerm.ToLower()) || d.DoctorId.ToString() == searchTerm);
            }

            // TOTAL COUNT (must be before pagination)
            int totalCount = await query.CountAsync();

            // Sorting
            query = orderByDescending
                ? query.OrderByDescending(d => d.FullName)
                : query.OrderBy(d => d.FullName);

            //  Pagination
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Return full paged result
            return new PagedResult<Doctor>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public override async Task DeleteAsync(Doctor doctor)
        {
            if (doctor == null)
                throw new ArgumentNullException(nameof(doctor));

            doctor.IsActive = false;

            _context.Entry(doctor).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}