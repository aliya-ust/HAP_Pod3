using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Exceptions;
namespace HealthApp.ConsoleApp.Repositories
{
    public class AppointmentRepo : IAppointmentRepository
    {
        private List<Appointment> _appointments;
        public AppointmentRepo(List<Appointment> appointments)
        {
            _appointments = appointments;
        }

        public void AddAppointment(Appointment appointment)
        {
            
            _appointments.Add(appointment);
        }

        public List<Appointment> GetAllAppointments()
        {
            return _appointments;
        }

        public Appointment GetAppointmentById(int id)
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
            var appointments = _appointments.Where(a => a.Patient.PatientId == patientId).ToList();
            if (appointments.Count == 0)
            {
                throw new AppointmentNotFoundException($"No appointments found for patient ID {patientId}.");
            }
            return appointments;
        }
        public List<Appointment> GetAppointmentsByDoctor(int doctorId)
        {
            var appointments = _appointments.Where(a => a.Doctor.DoctorId == doctorId).ToList();
            if (appointments.Count == 0)
            {
                throw new AppointmentNotFoundException($"No appointments found for doctor ID {doctorId}.");
            }
            return appointments;
        }
    }
}