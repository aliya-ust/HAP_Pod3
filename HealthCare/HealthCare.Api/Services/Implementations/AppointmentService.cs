using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Appointment;
using HealthCare.Api.Events;
using HealthCare.Api.Messaging;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;
using HealthCare.Shared.DTOs;
using HealthCare.Shared.DTOs.Appointment;
using Microsoft.EntityFrameworkCore;
using HealthCare.Api.Events;
using HealthCare.Api.Messaging;

namespace HealthCare.Api.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;
        private readonly IDoctorService _doctorService;
        private readonly HealthCareDbContext _context;
        private readonly IMapper _mapper;
       // private readonly RabbitMQPublisher _publisher;

        public AppointmentService(
    IAppointmentRepository repository,
    IDoctorService doctorService,
    HealthCareDbContext context,
    IMapper mapper
   // RabbitMQPublisher publisher
   )
        {
            _repository = repository;
            _doctorService = doctorService;
            _context = context;
            _mapper = mapper;
            //_publisher = publisher;
        }

        public async Task<AppointmentListDto?> GetByIdAsync(int id)
        {
            var appointment = await _repository.GetByIdAsync(id);

            if (appointment is null)
                throw new InvalidOperationException("Appointment not found.");

            return new AppointmentListDto
            {
                AppointmentId = appointment.AppointmentId,
                PatientId = appointment.PatientId,
                PatientName = appointment.Patient.FullName,
                DoctorName = appointment.Doctor.FullName,
                ScheduledDate = appointment.ScheduledDate,
                TimeSlot = appointment.TimeSlot,
                Status = appointment.Status
            };
        }

        public async Task<PagedResult<AppointmentListDto>> GetAllAsync(AppointmentFilter filter)
        {
            var query = _repository.GetQueryable();

            // Search by patient OR doctor name
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                query = query.Where(a =>
                    a.Patient.FullName.Contains(filter.Search) ||
                    a.Doctor.FullName.Contains(filter.Search));
            }

            // Filter by status
            if (!string.IsNullOrWhiteSpace(filter.Status))
            {
                query = query.Where(a => a.Status == filter.Status);
            }

            // Sorting by Scheduled Date
            if (filter.IsDescending)
            {
                query = query.OrderByDescending(a => a.ScheduledDate);
            }
            else
            {
                query = query.OrderBy(a => a.ScheduledDate);
            }

            // Total count
            var totalCount = await query.CountAsync();

            // Pagination
            var items = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .Select(a => new AppointmentListDto
                {
                    AppointmentId = a.AppointmentId,
                    PatientId = a.PatientId,
                    PatientName = a.Patient.FullName,
                    DoctorName = a.Doctor.FullName,
                    ScheduledDate = a.ScheduledDate,
                    TimeSlot = a.TimeSlot,
                    Status = a.Status
                })
                .ToListAsync();

            return new PagedResult<AppointmentListDto>
            {
                Items = items,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                TotalCount = totalCount
            };
        }

        public async Task AddAsync(CreateAppointmentDto dto, int patientId)
        {
            if (dto.ScheduledDate < DateOnly.FromDateTime(DateTime.Today))
                throw new InvalidOperationException("Cannot book an appointment for a past date.");

            await IsAvailable(dto.ScheduledDate, dto.DoctorId, dto.TimeSlot);

            var appointment = _mapper.Map<Appointment>(dto);
            appointment.PatientId = patientId;

            try
            {
                await _repository.AddAsync(appointment);
                await _context.SaveChangesAsync();

                var patient = await _context.Patients
                    .FirstOrDefaultAsync(p => p.PatientId == patientId);

                //await _publisher.PublishAsync(
                //    new AppointmentBookedEvent
                //    {
                //        AppointmentId = appointment.AppointmentId,
                //        PatientName = patient?.FullName ?? "Unknown",
                //        DoctorId = appointment.DoctorId,
                //        ScheduledDate = appointment.ScheduledDate,
                //        TimeSlot = appointment.TimeSlot,
                //        OccurredAt = DateTime.UtcNow
                //    });
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException(
                    "Failed to book the appointment.",
                    ex);
            }
        }

        public async Task UpdateAsync(int id, UpdateAppointmentDto dto)
        {
            var appointment = await _repository.GetByIdAsync(id);

            if (appointment is null)
                throw new InvalidOperationException("Appointment not found.");

            _mapper.Map(dto, appointment);
            await _repository.UpdateAsync(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int id, UpdateAppointmentDto dto)
        {
            var appointment = await _repository.GetByIdAsync(id);

            if (appointment is null)
                throw new InvalidOperationException("Patient not found.");

            appointment.Status = dto.Status;
            appointment.CancellationReason = dto.CancellationReason;

            await _repository.UpdateAsync(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var appointment = await _repository.GetByIdAsync(id);

            if (appointment is null)
                throw new InvalidOperationException("Appointment not found.");
            try
            {
                await _repository.DeleteAsync(id);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Failed to delete appointment. It may be referenced by existing health records.", ex);
            }
        }

        public async Task<List<string>> AvailableTimeSlots(DateOnly date, int doctorId)
        {
            if (date < DateOnly.FromDateTime(DateTime.Today))
                throw new InvalidOperationException("Cannot check availability for a past date.");

            var allSlots = await _doctorService.GetSlots(doctorId);

            if (allSlots == null || allSlots.Count == 0)
                return new List<string>();

            var bookedSlots = await _repository.BookedTimeSlots(date, doctorId);

            var freeSlots = allSlots
                .Except(bookedSlots)
                .ToList();

            return freeSlots;
        }

        public async Task<bool> IsAvailable(DateOnly date, int doctorId, string timeSlot)
        {
            var available = await _repository.IsAvailable(date, doctorId, timeSlot);

            if (!available)
                throw new InvalidOperationException("This time slot is already booked.");

            return true;
        }

        public async Task<List<AppointmentReportDto>> GetReport(AppointmentReportFilter filter)
        {
            var fromDate = filter.FromDate ?? DateOnly.FromDateTime(DateTime.Today.AddDays(-7));
            var toDate = filter.ToDate ?? DateOnly.FromDateTime(DateTime.Today);

            var report = await _repository.GetReport(fromDate, toDate);

            return report.Count == 0 ? new List<AppointmentReportDto>() : report;
        }


        public async Task<List<AppointmentListDto>> GetDoctorSchedule(DateOnly date, int id)
        {
            var schedule = await _repository.GetDoctorSchedule(date, id);
            return schedule.Count == 0 ? new List<AppointmentListDto>() : schedule;
        }

        public async Task<List<AppointmentListDto>> GetPatientSchedule(DateOnly date, int id)
        {
            var schedule = await _repository.GetPatientSchedule(date, id);
            return schedule.Count == 0 ? new List<AppointmentListDto>() : schedule;
        }

        public async Task<List<AppointmentListDto>> GetAppointmentByPatient(int id)
        {
            var appointments = await _repository.GetAppointmentByPatient(id);
            return appointments.Count == 0 ? new List<AppointmentListDto>() : appointments;
        }

        public async Task<List<AppointmentListDto>> GetAppointmentByDoctor(int id)
        {
            var appointments = await _repository.GetAppointmentByDoctor(id);
            return appointments.Count == 0 ? new List<AppointmentListDto>() : appointments;
        }

        public async Task CancelAppointmentsByDoctorDate(int doctorId, DateOnly date)
        {
            await _repository.CancelAppointmentsByDoctorDate(doctorId, date);
            await _context.SaveChangesAsync();
        }

        public async Task<AppointmentSummaryDto> GetSummaryAsync()
        {
            var summary = await _repository.GetSummaryAsync();
            return summary;
        }
        public async Task<AppointmentSummaryDto> GetDashboardSummaryAsync()
        {
            var summary = await _repository.GetDashboardSummaryAsync();
            return summary;
        }

    }
}