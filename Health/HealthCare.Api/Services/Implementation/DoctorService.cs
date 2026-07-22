using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.Exceptions;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthCare.Api.Services.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly HealthCareDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<DoctorService> _logger;

        private const string NotFoundExceptionMessage = "Doctor not found.";
        private const string DoctorNotFoundLogMessage = "Doctor {DoctorId} not found.";

        public DoctorService(
            IDoctorRepository repository,
            HealthCareDbContext context,
            IMapper mapper,
            IAppointmentRepository appointmentRepository,
            ILogger<DoctorService> logger)
        {
            _repository = repository;
            _context = context;
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
            _logger = logger;
        }

        public async Task UpdateAsync(
            int id,
            UpdateDoctorDto dto)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Updating doctor {DoctorId}",
                    id);
            }

            var doctor = await _repository.GetByIdAsync(id);

            if (doctor is null)
            {
                _logger.LogWarning(
                    DoctorNotFoundLogMessage,
                    id);

                throw new InvalidOperationException(
                    NotFoundExceptionMessage);
            }

            _mapper.Map(dto, doctor);

            await _repository.UpdateAsync(doctor);
            await _context.SaveChangesAsync();


            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Doctor {DoctorId} updated successfully",
                    id);
            }
        }


        public async Task UpdateStatusAsync(
            int id,
            bool isActive)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Updating Doctor {DoctorId} status to {Status}",
                    id,
                    isActive);
            }

            var doctor = await _repository.GetByIdAsync(id);

            if (doctor is null)
            {
                _logger.LogWarning(
                    DoctorNotFoundLogMessage,
                    id);

                throw new InvalidOperationException(
                    NotFoundExceptionMessage);
            }

            doctor.IsActive = isActive;

            await _repository.UpdateAsync(doctor);
            await _context.SaveChangesAsync();

            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Doctor {DoctorId} status updated successfully",
                    id);
            }
        }


        public async Task DeleteAsync(int id)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Deleting doctor {DoctorId}",
                    id);
            }

            var doctor = await _repository.GetByIdAsync(id);

            if (doctor is null)
            {
                _logger.LogWarning(
                   DoctorNotFoundLogMessage,
                    id);

                throw new InvalidOperationException(
                    NotFoundExceptionMessage);
            }

            try
            {
                await _repository.DeleteAsync(id);
                await _context.SaveChangesAsync();


                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation(
                        "Doctor {DoctorId} deleted successfully",
                        id);
                }
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
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Fetching doctor profile for Doctor {DoctorId}",
                    id);
            }

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
                    DoctorNotFoundLogMessage,
                    id);

                throw new InvalidOperationException(
                    NotFoundExceptionMessage);
            }


            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Doctor profile fetched successfully for Doctor {DoctorId}",
                    id);
            }

            return doctor;
        }

        public async Task<PagedResult<DoctorListDto>> GetAllAsync(
    DoctorFilter filter)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Fetching doctors. Page: {PageNumber}, PageSize: {PageSize}",
                    filter.PageNumber,
                    filter.PageSize);
            }

            IQueryable<Doctor> query = _context.Doctors;


            if (!string.IsNullOrWhiteSpace(filter.FullName))
            {
                query = query.Where(d =>
                    EF.Functions.Like(d.FullName, $"%{filter.FullName}%"));
            }


            if (!string.IsNullOrWhiteSpace(filter.Specialisation))
            {
                query = query.Where(d =>
                    d.Specialisation == filter.Specialisation);
            }


            if (!string.IsNullOrWhiteSpace(filter.Status))
            {
                bool isActive = string.Equals(
                    filter.Status,
                    "active",
                    StringComparison.OrdinalIgnoreCase);

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


            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "{DoctorCount} doctors fetched successfully",
                    totalCount);
            }


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
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Fetching slots for Doctor {DoctorId}",
                    doctorId);
            }


            var slots = await _repository.GetSlots(doctorId);


            if (slots.Count == 0)
            {
                _logger.LogWarning(
                    "No slots found for Doctor {DoctorId}",
                    doctorId);

                throw new InvalidOperationException(
                    "No available slots found for this doctor.");
            }


            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "{SlotCount} slots found for Doctor {DoctorId}",
                    slots.Count,
                    doctorId);
            }


            return slots;
        }




        public async Task CreateSlots(
            int id,
            List<string> timeslots)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Creating {SlotCount} slots for Doctor {DoctorId}",
                    timeslots.Count,
                    id);
            }


            await _repository.CreateSlots(
                id,
                timeslots);

            await _context.SaveChangesAsync();


            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Slots created successfully for Doctor {DoctorId}",
                    id);
            }
        }




        public async Task<List<string>> AvailableTimeSlotsCheck(
            DateOnly date,
            int doctorId)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Checking available slots for Doctor {DoctorId} on {Date}",
                    doctorId,
                    date);
            }


            var allSlots =
                await _repository.GetSlots(doctorId);


            var bookedSlots =
                await _appointmentRepository.BookedTimeSlots(
                    date,
                    doctorId);


            var availableSlots =
                allSlots.Except(bookedSlots).ToList();


            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "{AvailableSlotCount} slots available for Doctor {DoctorId}",
                    availableSlots.Count,
                    doctorId);
            }


            return availableSlots;
        }

        public async Task<CreateLeaveResultDto> CreateLeave(
             int id,
             List<CreateLeaveDto> leaves)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Creating leave for Doctor {DoctorId}",
                    id);
            }

            var result = new CreateLeaveResultDto();

            var existingLeaveDates = (await _repository.GetLeavesByDoctorId(id))
                .Select(l => l.LeaveDate)
                .ToHashSet();

            var leavesToCreate = new List<CreateLeaveDto>();

            foreach (var leave in leaves)
            {
                var canCreate = await ProcessLeaveAsync(
                    id,
                    leave,
                    existingLeaveDates,
                    result);

                if (canCreate)
                {
                    leavesToCreate.Add(leave);
                }
            }

            await SaveLeavesAsync(
                id,
                leavesToCreate);

            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Leave creation completed for Doctor {DoctorId}. Created: {CreatedCount}, Skipped: {SkippedCount}",
                    id,
                    leavesToCreate.Count,
                    result.SkippedDates.Count);
            }

            return result;
        }

        private async Task<bool> ProcessLeaveAsync(
                      int doctorId,
                      CreateLeaveDto leave,
                      HashSet<DateOnly> existingLeaveDates,
                      CreateLeaveResultDto result)
        {
            if (existingLeaveDates.Contains(leave.LeaveDate))
            {
                _logger.LogWarning(
                    "Leave already exists for Doctor {DoctorId} on {LeaveDate}",
                    doctorId,
                    leave.LeaveDate);

                result.SkippedDates.Add(leave.LeaveDate);
                return false;
            }

            var availableSlots =
                await AvailableTimeSlotsCheck(
                    leave.LeaveDate,
                    doctorId);

            var allSlots =
                await GetSlots(doctorId);

            if (availableSlots.Count != allSlots.Count)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation(
                        "Cancelling appointments for Doctor {DoctorId} on {LeaveDate} because leave is being created",
                        doctorId,
                        leave.LeaveDate);
                }

                await _appointmentRepository
                    .CancelAppointmentsByDoctorDate(
                        doctorId,
                        leave.LeaveDate);

                result.CreatedWithCancelledAppointments
                    .Add(leave.LeaveDate);
            }

            return true;
        }

        private async Task SaveLeavesAsync(
                       int doctorId,
                       List<CreateLeaveDto> leavesToCreate)
        {
            if (leavesToCreate.Count == 0)
            {
                return;
            }

            await _repository.CreateLeaves(
                doctorId,
                leavesToCreate);

            await _context.SaveChangesAsync();

            var doctor = await _context.Doctors
                .FirstOrDefaultAsync(
                    d => d.DoctorId == doctorId);

            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "{LeaveCount} leave(s) created successfully for Doctor {DoctorId}",
                    leavesToCreate.Count,
                    doctorId);
            }
        }


        public async Task<List<DoctorListDto>> AvailableDoctors(
    string specialisation,
    DateOnly date)
        { 

            var doctors =
                await _repository.AvailableDoctors(
                    specialisation,
                    date);


            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "{DoctorCount} doctor(s) loaded from database for Specialisation {Specialisation} on {Date}",
                    doctors.Count,
                    specialisation,
                    date);
            }


            return doctors;
        }
    }
}