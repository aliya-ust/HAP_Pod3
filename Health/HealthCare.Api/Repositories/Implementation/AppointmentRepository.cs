//using HealthCare.Api.Data;
//using HealthCare.Api.Models;
//using HealthCare.Api.Repositories.Interfaces;
////using HealthCare.Shared.DTOs;
////using HealthCare.Shared.Models;
//using Microsoft.EntityFrameworkCore;

//namespace HealthCare.Api.Repositories.Implementation
//{
//    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
//    {
//        public AppointmentRepository(HealthCareDbContext context)
//            : base(context)
//        {
//        }

//        public async Task<List<string>> AvailableTimeSlotsAsync(
//            DateOnly date,
//            int doctorId)
//        {
//            return await _context.Appointments
//                .Where(a =>
//                    a.DoctorId == doctorId &&
//                    a.ScheduledDate == date &&
//                    a.Status != "Cancelled")
//                .Select(a => a.TimeSlot)
//                .ToListAsync();
//        }

//        public async Task<bool> IsAvailableAsync(
//            DateOnly date,
//            int doctorId,
//            string timeSlot)
//        {
//            bool exists = await _context.Appointments.AnyAsync(a =>
//                a.DoctorId == doctorId &&
//                a.ScheduledDate == date &&
//                a.TimeSlot == timeSlot &&
//                a.Status != "Cancelled");

//            return !exists;
//        }

//        public async Task<List<AppointmentReportDto>> GetDailyReportAsync()
//        {
//            return await _context.Appointments
//                .Select(a => new AppointmentReportDto
//                {
//                    AppointmentId = a.AppointmentId,
//                    DoctorId = a.DoctorId,
//                    PatientId = a.PatientId,
//                    ScheduledDate = a.ScheduledDate,
//                    TimeSlot = a.TimeSlot,
//                    Status = a.Status
//                })
//                .ToListAsync();
//        }

//        public async Task<List<Appointment>> GetDoctorScheduleAsync(
//            DateOnly date,
//            int doctorId)
//        {
//            return await _context.Appointments
//                .Where(a =>
//                    a.ScheduledDate == date &&
//                    a.DoctorId == doctorId)
//                .ToListAsync();
//        }

//        public async Task<List<Appointment>> GetPatientScheduleAsync(
//            DateOnly date,
//            int patientId)
//        {
//            return await _context.Appointments
//                .Where(a =>
//                    a.ScheduledDate == date &&
//                    a.PatientId == patientId)
//                .ToListAsync();
//        }

//        public async Task<List<Appointment>> GetAppointmentByPatientAsync(
//            int patientId)
//        {
//            return await _context.Appointments
//                .Where(a =>
//                    a.PatientId == patientId &&
//                    a.ScheduledDate >= DateOnly.FromDateTime(DateTime.Today))
//                .ToListAsync();
//        }

//        public async Task<(List<Appointment>, int)>
//            GetAppointmentByDoctorAsync(
//                int doctorId,
//                int pageNumber,
//                int pageSize)
//        {
//            var query = _context.Appointments
//                .Where(a =>
//                    a.DoctorId == doctorId &&
//                    a.ScheduledDate >= DateOnly.FromDateTime(DateTime.Today));

//            var total = await query.CountAsync();

//            var data = await query
//                .OrderBy(a => a.ScheduledDate)
//                .Skip((pageNumber - 1) * pageSize)
//                .Take(pageSize)
//                .ToListAsync();

//            return (data, total);
//        }
//    }
//}