using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace HealthCare.Api.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient> _repository;
        private readonly HealthCareDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<PatientService> _logger;
        private const string NotFoundExceptionMessage = "Patient not found.";
        private const string PatientIDNotFoundMessage = "Patient {PatientId} not found";
        public PatientService(
            IRepository<Patient> repository,
            HealthCareDbContext context,
            IMapper mapper,
            ILogger<PatientService> logger)
        {
            _repository = repository;
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PatientProfileDto> GetByIdAsync(int id)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Fetching patient profile for Patient {PatientId}",
                    id);
            }

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
                    Email = u.Email!,
                    PhoneNumber = p.PhoneNumber,
                    DateOfBirth = p.DateOfBirth,
                    Gender = p.Gender,
                    InsuranceId = p.InsuranceId
                }
            ).FirstOrDefaultAsync();

            if (patient == null)
            {
                _logger.LogWarning(
                    PatientIDNotFoundMessage,
                    id);

                throw new InvalidOperationException(NotFoundExceptionMessage);
            }

            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Patient profile fetched successfully for Patient {PatientId}",
                    id);
            }

            return patient;
        }

        public async Task<PagedResult<PatientListDto>> GetAllAsync(PatientFilter filter)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
               "Fetching patients. Page: {PageNumber}, PageSize: {PageSize}",
               filter.PageNumber,
               filter.PageSize);
            }
           

            Expression<Func<Patient, bool>> predicate = p =>

                (string.IsNullOrWhiteSpace(filter.SearchTerm)
                    || p.FullName.Contains(filter.SearchTerm))

                &&

                (filter.HasInsurance == null
                    || (filter.HasInsurance.Value
                        ? !string.IsNullOrWhiteSpace(p.InsuranceId)
                        : string.IsNullOrWhiteSpace(p.InsuranceId)));

            var pagedResult = await _repository.GetAllAsync(
                filter.PageNumber,
                filter.PageSize,
                predicate);

            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                "{PatientCount} patients fetched successfully",
                pagedResult.TotalCount);
            }

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
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Creating patient {PatientName}",
                    dto.FullName);
            }

            var patient = _mapper.Map<Patient>(dto);

            await _repository.AddAsync(patient);
            await _context.SaveChangesAsync();

            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Patient created successfully with ID {PatientId}",
                    patient.PatientId);
            }
        }

        public async Task UpdateAsync(int id, UpdatePatientDto dto)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Updating patient {PatientId}",
                    id);
            }

            var patient = await _repository.GetByIdAsync(id);

            if (patient is null)
            {
                _logger.LogWarning(
                    PatientIDNotFoundMessage,
                    id);

                throw new InvalidOperationException(NotFoundExceptionMessage);
            }

            _mapper.Map(dto, patient);

            await _repository.UpdateAsync(patient);
            await _context.SaveChangesAsync();

            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Patient {PatientId} updated successfully",
                    id);
            }
        }

        public async Task UpdateStatusAsync(int id, bool isActive)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Updating Patient {PatientId} status to {Status}",
                    id,
                    isActive);
            }

            var patient = await _repository.GetByIdAsync(id);

            if (patient is null)
            {
                _logger.LogWarning(
                   PatientIDNotFoundMessage,
                    id);

                throw new InvalidOperationException(NotFoundExceptionMessage);
            }

            patient.IsActive = isActive;

            await _repository.UpdateAsync(patient);
            await _context.SaveChangesAsync();

            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Patient {PatientId} status updated successfully",
                    id);
            }
        }

        public async Task DeleteAsync(int id)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Deleting patient {PatientId}",
                    id);
            }

            var patient = await _repository.GetByIdAsync(id);

            if (patient is null)
            {
                _logger.LogWarning(
                    PatientIDNotFoundMessage,
                    id);

                throw new InvalidOperationException(NotFoundExceptionMessage);
            }

            try
            {
                await _repository.DeleteAsync(id);
                await _context.SaveChangesAsync();

                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation(
                        "Patient {PatientId} deleted successfully",
                        id);
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(
                    ex,
                    "Failed to delete Patient {PatientId}",
                    id);

                throw new InvalidOperationException(
                    "Failed to delete patient. It may be referenced by existing appointments or health records.",
                    ex);
            }
        }
    }
}