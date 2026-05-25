using System;
using System.Collections.Generic;
using System.Linq;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Databases;

namespace HealthApp.ConsoleApp.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly List<Appointment> _appointments;

        public AppointmentRepository(AppointmentDb appointmentDb)
        {
            _appointments = appointmentDb.Appointments;
        }

        public void AddAppointment(Appointment appointment)
        {
            if (appointment == null)
                return;

            _appointments.Add(appointment);
        }

        public List<Appointment> GetAllAppointments()
        {
            return new List<Appointment>(_appointments);
        }

        public Appointment GetAppointmentById(int id)
        {
            return _appointments
                .FirstOrDefault(a => a.AppointmentId == id);
        }

        public void UpdateAppointment(Appointment appointment)
        {
            if (appointment == null)
                return;

            var existing = _appointments
                .FirstOrDefault(a => a.AppointmentId == appointment.AppointmentId);

            if (existing == null)
                return;

            existing.Patient = appointment.Patient;
            existing.Doctor = appointment.Doctor;
            existing.ScheduledDate = appointment.ScheduledDate;
            existing.TimeSlot = appointment.TimeSlot;
            existing.Status = appointment.Status;
            existing.CancellationReason = appointment.CancellationReason;
        }

        public void CancelAppointment(int id, string reason)
        {
            if (string.IsNullOrWhiteSpace(reason))
                return;

            var appointment = _appointments
                .FirstOrDefault(a => a.AppointmentId == id);

            if (appointment == null)
                return;

            appointment.Cancel(reason);
        }

        public void DeleteAppointment(int id)
        {
            var appointment = _appointments
                .FirstOrDefault(a => a.AppointmentId == id);

            if (appointment == null)
                return;

            _appointments.Remove(appointment);
        }

        public List<Appointment> GetAppointmentsByPatient(int patientId)
        {
            return _appointments
                .Where(a => a.Patient != null && a.Patient.Id == patientId)
                .ToList();
        }

        public List<Appointment> GetAppointmentsByDoctor(int doctorId)
        {
            return _appointments
                .Where(a => a.Doctor != null && a.Doctor.DoctorId == doctorId)
                .ToList();
        }
    }
}