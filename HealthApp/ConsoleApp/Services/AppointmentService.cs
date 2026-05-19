using System;
using System.Collections.Generic;
using System.Linq;
using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Interfaces;

namespace HealthApp.ConsoleApp.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        private int _appointmentIdCounter = 1;

        //  Constructor Injection
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        //  BOOK APPOINTMENT
        public Appointment BookAppointment(Patient patient, Doctor doctor, DateTime date, string slot)
        {
            if (date < DateTime.Now)
            {
                throw new PastDateException("Cannot book appointment in the past.");
            }

            if (!doctor.IsAvailable(date))
            {
                throw new DoctorUnavailableException("Doctor is not available on selected date.");
            }

            var appointments = _appointmentRepository.GetAllAppointments();

            bool isSlotTaken = appointments.Any(a =>
                a.Doctor.DoctorId == doctor.DoctorId &&
                a.ScheduledDate.Date == date.Date &&
                a.TimeSlot == slot &&
                a.Status != AppointmentStatus.Cancelled);

            if (isSlotTaken)
            {
                throw new AppointmentConflictException("Selected time slot is already booked.");
            }

            var appointment = new Appointment
            {
                AppointmentId = _appointmentIdCounter++,
                Patient = patient,
                Doctor = doctor,
                ScheduledDate = date,
                TimeSlot = slot,
                Status = AppointmentStatus.Pending
            };

            _appointmentRepository.AddAppointment(appointment);

            return appointment;
        }

        //  CANCEL APPOINTMENT
        public void CancelAppointment(int appointmentId, string reason)
        {
            var appointment = _appointmentRepository.GetAppointmentById(appointmentId);

            if (appointment != null)
            {
                appointment.CancellationReason = reason;
                _appointmentRepository.UpdateAppointment(appointment);
            }
        }

        //  GET BY PATIENT
        public List<Appointment> GetAppointmentsByPatient(int patientId)
        {
            return _appointmentRepository.GetAppointmentsByPatient(patientId);
        }

        //  GET BY DOCTOR
        public List<Appointment> GetAppointmentsByDoctor(int doctorId)
        {
            return _appointmentRepository.GetAppointmentsByDoctor(doctorId);
        }

        //  GET UPCOMING
        public List<Appointment> GetUpcomingAppointments()
        {
            return _appointmentRepository
                .GetAllAppointments()
                .Where(a => a.ScheduledDate > DateTime.Now &&
                            a.Status == AppointmentStatus.Confirmed)
                .OrderBy(a => a.ScheduledDate)
                .ToList();
        }
    }
}
