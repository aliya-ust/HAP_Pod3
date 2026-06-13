using HealthCare.Api;
using HealthCare.Shared;
using HealthCareApi;
using HealthCareApi.Repositories.Implementations;
using HealthCareApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
{
    [ExcludeFromCodeCoverage]
    public AppointmentRepository(HealthAppDbContext context) : base(context)
    {

    }

    // Check if slot exists for doctor
    public async Task<bool> SlotExistsAsync(int doctorId, string timeSlot)
    {
        return await _context.DoctorAvailableSlots.AnyAsync(s =>
            s.DoctorId == doctorId &&
            s.TimeSlot == timeSlot);
    }

    // Check if slot already booked
    public async Task<bool> IsSlotBookedAsync(int doctorId, DateTime date, string timeSlot)
    {
        return await _context.Appointments.AnyAsync(a =>
            a.DoctorId == doctorId &&
            DbFunctions.TruncateTime(a.ScheduledDate) == date.Date &&
            a.TimeSlot == timeSlot &&
            a.Status != "Cancelled"); 
    }

    // Get patient appointments with pagination and filtering
    public async Task<PagedResult<Appointment>> GetPatientAppointmentsAsync(
        int patientId,
        string status,
        int pageNumber,
        int pageSize)
    {
        
        pageNumber = pageNumber < 1 ? 1 : pageNumber;
        pageSize = pageSize > 50 ? 50 : pageSize;

       
        IQueryable<Appointment> query = _context.Appointments
            .Where(a => a.PatientId == patientId);

     
        if (!string.IsNullOrWhiteSpace(status))
        {
            query = query.Where(a => a.Status == status);
        }

        
        int totalCount = await query.CountAsync();

      
        query = query
            .OrderByDescending(a => a.ScheduledDate)
            .ThenByDescending(a => a.TimeSlot);

        
        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        
        return new PagedResult<Appointment>
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

   

    // Get appointments by date for a doctor
    public async Task<IEnumerable<Appointment>> GetAppointmentsByDateAsync(DateTime date)
    {
        return await _context.Appointments
            .Where(a => DbFunctions.TruncateTime(a.ScheduledDate) == date.Date)
            .OrderBy(a => a.TimeSlot)
            .ToListAsync();
    }

    // Get available slots for a doctor
    public async Task<List<string>> GetDoctorSlotsAsync(int doctorId)
    {
        return await _context.DoctorAvailableSlots
            .Where(s => s.DoctorId == doctorId)
            .Select(s => s.TimeSlot)
            .ToListAsync();
    }

    // Get booked slots for a doctor on a specific date

    public async Task<List<string>> GetBookedSlotsAsync(int doctorId, DateTime date)
    {
        return await _context.Appointments
            .Where(a => a.DoctorId == doctorId &&
                        DbFunctions.TruncateTime(a.ScheduledDate) == date.Date &&
                        a.Status != "Cancelled")
            .Select(a => a.TimeSlot)
            .ToListAsync();
    }
}