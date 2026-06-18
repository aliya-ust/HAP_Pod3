//using HealthCare.Api.Models;
//using HealthCare.Shared.DTOs;
//using HealthCare.Shared.Models;

//namespace HealthCare.Api.Repositories.Interfaces
//{
//    public interface IAppointmentRepository : IRepository<Appointment>
//    {
//        Task<List<string>> AvailableTimeSlotsAsync(
//            DateOnly date,
//            int doctorId);

//        Task<bool> IsAvailableAsync(
//            DateOnly date,
//            int doctorId,
//            string timeSlot);

//        Task<List<AppointmentReportDto>> GetDailyReportAsync();

//        Task<List<Appointment>> GetDoctorScheduleAsync(
//            DateOnly date,
//            int doctorId);

//        Task<List<Appointment>> GetPatientScheduleAsync(
//            DateOnly date,
//            int patientId);

//        Task<List<Appointment>> GetAppointmentByPatientAsync(
//            int patientId);

//        Task<(List<Appointment> Appointments, int TotalCount)>
//            GetAppointmentByDoctorAsync(
//                int doctorId,
//                int pageNumber,
//                int pageSize);
//    }
//}