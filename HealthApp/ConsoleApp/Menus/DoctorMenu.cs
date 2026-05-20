using System;
using System.Collections.Generic;
using System.Linq;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Services;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Databases;
using HealthApp.ConsoleApp.Exceptions;

namespace HealthApp
{
    public class DoctorMenu
    {
        private IDoctorService _doctorService;

        public DoctorMenu(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public string AddDoctor()
        {
            int doctorId;
            string fullName;
            string specialisation;
            int yearsOfExperience;
            decimal consultationFee;
            bool isActive;

            while (true)
            {
                Console.Write("Enter Doctor ID (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Doctor registration cancelled.";

                if (int.TryParse(input, out doctorId) && doctorId > 0)
                    break;

                Console.WriteLine("Invalid Doctor ID.");
            }

            while (true)
            {
                Console.Write("Enter Full Name (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Doctor registration cancelled.";

                if (!string.IsNullOrWhiteSpace(input))
                {
                    fullName = input.Trim();
                    break;
                }

                Console.WriteLine("Full Name cannot be empty.");
            }

            while (true)
            {
                Console.Write("Enter Specialisation (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Doctor registration cancelled.";

                if (!string.IsNullOrWhiteSpace(input))
                {
                    specialisation = input.Trim();
                    break;
                }

                Console.WriteLine("Specialisation cannot be empty.");
            }

            while (true)
            {
                Console.Write("Enter Years of Experience (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Doctor registration cancelled.";

                if (int.TryParse(input, out yearsOfExperience) && yearsOfExperience >= 0)
                    break;

                Console.WriteLine("Invalid years of experience.");
            }

            while (true)
            {
                Console.Write("Enter Consultation Fee (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Doctor registration cancelled.";

                if (decimal.TryParse(input, out consultationFee) && consultationFee >= 0)
                    break;

                Console.WriteLine("Invalid consultation fee.");
            }

            while (true)
            {
                Console.Write("Is the doctor active? (Y/N) (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Doctor registration cancelled.";

                if (input?.Trim().ToLower() == "y")
                {
                    isActive = true;
                    break;
                }
                else if (input?.Trim().ToLower() == "n")
                {
                    isActive = false;
                    break;
                }

                Console.WriteLine("Invalid input. Enter Y or N.");
            }

            var doctor = new Doctor
            {
                DoctorId = doctorId,
                FullName = fullName,
                Specialisation = specialisation,
                YearsOfExperience = yearsOfExperience,
                ConsultationFee = consultationFee,
                IsActive = isActive
            };

            return _doctorService.AddDoctor(doctor);
        }

        public List<Doctor> SearchDoctorBySpecialisation()
        {
            string specialisation;

            while (true)
            {
                Console.Write("Enter Specialisation to search (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    Console.WriteLine("Search cancelled.");

                if (!string.IsNullOrWhiteSpace(input))
                {
                    specialisation = input.Trim();
                    break;
                }

                Console.WriteLine("Specialisation cannot be empty.");
            }

            return _doctorService.GetDoctorsBySpecialisation(specialisation);
        }

    //     public void ShowMenu()
    //     {
    //         int choice;

    //         do
    //         {
    //             Console.WriteLine("\n===== DOCTOR MENU =====");
    //             Console.WriteLine("1. Add Doctor");
    //             Console.WriteLine("2. View All Doctors");
    //             Console.WriteLine("3. Search Doctor By Specialisation");
    //             Console.WriteLine("4. Exit");

    //             Console.Write("Enter choice: ");
    //             while (!int.TryParse(Console.ReadLine(), out choice))
    //             {
    //                 Console.Write("Invalid choice. Enter again: ");
    //             }

    //             switch (choice)
    //             {
    //                 case 1:
    //                     AddDoctor();
    //                     break;

    //                 case 2:
    //                     ViewDoctors();
    //                     break;

    //                 case 3:
    //                     SearchDoctorBySpecialisation();
    //                     break;

    //                 case 4:
    //                     Console.WriteLine("Exiting...");
    //                     break;

    //                 default:
    //                     Console.WriteLine("Invalid Choice");
    //                     break;
    //             }

    //         } while (choice != 4);
    //     }

    //     // ✅ UPDATED METHOD (Main Fix)
    //     private void AddDoctor()
    //     {
    //         Console.Write("Enter Doctor ID: ");
    //         int id = int.Parse(Console.ReadLine() ?? "0");

    //         try
    //         {
    //             // ✅ CHECK DUPLICATE ID FIRST
    //             List<Doctor> existingDoctors = doctorService.GetAllDoctors();

    //             foreach (var d in existingDoctors)
    //             {
    //                 if (d.DoctorId == id)
    //                 {
    //                     throw new DoctorAlreadyExistsException("Doctor ID already exists!");
    //                 }
    //             }

    //             // ✅ Only ask remaining inputs if ID is valid
    //             Console.Write("Enter Full Name: ");
    //             string name = Console.ReadLine() ?? "";

    //             Console.Write("Enter Specialisation: ");
    //             string specialisation = Console.ReadLine() ?? "";

    //             Console.Write("Enter Years Of Experience: ");
    //             int experience = int.Parse(Console.ReadLine() ?? "0");

    //             Console.Write("Enter Consultation Fee: ");
    //             decimal fee = decimal.Parse(Console.ReadLine() ?? "0");

    //             Console.Write("Is Active (true/false): ");
    //             bool isActive = bool.Parse(Console.ReadLine() ?? "true");

    //             Doctor doctor = new Doctor
    //             {
    //                 DoctorId = id,
    //                 FullName = name,
    //                 Specialisation = specialisation,
    //                 YearsOfExperience = experience,
    //                 ConsultationFee = fee,
    //                 IsActive = isActive
    //             };

    //             doctorService.AddDoctor(doctor);

    //             Console.WriteLine("Doctor Added Successfully");
    //         }
    //         catch (DoctorAlreadyExistsException ex)
    //         {
    //             Console.WriteLine(ex.Message);
    //         }
    //         catch (Exception ex)
    //         {
    //             Console.WriteLine("Unexpected error: " + ex.Message);
    //         }
    //     }

    //     private void ViewDoctors()
    //     {
    //         List<Doctor> doctors = doctorService.GetAllDoctors();

    //         if (doctors.Count == 0)
    //         {
    //             Console.WriteLine("No Doctors Found");
    //             return;
    //         }

    //         Console.WriteLine("\n=== Doctor List ===\n");

    //         foreach (Doctor doctor in doctors)
    //         {
    //             Console.WriteLine(doctor.GetDoctorDetails());

    //             // ✅ Print availability
    //             Console.WriteLine(doctor.IsAvailable(DateTime.Today));

    //             // ✅ ✅ IMPORTANT: STOP if inactive
    //             if (!doctor.IsActive)
    //             {
    //                 Console.WriteLine("-----------------------------------");
    //                 continue;  // 🔥 THIS LINE FIXES YOUR ISSUE
    //             }

    //             // ✅ Only active doctors reach here
    //             Console.WriteLine(doctor.GetScheduleSummary());

    //             var upcoming = doctor.GetUpcomingAppointments();

    //             if (upcoming.Count > 0)
    //             {
    //                 Console.WriteLine("Dates are:");

    //                 foreach (var date in upcoming)
    //                 {
    //                     Console.WriteLine(date.ToString("yyyy-MM-dd"));
    //                 }
    //             }

    //             Console.WriteLine("-----------------------------------");
    //         }
    //     }

    //     private void SearchDoctorBySpecialisation()
    //     {
    //         Console.Write("Enter Specialisation: ");
    //         string specialisation = Console.ReadLine() ?? "";

    //         try
    //         {
    //             List<Doctor> doctors =
    //                 doctorService.SearchBySpecialisation(specialisation);

    //             Console.WriteLine("\n=== Matching Doctors ===\n");

    //             foreach (var doctor in doctors)
    //             {
    //                 Console.WriteLine(doctor.GetDoctorDetails());
    //                 Console.WriteLine("Available Today: " + doctor.IsAvailable(DateTime.Today));
    //                 Console.WriteLine(doctor.GetScheduleSummary());
    //                 Console.WriteLine("-----------------------------------");
    //             }
    //         }
    //         catch (SpecialisationNotFoundException ex)
    //         {
    //             Console.WriteLine(ex.Message);
    //         }
    //         catch (Exception ex)
    //         {
    //             Console.WriteLine("Unexpected error: " + ex.Message);
    //         }
    //     }
    }
}