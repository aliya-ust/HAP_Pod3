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
            if (!InputValidator.TryReadName("Full name            : ", out string fullName))
            {
                InputValidator.Pause(); return;
            }

            // ── Specialisation ───────────────────────────────────────────────────
            if (!InputValidator.TryReadName("Specialisation       : ", out string spec))
            {
                InputValidator.Pause(); return;
            }

            // ── Years of Experience ──────────────────────────────────────────────
            if (!InputValidator.TryReadPositiveInt("Years of experience  : ", out int years))
            {
                InputValidator.Pause(); return;
            }

            // ── Consultation Fee ─────────────────────────────────────────────────
            if (!InputValidator.TryReadDecimal("Consultation fee (Rs.) : ", out decimal fee))
            {
                InputValidator.Pause(); return;
            }
            if (!InputValidator.TryReadFutureDate("Enter the future days when the doctor is available (e.g. 01/07/2024). Type 'done' when finished.", out DateTime availableDate))
            {
                InputValidator.Pause(); return;
            }
            List<DateTime> availableDates = new List<DateTime>();
            while (true)            {
                Console.Write("Available date (or 'done'): ");
                string input = Console.ReadLine()?.Trim() ?? "";
                if (input.Equals("done", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                if (DateTime.TryParse(input, out DateTime date))
                {
                    if (date.Date < DateTime.Today)
                    {
                        Console.WriteLine("Please enter a future date.");
                    }
                    else
                    {
                        availableDates.Add(date);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please enter in DD/MM/YYYY format.");
                }
            }
            Console.WriteLine("Enter Avaliable slots which doctor can take (e.g. 09:00 AM). Type 'done' when finished.");
            List<string> availableSlots = new List<string>();
            while (true)
            {
                Console.Write("Available slot (or 'done'): ");
                string input = Console.ReadLine()?.Trim() ?? "";
                if (input.Equals("done", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                if (new SlotHelper().AvailableSlots.Contains(input))
                {
                    availableSlots.Add(input);
                }
                else
                {
                    Console.WriteLine("Invalid slot. Please choose from the available slots.");
                }
            }

            // DoctorId is assigned by the service (keeps ID management in one place)
            var doctor = new Doctor
            {
                FullName          = fullName,
                Specialisation    = spec,
                YearsOfExperience = years,
                ConsultationFee   = fee,
                IsActive          = true,
                AvailableDates      = availableDates,
                AvailableSlots      = availableSlots
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

            if (!InputValidator.TryReadName("Specialisation (e.g. Cardiology): ", out string query))
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
                Console.WriteLine($"       Fee            : Rs.{d.ConsultationFee}");

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
            Console.WriteLine($"{msg}");
            Console.ResetColor();
        }
    }
}