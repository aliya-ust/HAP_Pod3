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
            bool isActive;

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

                if (!string.IsNullOrWhiteSpace(input) && !input.Any(char.IsDigit))
                {
                    specialisation = input.Trim();
                    break;
                }

                Console.WriteLine("Specialisation cannot be empty and must not contain numbers");
            }

            return _doctorService.GetDoctorsBySpecialisation(specialisation);
        }

        public string UpdateDoctor()
        {
            try
            {
                
                int doctorId;

                Console.Write("Enter Doctor ID to update (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Update cancelled.";

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
                Console.WriteLine("\nPress ENTER to keep existing value.\n");

                Console.Write("Enter Full Name: ");
                input = Console.ReadLine();
                string fullName = string.IsNullOrWhiteSpace(input)
                    ? existingDoctor.FullName
                    : input.Trim();

                Console.Write("Enter Specialisation: ");
                input = Console.ReadLine();
                string specialisation = string.IsNullOrWhiteSpace(input)
                    ? existingDoctor.Specialisation
                    : input.Trim();

                int experience = existingDoctor.YearsOfExperience;
                while (true)
                {
                    Console.Write("Enter Years of Experience: ");
                    input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                        break;

                    if (int.TryParse(input, out int exp) && exp >= 0)
                    {
                        experience = exp;
                        break;
                    }

                    Console.WriteLine("Invalid experience value.");
                }

                decimal fee = existingDoctor.ConsultationFee;
                while (true)
                {
                    Console.Write("Enter Consultation Fee: ");
                    input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                        break;

                    if (decimal.TryParse(input, out decimal parsedFee) && parsedFee >= 0)
                    {
                        fee = parsedFee;
                        break;
                    }

                    Console.WriteLine("Invalid fee.");
                }

                bool isActive = existingDoctor.IsActive;
                while (true)
                {
                    Console.Write("Is Active? (Y/N): ");
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
                            Console.WriteLine("Invalid input. Enter Y or N.");
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

                return _doctorService.UpdateDoctor(updatedDoctor).ToString();
            } catch (DoctorNotFoundException ex)
            {
                return ex.Message;
            }
        }

        public string DeleteDoctor()
        {
            int doctorId;

            Console.Write("Enter Doctor ID to delete (or 'q' to quit): ");
            string? input = Console.ReadLine();

            if (input?.ToLower() == "q")
                return "Delete cancelled.";

            if (!int.TryParse(input, out doctorId) || doctorId <= 0)
                return "Invalid Doctor ID";

            var existingDoctor = _doctorService.GetDoctorById(doctorId);

            if (existingDoctor == null)
                return "Doctor not found";

            return _doctorService.DeleteDoctor(doctorId);
        }
    }
}