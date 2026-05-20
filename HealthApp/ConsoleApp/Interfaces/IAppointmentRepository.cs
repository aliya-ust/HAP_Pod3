using HealthApp.ConsoleApp.Models;
namespace HealthApp.ConsoleApp.Interfaces
{
    public interface IAppointmentRepository
    {
        void AddAppointment(Appointment appointment);
        // List<Appointment> GetAllAppointments();
        // Appointment GetAppointmentById(int id);
        // void UpdateAppointment(Appointment appointment);
        // void DeleteAppointment(int id);
        // List<Appointment> GetAppointmentsByDoctor(int doctorId);
        // List<Appointment> GetAppointmentsByPatient(int patientId);
    }
}