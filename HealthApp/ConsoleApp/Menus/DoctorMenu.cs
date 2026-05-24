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

namespace HealthApp
{
    public class DoctorMenu
    {
        private readonly IDoctorService _doctorService;
        public const string Continue = "\nPress any key to continue...";

        public DoctorMenu(IDoctorService doctorService)
        {
            _doctorService = doctorService;
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

                var doctor = new Doctor
                {
                    FullName = fullName!,
                    Specialisation = specialisation!,
                    YearsOfExperience = int.Parse(experienceInput!),
                    ConsultationFee = decimal.Parse(feeInput!),
                    IsActive = true
                };

                return _doctorService.AddDoctor(doctor);
            }
            catch (OperationCanceledException)
            {
                return "Operation Canceled";
            }
        }


        public List<Doctor> SearchDoctorBySpecialisation()
        {
            try
            {
                Console.Clear();

                var specialisation = InputValidator.GetValidatedInput(
                    "Enter Specialisation to search (or 'q' to quit): ",
                    InputValidator.IsValidName,
                    "Invalid specialisation.");

                return _doctorService.GetDoctorsBySpecialisation(specialisation!);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Search cancelled.");
                Console.Write(Continue);
                Console.ReadKey();
                return [];
            }
            catch (SpecialisationNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Write(Continue);
                Console.ReadKey();
                return [];
            }
        }

        public string UpdateDoctor()
        {
            try
            {
                Console.Clear();

                Console.Write("Enter Doctor ID (or 'q' to quit): ");
                var input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Update cancelled.";

                if (!int.TryParse(input, out int doctorId) || doctorId <= 0)
                    return "Invalid Doctor ID";

                var existingDoctor = _doctorService.GetDoctorById(doctorId);
                if (existingDoctor == null)
                    return "Doctor not found";

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

                var updatedDoctor = new Doctor
                {
                    DoctorId = existingDoctor.DoctorId,
                    FullName = fullNameInput ?? existingDoctor.FullName,
                    Specialisation = specInput ?? existingDoctor.Specialisation,
                    YearsOfExperience = expInput != null ? int.Parse(expInput) : existingDoctor.YearsOfExperience,
                    ConsultationFee = feeInput != null ? decimal.Parse(feeInput) : existingDoctor.ConsultationFee,
                    IsActive = existingDoctor.IsActive
                };

                Console.Clear();
                return _doctorService.UpdateDoctor(updatedDoctor).ToString();
            }
            catch (OperationCanceledException)
            {
                return "Update cancelled.";
            }
            catch (DoctorNotFoundException ex)
            {
                return ex.Message;
            }
        }
    }
}