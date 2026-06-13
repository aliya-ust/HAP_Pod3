using HealthCare.Api;
using HealthCare.Shared;
using HealthCareApi.Repositories.Implementations;
using HealthCareApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareApi.Repositories.Implementations
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        [ExcludeFromCodeCoverage]
        public DoctorRepository(HealthAppDbContext _context) : base(_context)
        {
        }

        public async Task<PagedResult<Doctor>> GetDoctorsAsync(
            string specialisation = null,
            string searchTerm = null,
            bool orderByDescending = true,
            int pageNumber = 1,
            int pageSize = 10)
        {
            
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize > 50 ? 50 : pageSize;

            
            IQueryable<Doctor> query = _context.Doctors
                .Where(d => d.IsActive)
                .AsQueryable();


            bool hasSpecialisation = !string.IsNullOrWhiteSpace(specialisation);
            bool hasSearchTerm = !string.IsNullOrWhiteSpace(searchTerm);

            if (hasSearchTerm)
            {
                query = query.Where(d =>
                    d.FullName.ToLower().Contains(searchTerm.ToLower()) || d.DoctorId.ToString() == searchTerm);
            }

            if (hasSpecialisation)
            {
                query = query.Where(d =>
                     d.Specialisation.ToLower().Trim() == specialisation.ToLower().Trim());
            }

           
            int totalCount = await query.CountAsync();

           
            query = orderByDescending
                ? query.OrderByDescending(d => d.FullName)
                : query.OrderBy(d => d.FullName);

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            
            return new PagedResult<Doctor>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<List<Doctor>> DoctorBySpecializationAsync(string specialisation)
        {
           return await _context.Doctors
                .Where(d => d.Specialisation == specialisation && d.IsActive)
                .ToListAsync();
        }

        public async Task AddDoctorSlotAsync(List<DoctorAvailableSlot> slots)
        {
            _context.DoctorAvailableSlots.AddRange(slots);
            await _context.SaveChangesAsync();
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