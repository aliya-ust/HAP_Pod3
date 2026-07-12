using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Appointment;
using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.Events;
using HealthCare.Api.Messaging;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace HealthCare.Api.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;
        private readonly IDoctorService _doctorService;
        private readonly HealthCareDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<AppointmentService> _logger;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IDoctorAvailabilityCacheService _doctorCache;
        public AppointmentService(
            IAppointmentRepository repository,
            IDoctorService doctorService,
            HealthCareDbContext context,
            IMapper mapper,
            ILogger<AppointmentService> logger,
            IPublishEndpoint publishEndpoint,
            IDistributedCache cache,
            IDoctorAvailabilityCacheService doctorCache)
        {
            _repository = repository;
            _doctorService = doctorService;
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _publishEndpoint = publishEndpoint;
            _doctorCache = doctorCache;
        }

        public async Task<AppointmentListDto?> GetByIdAsync(int id)
        {
            _logger.LogInformation("Fetching appointment with ID {AppointmentId}", id);

            var appointment = await _repository.GetByIdAsync(id);

            if (appointment == null)
            {
                _logger.LogWarning("Appointment with ID {AppointmentId} not found", id);
                return null;
            }

            _logger.LogInformation("Appointment with ID {AppointmentId} retrieved successfully", id);

            return _mapper.Map<AppointmentListDto>(appointment);
        }

        public async Task<PagedResult<AppointmentListDto>> GetAllAsync(AppointmentFilter filter)
        {
            _logger.LogInformation(
                "Fetching appointments. Page: {PageNumber}, PageSize: {PageSize}, Status: {Status}, Date: {ScheduledDate}",
                filter.PageNumber,
                filter.PageSize,
                filter.Status,
                filter.ScheduledDate);

            Expression<Func<Appointment, bool>>? predicate = null;

            if (!string.IsNullOrWhiteSpace(filter.Status) && filter.ScheduledDate.HasValue)
            {
                predicate = a =>
                    a.Status == filter.Status &&
                    a.ScheduledDate == filter.ScheduledDate.Value;
            }
            else if (!string.IsNullOrWhiteSpace(filter.Status))
            {
                predicate = a => a.Status == filter.Status;
            }
            else if (filter.ScheduledDate.HasValue)
            {
                predicate = a => a.ScheduledDate == filter.ScheduledDate.Value;
            }

            Func<IQueryable<Appointment>, IOrderedQueryable<Appointment>> orderBy =
                q => q.OrderBy(a => a.ScheduledDate);

            var pagedResult = await _repository.GetAllAsync(
                filter.PageNumber,
                filter.PageSize,
                predicate,
                orderBy
            );

            _logger.LogInformation(
                "Retrieved {TotalCount} appointments successfully",
                pagedResult.TotalCount);

            return new PagedResult<AppointmentListDto>
            {
                Items = _mapper.Map<IEnumerable<AppointmentListDto>>(pagedResult.Items),
                PageNumber = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize,
                TotalCount = pagedResult.TotalCount
            };
        }

        public async Task AddAsync(CreateAppointmentDto dto, int patientId)
        {
            _logger.LogInformation(
                "Booking appointment for Patient {PatientId} with Doctor {DoctorId} on {Date} at {TimeSlot}",
                patientId,
                dto.DoctorId,
                dto.ScheduledDate,
                dto.TimeSlot);

            if (dto.ScheduledDate < DateOnly.FromDateTime(DateTime.Today))
            {
                _logger.LogWarning(
                    "Patient {PatientId} attempted to book an appointment for a past date {Date}",
                    patientId,
                    dto.ScheduledDate);

                throw new InvalidOperationException("Cannot book an appointment for a past date.");
            }

            await ValidateDoctorAvailability(dto.DoctorId, dto.ScheduledDate);

            await IsAvailable(dto.ScheduledDate, dto.DoctorId, dto.TimeSlot);

            var appointment = _mapper.Map<Appointment>(dto);
            appointment.PatientId = patientId;

            try
            {
                await _repository.AddAsync(appointment);
                await _context.SaveChangesAsync();

                var patient = await _context.Patients.FirstOrDefaultAsync(p => p.PatientId == patientId);

                if (patient == null)
                {
                    throw new InvalidOperationException("Patient not found.");
                }

                await _publishEndpoint.Publish(
                new AppointmentBookedEvent
                 {
                  AppointmentId = appointment.AppointmentId,
                  PatientName = patient.FullName,
                  DoctorId = appointment.DoctorId,
                  ScheduledDate = appointment.ScheduledDate,
                  TimeSlot = appointment.TimeSlot
                });

                _logger.LogInformation(
                    "Appointment booked and event published. AppointmentId {AppointmentId}",
                    appointment.AppointmentId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while booking appointment");
                throw;
            }
        }

        public async Task UpdateAsync(int id, UpdateAppointmentDto dto)
        {
            _logger.LogInformation("Updating appointment {AppointmentId}", id);

            var appointment = await _repository.GetByIdAsync(id);

            if (appointment is null)
            {
                _logger.LogWarning("Appointment {AppointmentId} not found", id);
                throw new InvalidOperationException("Appointment not found.");
            }

            _mapper.Map(dto, appointment);

            await _repository.UpdateAsync(appointment);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Appointment {AppointmentId} updated successfully", id);
        }

        public async Task UpdateStatusAsync(int id, UpdateAppointmentDto dto)
        {
            _logger.LogInformation(
                "Updating status of appointment {AppointmentId} to {Status}",
                id,
                dto.Status);

            var appointment = await _repository.GetByIdAsync(id);

            if (appointment is null)
            {
                _logger.LogWarning(
                    "Appointment {AppointmentId} not found while updating status",
                    id);

                throw new InvalidOperationException("Patient not found.");
            }

            appointment.Status = dto.Status;
            appointment.CancellationReason = dto.CancellationReason;

            await _repository.UpdateAsync(appointment);
            await _context.SaveChangesAsync();

            _logger.LogInformation(
                "Appointment {AppointmentId} status updated successfully",
                id);
        }

        public async Task DeleteAsync(int id)
        {
            _logger.LogInformation("Deleting appointment {AppointmentId}", id);

            var appointment = await _repository.GetByIdAsync(id);

            if (appointment is null)
            {
                _logger.LogWarning("Appointment {AppointmentId} not found", id);
                throw new InvalidOperationException("Appointment not found.");
            }

            try
            {
                await _repository.DeleteAsync(id);
                await _context.SaveChangesAsync();

                _logger.LogInformation(
                    "Appointment {AppointmentId} deleted successfully",
                    id);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(
                    ex,
                    "Failed to delete appointment {AppointmentId}",
                    id);

                throw new InvalidOperationException(
                    "Failed to delete appointment. It may be referenced by existing health records.",
                    ex);
            }
        }

        public async Task<List<string>> AvailableTimeSlots(DateOnly date, int doctorId)
        {
            _logger.LogInformation(
                "Checking available slots for Doctor {DoctorId} on {Date}",
                doctorId,
                date);

            if (date < DateOnly.FromDateTime(DateTime.Today))
            {
                _logger.LogWarning(
                    "Attempted to check slots for a past date {Date}",
                    date);

                throw new InvalidOperationException("Cannot check availability for a past date.");
            }

            var allSlots = await _doctorService.GetSlots(doctorId);
            var bookedSlots = await _repository.BookedTimeSlots(date, doctorId);

            var freeSlots = allSlots.Except(bookedSlots).ToList();

            _logger.LogInformation(
                "{Count} available slots found for Doctor {DoctorId}",
                freeSlots.Count,
                doctorId);

            return freeSlots;
        }

        public async Task<bool> IsAvailable(DateOnly date, int doctorId, string timeSlot)
        {
            _logger.LogInformation(
                "Checking availability of Doctor {DoctorId} for slot {TimeSlot} on {Date}",
                doctorId,
                timeSlot,
                date);

            var available = await _repository.IsAvailable(date, doctorId, timeSlot);

            if (!available)
            {
                _logger.LogWarning(
                    "Time slot {TimeSlot} is already booked for Doctor {DoctorId} on {Date}",
                    timeSlot,
                    doctorId,
                    date);

                throw new InvalidOperationException("This time slot is already booked.");
            }

            _logger.LogInformation(
                "Time slot {TimeSlot} is available for Doctor {DoctorId}",
                timeSlot,
                doctorId);

            return true;
        }

        public async Task<List<AppointmentReportDto>> GetDailyReport(
            DateOnly? startDate,
            DateOnly? endDate)
        {
            _logger.LogInformation(
                "Generating daily appointment report from {StartDate} to {EndDate}",
                startDate,
                endDate);

            return await _repository.GetDailyReport(startDate, endDate);
        }

        public async Task<List<AppointmentListDto>> GetDoctorSchedule(DateOnly date, int id)
        {
            _logger.LogInformation(
                "Fetching schedule for Doctor {DoctorId} on {Date}",
                id,
                date);

            var schedule = await _repository.GetDoctorSchedule(date, id);

            return schedule.Count == 0 ? new List<AppointmentListDto>() : schedule;
        }

        public async Task<List<AppointmentListDto>> GetPatientSchedule(DateOnly date, int id)
        {
            _logger.LogInformation(
                "Fetching schedule for Patient {PatientId} on {Date}",
                id,
                date);

            var schedule = await _repository.GetPatientSchedule(date, id);

            return schedule.Count == 0 ? new List<AppointmentListDto>() : schedule;
        }

        public async Task<List<AppointmentListDto>> GetAppointmentByPatient(int id)
        {
            _logger.LogInformation(
                "Fetching appointments for Patient {PatientId}",
                id);

            var appointments = await _repository.GetAppointmentByPatient(id);

            return appointments.Count == 0 ? new List<AppointmentListDto>() : appointments;
        }

        public async Task<List<AppointmentListDto>> GetAppointmentByDoctor(int id)
        {
            _logger.LogInformation(
                "Fetching appointments for Doctor {DoctorId}",
                id);

            var appointments = await _repository.GetAppointmentByDoctor(id);

            return appointments.Count == 0 ? new List<AppointmentListDto>() : appointments;
        }

        public async Task ValidateDoctorAvailability(int doctorId, DateOnly date)
        {
            _logger.LogInformation(
                "Validating availability for Doctor {DoctorId} on {Date}",
                doctorId,
                date);

            var doctor = await _context.Doctors
                .FirstOrDefaultAsync(d => d.DoctorId == doctorId);

            if (doctor == null)
            {
                _logger.LogWarning(
                    "Doctor {DoctorId} not found",
                    doctorId);

                throw new InvalidOperationException("Doctor not found.");
            }

            if (!doctor.IsActive)
            {
                _logger.LogWarning(
                    "Doctor {DoctorId} is inactive",
                    doctorId);

                throw new InvalidOperationException("Doctor is inactive.");
            }

            var isOnLeave = await _context.DoctorLeaves
                .AnyAsync(l => l.DoctorId == doctorId && l.LeaveDate == date);

            if (isOnLeave)
            {
                _logger.LogWarning(
                    "Doctor {DoctorId} is on leave on {Date}",
                    doctorId,
                    date);

                throw new InvalidOperationException("Doctor is on leave on selected date.");
            }

            _logger.LogInformation(
                "Doctor {DoctorId} is available on {Date}",
                doctorId,
                date);
        }

        public async Task<List<DoctorDropdownDto>> GetAvailableDoctorsAsync(DateOnly date, string specialization)
        {
            _logger.LogInformation(
                "Fetching available doctors for Specialization {Specialization} on {Date}",
                specialization,
                date);

            var doctors = await _context.Doctors
                .Where(d => d.IsActive)
                .Where(d => d.Specialisation == specialization)
                .Where(d => !_context.DoctorLeaves
                    .Any(l => l.DoctorId == d.DoctorId && l.LeaveDate == date))
                .ToListAsync();

            var result = new List<DoctorDropdownDto>();

            foreach (var doctor in doctors)
            {
                var slots = await GetAvailableSlotsAsync(doctor.DoctorId, date);

                if (slots.Count > 0)
                {
                    result.Add(new DoctorDropdownDto
                    {
                        DoctorId = doctor.DoctorId,
                        fullName = doctor.FullName,
                        Specialization = doctor.Specialisation
                    });

                    _logger.LogInformation(
                        "Doctor {DoctorId} has {SlotCount} available slots",
                        doctor.DoctorId,
                        slots.Count);
                }
            }

            _logger.LogInformation(
                "{DoctorCount} doctors available for Specialization {Specialization} on {Date}",
                result.Count,
                specialization,
                date);

            return result;
        }

        public async Task<List<string>> GetAvailableSlotsAsync(int doctorId, DateOnly date)
        {
            _logger.LogInformation(
                "Fetching available slots for Doctor {DoctorId} on {Date}",
                doctorId,
                date);

            var availableSlots = await _doctorService.AvailableTimeSlotsCheck(date, doctorId);

            _logger.LogInformation(
                "Doctor {DoctorId} has {AvailableSlotCount} available slots on {Date}",
                doctorId,
                availableSlots.Count,
                date);

            return availableSlots;
        }

        public async Task ConfirmAppointment(int appointmentId)
        {
            _logger.LogInformation(
                "Confirming appointment {AppointmentId}",
                appointmentId);

            await _repository.ConfirmAppointment(appointmentId);

            _logger.LogInformation(
                "Appointment {AppointmentId} confirmed successfully",
                appointmentId);
        }

        public async Task CancelAppointment(int appointmentId)
        {
            _logger.LogInformation(
                "Cancelling appointment {AppointmentId}",
                appointmentId);

            await _repository.CancelAppointment(appointmentId);

            var appointment = await _repository.GetByIdAsync(appointmentId);

            var doctor = await _context.Doctors.FirstAsync(d => d.DoctorId == appointment.DoctorId);

            await _doctorCache.RefreshAsync(doctor.Specialisation,appointment.ScheduledDate);

            _logger.LogInformation(
                "Appointment {AppointmentId} cancelled successfully",
                appointmentId);
        }
    }
}