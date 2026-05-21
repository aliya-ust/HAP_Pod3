using System;
using System.Collections.Generic;
using System.Linq;
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
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment));

            _appointments.Add(appointment);
        }

        public List<Appointment> GetAllAppointments()
        {
            return new List<Appointment>(_appointments);
        }

        public Appointment GetAppointmentById(int id)
        {
            var appointment = _appointments.FirstOrDefault(a => a.Id == id);

            if (appointment == null)
                throw new AppointmentNotFoundException($"Appointment with ID {id} not found.");

            return appointment;
        }

        public void UpdateAppointment(Appointment appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment));

            var existing = GetAppointmentById(appointment.Id);

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
                throw new ArgumentException("Cancellation reason is required.");

            var appointment = GetAppointmentById(id);
            appointment.Cancel(reason);
        }

        public void DeleteAppointment(int id)
        {
            var appointment = GetAppointmentById(id);
            _appointments.Remove(appointment);
        }

        public List<Appointment> GetAppointmentsByPatient(int patientId)
        {
            var appointments = _appointments
                .Where(a => a.Patient != null && a.Patient.Id == patientId)
                .ToList();

            if (appointments.Count == 0)
                throw new AppointmentNotFoundException($"No appointments found for patient ID {patientId}.");

            return appointments;
        }

        public List<Appointment> GetAppointmentsByDoctor(int doctorId)
        {
            var appointments = _appointments
                .Where(a => a.Doctor != null && a.Doctor.Id == doctorId)
                .ToList();

            if (appointments.Count == 0)
                throw new AppointmentNotFoundException($"No appointments found for doctor ID {doctorId}.");

            return appointments;
        }
    }
}