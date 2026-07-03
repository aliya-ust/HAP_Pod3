using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Shared.DTOs;
using HealthCare.Shared.DTOs.Patient;
using HealthCare.Api.Exceptions;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Api.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient> _repository;
        private readonly IPatientRepository _patientRepository;
        private readonly HealthCareDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public PatientService(IRepository<Patient> repository, IPatientRepository patientRepository, HealthCareDbContext context, IMapper mapper, UserManager<User> userManager)
        {
            _repository = repository;
            _patientRepository = patientRepository;
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<PatientListDto> GetByIdAsync(int id)
        {
            var patient = await _patientRepository.GetQueryable()
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.PatientId == id);

            if (patient is null)
                throw new PatientNotFoundException(id);

            return _mapper.Map<PatientListDto>(patient);
        }

        public async Task<PagedResult<PatientListDto>> GetAllAsync(PatientFilter filter)
        {
            var query = _patientRepository.GetQueryable(); // Get IQueryable from repo

            // Search by name
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                query = query.Where(p =>
                    p.FullName.Contains(filter.Search));
            }

            // Insurance filter
            if (filter.HasInsurance == true)
            {
                query = query.Where(p => p.InsuranceId != null);
            }
            else if (filter.HasInsurance == false)
            {
                query = query.Where(p => p.InsuranceId == null);
            }

            // Active status
            if (filter.IsActive.HasValue)
            {
                query = query.Where(p => p.IsActive == filter.IsActive.Value);
            }

            // Pagination
            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            // Map result
            return new PagedResult<PatientListDto>
            {
                Items = _mapper.Map<IEnumerable<PatientListDto>>(items),
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                TotalCount = totalCount
            };
        }


        public async Task AddAsync(CreatePatientDto dto)
        {
            var patient = _mapper.Map<Patient>(dto);
            await _repository.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, UpdatePatientDto dto)
        {
            var patient = await _repository.GetByIdAsync(id);

            if (patient is null)
                throw new PatientNotFoundException(id);

            _mapper.Map(dto, patient); // maps onto the tracked entity � EF picks up the changes

            await _repository.UpdateAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int id, bool isActive)
        {
            var patient = await _repository.GetByIdAsync(id);

            if (patient is null)
                throw new PatientNotFoundException(id);

            patient.IsActive = isActive;

            await _repository.UpdateAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var patient = await _repository.GetByIdAsync(id);

            if (patient is null)
                throw new PatientNotFoundException(id);

            try
            {
                if (patient.UserId is not null)
                {
                    var user = await _userManager.FindByIdAsync(patient.UserId);
                    if (user is not null)
                    {
                        var result = await _userManager.DeleteAsync(user);
                        if (!result.Succeeded)
                            throw new IdentityOperationException(
                                string.Join(", ", result.Errors.Select(e => e.Description)));
                        return;
                    }
                }

                await _repository.DeleteAsync(id);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new DbHandleException("Failed to delete patient. It may be referenced by existing appointments or health records.");
            }
        }

        public async Task<PatientSummaryDto> GetSummaryAsync() => 
            await _patientRepository.GetSummaryAsync();
    }
}