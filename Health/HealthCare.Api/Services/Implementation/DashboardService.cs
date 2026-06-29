using HealthCare.Api.Data;
//using HealthCare.Api.DTOs.Dashboard;
using HealthCare.Api.Services.Interfaces;
using HealthCare.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

public class DashboardService : IDashboardService
{
    private readonly HealthCareDbContext _context;

    public DashboardService(HealthCareDbContext context)
    {
        _context = context;
    }

    public async Task<DashboardSummaryDto> GetDashboardSummaryAsync()
    {
        return new DashboardSummaryDto
        {
            TotalDoctors = await _context.Doctors.CountAsync(),

            ActiveDoctors = await _context.Doctors
                .CountAsync(d => d.IsActive == true ),

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
    }

    public async Task<DashboardPatientDto> GetPatientDashboardSummaryAsync(int patientId)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);

        var patient = await _context.Patients
            .FirstAsync(x => x.PatientId == patientId);

        return new DashboardPatientDto
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
    }

    public async Task<DashboardDoctorDto> GetDoctorDashboardSummaryAsync(int doctorId)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);

        return new DashboardDoctorDto
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
    }
}