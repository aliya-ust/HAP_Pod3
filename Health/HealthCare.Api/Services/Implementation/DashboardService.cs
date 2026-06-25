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
}