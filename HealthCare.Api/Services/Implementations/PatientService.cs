using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;
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

        public async Task<PatientListDto?> GetByIdAsync(int id)
        {
            var patient = await _repository.GetByIdAsync(id);
            return patient is null ? null : _mapper.Map<PatientListDto>(patient);
        }

        public async Task<PagedResult<PatientListDto>> GetAllAsync(PatientFilter filter)
        {
            // Build predicate
            Expression<Func<Patient, bool>>? predicate = null;

            if (filter.HasInsurance == true)
            {
                predicate = p => p.InsuranceId != null;
            }
            else if (filter.HasInsurance == false)
            {
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
            if (patient is null) return;
            _mapper.Map(dto, patient);  // maps onto the tracked entity — EF picks up the changes
            await _repository.UpdateAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _context.SaveChangesAsync();
        }
    }
}