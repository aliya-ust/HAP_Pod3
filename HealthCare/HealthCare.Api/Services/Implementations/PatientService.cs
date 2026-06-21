using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace HealthCare.Api.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient> _repository;
        private readonly HealthCareDbContext _context;
        private readonly IMapper _mapper;

        public PatientService(IRepository<Patient> repository, HealthCareDbContext context, IMapper mapper)
        {
            _repository = repository;
            _context = context;
            _mapper = mapper;
        }

        public async Task<PatientListDto> GetByIdAsync(int id)
        {
            var patient = await _repository.GetByIdAsync(id);

            if (patient is null)
                throw new InvalidOperationException("Patient not found.");

            return _mapper.Map<PatientListDto>(patient);
        }

        public async Task<PagedResult<PatientListDto>> GetAllAsync(PatientFilter filter)
        {
            // Build predicate
            Expression<Func<Patient, bool>>? predicate = null;
            // Support three filtering scenarios similar to DoctorService:
            // 1) SearchByName only
            // 2) HasInsurance only
            // 3) Both provided -> both conditions must be satisfied
            var hasName = !string.IsNullOrWhiteSpace(filter.SearchByName);
            var hasInsurance = filter.HasInsurance.HasValue;

            if (hasName && hasInsurance)
            {
                var name = filter.SearchByName!.Trim();
                if (filter.HasInsurance == true)
                    predicate = p => p.FullName.Contains(name) && p.InsuranceId != null;
                else
                    predicate = p => p.FullName.Contains(name) && p.InsuranceId == null;
            }
            else if (hasName)
            {
                var name = filter.SearchByName!.Trim();
                predicate = p => p.FullName.Contains(name);
            }
            else if (hasInsurance)
            {
                if (filter.HasInsurance == true)
                    predicate = p => p.InsuranceId != null;
                else
                    predicate = p => p.InsuranceId == null;
            }

            // Call repository (no ordering needed here)
            var pagedResult = await _repository.GetAllAsync(
                filter.PageNumber,
                filter.PageSize,
                predicate
            );

            // Map result
            return new PagedResult<PatientListDto>
            {
                Items = _mapper.Map<IEnumerable<PatientListDto>>(pagedResult.Items),
                PageNumber = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize,
                TotalCount = pagedResult.TotalCount
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
                throw new InvalidOperationException("Patient not found.");

            _mapper.Map(dto, patient); // maps onto the tracked entity — EF picks up the changes

            await _repository.UpdateAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int id, bool isActive)
        {
            var patient = await _repository.GetByIdAsync(id);

            if (patient is null)
                throw new InvalidOperationException("Patient not found.");

            patient.IsActive = isActive;

            await _repository.UpdateAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var patient = await _repository.GetByIdAsync(id);

            if (patient is null)
                throw new InvalidOperationException("Patient not found.");

            try
            {
                await _repository.DeleteAsync(id);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Failed to delete patient. It may be referenced by existing appointments or health records.", ex);
            }
        }
    }
}