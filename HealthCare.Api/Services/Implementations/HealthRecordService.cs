using AutoMapper;
using HealthCare.Api.Constants;
using HealthCare.Api.Data;
using HealthCare.Shared.DTOs;
using HealthCare.Shared.DTOs.HealthRecord;
using HealthCare.Api.Exceptions;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HealthCare.Api.Services.Implementations
{
    public class HealthRecordService : IHealthRecordService
    {
        private readonly IHealthRecordRepository _repository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly HealthCareDbContext _context;
        private readonly IMapper _mapper;

        public HealthRecordService(IHealthRecordRepository repository, IAppointmentRepository appointmentRepository, HealthCareDbContext context, IMapper mapper)
        {
            _repository = repository;
            _appointmentRepository = appointmentRepository;
            _context = context;
            _mapper = mapper;
        }

        public async Task<HealthRecordListDto?> GetByIdAsync(int id)
        {
            var record = await _repository.GetByIdAsync(id);

            if (record is null)
                throw new HealthRecordNotFoundException(id);

            return _mapper.Map<HealthRecordListDto>(record);
        }

        public async Task<PagedResult<HealthRecordListDto>> GetAllAsync(HealthRecordFilter filter)
        {
            // Build predicate (date filtering)
            Expression<Func<HealthRecord, bool>>? predicate = null;

            if (filter.VisitDate.HasValue)
            {
                predicate = hr => hr.VisitDate == filter.VisitDate.Value;
            }

            // Ordering (by VisitDate)
            Func<IQueryable<HealthRecord>, IOrderedQueryable<HealthRecord>> orderBy =
                q => q.OrderBy(hr => hr.VisitDate);

            // Call repository
            var pagedResult = await _repository.GetAllAsync(
                filter.PageNumber,
                filter.PageSize,
                predicate,
                orderBy
            );

            // Map result
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
            if (dto.VisitDate > DateOnly.FromDateTime(DateTime.Today))
                throw new InvalidOperationException("Visit date must be today or in the past.");

            var record = _mapper.Map<HealthRecord>(dto);
            record.DoctorId = doctorId;
            await _repository.AddAsync(record);
            await _context.SaveChangesAsync();

            var appointment = await _appointmentRepository.GetByIdAsync(dto.AppointmentId);
            if (appointment is null)
                throw new AppointmentNotFoundException();
            appointment.Status = AppointmentStatus.Completed;
            await _appointmentRepository.UpdateAsync(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, UpdateHealthRecordDto dto)
        {
            var record = await _repository.GetByIdAsync(id);

            if (record is null) 
                throw new HealthRecordNotFoundException(id);

            _mapper.Map(dto, record); // maps onto the tracked entity � EF picks up the changes
            await _repository.UpdateAsync(record);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var record = await _repository.GetByIdAsync(id);

            if (record is null)
                throw new HealthRecordNotFoundException(id);

            try
            {
                await _repository.DeleteAsync(id);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new DbHandleException("Failed to delete health record.");
            }
        }

        public async Task<List<HealthRecordListDto>> GetHealthRecordByPatient(int id)
        {
            var records = await _repository.GetHealthRecordByPatient(id);
            return records.Count == 0 ? new List<HealthRecordListDto>() : records;
        }

        public async Task<List<HealthRecordListDto>> GetHealthRecordByAppointment(int id)
        {
            var records = await _repository.GetHealthRecordByAppointment(id);
            return records.Count == 0 ? new List<HealthRecordListDto>() : records;
        }
    }
}