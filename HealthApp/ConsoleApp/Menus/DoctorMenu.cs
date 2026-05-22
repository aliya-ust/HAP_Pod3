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
            string fullName;
            string specialisation;
            int yearsOfExperience;
            decimal consultationFee;

            Console.Clear();
            while (true)
            {
                Console.Write("Enter Full Name (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                {
                    Console.WriteLine("Doctor registration cancelled.");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    return "";            
                }

                if (!string.IsNullOrWhiteSpace(input) && !input.Any(char.IsDigit))
                {
                    fullName = input.Trim();
                    break;
                }

                Console.WriteLine("Full Name cannot be empty and must not contain numbers.\n");
            }

            while (true)
            {
                Console.Write("Enter Specialisation (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                {
                    Console.WriteLine("Doctor registration cancelled.");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    return "";            
                }

                if (!string.IsNullOrWhiteSpace(input) && !input.Any(char.IsDigit))
                {
                    specialisation = input.Trim();
                    break;
                }

                Console.WriteLine("Specialisation cannot be empty and must not contain numbers.\n");
            }

            while (true)
            {
                Console.Write("Enter Years of Experience (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                {
                    Console.WriteLine("Doctor registration cancelled.");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    return "";            
                }

                if (int.TryParse(input, out yearsOfExperience) && yearsOfExperience >= 0)
                    break;

                Console.WriteLine("Invalid years of experience.\n");
            }

            while (true)
            {
                Console.Write("Enter Consultation Fee (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                {
                    Console.WriteLine("Doctor registration cancelled.");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    return "";            
                }

                if (decimal.TryParse(input, out consultationFee) && consultationFee >= 0)
                    break;

                Console.WriteLine("Invalid consultation fee.\n");
            }

            var doctor = new Doctor
            {
                FullName = fullName,
                Specialisation = specialisation,
                YearsOfExperience = yearsOfExperience,
                ConsultationFee = consultationFee,
                IsActive = true
            };

            return _doctorService.AddDoctor(doctor);
        }

        public List<Doctor> SearchDoctorBySpecialisation()
        {
            try
            {
                string? specialisation;

                Console.Clear();
                while (true)
                {
                    Console.Write("Enter Specialisation to search (or 'q' to quit): ");
                    string? input = Console.ReadLine();

                    if (input?.ToLower() == "q")
                    {
                        Console.WriteLine("Search cancelled.");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        return [];            
                    }

                    if (!string.IsNullOrWhiteSpace(input) && !input.Any(char.IsDigit))
                    {
                        specialisation = input.Trim();
                        break;
                    }

                    Console.WriteLine("Specialisation cannot be empty and must not contain numbers\n");
                }

                return _doctorService.GetDoctorsBySpecialisation(specialisation);
            } catch (SpecialisationNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Write("\nPress any key to continue...");
                Console.ReadKey();
                return [];
            }
        }

        public string UpdateDoctor()
        {
            try
            {
                int doctorId;
                Console.Clear();

                Console.Write("Enter Doctor ID to update (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                {
                        Console.WriteLine("Update cancelled.");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        return "";            
                }

                if (!int.TryParse(input, out doctorId) || doctorId <= 0)
                    return "Invalid Doctor ID";

                var existingDoctor = _doctorService.GetDoctorById(doctorId);

                if (existingDoctor == null)
                    return "Doctor not found";

                Console.WriteLine("\nCurrent Doctor Details:");
                Console.WriteLine($"Name: {existingDoctor.FullName}");
                Console.WriteLine($"Specialisation: {existingDoctor.Specialisation}");
                Console.WriteLine($"Experience: {existingDoctor.YearsOfExperience} years");
                Console.WriteLine($"Consultation Fee: {existingDoctor.ConsultationFee}");
                Console.WriteLine($"Active: {(existingDoctor.IsActive ? "Yes" : "No")}");

                string fullName = existingDoctor.FullName;
                while (true)
                {
                    Console.Write("Enter Full Name (Press ENTER to keep existing value): ");
                    input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                        break;

                    if (!input.Any(char.IsDigit))
                    {
                        fullName = input.Trim();
                        break;
                    }

                    Console.WriteLine("Full Name must not contain numbers.\n");
                }

                string specialisation = existingDoctor.Specialisation;
                while (true)
                {
                    Console.Write("Enter Specialisation (Press ENTER to keep existing value): ");
                    input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                        break;

                    if (!input.Any(char.IsDigit))
                    {
                        specialisation = input.Trim();
                        break;
                    }

                    Console.WriteLine("Specialisation must not contain numbers.\n");
                }

                int experience = existingDoctor.YearsOfExperience;
                while (true)
                {
                    Console.Write("Enter Years of Experience (Press ENTER to keep existing value): ");
                    input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                        break;

                    if (int.TryParse(input, out int exp) && exp >= 0)
                    {
                        experience = exp;
                        break;
                    }

                    Console.WriteLine("Invalid experience value.\n");
                }

                decimal fee = existingDoctor.ConsultationFee;
                while (true)
                {
                    Console.Write("Enter Consultation Fee (Press ENTER to keep existing value): ");
                    input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                        break;

                    if (decimal.TryParse(input, out decimal parsedFee) && parsedFee >= 0)
                    {
                        fee = parsedFee;
                        break;
                    }

                    Console.WriteLine("Invalid fee.\n");
                }

                bool isActive = existingDoctor.IsActive;
                while (true)
                {
                    Console.Write("Is Active? (Y/N) (Press ENTER to keep existing value): ");
                    input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                        break;

                    switch (input.Trim().ToLower())
                    {
                        case "y":
                            isActive = true;
                            break;
                        case "n":
                            isActive = false;
                            break;
                        default:
                            Console.WriteLine("Invalid input. Enter Y or N.\n");
                            continue;
                    }
                    break;
                }

                var updatedDoctor = new Doctor
                {
                    DoctorId = existingDoctor.DoctorId,
                    FullName = fullName,
                    Specialisation = specialisation,
                    YearsOfExperience = experience,
                    ConsultationFee = fee,
                    IsActive = isActive,
                    Appointments = existingDoctor.Appointments
                };

                Console.Clear();
                return _doctorService.UpdateDoctor(updatedDoctor).ToString();
            } catch (DoctorNotFoundException ex)
            {
                return ex.Message;
            }
        }
    }
}