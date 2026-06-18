//using HealthCare.Api.Data;
//using HealthCare.Api.Models;
//using HealthCare.Api.Repositories.Interfaces;
////using HealthCare.Shared.Models;
//using Microsoft.EntityFrameworkCore;

//namespace HealthCare.Api.Repositories.Implementation
//{
//    public class HealthRecordRepository : Repository<HealthRecord>, IHealthRecordRepository
//    {
//        public HealthRecordRepository(HealthCareDbContext context)
//            : base(context)
//        {
//        }

//        public async Task<List<HealthRecord>> GetHealthRecordByPatientAsync(int patientId)
//        {
//            return await _context.HealthRecords
//                .Where(h => h.PatientId == patientId)
//                .ToListAsync();
//        }

//        public async Task<List<HealthRecord>> GetHealthRecordByAppointmentAsync(int appointmentId)
//        {
//            return await _context.HealthRecords
//                .Where(h => h.AppointmentId == appointmentId)
//                .ToListAsync();
//        }
//    }
//}