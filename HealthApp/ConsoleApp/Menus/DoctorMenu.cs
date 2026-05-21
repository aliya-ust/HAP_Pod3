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

        public DoctorMenu(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public void AddDoctor()
        {
            PrintHeader("Add New Doctor");

            
            if (!InputValidator.TryReadString("Full name            : ", out string fullName))
            {
                InputValidator.Pause(); return;
            }

            if (!InputValidator.TryReadString("Specialisation       : ", out string spec))
            {
                InputValidator.Pause(); return;
            }

            if (!InputValidator.TryReadPositiveInt("Years of experience  : ", out int years))
            {
                InputValidator.Pause(); return;
            }

            if (!InputValidator.TryReadDecimal("Consultation fee (₹) : ", out decimal fee))
            {
                InputValidator.Pause(); return;
            }
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

            Console.WriteLine($"  {doctor.GetScheduleSummary}");

            InputValidator.Pause();
        }

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

        private static void PrintHeader(string title)
        {
            Console.WriteLine();
            Console.WriteLine($"  ── {title} ──");
            Console.WriteLine();
        }

        private static void PrintSuccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"   {msg}");
            Console.ResetColor();
        }
    }
}