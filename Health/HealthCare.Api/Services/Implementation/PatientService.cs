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
        private const string NotFoundExceptionMessage = "Patient not found.";

        public PatientService(IRepository<Patient> repository, HealthCareDbContext context, IMapper mapper)
        {
            _repository = repository;
            _context = context;
            _mapper = mapper;
        }

        public async Task<PatientProfileDto> GetByIdAsync(int id)
        {
            var patient = await
            (
                from p in _context.Patients
                join u in _context.Users
                    on p.UserId equals u.Id

                where p.PatientId == id

                select new PatientProfileDto
                {
                    PatientId = p.PatientId,
                    FullName = p.FullName,
                    Email = u.Email,
                    PhoneNumber = p.PhoneNumber,
                    DateOfBirth = p.DateOfBirth,
                    Gender = p.Gender,
                    InsuranceId = p.InsuranceId
                }
            ).FirstOrDefaultAsync();

            if (patient == null)
                throw new InvalidOperationException("Patient not found.");

            return patient;
        }

        public async Task<PagedResult<PatientListDto>> GetAllAsync(PatientFilter filter)
        {
            Expression<Func<Patient, bool>> predicate = p =>

                // Search by name
                (string.IsNullOrWhiteSpace(filter.SearchTerm)
                    || p.FullName.Contains(filter.SearchTerm))

                // Filter by insurance
                &&

                (filter.HasInsurance == null
                    || (filter.HasInsurance.Value
                            ? p.InsuranceId != null
                            : p.InsuranceId == null));

            var pagedResult = await _repository.GetAllAsync(
                filter.PageNumber,
                filter.PageSize,
                predicate);

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
                throw new InvalidOperationException(NotFoundExceptionMessage);

            _mapper.Map(dto, patient); // maps onto the tracked entity — EF picks up the changes

            await _repository.UpdateAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int id, bool isActive)
        {
            var patient = await _repository.GetByIdAsync(id);

            if (patient is null)
                throw new InvalidOperationException(NotFoundExceptionMessage);

            patient.IsActive = isActive;

            await _repository.UpdateAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var patient = await _repository.GetByIdAsync(id);

            if (patient is null)
                throw new InvalidOperationException(NotFoundExceptionMessage);

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