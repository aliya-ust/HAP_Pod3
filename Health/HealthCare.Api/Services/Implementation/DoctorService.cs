using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.Exceptions;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System.Linq.Expressions;
using System.Text.Json;

namespace HealthCare.Api.Services.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly HealthCareDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<DoctorService> _logger;
        private readonly IDoctorAvailabilityCacheService _doctorCache;
        private const string NotFoundExceptionMessage = "Doctor not found.";

        public DoctorService(
            IDoctorRepository repository,
            HealthCareDbContext context,
            IMapper mapper,
            IAppointmentRepository appointmentRepository,
            ILogger<DoctorService> logger,
            IDoctorAvailabilityCacheService doctorCache)
        {
            _repository = repository;
            _context = context;
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
            _logger = logger;
            _doctorCache = doctorCache;
        }

        public async Task AddAsync(CreateDoctorDto dto)
        {
            _logger.LogInformation(
                "Creating doctor {DoctorName}",
                dto.FullName);

            var doctor = _mapper.Map<Doctor>(dto);

            await _repository.AddAsync(doctor);
            await _context.SaveChangesAsync();

            await _repository.CreateSlots(doctor.DoctorId, dto.TimeSlots);
            await _context.SaveChangesAsync();

            _logger.LogInformation(
                "Doctor {DoctorId} created successfully",
                doctor.DoctorId);
        }

        public async Task UpdateAsync(int id, UpdateDoctorDto dto)
        {
            _logger.LogInformation(
                "Updating doctor {DoctorId}",
                id);

            var doctor = await _repository.GetByIdAsync(id);

            if (doctor is null)
            {
                _logger.LogWarning(
                    "Doctor {DoctorId} not found",
                    id);

                throw new InvalidOperationException(NotFoundExceptionMessage);
            }

            _mapper.Map(dto, doctor);

            await _repository.UpdateAsync(doctor);
            await _context.SaveChangesAsync();

            _logger.LogInformation(
                "Doctor {DoctorId} updated successfully",
                id);
        }

        public async Task UpdateStatusAsync(int id, bool isActive)
        {
            _logger.LogInformation(
                "Updating Doctor {DoctorId} status to {Status}",
                id,
                isActive);

            var doctor = await _repository.GetByIdAsync(id);

            if (doctor is null)
            {
                _logger.LogWarning(
                    "Doctor {DoctorId} not found",
                    id);

                throw new InvalidOperationException(NotFoundExceptionMessage);
            }

            doctor.IsActive = isActive;

            await _repository.UpdateAsync(doctor);
            await _context.SaveChangesAsync();

            await _doctorCache.RefreshSpecializationAsync(doctor.Specialisation);

            _logger.LogInformation(
                "Doctor {DoctorId} status updated successfully",
                id);
        }

        public async Task DeleteAsync(int id)
        {
            _logger.LogInformation(
                "Deleting doctor {DoctorId}",
                id);

            var doctor = await _repository.GetByIdAsync(id);

            if (doctor is null)
            {
                _logger.LogWarning(
                    "Doctor {DoctorId} not found",
                    id);

                throw new InvalidOperationException(NotFoundExceptionMessage);
            }

            try
            {
                await _repository.DeleteAsync(id);
                await _context.SaveChangesAsync();

                _logger.LogInformation(
                    "Doctor {DoctorId} deleted successfully",
                    id);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(
                    ex,
                    "Failed to delete Doctor {DoctorId}",
                    id);

                throw new InvalidOperationException(
                    "Failed to delete Doctor. It may be referenced by existing appointments or health records.",
                    ex);
            }
        }

        public async Task<DoctorProfileDto> GetByIdAsync(int id)
        {
            _logger.LogInformation(
                "Fetching doctor profile for Doctor {DoctorId}",
                id);

            var doctor =
                await
                (
                    from d in _context.Doctors
                    join u in _context.Users
                        on d.UserId equals u.Id

                    where d.DoctorId == id

                    select new DoctorProfileDto
                    {
                        DoctorId = d.DoctorId,
                        FullName = d.FullName,
                        Email = u.Email!,
                        Specialisation = d.Specialisation,
                        YearsOfExperience = d.YearsOfExperience,
                        ConsultationFee = d.ConsultationFee
                    }
                ).FirstOrDefaultAsync();

            if (doctor == null)
            {
                _logger.LogWarning(
                    "Doctor {DoctorId} not found",
                    id);

                throw new InvalidOperationException(NotFoundExceptionMessage);
            }

            _logger.LogInformation(
                "Doctor profile fetched successfully for Doctor {DoctorId}",
                id);

            return doctor;
        }

        public async Task<PagedResult<DoctorListDto>> GetAllAsync(DoctorFilter filter)
        {
            _logger.LogInformation(
                "Fetching doctors. Page: {PageNumber}, PageSize: {PageSize}",
                filter.PageNumber,
                filter.PageSize);

            IQueryable<Doctor> query = _context.Doctors;

            if (!string.IsNullOrWhiteSpace(filter.FullName))
            {
                var search = filter.FullName.Trim().ToLower();

                query = query.Where(d =>
                    d.FullName.ToLower().Contains(search));
            }

            if (!string.IsNullOrWhiteSpace(filter.Specialisation))
            {
                query = query.Where(d => d.Specialisation == filter.Specialisation);
            }

            if (!string.IsNullOrWhiteSpace(filter.Status))
            {
                bool isActive = filter.Status.ToLower() == "active";
                query = query.Where(d => d.IsActive == isActive);
            }

            query = filter.ExperienceSort?.ToLower() == "asc"
                ? query.OrderBy(d => d.YearsOfExperience)
                : query.OrderByDescending(d => d.YearsOfExperience);

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            _logger.LogInformation(
                "{DoctorCount} doctors fetched successfully",
                totalCount);

            return new PagedResult<DoctorListDto>
            {
                Items = _mapper.Map<IEnumerable<DoctorListDto>>(items),
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                TotalCount = totalCount
            };
        }

        public async Task<List<string>> GetSlots(int doctorId)
        {
            _logger.LogInformation(
                "Fetching slots for Doctor {DoctorId}",
                doctorId);

            var slots = await _repository.GetSlots(doctorId);

            if (slots.Count == 0)
            {
                _logger.LogWarning(
                    "No slots found for Doctor {DoctorId}",
                    doctorId);

                throw new InvalidOperationException("No available slots found for this doctor.");
            }

            _logger.LogInformation(
                "{SlotCount} slots found for Doctor {DoctorId}",
                slots.Count,
                doctorId);

            return slots;
        }

        public async Task CreateSlots(int id, List<string> timeslots)
        {
            _logger.LogInformation(
                "Creating {SlotCount} slots for Doctor {DoctorId}",
                timeslots.Count,
                id);

            await _repository.CreateSlots(id, timeslots);
            await _context.SaveChangesAsync();

            _logger.LogInformation(
                "Slots created successfully for Doctor {DoctorId}",
                id);
        }

        public async Task<List<string>> AvailableTimeSlotsCheck(DateOnly date, int doctorId)
        {
            _logger.LogInformation(
                "Checking available slots for Doctor {DoctorId} on {Date}",
                doctorId,
                date);

            var allSlots = await _repository.GetSlots(doctorId);
            var bookedSlots = await _appointmentRepository.BookedTimeSlots(date, doctorId);

            var availableSlots = allSlots.Except(bookedSlots).ToList();

            _logger.LogInformation(
                "{AvailableSlotCount} slots available for Doctor {DoctorId}",
                availableSlots.Count,
                doctorId);

            return availableSlots;
        }

        public async Task<CreateLeaveResultDto> CreateLeave(int id, List<CreateLeaveDto> leaves)
        {
            _logger.LogInformation(
                "Creating leave for Doctor {DoctorId}",
                id);

            var result = new CreateLeaveResultDto();

            var existingLeaves = await _repository.GetLeavesByDoctorId(id);
            var existingLeaveDates = existingLeaves
                .Select(l => l.LeaveDate)
                .ToHashSet();

            var leavesToCreate = new List<CreateLeaveDto>();

            foreach (var leave in leaves)
            {
                if (existingLeaveDates.Contains(leave.LeaveDate))
                {
                    _logger.LogWarning(
                        "Leave already exists for Doctor {DoctorId} on {LeaveDate}",
                        id,
                        leave.LeaveDate);

                    result.SkippedDates.Add(leave.LeaveDate);
                    continue;
                }

                var availableSlots = await AvailableTimeSlotsCheck(
                    leave.LeaveDate,
                    id);

                var allSlots = await GetSlots(id);

                if (availableSlots.Count != allSlots.Count)
                {
                    _logger.LogInformation(
                        "Cancelling appointments for Doctor {DoctorId} on {LeaveDate} because leave is being created",
                        id,
                        leave.LeaveDate);

                    await _appointmentRepository.CancelAppointmentsByDoctorDate(
                        id,
                        leave.LeaveDate);

                    result.CreatedWithCancelledAppointments.Add(
                        leave.LeaveDate);
                }

                leavesToCreate.Add(leave);
            }

            if (leavesToCreate.Count > 0)
            {
                await _repository.CreateLeaves(id, leavesToCreate);
                await _context.SaveChangesAsync();

                var doctor = await _context.Doctors
                    .FirstOrDefaultAsync(d => d.DoctorId == id);

                if (doctor != null)
                {
                    foreach (var leave in leavesToCreate)
                    {
                        await _doctorCache.RefreshAsync(
                            doctor.Specialisation,
                            leave.LeaveDate);

                        _logger.LogInformation(
                            "Doctor availability cache refreshed for {Specialisation} on {LeaveDate}",
                            doctor.Specialisation,
                            leave.LeaveDate);
                    }
                }

                _logger.LogInformation(
                    "{LeaveCount} leave(s) created successfully for Doctor {DoctorId}",
                    leavesToCreate.Count,
                    id);
            }

            _logger.LogInformation(
                "Leave creation completed for Doctor {DoctorId}. Created: {CreatedCount}, Skipped: {SkippedCount}",
                id,
                leavesToCreate.Count,
                result.SkippedDates.Count);

            return result;
        }

        public async Task<List<DoctorListDto>> AvailableDoctors(
    string specialisation,
    DateOnly date)
        {
            _logger.LogInformation(
                "Fetching available doctors for Specialisation {Specialisation} on {Date}",
                specialisation,
                date);

            // Try to get data from cache
            var cachedDoctors = await _doctorCache.GetAsync(specialisation, date);

            if (cachedDoctors != null)
            {
                _logger.LogInformation(
                    "Cache hit for Specialisation {Specialisation} on {Date}",
                    specialisation,
                    date);

                return cachedDoctors;
            }

            _logger.LogInformation(
                "Cache miss for Specialisation {Specialisation} on {Date}. Loading from database.",
                specialisation,
                date);

            // Load from database
            var doctors = await _repository.AvailableDoctors(
                specialisation,
                date);

            // Store in cache for 5 minutes
            await _doctorCache.SetAsync(
                specialisation,
                date,
                doctors);

            _logger.LogInformation(
                "{DoctorCount} doctor(s) loaded from database and cached for Specialisation {Specialisation} on {Date}",
                doctors.Count,
                specialisation,
                date);

            return doctors;
        }
    }
}