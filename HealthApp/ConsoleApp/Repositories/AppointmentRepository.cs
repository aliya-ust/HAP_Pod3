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

        public string AddAppointment(Appointment appointment)
        {
            _appointments.Add(appointment);
            return $"Appointment of ID {appointment.AppointmentId} has been created successfully";
        }

        public List<Appointment> GetAllAppointments()
        {
            return _appointments;
        }

        // public Appointment GetAppointmentById(int id)
        // {
        //     return _appointments.FirstOrDefault(a => a.AppointmentId == id);
        // }

        // public void UpdateAppointment(Appointment appointment)
        // {
        //     var existing = GetAppointmentById(appointment.AppointmentId);
        //     if (existing is null)
        //     {

        //         throw new AppointmentNotFoundException($"Appointment with ID {appointment.AppointmentId} not found.");
        //     }
        //     existing.Patient = appointment.Patient;
        //     existing.Doctor = appointment.Doctor;
        //     existing.ScheduledDate = appointment.ScheduledDate;
        //     existing.TimeSlot = appointment.TimeSlot;
        //     existing.Status = appointment.Status;
        //     //existing.CancellationReason = appointment.CancellationReason;
        // }
        
        // public void CancelAppointment(int id, string reason)
        // {
        //     var appointment = GetAppointmentById(id);
        //     if (appointment != null)
        //     {
        //         appointment.Status = AppointmentStatus.Cancelled;
        //         appointment.CancellationReason = reason;
        //     }
        // }

        // public void DeleteAppointment(int id)
        // {
        //     var appointment = GetAppointmentById(id);
        //     if (appointment != null)
        //     {
        //         _appointments.Remove(appointment);
        //     }
        // }

        public List<Appointment> GetAppointmentsByPatientId(int patientId)
        {
            return _appointments.Where(a => a.Patient.PatientId == patientId).ToList();
        }

        public List<Appointment> GetAppointmentsByDoctorId(int doctorId)
        {
            return _appointments.Where(a => a.Doctor.DoctorId == doctorId).ToList();
        }
    }
}