using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.HealthRecord;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace HealthCare.Api.Services.Implementations
{
    public class HealthRecordService : IHealthRecordService
    {
        private readonly IHealthRecordRepository _repository;
        private readonly HealthCareDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<HealthRecordService> _logger;

        public HealthRecordService(
            IHealthRecordRepository repository,
            HealthCareDbContext context,
            IMapper mapper,
            ILogger<HealthRecordService> logger)
        {
            _repository = repository;
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<HealthRecordListDto?> GetByIdAsync(int id)
        {
            _logger.LogInformation(
                "Fetching health record {HealthRecordId}",
                id);

            var record = await _repository.GetByIdAsync(id);

            if (record is null)
            {
                _logger.LogWarning(
                    "Health record {HealthRecordId} not found",
                    id);

                throw new InvalidOperationException("Health Record not found.");
            }

            _logger.LogInformation(
                "Health record {HealthRecordId} fetched successfully",
                id);

            return _mapper.Map<HealthRecordListDto>(record);
        }

        public async Task<PagedResult<HealthRecordListDto>> GetAllAsync(HealthRecordFilter filter)
        {
            _logger.LogInformation(
                "Fetching health records. Page {PageNumber}, PageSize {PageSize}",
                filter.PageNumber,
                filter.PageSize);

            Expression<Func<HealthRecord, bool>>? predicate = null;

            if (filter.VisitDate.HasValue)
            {
                var start = filter.VisitDate.Value.ToDateTime(TimeOnly.MinValue);
                var end = start.AddDays(1);

                predicate = hr => hr.VisitDate >= start && hr.VisitDate < end;
            }

            Func<IQueryable<HealthRecord>, IOrderedQueryable<HealthRecord>> orderBy =
                q => q.OrderBy(hr => hr.VisitDate);

            var pagedResult = await _repository.GetAllAsync(
                filter.PageNumber,
                filter.PageSize,
                predicate,
                orderBy);

            _logger.LogInformation(
                "{Count} health records fetched successfully",
                pagedResult.TotalCount);

            return new PagedResult<HealthRecordListDto>
            {
                Items = _mapper.Map<IEnumerable<HealthRecordListDto>>(pagedResult.Items),
                PageNumber = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize,
                TotalCount = pagedResult.TotalCount
            };
        }

        public async Task AddAsync(int doctorId, CreateHealthRecordDto dto)
        {
            _logger.LogInformation(
                "Creating health record for Appointment {AppointmentId} by Doctor {DoctorId}",
                dto.AppointmentId,
                doctorId);

            var record = _mapper.Map<HealthRecord>(dto);
            record.DoctorId = doctorId;

            await _repository.AddAsync(record);

            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(a => a.AppointmentId == dto.AppointmentId);

            if (appointment != null)
            {
                appointment.Status = "Completed";

                _logger.LogInformation(
                    "Appointment {AppointmentId} marked as Completed",
                    dto.AppointmentId);
            }

            await _context.SaveChangesAsync();

            _logger.LogInformation(
                "Health record created successfully");
        }

        public async Task UpdateAsync(int id, UpdateHealthRecordDto dto)
        {
            _logger.LogInformation(
                "Updating health record {HealthRecordId}",
                id);

            var record = await _repository.GetByIdAsync(id);

            if (record is null)
            {
                _logger.LogWarning(
                    "Health record {HealthRecordId} not found",
                    id);

                throw new InvalidOperationException("Health record not found.");
            }

            _mapper.Map(dto, record);

            await _repository.UpdateAsync(record);
            await _context.SaveChangesAsync();

            _logger.LogInformation(
                "Health record {HealthRecordId} updated successfully",
                id);
        }

        public async Task DeleteAsync(int id)
        {
            _logger.LogInformation(
                "Deleting health record {HealthRecordId}",
                id);

            var record = await _repository.GetByIdAsync(id);

            if (record is null)
            {
                _logger.LogWarning(
                    "Health record {HealthRecordId} not found",
                    id);

                throw new InvalidOperationException("Health record not found.");
            }

            try
            {
                await _repository.DeleteAsync(id);
                await _context.SaveChangesAsync();

                _logger.LogInformation(
                    "Health record {HealthRecordId} deleted successfully",
                    id);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(
                    ex,
                    "Failed to delete health record {HealthRecordId}",
                    id);

                throw new InvalidOperationException(
                    "Failed to delete health record.",
                    ex);
            }
        }

        public async Task<List<HealthRecordListDto>> GetHealthRecordByPatient(int id)
        {
            _logger.LogInformation(
                "Fetching health records for Patient {PatientId}",
                id);

            var records = await _repository.GetPatientHealthRecords(id);

            _logger.LogInformation(
                "{Count} health records found for Patient {PatientId}",
                records.Count,
                id);

            return records.Count == 0
                ? new List<HealthRecordListDto>()
                : records;
        }

        public async Task<List<HealthRecordListDto>> GetHealthRecordByAppointment(int id)
        {
            _logger.LogInformation(
                "Fetching health records for Appointment {AppointmentId}",
                id);

            var records = await _repository.GetHealthRecordByAppointment(id);

            _logger.LogInformation(
                "{Count} health records found for Appointment {AppointmentId}",
                records.Count,
                id);

            return records.Count == 0
                ? new List<HealthRecordListDto>()
                : records;
        }
    }
}