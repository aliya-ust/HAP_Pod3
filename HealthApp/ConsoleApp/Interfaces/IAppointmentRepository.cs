using HealthApp.ConsoleApp.Models;
namespace HealthApp.ConsoleApp.Interfaces
{
    public interface IAppointmentRepository
    {
        string AddAppointment(Appointment appointment);
        List<Appointment> GetAllAppointments();
        // Appointment GetAppointmentById(int id);
        // void UpdateAppointment(Appointment appointment);
        // void DeleteAppointment(int id);
        List<Appointment> GetAppointmentsByDoctorId(int doctorId);
        List<Appointment> GetAppointmentsByPatientId(int patientId);
    }
}