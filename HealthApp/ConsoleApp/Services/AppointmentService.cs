using System;
using System.Collections.Generic;
using System.Linq;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Exceptions;

namespace HealthApp.ConsoleApp.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private int _appointmentIdCounter = 1;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public Appointment BookAppointment(Patient patient, Doctor doctor, DateTime date, string slot)
        {
            if (patient == null)
                throw new ArgumentException("Patient details are required.");

            if (doctor == null)
                throw new ArgumentException("Doctor details are required.");

            if (patient.Id <= 0)
                throw new ArgumentException("Invalid patient ID.");

            if (doctor.DoctorId <= 0)
                throw new ArgumentException("Invalid doctor ID.");

            if (!doctor.IsActive)
                throw new DoctorUnavailableException("Doctor is not active.");

            if (date < DateTime.Today)
                throw new PastDateException("Cannot book appointment in the past.");

            if (string.IsNullOrWhiteSpace(slot))
                throw new ArgumentException("Time slot cannot be empty.");

            var availability = doctor.CheckAvailability(date);
            if (availability != "Doctor is available.")
                throw new DoctorUnavailableException(availability);

            var appointments = _appointmentRepository.GetAllAppointments();

            bool isSlotTaken = appointments.Any(a =>
                a.Doctor != null &&
                a.Doctor.DoctorId == doctor.DoctorId &&
                a.ScheduledDate.Date == date.Date &&
                a.TimeSlot == slot &&
                a.Status != AppointmentStatus.Cancelled);

            if (isSlotTaken)
                throw new AppointmentConflictException("Selected time slot is already booked.");

            var appointment = new Appointment
            {
                AppointmentId = _appointmentIdCounter++,
                Patient = patient,
                Doctor = doctor,
                ScheduledDate = date,
                TimeSlot = slot,
                Status = AppointmentStatus.Confirmed
            };

            _appointmentRepository.AddAppointment(appointment);

            return appointment;
        }

        public void CancelAppointment(int appointmentId, string reason)
        {
            if (appointmentId <= 0)
                throw new ArgumentException("Invalid appointment ID.");

            if (string.IsNullOrWhiteSpace(reason))
                throw new ArgumentException("Cancellation reason is required.");

            var existing = _appointmentRepository.GetAppointmentById(appointmentId);

            if (existing == null)
                throw new AppointmentNotFoundException($"Appointment with ID {appointmentId} not found.");

            _appointmentRepository.CancelAppointment(appointmentId, reason);
        }

        public List<Appointment> GetAppointmentsByPatient(int patientId)
        {
            if (patientId <= 0)
                throw new ArgumentException("Invalid patient ID.");

            var list = _appointmentRepository.GetAppointmentsByPatient(patientId);

            if (list == null || list.Count == 0)
                throw new AppointmentNotFoundException("No appointments found for this patient.");

            return list;
        }

        public List<Appointment> GetAppointmentsByDoctor(int doctorId)
        {
            if (doctorId <= 0)
                throw new ArgumentException("Invalid doctor ID.");

            var list = _appointmentRepository.GetAppointmentsByDoctor(doctorId);

            if (list == null || list.Count == 0)
                throw new AppointmentNotFoundException("No appointments found for this doctor.");

            return list;
        }

        public Appointment GetAppointmentById(int appointmentId)
        {
            if (appointmentId <= 0)
                throw new ArgumentException("Invalid appointment ID.");

            var appointment = _appointmentRepository.GetAppointmentById(appointmentId);

            if (appointment == null)
                throw new AppointmentNotFoundException($"Appointment with ID {appointmentId} not found.");

            return appointment;
        }

        public List<Appointment> GetUpcomingAppointments()
        {
            var list = _appointmentRepository.GetAllAppointments()
                .Where(a => a.ScheduledDate > DateTime.Now &&
                            a.Status == AppointmentStatus.Confirmed)
                .OrderBy(a => a.ScheduledDate)
                .ToList();

            if (list.Count == 0)
                throw new AppointmentNotFoundException("No upcoming appointments.");

            return list;
        }
    }
}