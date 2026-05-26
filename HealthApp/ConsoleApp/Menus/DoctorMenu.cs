using System;
using System.Collections.Generic;
using System.Linq;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Services;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Databases;
using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Helpers;
using System.Globalization;

namespace HealthApp
{
    public class DoctorMenu
    {
        private readonly IDoctorService _doctorService;
        private readonly IAppointmentService _appointmentService;
        public const string Continue = "\nPress any key to continue...";

        public DoctorMenu(IDoctorService doctorService, 
                        IAppointmentService appointmentService)
        {
            _doctorService = doctorService;
            _appointmentService = appointmentService;
        }

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
                string ?choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddDoctor(); break;
                    case "2": SearchDoctorBySpecialisation(); break;
                    case "3": GetDoctorById(); break;
                    case "4": ViewAllDoctors(); break;
                    case "5": return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        public string AddDoctor()
        {
            try
            {
                Console.Clear();

                var fullName = InputValidator.GetValidatedInput(
                    "Enter Full Name (or 'q' to quit): ",
                    InputValidator.IsValidName,
                    "Full Name must not contain numbers.");

                var specialisation = InputValidator.GetValidatedInput(
                    "Enter Specialisation (or 'q' to quit): ",
                    InputValidator.IsValidName,
                    "Specialisation must not contain numbers.");

                var experienceInput = InputValidator.GetValidatedInput(
                    "Enter Years of Experience: ",
                    InputValidator.IsValidExperience,
                    "Invalid experience.");

                var feeInput = InputValidator.GetValidatedInput(
                    "Enter Consultation Fee: ",
                    InputValidator.IsValidFee,
                    "Invalid consultation fee.");

                int years = int.Parse(experienceInput!);
                decimal fee = decimal.Parse(feeInput!);

                List<DateTime> leaveDates = new();

                DateTime startDate = DateTime.Today;
                DateTime endDate = DateTime.Today.AddDays(30);

                Console.WriteLine("\nDoctor is available for the next 30 days.");
                Console.WriteLine("Enter leave dates (dd/MM/yyyy). Type 'done' when finished.\n");

                while (true)
                {
                    Console.Write("Enter Leave Date (or 'done'): ");
                    string input = Console.ReadLine()?.Trim().ToLower() ?? "";

                    if (input == "q" || input == "back")
                        throw new OperationCanceledException();

                    if (input == "done")
                        break;

                    if (!DateTime.TryParseExact(
                            input,
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out DateTime leaveDate))
                    {
                        Console.WriteLine("Invalid date format.");
                        continue;
                    }

                    if (leaveDate < startDate || leaveDate > endDate)
                    {
                        Console.WriteLine("Only dates within next 30 days allowed.");
                        continue;
                    }

                    if (leaveDates.Contains(leaveDate))
                    {
                        Console.WriteLine("Date already added.");
                        continue;
                    }

                    leaveDates.Add(leaveDate);
                    Console.WriteLine($"Leave added: {leaveDate:dd/MM/yyyy}");
                }

                List<DateTime> availableDates = new();

                for (DateTime d = startDate; d <= endDate; d = d.AddDays(1))
                {
                    if (!leaveDates.Contains(d))
                        availableDates.Add(d);
                }

                Console.WriteLine("\nAvailable Slots:");
                SlotHelper.PrintSlots();

                List<string>? selectedSlots;

                while (true)
                {
                    Console.Write("Select slots (e.g. 1,2,3): ");
                    string? input = Console.ReadLine();

                    selectedSlots = SlotHelper.SimpleParseSlots(input ?? "");

                    if (selectedSlots != null && selectedSlots.Count > 0)
                        break;

                    Console.WriteLine("Invalid slot selection. Try again.\n");
                }

                var doctor = new Doctor
                {
                    FullName = fullName!,
                    Specialisation = specialisation!,
                    YearsOfExperience = years,
                    ConsultationFee = fee,
                    IsActive = true,

                    AvailableDates = availableDates,
                    AvailableSlots = selectedSlots
                };

                return _doctorService.AddDoctor(doctor);
            }
            catch (OperationCanceledException)
            {
                return "Operation Canceled";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public void SearchDoctorBySpecialisation()
        {
            try
            {
                Console.Clear();

                var specialisation = InputValidator.GetValidatedInput(
                    "Enter Specialisation to search (or 'q' to quit): ",
                    InputValidator.IsValidName,
                    "Invalid specialisation.");

                var results = _doctorService.GetDoctorsBySpecialisation(specialisation!);

                Console.WriteLine($"\n{results.Count} doctor(s) found:\n");

                foreach (var d in results)
                {
                    PrintDoctorDetails(d);
                }

                Console.WriteLine(Continue);
                Console.ReadKey();
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Search cancelled.");
                Console.Write(Continue);
                Console.ReadKey();
                return;
            }
            catch (SpecialisationNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Write(Continue);
                Console.ReadKey();
                return;
            }
        }

        public void UpdateDoctor()
        {
            try
            {
                Console.Clear();

                Console.Write("Enter Doctor ID (or 'q' to quit): ");
                var input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return;

                if (!int.TryParse(input, out int doctorId) || doctorId <= 0)
                    return;

                var existingDoctor = _doctorService.GetDoctorById(doctorId);
                if (existingDoctor == null)
                    return;

                Console.WriteLine("\nCurrent Doctor Details:");
                Console.WriteLine(existingDoctor);

                var fullNameInput = InputValidator.GetValidatedInput(
                    "Enter Full Name (Press ENTER to keep existing): ",
                    InputValidator.IsValidName,
                    "Invalid name.",
                    allowEmpty: true);

                var specInput = InputValidator.GetValidatedInput(
                    "Enter Specialisation (Press ENTER to keep existing): ",
                    InputValidator.IsValidName,
                    "Invalid specialisation.",
                    allowEmpty: true);

                var expInput = InputValidator.GetValidatedInput(
                    "Enter Experience (Press ENTER to keep existing): ",
                    InputValidator.IsValidExperience,
                    "Invalid experience.",
                    allowEmpty: true);

                var feeInput = InputValidator.GetValidatedInput(
                    "Enter Fee (Press ENTER to keep existing): ",
                    InputValidator.IsValidFee,
                    "Invalid fee.",
                    allowEmpty: true);

                var isActiveInput = InputValidator.GetOptionalBool(
                    "Is Active? (Y/N) (Press ENTER to keep existing): ");

                var updatedDoctor = new Doctor
                {
                    DoctorId = existingDoctor.DoctorId,
                    FullName = fullNameInput ?? existingDoctor.FullName,
                    Specialisation = specInput ?? existingDoctor.Specialisation,
                    YearsOfExperience = expInput != null ? int.Parse(expInput) : existingDoctor.YearsOfExperience,
                    ConsultationFee = feeInput != null ? decimal.Parse(feeInput) : existingDoctor.ConsultationFee,
                    IsActive = isActiveInput ?? existingDoctor.IsActive,
                };

                Console.Clear();
                Console.WriteLine(_doctorService.UpdateDoctor(updatedDoctor).ToString());
            }
            catch (OperationCanceledException)
            {
                return;
            }
            catch (DoctorNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Doctor? GetDoctorById()
        {
            try
            {
                Console.Clear();

                var input = InputValidator.GetValidatedInput(
                    "Enter Doctor ID (or 'q' to quit): ",
                    InputValidator.IsValidId,
                    "Invalid Doctor ID.");

                int doctorId = int.Parse(input!);

                var doctor = _doctorService.GetDoctorById(doctorId);

                Console.Clear();

                Console.WriteLine("\nDoctor Details:\n");

                PrintDoctorDetails(doctor);

                Console.WriteLine("\n" + Continue);
                Console.ReadKey();

                return doctor;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\nOperation cancelled.");
                Console.WriteLine(Continue);
                Console.ReadKey();
                return null;
            }
            catch (DoctorNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(Continue);
                Console.ReadKey();
                return null;
            }
        }

        public void ViewAllDoctors()
        {
            try
            {
                Console.Clear();

                var doctors = _doctorService.GetAllDoctors();

                Console.WriteLine($"\n{doctors.Count} doctor(s) found:\n");

                foreach (var d in doctors)
                {
                    PrintDoctorDetails(d);
                }

                Console.WriteLine(Continue);
                Console.ReadKey();
            }
            catch (DoctorNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine(Continue);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine(Continue);
                Console.ReadKey();
            }
        }

        private void PrintDoctorDetails(Doctor doctor)
        {
            Console.WriteLine(doctor);
            Console.WriteLine($"Status: {(doctor.IsActive ? "Active" : "Inactive")}");

            Console.WriteLine(doctor.AvailableSlots?.Count > 0
                ? $"Slots: {string.Join(", ", doctor.AvailableSlots)}"
                : "Slots: None configured");

            bool availableToday = doctor.IsAvailable(DateTime.Today);

            try
            {
                var appts = _appointmentService.GetAppointmentsByDoctorId(doctor.DoctorId);
                Console.WriteLine($"{doctor.GetScheduleSummary(appts)}");
            }
            catch (AppointmentNotFoundException) {}

            Console.ForegroundColor = availableToday ? ConsoleColor.Green : ConsoleColor.Yellow;
            Console.WriteLine($"Available Today: {(availableToday ? "Yes" : "No")}");
            Console.ResetColor();

            Console.WriteLine(new string('-', 50));
        }
    }
}