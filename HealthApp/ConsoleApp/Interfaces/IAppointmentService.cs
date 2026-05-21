using System;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Interfaces
{   
public interface IAppointmentService
{
    string BookAppointment(Patient patient, Doctor doctor, DateTime date, string slot);
    // void CancelAppointment(int appointmentId, string reason);
    List<Appointment> GetAppointmentsByPatientId(int patientId);
    List<Appointment> GetAppointmentsByDoctorId(int doctorId);
    // List<Appointment> GetUpcomingAppointments();
}
}