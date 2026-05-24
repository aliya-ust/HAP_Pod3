using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Helpers;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthApp.ConsoleApp.Menus
{
    public class DoctorMenu
    {
        private readonly IDoctorService _doctorService;
        private readonly IAppointmentService _appointmentService;

        public DoctorMenu(IDoctorService doctorService, IAppointmentService appointmentService)
        {
            _doctorService = doctorService;
            _appointmentService = appointmentService;
        }

        // ADD DOCTOR
        public void AddDoctor()
        {
            PrintHeader("Add New Doctor");

            //FULL NAME
            string fullName;
            while (!InputValidator.TryReadName("Full name            : ", out fullName)) { }

            //SPECIALISATION
            string spec;
            while (!InputValidator.TryReadName("Specialisation       : ", out spec)) { }

            //EXPERIENCE
            int years;
            while (!InputValidator.TryReadPositiveInt("Years of experience  : ", out years))
            {
                Console.WriteLine("Invalid number.");
            }

            //FEE
            decimal fee;
            while (!InputValidator.TryReadDecimal("Consultation fee (Rs.) : ", out fee))
            {
                Console.WriteLine("Invalid fee.");
            }

            //LEAVE INPUT
            Console.WriteLine("\nDoctor is available EVERYDAY for next 30 days.");
            Console.WriteLine("Enter leave dates (dd/MM/yyyy). Type 'done'");

            List<DateTime> leaveDates = new();
            DateTime startDate = DateTime.Today;
            DateTime endDate = DateTime.Today.AddDays(30);

            while (true)
            {
                Console.Write("\nEnter leave date (or 'done'): ");
                string input = Console.ReadLine()?.Trim() ?? "";

                if (input.Equals("done", StringComparison.OrdinalIgnoreCase))
                    break;

                if (!DateTime.TryParseExact(input, "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime date))
                {
                    Console.WriteLine("Invalid format.");
                    continue;
                }

                if (date < startDate || date > endDate)
                {
                    Console.WriteLine("Only next 30 days allowed.");
                    continue;
                }

                if (leaveDates.Contains(date))
                {
                    Console.WriteLine("Already added.");
                    continue;
                }

                leaveDates.Add(date);
                Console.WriteLine($"✅ Leave added: {date:dd/MM/yyyy}");
            }

            //GENERATE AVAILABLE DATES
            List<DateTime> availableDates = new();
            for (DateTime d = startDate; d <= endDate; d = d.AddDays(1))
            {
                if (!leaveDates.Contains(d))
                    availableDates.Add(d);
            }

            //SLOT SELECTION (VALIDATION FIXED)
            var allSlots = new SlotHelper().AvailableSlots;
            List<string> defaultSlots = new();

            while (true)
            {
                Console.WriteLine("\nAvailable Slots:");

                for (int i = 0; i < allSlots.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {allSlots[i]}");
                }

                Console.Write("Select slots (example: 1,3,5): ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("❌ Select at least one slot.");
                    continue;
                }

                string[] choices = input.Split(',');
                List<string> tempSlots = new();
                bool isValid = true;

                foreach (var c in choices)
                {
                    if (!int.TryParse(c.Trim(), out int index))
                    {
                        Console.WriteLine($"❌ Invalid input: {c}");
                        isValid = false;
                        break;
                    }

                    if (index < 1 || index > allSlots.Count)
                    {
                        Console.WriteLine($"❌ Only {allSlots.Count} slots available.");
                        isValid = false;
                        break;
                    }

                    string slot = allSlots[index - 1];

                    if (!tempSlots.Contains(slot))
                        tempSlots.Add(slot);
                }

                if (!isValid)
                    continue;

                defaultSlots = tempSlots;
                break;
            }

            //APPLY DEFAULT SLOTS
            Dictionary<DateTime, List<string>> doctorSchedule = new();

            foreach (var date in availableDates)
            {
                doctorSchedule[date] = new List<string>(defaultSlots);
            }

            //MODIFY FEATURE (FIXED)
            string modifyChoice;

            while (true)
            {
                Console.Write("\nModify slots for specific date? (Y/N): ");
                modifyChoice = Console.ReadLine()?.Trim().ToUpper();

                if (modifyChoice == "Y" || modifyChoice == "N")
                    break;

                Console.WriteLine("❌ Enter Y or N.");
            }

            while (modifyChoice == "Y")
            {
                Console.Write("\nEnter date to modify (dd/MM/yyyy): ");
                string input = Console.ReadLine();

                if (!DateTime.TryParseExact(input, "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime modifyDate))
                {
                    Console.WriteLine("Invalid date.");
                    continue;
                }

                if (!doctorSchedule.ContainsKey(modifyDate))
                {
                    Console.WriteLine("Date not available.");
                    continue;
                }

                Console.WriteLine($"\nCurrent slots: {string.Join(", ", doctorSchedule[modifyDate])}");

                Console.WriteLine("\nAvailable Slots:");
                for (int i = 0; i < allSlots.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {allSlots[i]}");
                }

                Console.Write("Enter new slots (or 'none' to mark leave): ");
                string slotInput = Console.ReadLine();

                if (slotInput.ToLower() == "none")
                {
                    doctorSchedule.Remove(modifyDate);
                    Console.WriteLine("✅ Marked as leave.");
                }
                else
                {
                    string[] choices = slotInput.Split(',');
                    List<string> updatedSlots = new();
                    bool isValid = true;

                    foreach (var c in choices)
                    {
                        if (!int.TryParse(c.Trim(), out int index) ||
                            index < 1 || index > allSlots.Count)
                        {
                            Console.WriteLine($"❌ Invalid choice: {c}");
                            isValid = false;
                            break;
                        }

                        string slot = allSlots[index - 1];

                        if (!updatedSlots.Contains(slot))
                            updatedSlots.Add(slot);
                    }

                    if (!isValid || updatedSlots.Count == 0)
                    {
                        Console.WriteLine("❌ Try again.");
                        continue;
                    }

                    doctorSchedule[modifyDate] = updatedSlots;
                    Console.WriteLine($"✅ Updated: {string.Join(", ", updatedSlots)}");
                }

                Console.Write("Modify another date? (Y/N): ");
                modifyChoice = Console.ReadLine()?.Trim().ToUpper();
            }

            //FINAL SCHEDULE PRINT
            Console.WriteLine("\n========== FINAL DOCTOR SCHEDULE ==========");

            foreach (var entry in doctorSchedule)
            {
                Console.WriteLine($"{entry.Key:dd/MM/yyyy} → {string.Join(", ", entry.Value)}");
            }

            Console.WriteLine("===========================================");

            //CREATE DOCTOR
            var doctor = new Doctor
            {
                FullName = fullName,
                Specialisation = spec,
                YearsOfExperience = years,
                ConsultationFee = fee,
                IsActive = true,
                AvailableDates = doctorSchedule.Keys.ToList(),
                AvailableSlots = doctorSchedule
                    .SelectMany(d => d.Value)
                    .Distinct()
                    .ToList()
            };

            _doctorService.AddDoctor(doctor);

            Console.WriteLine();
            PrintSuccess("Doctor added successfully!");

            InputValidator.Pause();
        }


        //SEARCH
        public void SearchBySpecialisation()
        {
            PrintHeader("Search Doctors by Specialisation");

            if (!InputValidator.TryReadName("Specialisation: ", out string query))
            {
                InputValidator.Pause();
                return;
            }

            try
            {

                var results = _doctorService.SearchBySpecialisation(query);

                foreach (var d in results)
                {
                    Console.WriteLine($"\n[{d.DoctorId}] {d.FullName} - {d.Specialisation}");

                    // ✅ Fetch appointments for this doctor
                    var appointments = _appointmentService.GetAppointmentsByDoctor(d.DoctorId);

                    if (appointments.Count == 0)
                    {
                        Console.WriteLine("No available slots.");
                        continue;
                    }

                    Console.WriteLine("Available Slots:");

                    foreach (var appt in appointments)
                    {
                        Console.WriteLine($"Date: {appt.ScheduledDate:dd-MM-yyyy} | Time: {appt.TimeSlot}");
                    }
                }
            }
            catch (SpecialisationNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            InputValidator.Pause();
        }

        // GET BY ID
        public void GetDoctorById()
        {
            Console.WriteLine("----- Get Doctor By ID -----");

            if (!InputValidator.TryReadPositiveInt("Enter Doctor ID: ", out int doctorId))
            {
                Console.WriteLine("Invalid input.");
                InputValidator.Pause();
                return;
            }

            Doctor doctor = _doctorService.GetByDoctorId(doctorId);

            if (doctor == null)
            {
                Console.WriteLine("Doctor not found.");
                InputValidator.Pause();
                return;
            }

            Console.WriteLine("\nDoctor Details:");
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"ID             : {doctor.DoctorId}");
            Console.WriteLine($"Name           : {doctor.FullName}");
            Console.WriteLine($"Specialisation : {doctor.Specialisation}");
            Console.WriteLine($"Experience     : {doctor.YearsOfExperience} years");
            Console.WriteLine($"Consultation   : Rs.{doctor.ConsultationFee}");
            Console.WriteLine($"Active         : {(doctor.IsActive ? "Yes" : "No")}");
            Console.WriteLine("--------------------------------");

            InputValidator.Pause();
        }
        public void ViewAllDoctors()
        {
            Console.WriteLine("----- ALL DOCTORS -----\n");

            var doctors = _doctorService.GetAllDoctors();

            if (doctors == null || doctors.Count == 0)
            {
                Console.WriteLine("No doctors available.");
                InputValidator.Pause();
                return;
            }

            foreach (var doctor in doctors)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine($"ID             : {doctor.DoctorId}");
                Console.WriteLine($"Name           : {doctor.FullName}");
                Console.WriteLine($"Specialisation : {doctor.Specialisation}");
                Console.WriteLine($"Experience     : {doctor.YearsOfExperience} years");
                Console.WriteLine($"Fee            : Rs.{doctor.ConsultationFee}");
                Console.WriteLine($"Active         : {(doctor.IsActive ? "Yes" : "No")}");
            }

            Console.WriteLine("------------------------------------");

            InputValidator.Pause();
        }

        // MENU
        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("DOCTOR MENU");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. Search by Specialisation");
                Console.WriteLine("3. Get Doctor By ID");
                Console.WriteLine("4. View All Doctors");
                Console.WriteLine("5. Back");

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddDoctor(); break;
                    case "2": SearchBySpecialisation(); break;
                    case "3": GetDoctorById(); break;
                    case "4": ViewAllDoctors(); break;
                    case "5": return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        InputValidator.Pause();
                        break;
                }
            }
        }

        private static void PrintHeader(string title)
        {
            Console.WriteLine($"\n--- {title} ---\n");
        }

        private static void PrintSuccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}