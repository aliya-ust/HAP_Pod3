using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Databases;
namespace HealthApp.ConsoleApp.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly List<Appointment> _appointments;
        public AppointmentRepository(AppointmentDb appointmentDb)
        {
            _appointments = appointmentDb.appointments;
        }

        public void AddAppointment(Appointment appointment)
        {

            _appointments.Add(appointment);
        }

        public List<Appointment> GetAllAppointments()
        {
            return _appointments.ToList();
        }

        public Appointment? GetAppointmentById(int id)
        {
            return _appointments.FirstOrDefault(a => a.AppointmentId == id);
        }

        public void UpdateAppointment(Appointment appointment)
        {
            var existing = GetAppointmentById(appointment.AppointmentId);
            if (existing is null)
            {

                throw new AppointmentNotFoundException($"Appointment with ID {appointment.AppointmentId} not found.");
            }
            existing.Patient = appointment.Patient;
            existing.Doctor = appointment.Doctor;
            existing.ScheduledDate = appointment.ScheduledDate;
            existing.TimeSlot = appointment.TimeSlot;
            existing.Status = appointment.Status;
            //existing.CancellationReason = appointment.CancellationReason;
        }

        public void CancelAppointment(int id, string reason)
        {
            var appointment = GetAppointmentById(id);
            if (appointment != null)
            {
                appointment.Status = AppointmentStatus.Cancelled;
                appointment.CancellationReason = reason;
            }
        }

        public void DeleteAppointment(int id)
        {
            var appointment = GetAppointmentById(id);
            if (appointment != null)
            {
                _appointments.Remove(appointment);
            }
        }
        public List<Appointment> GetAppointmentsByPatient(int patientId)
        {
            var appointments = _appointments
    .Where(a => a.Patient != null && a.Patient.PatientId == patientId)
    .ToList();
            if (appointments.Count == 0)
            {
                throw new AppointmentNotFoundException($"No appointments found for patient ID {patientId}.");
            }
            return appointments;
        }
        public List<Appointment> GetAppointmentsByDoctor(int doctorId)
        {
            return _appointments
                .Where(a => a.Doctor != null
                         && a.Doctor.DoctorId == doctorId
                         && a.Status == AppointmentStatus.Confirmed)   // ✅ ADD HERE
                .ToList();
        }
    }
}