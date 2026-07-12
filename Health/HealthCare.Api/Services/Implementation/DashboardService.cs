using HealthCare.Api.Data;
using HealthCare.Api.Services.Interfaces;
using HealthCare.Shared.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthCare.Api.Services.Implementation;

public class DashboardService : IDashboardService
{
    private readonly HealthCareDbContext _context;
    private readonly ILogger<DashboardService> _logger;

    public DashboardService(
        HealthCareDbContext context,
        ILogger<DashboardService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<DashboardSummaryDto> GetDashboardSummaryAsync()
    {
        _logger.LogInformation("Fetching admin dashboard summary.");

        var summary = new DashboardSummaryDto
        {
            TotalDoctors = await _context.Doctors.CountAsync(),

            ActiveDoctors = await _context.Doctors
                .CountAsync(d => d.IsActive),

            TotalPatients = await _context.Patients.CountAsync(),

            TotalAppointments = await _context.Appointments.CountAsync(),

            PendingAppointments = await _context.Appointments
                .CountAsync(a => a.Status == "Pending"),

            ConfirmedAppointments = await _context.Appointments
                .CountAsync(a => a.Status == "Confirmed"),

            CancelledAppointments = await _context.Appointments
                .CountAsync(a => a.Status == "Cancelled"),

            CompletedAppointments = await _context.Appointments
                .CountAsync(a => a.Status == "Completed"),

            TotalRevenue = await _context.Appointments
                .Where(a => a.Status == "Completed")
                .SumAsync(a => (decimal?)a.Doctor.ConsultationFee) ?? 0
        };

        _logger.LogInformation(
            "Dashboard summary generated successfully. Doctors: {Doctors}, Patients: {Patients}, Appointments: {Appointments}",
            summary.TotalDoctors,
            summary.TotalPatients,
            summary.TotalAppointments);

        return summary;
    }

    public async Task<DashboardPatientDto> GetPatientDashboardSummaryAsync(int patientId)
    {
        _logger.LogInformation(
            "Fetching dashboard summary for Patient {PatientId}",
            patientId);

        var today = DateOnly.FromDateTime(DateTime.Today);

        var patient = await _context.Patients
            .FirstOrDefaultAsync(x => x.PatientId == patientId);

        if (patient == null)
        {
            _logger.LogWarning(
                "Patient {PatientId} not found while fetching dashboard",
                patientId);

            throw new InvalidOperationException("Patient not found.");
        }

        var dashboard = new DashboardPatientDto
        {
            PatientName = patient.FullName,

            UpcomingAppointments = await _context.Appointments
                .CountAsync(a =>
                    a.PatientId == patientId &&
                    a.ScheduledDate >= today &&
                    a.Status != "Cancelled"),

            HealthRecordCount = await _context.HealthRecords
                .CountAsync(h => h.PatientId == patientId)
        };

        _logger.LogInformation(
            "Patient dashboard generated successfully for Patient {PatientId}",
            patientId);

        return dashboard;
    }

    public async Task<DashboardDoctorDto> GetDoctorDashboardSummaryAsync(int doctorId)
    {
        _logger.LogInformation(
            "Fetching dashboard summary for Doctor {DoctorId}",
            doctorId);

        var today = DateOnly.FromDateTime(DateTime.Today);

        var dashboard = new DashboardDoctorDto
        {
            UpcomingAppointments = await _context.Appointments
                .CountAsync(a =>
                    a.DoctorId == doctorId &&
                    a.ScheduledDate >= today &&
                    a.Status == "Confirmed"),

            CompletedAppointments = await _context.Appointments
                .CountAsync(a =>
                    a.DoctorId == doctorId &&
                    a.Status == "Completed"),

            UpcomingLeaves = await _context.DoctorLeaves
                .CountAsync(l =>
                    l.DoctorId == doctorId &&
                    l.LeaveDate >= today),

            TodayAppointments = await _context.Appointments
                .Where(a =>
                    a.DoctorId == doctorId &&
                    a.ScheduledDate == today &&
                    a.Status == "Confirmed")
                .OrderBy(a => a.TimeSlot)
                .Select(a => new TodayAppointmentSlotDto
                {
                    Slot = a.TimeSlot
                })
                .ToListAsync()
        };

        _logger.LogInformation(
            "Doctor dashboard generated successfully for Doctor {DoctorId}. Today's appointments: {Count}",
            doctorId,
            dashboard.TodayAppointments.Count);

        return dashboard;
    }
}