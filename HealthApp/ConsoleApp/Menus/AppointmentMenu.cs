using System;
using System.Collections.Generic;
using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Helpers;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Menus
{
    public class AppointmentMenu
    {
        // Three services injected — menu needs to look up patient + doctor before booking
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService     _patientService;
        private readonly IDoctorService      _doctorService;

        // DI Constructor
        public AppointmentMenu(
            IAppointmentService appointmentService,
            IPatientService     patientService,
            IDoctorService      doctorService)
        {
            _appointmentService = appointmentService;
            _patientService     = patientService;
            _doctorService      = doctorService;
        }

       // Book an appointment

        // Books an appointment for a patient with a doctor.
        public void BookAppointment()
        {
            PrintHeader("Book an Appointment");

            if (!InputValidator.TryReadPositiveInt("Patient ID : ", out int patientId))
            {
                InputValidator.Pause(); return;
            }

            Patient? patient = _patientService.GetPatientById(patientId);
            if (patient == null)
            {
                PrintError($"No patient found with ID {patientId}.");
                InputValidator.Pause(); return;
            }

            Console.WriteLine($"  Found: {patient.GetProfileSummary()}");

            // ── Doctor lookup ────────────────────────────────────────────────────
            if (!InputValidator.TryReadPositiveInt("Doctor ID  : ", out int doctorId))
            {
                InputValidator.Pause(); return;
            }

            Doctor? doctor = _doctorService.GetByDoctorId(doctorId);
            if (doctor == null)
            {
                PrintError($"No doctor found with ID {doctorId}.");
                InputValidator.Pause(); return;
            }

            if (!doctor.IsActive)
            {
                PrintError($"Dr. {doctor.FullName} is currently inactive.");
                InputValidator.Pause(); return;
            }

            Console.WriteLine($"  Found: Dr. {doctor.FullName} ({doctor.Specialisation})");

            // ── Appointment date ─────────────────────────────────────────────────
            if (!InputValidator.TryReadFutureDate("Date (dd/MM/yyyy)  : ", out DateTime date))
            {
          
                InputValidator.Pause(); return;
            }

            // ── Time slot ────────────────────────────────────────────────────────
            // Show available slots so the user doesn't have to guess the format
            Console.WriteLine();
            Console.WriteLine("  Available time slots:");
            Console.WriteLine("    [1] 09:00 AM    [2] 10:00 AM    [3] 11:00 AM");
            Console.WriteLine("    [4] 02:00 PM    [5] 03:00 PM    [6] 04:00 PM");

            if (!InputValidator.TryReadInt("  Choose slot (1-6): ", out int slotChoice)
                || slotChoice < 1 || slotChoice > 6)
            {
                PrintError("Please enter a number between 1 and 6.");
                InputValidator.Pause(); return;
            }

            string[] slots = { "09:00 AM", "10:00 AM", "11:00 AM", "02:00 PM", "03:00 PM", "04:00 PM" };
            string   slot  = slots[slotChoice - 1];

            // ── Book via service — catches all three spec exceptions ──────────────
            try
            {
                Appointment appt = _appointmentService.BookAppointment(patient, doctor, date, slot);

                Console.WriteLine();
                PrintSuccess("Appointment booked!");
                Console.WriteLine($"  {appt.GetDetails()}");     // spec method: GetDetails()
            }
            catch (PastDateException ex)
            {
                PrintError(ex.Message);
            }
            catch (DoctorUnavailableException ex)
            {
                PrintError(ex.Message);
            }
            catch (AppointmentConflictException ex)
            {
                PrintError(ex.Message);
            }

            InputValidator.Pause();
        }

        // ── Option 5: View all appointments for a patient ─────────────────────────
        public void ViewPatientAppointments()
        {
            PrintHeader("View Appointments for a Patient");

            if (!InputValidator.TryReadPositiveInt("Patient ID: ", out int patientId))
            {
                InputValidator.Pause(); return;
            }

            List<Appointment> list = _appointmentService.GetAppointmentsByPatient(patientId);

            if (list.Count == 0)
            {
                Console.WriteLine($"\n  No appointments found for patient ID {patientId}.");
                InputValidator.Pause();
                return;
            }

            Console.WriteLine($"\n  {list.Count} appointment(s):\n");
            foreach (Appointment a in list)
            {
                Console.WriteLine($"  {a.GetDetails()}");    
                Console.WriteLine();
            }

            InputValidator.Pause();
        }

        // Confirm or cancel an appointment
            public void ConfirmOrCancel()
        {
            PrintHeader("Confirm or Cancel an Appointment");

            // Show upcoming appointments first so the user can see valid IDs
            List<Appointment> upcoming = _appointmentService.GetUpcomingAppointments();

            if (upcoming.Count == 0)
            {
                Console.WriteLine("  No upcoming confirmed appointments.");
                InputValidator.Pause();
                return;
            }

            Console.WriteLine("  Upcoming appointments:\n");
            foreach (Appointment a in upcoming)
                Console.WriteLine($"  {a.GetDetails()}");

            Console.WriteLine();

            // ── Appointment ID ───────────────────────────────────────────────────
            if (!InputValidator.TryReadPositiveInt("Appointment ID       : ", out int apptId))
            {
                InputValidator.Pause(); return;
            }

            Console.Write("Action — [C] Confirm  [X] Cancel : ");
            string action = Console.ReadLine()?.Trim().ToUpper() ?? "";

            if (action == "C")
            {
                // Find the appointment through the service and confirm it
                Appointment? appt = _appointmentService.GetAppointmentById(apptId);

                if (appt == null)
                {
                    PrintError($"Appointment ID {apptId} not found.");
                    InputValidator.Pause(); return;
                }

                if (appt.Status == AppointmentStatus.Confirmed)
                {
                    Console.WriteLine("  This appointment is already confirmed.");
                    InputValidator.Pause(); return;
                }

                appt.Confirm();    // spec method: Confirm()
                PrintSuccess($"Appointment {apptId} confirmed.");
                Console.WriteLine($"  {appt.GetDetails()}");
            }
            else if (action == "X")
            {
                if (!InputValidator.TryReadString("Reason for cancellation: ", out string reason))
                {
                    InputValidator.Pause(); return;
                }

                try
                {
                    _appointmentService.CancelAppointment(apptId, reason);
                    PrintSuccess($"Appointment {apptId} cancelled. Reason: {reason}");
                }
                catch (Exception ex)
                {
                    PrintError(ex.Message);
                }
            }
            else
            {
                PrintError("Invalid action. Please enter C to confirm or X to cancel.");
            }

            InputValidator.Pause();
        }


        private static void PrintHeader(string title)
        {
            Console.WriteLine();
            Console.WriteLine($"  ── {title} ──");
            Console.WriteLine();
        }

        private static void PrintSuccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  ✔ {msg}");
            Console.ResetColor();
        }

        private static void PrintError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"  ✗ {msg}");
            Console.ResetColor();
        }
    }
}