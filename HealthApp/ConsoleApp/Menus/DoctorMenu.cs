using System;
using System.Collections.Generic;
using HealthApp.ConsoleApp.Helpers;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Menus
{
    public class DoctorMenu
    {
        private readonly IDoctorService _doctorService;

        // DI Constructor
        public DoctorMenu(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // ── Option 2: Add a new doctor ────────────────────────────────────────────

        public void AddDoctor()
        {
            PrintHeader("Add New Doctor");

            // ── Full Name ────────────────────────────────────────────────────────
            if (!InputValidator.TryReadString("Full name            : ", out string fullName))
            {
                InputValidator.Pause(); return;
            }

            // ── Specialisation ───────────────────────────────────────────────────
            if (!InputValidator.TryReadString("Specialisation       : ", out string spec))
            {
                InputValidator.Pause(); return;
            }

            // ── Years of Experience ──────────────────────────────────────────────
            if (!InputValidator.TryReadPositiveInt("Years of experience  : ", out int years))
            {
                InputValidator.Pause(); return;
            }

            // ── Consultation Fee ─────────────────────────────────────────────────
            if (!InputValidator.TryReadDecimal("Consultation fee (₹) : ", out decimal fee))
            {
                InputValidator.Pause(); return;
            }
            // DoctorId is assigned by the service (keeps ID management in one place)
            var doctor = new Doctor
            {
                FullName          = fullName,
                Specialisation    = spec,
                YearsOfExperience = years,
                ConsultationFee   = fee,
                IsActive          = true
            };

            _doctorService.AddDoctor(doctor);

            Console.WriteLine();
            PrintSuccess("Doctor added successfully!");

            // GetScheduleSummary() — spec method (shows appointment count = 0 for new doctor)
            Console.WriteLine($"  {doctor.GetScheduleSummary}");

            InputValidator.Pause();
        }

        //  Search by specialisation

        public void SearchBySpecialisation()
        {
            PrintHeader("Search Doctors by Specialisation");

            if (!InputValidator.TryReadString("Specialisation (e.g. Cardiology): ", out string query))
            {
                InputValidator.Pause(); return;
            }

            List<Doctor> results = _doctorService.SearchBySpecialisation(query);

            if (results.Count == 0)
            {
                Console.WriteLine($"\n  No active doctors found for '{query}'.");
                InputValidator.Pause();
                return;
            }

            Console.WriteLine($"\n  {results.Count} doctor(s) found:\n");

            foreach (Doctor d in results)
            {
                Console.WriteLine($"  [{d.DoctorId}] Dr. {d.FullName}");
                Console.WriteLine($"       Specialisation : {d.Specialisation}");
                Console.WriteLine($"       Experience     : {d.YearsOfExperience} years");
                Console.WriteLine($"       Fee            : ₹{d.ConsultationFee}");

                // IsAvailable() — spec method
                bool available = d.IsAvailable(DateTime.Today);
                Console.ForegroundColor = available ? ConsoleColor.Green : ConsoleColor.Yellow;
                Console.WriteLine($"       Available Today : {(available ? "Yes" : "No")}");
                Console.ResetColor();

                Console.WriteLine($"       {d.GetScheduleSummary}");
                Console.WriteLine();
            }

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