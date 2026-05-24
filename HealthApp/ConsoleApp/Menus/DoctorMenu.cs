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

       // =========================================================
        // ADD DOCTOR
        // =========================================================

        public void AddDoctor()
        {
            PrintHeader("Add New Doctor");

            // NAME
            if (!InputValidator.TryReadName(
                "Full Name              : ",
                out string fullName))
            {
                return;
            }

            // SPECIALISATION
            if (!InputValidator.TryReadName(
                "Specialisation         : ",
                out string spec))
            {
                return;
            }

            // EXPERIENCE
            if (!InputValidator.TryReadPositiveInt(
                "Years Of Experience    : ",
                out int years))
            {
                return;
            }

            // FEE
            if (!InputValidator.TryReadDecimal(
                "Consultation Fee       : ",
                out decimal fee))
            {
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Doctor available for next 30 days.");
            Console.WriteLine("Type 'done' when finished.\n");

            // =====================================================
            // LEAVE DATES
            // =====================================================

            List<DateTime> leaveDates = new();

            DateTime startDate = DateTime.Today;
            DateTime endDate = DateTime.Today.AddDays(30);

            while (true)
            {
                Console.Write("Enter Leave Date : ");

                string input =
                    Console.ReadLine()?.Trim() ?? "";

                InputValidator.CheckForExit(input);

                if (input.Equals("done",
                    StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                if (!DateTime.TryParseExact(
                    input,
                    "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime leaveDate))
                {
                    PrintError("Invalid format. Use dd/MM/yyyy");
                    continue;
                }

                if (leaveDate < startDate ||
                    leaveDate > endDate)
                {
                    PrintError("Only next 30 days allowed.");
                    continue;
                }

                if (leaveDates.Contains(leaveDate))
                {
                    PrintError("Already added.");
                    continue;
                }

                leaveDates.Add(leaveDate);

                Console.WriteLine(
                    $"Leave Added : {leaveDate:dd/MM/yyyy}");
            }

            // =====================================================
            // GENERATE AVAILABLE DATES
            // =====================================================

            List<DateTime> availableDates = new();

            for (DateTime d = startDate;
                 d <= endDate;
                 d = d.AddDays(1))
            {
                if (!leaveDates.Contains(d))
                {
                    availableDates.Add(d);
                }
            }

            // =====================================================
            // SLOT SELECTION
            // =====================================================

            SlotHelper slotHelper = new();

            List<string> allSlots =
                slotHelper.AvailableSlots;

            List<string> defaultSlots = new();

            while (true)
            {
                Console.WriteLine("\nAvailable Slots:");

                for (int i = 0; i < allSlots.Count; i++)
                {
                    Console.WriteLine(
                        $"{i + 1}. {allSlots[i]}");
                }

                if (!InputValidator.TryReadString(
                    "\nSelect Slots (1,2,3): ",
                    out string slotInput))
                {
                    return;
                }

                string[] choices = slotInput.Split(',');

                List<string> selectedSlots = new();

                bool valid = true;

                foreach (string choice in choices)
                {
                    if (!int.TryParse(
                        choice.Trim(),
                        out int index))
                    {
                        PrintError($"Invalid choice : {choice}");
                        valid = false;
                        break;
                    }

                    if (index < 1 || index > allSlots.Count)
                    {
                        PrintError("Invalid slot number.");
                        valid = false;
                        break;
                    }

                    string slot = allSlots[index - 1];

                    if (!selectedSlots.Contains(slot))
                    {
                        selectedSlots.Add(slot);
                    }
                }

                if (!valid || selectedSlots.Count == 0)
                {
                    continue;
                }

                defaultSlots = selectedSlots;
                break;
            }

            // =====================================================
            // CREATE SCHEDULE
            // =====================================================

            Dictionary<DateTime, List<string>>
                doctorSchedule = new();

            foreach (DateTime date in availableDates)
            {
                doctorSchedule[date] =
                    new List<string>(defaultSlots);
            }

            // =====================================================
            // MODIFY SPECIFIC DATES
            // =====================================================

            while (InputValidator.Confirm(
                "\nModify slots for specific date"))
            {
                if (!InputValidator.TryReadFutureDate(
                    "Enter Date (dd/MM/yyyy): ",
                    out DateTime modifyDate))
                {
                    return;
                }

                if (!doctorSchedule.ContainsKey(modifyDate))
                {
                    PrintError("Date unavailable.");
                    continue;
                }

                Console.WriteLine(
                    $"\nCurrent Slots : " +
                    $"{string.Join(", ",
                    doctorSchedule[modifyDate])}");

                for (int i = 0; i < allSlots.Count; i++)
                {
                    Console.WriteLine(
                        $"{i + 1}. {allSlots[i]}");
                }

                Console.WriteLine(
                    "\nType NONE for leave");

                if (!InputValidator.TryReadString(
                    "New Slots : ",
                    out string newInput))
                {
                    return;
                }

                if (newInput.Equals("none",
                    StringComparison.OrdinalIgnoreCase))
                {
                    doctorSchedule.Remove(modifyDate);

                    Console.WriteLine(
                        "Marked as leave.");

                    continue;
                }

                string[] choices = newInput.Split(',');

                List<string> updatedSlots = new();

                bool valid = true;

                foreach (string choice in choices)
                {
                    if (!int.TryParse(
                        choice.Trim(),
                        out int index))
                    {
                        valid = false;
                        break;
                    }

                    if (index < 1 || index > allSlots.Count)
                    {
                        valid = false;
                        break;
                    }

                    string slot = allSlots[index - 1];

                    if (!updatedSlots.Contains(slot))
                    {
                        updatedSlots.Add(slot);
                    }
                }

                if (!valid || updatedSlots.Count == 0)
                {
                    PrintError("Invalid slots.");
                    continue;
                }

                doctorSchedule[modifyDate] =
                    updatedSlots;

                Console.WriteLine(
                    "Schedule updated.");
            }

            // =====================================================
            // FINAL SCHEDULE
            // =====================================================

            Console.WriteLine(
                "\n========== FINAL SCHEDULE ==========");

            foreach (var entry in doctorSchedule)
            {
                Console.WriteLine(
                    $"{entry.Key:dd/MM/yyyy}" +
                    $" → {string.Join(", ", entry.Value)}");
            }

            // =====================================================
            // CREATE DOCTOR
            // =====================================================

            Doctor doctor = new()
            {
                Name = fullName,
                Specialisation = spec,
                YearsOfExperience = years,
                ConsultationFee = fee,
                IsActive = true,

                AvailableDates =
                    doctorSchedule.Keys.ToList(),

                AvailableSlots =
                    doctorSchedule
                    .SelectMany(x => x.Value)
                    .Distinct()
                    .ToList()
            };

            _doctorService.AddDoctor(doctor);

            Console.WriteLine();

            PrintSuccess(
                "Doctor Added Successfully!");

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
                    Console.WriteLine($"\n[{d.DoctorId}] {d.Name} - {d.Specialisation}");

                    // Fetch appointments for this doctor
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
            Console.WriteLine($"Name           : {doctor.Name}");
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
                Console.WriteLine($"Name           : {doctor.Name}");
                Console.WriteLine($"Specialisation : {doctor.Specialisation}");
                Console.WriteLine($"Experience     : {doctor.YearsOfExperience} years");
                Console.WriteLine($"Fee            : Rs.{doctor.ConsultationFee}");
                Console.WriteLine($"Active         : {(doctor.IsActive ? "Yes" : "No")}");
            }

            Console.WriteLine("------------------------------------");

            InputValidator.Pause();
        }

        // // MENU
        // public void ShowMenu()
        // {
        //     while (true)
        //     {
        //         Console.Clear();
        //         Console.WriteLine("=================================");
        //         Console.WriteLine("DOCTOR MENU");
        //         Console.WriteLine("=================================");
        //         Console.WriteLine("1. Add Doctor");
        //         Console.WriteLine("2. Search by Specialisation");
        //         Console.WriteLine("3. Get Doctor By ID");
        //         Console.WriteLine("4. View All Doctors");
        //         Console.WriteLine("5. Back");

        //         Console.Write("Enter choice: ");
        //         string choice = Console.ReadLine();

        //         switch (choice)
        //         {
        //             case "1": AddDoctor(); break;
        //             case "2": SearchBySpecialisation(); break;
        //             case "3": GetDoctorById(); break;
        //             case "4": ViewAllDoctors(); break;
        //             case "5": return;
        //             default:
        //                 Console.WriteLine("Invalid choice.");
        //                 InputValidator.Pause();
        //                 break;
        //         }
        //     }
        // }

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
        private void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nERROR : {message}");
            Console.ResetColor();
        }
    }
}
// using System;
// using System.Collections.Generic;
// using System.Xml.Linq;
// using HealthApp.ConsoleApp.Helpers;
// using HealthApp.ConsoleApp.Interfaces;
// using HealthApp.ConsoleApp.Models;

// namespace HealthApp.ConsoleApp.Menus
// {
//     public class DoctorMenu
//     {
//         private readonly IDoctorService _doctorService;

//         // DI Constructor
//         public DoctorMenu(IDoctorService doctorService)
//         {
//             _doctorService = doctorService;
//         }

//         // ── Option 2: Add a new doctor ────────────────────────────────────────────

//         public void AddDoctor()
//         {
//             PrintHeader("Add New Doctor");

//                 // ── Full Name ────────────────────────────────────────────────────────
//                 if (!InputValidator.TryReadName("Full name            : ", out string Name))
//                 {
//                     PrintError("Name can contain only letters.Try again");//InputValidator.Pause(); return;
//                 }

//                 // ── Specialisation ───────────────────────────────────────────────────
//                 if (!InputValidator.TryReadName("Specialisation       : ", out string spec))
//                 {
//                     InputValidator.Pause(); return;
//                 }

//                 // ── Years of Experience ──────────────────────────────────────────────
//                 if (!InputValidator.TryReadPositiveInt("Years of experience  : ", out int years))
//                 {
//                     InputValidator.Pause(); return;
//                 }

//                 // ── Consultation Fee ─────────────────────────────────────────────────
//                 if (!InputValidator.TryReadDecimal("Consultation fee (Rs.) : ", out decimal fee))
//                 {
//                     InputValidator.Pause(); return;
//                 }
//                 if (!InputValidator.TryReadFutureDate("Enter the future days when the doctor is available (e.g. 01/07/2024). Type 'done' when finished.", out DateTime availableDate))
//                 {
//                     InputValidator.Pause(); return;
//                 }


//             List<DateTime> availableDates = new List<DateTime>();
//             while (true)
//             {
//                 Console.Write("Available date (or 'done'): ");
//                 string input = Console.ReadLine()?.Trim() ?? "";
//                 if (input.Equals("done", StringComparison.OrdinalIgnoreCase))
//                 {
//                     break;
//                 }
//                 if (DateTime.TryParse(input, out DateTime date))
//                 {
//                     if (date.Date < DateTime.Today)
//                     {
//                         Console.WriteLine("Please enter a future date.");
//                     }
//                     else
//                     {
//                         availableDates.Add(date);
//                     }
//                 }
//                 else
//                 {
//                     Console.WriteLine("Invalid date format. Please enter in DD/MM/YYYY format.");
//                 }
//             }
//             Console.WriteLine("Enter Avaliable slots which doctor can take (e.g. 09:00 AM). Type 'done' when finished.");
//             List<string> availableSlots = new List<string>();
//             while (true)
//             {
//                 Console.Write("Available slot (or 'done'): ");
//                 string input = Console.ReadLine()?.Trim() ?? "";
//                 if (input.Equals("done", StringComparison.OrdinalIgnoreCase))
//                 {
//                     break;
//                 }
//                 if (new SlotHelper().AvailableSlots.Contains(input))
//                 {
//                     availableSlots.Add(input);
//                 }
//                 else
//                 {
//                     Console.WriteLine("Invalid slot. Please choose from the available slots.");
//                 }
//             }

//             // DoctorId is assigned by the service (keeps ID management in one place)
//             var doctor = new Doctor
//             {
//                 Name = Name,
//                 Specialisation = spec,
//                 YearsOfExperience = years,
//                 ConsultationFee = fee,
//                 IsActive = true,
//                 AvailableDates = availableDates,
//                 AvailableSlots = availableSlots
//             };

//             _doctorService.AddDoctor(doctor);

//             Console.WriteLine();
//             PrintSuccess("Doctor added successfully!");

//             // GetScheduleSummary() — spec method (shows appointment count = 0 for new doctor)
//             Console.WriteLine($"  {doctor.GetScheduleSummary}");

//             InputValidator.Pause();
//         }


//         //  Search by specialisation

//         public void SearchBySpecialisation()
//         {
//             PrintHeader("Search Doctors by Specialisation");

//             if (!InputValidator.TryReadName("Specialisation (e.g. Cardiology): ", out string query))
//             {
//                 InputValidator.Pause(); return;
//             }

//             List<Doctor> results = _doctorService.SearchBySpecialisation(query);

//             if (results.Count == 0)
//             {
//                 Console.WriteLine($"\n  No active doctors found for '{query}'.");
//                 InputValidator.Pause();
//                 return;
//             }

//             Console.WriteLine($"\n  {results.Count} doctor(s) found:\n");

//             foreach (Doctor d in results)
//             {
//                 Console.WriteLine($"  [{d.DoctorId}] Dr. {d.Name}");
//                 Console.WriteLine($"       Specialisation : {d.Specialisation}");
//                 Console.WriteLine($"       Experience     : {d.YearsOfExperience} years");
//                 Console.WriteLine($"       Fee            : Rs.{d.ConsultationFee}");

//                 // IsAvailable() — spec method
//                 bool available = d.IsAvailable(DateTime.Today);
//                 Console.ForegroundColor = available ? ConsoleColor.Green : ConsoleColor.Yellow;
//                 Console.WriteLine($"       Available Today : {(available ? "Yes" : "No")}");
//                 Console.ResetColor();

//                 // Console.WriteLine($"       {d.GetScheduleSummary}");
//                 Console.WriteLine();
//             }

//             InputValidator.Pause();
//         }

//         // ── Helper methods ────────────────────────────────────────────────────────

//         private static void PrintHeader(string title)
//         {
//             Console.WriteLine();
//             Console.WriteLine($"  ── {title} ──");
//             Console.WriteLine();
//         }
//          private void PrintError(string message)
//         {
//             Console.ForegroundColor = ConsoleColor.Red;
//             Console.WriteLine($"\nERROR : {message}");
//             Console.ResetColor();
//         }

//         private static void PrintSuccess(string msg)
//         {
//             Console.ForegroundColor = ConsoleColor.Green;
//             Console.WriteLine($"{msg}");
//             Console.ResetColor();
//         }
//     }
// }