using System;
using System.Collections.Generic;
using System.Linq;
using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepo;

        private int _appointmentIdCounter = 1;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepo = appointmentRepository;
        }

        public string BookAppointment(Patient patient, Doctor doctor, DateTime date, string slot)
        {
            if (date < DateTime.Now)
            {
                throw new PastDateException("Cannot book appointment in the past.");
            }

            if (!doctor.IsAvailable(date))
            {
                throw new DoctorUnavailableException("Doctor is not available on selected date.");
            }

            var appointments = _appointmentRepo.GetAllAppointments();

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
            
            return _appointmentRepo.AddAppointment(appointment);
        }

        public List<Appointment> GetAppointmentsByPatientId(int patientId)
        {
            var appointments = _appointmentRepo.GetAppointmentsByPatientId(patientId);
            if (appointments.Count == 0)
            {
                throw new AppointmentNotFoundException($"No appointments found for patient ID {patientId}.");
            }

            return appointments;
        }

        public List<Appointment> GetAppointmentsByDoctorId(int doctorId)
        {
            var appointments = _appointmentRepo.GetAppointmentsByDoctorId(doctorId);
            if (appointments.Count == 0)
            {
                throw new AppointmentNotFoundException($"No appointments found for doctor ID {doctorId}.");
            }
            
            return appointments;
        }

        public Appointment? GetAppointmentById(int appointmentId)
        {
            Appointment? appointment = _appointmentRepo.GetAppointmentById(appointmentId);

            if (appointment is null)
            {
                throw new AppointmentNotFoundException($"Appointment of ID {appointmentId} does not exist");
            }
            return appointment;
        }

        public bool isAppointmentCompleted(Appointment appointment)
        {
            if (appointment.Status != AppointmentStatus.Completed)
            {
                throw new AppointmentNotCompletedException($"Health record of appointment ID {appointment.AppointmentId} cannot be created as the appointment has not been completed");
            }
            return true;
        }

//         //  CANCEL APPOINTMENT
//         public void CancelAppointment(int appointmentId, string reason)
//         {
//             var appointment = _appointmentRepository.GetAppointmentById(appointmentId);

//             if (appointment != null)
//             {
//                 appointment.CancellationReason = reason;
//                 _appointmentRepository.UpdateAppointment(appointment);
//             }
//         }

//         //  GET UPCOMING
//         public List<Appointment> GetUpcomingAppointments()
//         {
//             return _appointmentRepository
//                 .GetAllAppointments()
//                 .Where(a => a.ScheduledDate > DateTime.Now &&
//                             a.Status == AppointmentStatus.Confirmed)
//                 .OrderBy(a => a.ScheduledDate)
//                 .ToList();
//         }
    }
}
