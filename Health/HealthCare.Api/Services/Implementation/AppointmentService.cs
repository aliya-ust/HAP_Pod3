//using HealthCare.Api.Models;
//using HealthCare.Api.Repositories.Interfaces;
//using HealthCare.Api.Services.Interfaces;

//namespace HealthCare.Api.Services.Implementation
//{
//    public class AppointmentService : IAppointmentService
//    {
//        private readonly IAppointmentRepository _appointmentRepository;

//        public AppointmentService(IAppointmentRepository appointmentRepository)
//        {
//            _appointmentRepository = appointmentRepository;
//        }

//        public Task<Appointment> CreateAsync(Appointment appointment, CancellationToken ct = default)
//            => _appointmentRepository.CreateAsync(appointment, ct);

//        public Task<Appointment> UpdateAsync(int id, Appointment appointment, CancellationToken ct = default)
//            => _appointmentRepository.UpdateAsync(id, appointment, ct);

//        public Task<Appointment> DeleteAsync(Appointment appointment, CancellationToken ct = default)
//            => _appointmentRepository.DeleteAsync(appointment, ct);

//        public Task<List<Appointment>> GetAllAsync(CancellationToken ct = default)
//            => _appointmentRepository.GetAllAsync(ct);

//        public Task<Appointment> GetByIdAsync(int id, CancellationToken ct = default)
//            => _appointmentRepository.GetByIdAsync(id, ct);

//        public Task<List<Appointment>> GetAppointmentsByPatientIdAsync(int patientId, CancellationToken ct = default)
//            => _appointmentRepository.GetAppointmentsByPatientIdAsync(patientId, ct);

//        public Task<List<Appointment>> GetAppointmentsByDoctorIdAsync(int doctorId, CancellationToken ct = default)
//            => _appointmentRepository.GetAppointmentsByDoctorIdAsync(doctorId, ct);

//        public Task<List<Appointment>> GetConfirmedAppointmentsAsync(CancellationToken ct = default)
//            => _appointmentRepository.GetConfirmedAppointmentsAsync(ct);
//    }
//}
