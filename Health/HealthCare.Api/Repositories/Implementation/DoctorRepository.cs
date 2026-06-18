//using HealthCare.Api.Data;
//using HealthCare.Api.Models;
//using HealthCare.Api.Repositories.Interfaces;
//using Microsoft.EntityFrameworkCore;

//namespace HealthCare.Api.Repositories.Implementation
//{
//    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
//    {
//        public DoctorRepository(HealthCareDbContext context)
//            : base(context)
//        {
//        }

//        public async Task<List<Doctor>> GetDoctorBySpecialisationAsync(string specialisation)
//        {
//            return await _context.Doctors
//                .Where(d => d.Specialisation == specialisation)
//                .ToListAsync();
//        }

//        public async Task<List<string>> GetBookedSlotsAsync(DateOnly date, int doctorId)
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

//        public async Task<List<DoctorLeaves>> GetDoctorLeavesAsync(int doctorId)
//        {
//            return await _context.DoctorLeaves
//                .Where(l => l.DoctorId == doctorId)
//                .ToListAsync();
//        }
//    }
//}