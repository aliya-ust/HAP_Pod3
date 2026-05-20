using System;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Interfaces
{   
public interface IAppointmentService
{
    Appointment BookAppointment(Patient patient, Doctor doctor, DateTime date, string slot);
    void CancelAppointment(int appointmentId, string reason);
    List<Appointment> GetAppointmentsByPatient(int patientId);
    List<Appointment> GetAppointmentsByDoctor(int doctorId);
    List<Appointment> GetUpcomingAppointments();
    Appointment GetAppointmentById(int appointmentId);
}
}