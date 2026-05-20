using System;
using System.Collections.Generic;
using HealthApp.ConsoleApp.Helpers;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Menus
{

    public class PatientMenu
    {
        private readonly IPatientService _patientService;

        // DI Constructor — IPatientService is injected by the ServiceProvider in Program.cs
        public PatientMenu(IPatientService patientService)
        {
            _patientService = patientService;
        }


        public void RegisterPatient()
        {
            PrintHeader("Register New Patient");

            // ── Full Name ───────────────────────────────────────────────────────
            if (!InputValidator.TryReadString("Full name         : ", out string fullName))
            {
                InputValidator.Pause();
                return;
            }

            // ── Date of Birth ───────────────────────────────────────────────────
            if (!InputValidator.TryReadPastDate("Date of birth     : ", out DateTime dob))
            {
                InputValidator.Pause();
                return;
            }

            // Gender
            if (!InputValidator.TryReadString("Gender (M/F/Other): ", out string gender))
            {
                InputValidator.Pause();
                return;
            }

            // Phone Number 
            if (!InputValidator.TryReadPhone("Phone number      : ", out string phone))
            {
                InputValidator.Pause();
                return;
            }

            //  Email 
            if (!InputValidator.TryReadEmail("Email             : ", out string email))
            {
                InputValidator.Pause();
                return;
            }

            //  Insurance ID (optional — spec says "press Enter to skip") 
            string insuranceId = InputValidator.ReadOptionalString("Insurance ID      : ");

            //  Build and register 
            // PatientId and CreatedDate are set by the service (not the menu)
            var patient = new Patient
            {
                Name = fullName,
                Dob = dob,
                Gender = gender,
                PhoneNumber = phone,
                Email = email,
                InsuranceId = insuranceId,
                CreatedAt = DateTime.Now   // spec property: CreatedDate
            };

            _patientService.Register(patient);

            Console.WriteLine();
            PrintSuccess("Patient registered successfully!");
            Console.WriteLine(patient.GetProfileSummary());   // spec method: GetProfileSummary()

            InputValidator.Pause();
        }

        // ── Helper methods ────────────────────────────────────────────────────────

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
    }
}