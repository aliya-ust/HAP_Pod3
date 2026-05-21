using System;
using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Menus
{
    public class PatientMenu
    {
        private readonly IPatientService _patientService;

        public PatientMenu(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public string RegisterPatient()
        {
            string fullName;
            DateTime dob;
            GenderType gender;
            string phone;
            string email;
            int insuranceId;

            while (true)
            {
                Console.Write("Enter Full Name (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Patient registration cancelled.";

                if (!string.IsNullOrWhiteSpace(input))
                {
                    fullName = input.Trim();
                    break;
                }

                Console.WriteLine("Full Name cannot be empty.");
            }

            while (true)
            {
                Console.Write("Enter Date of Birth (dd-mm-yyyy) (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Patient registration cancelled.";

                if (DateTime.TryParse(input, out dob) && dob < DateTime.Today)
                    break;

                Console.WriteLine("Invalid Date of Birth.");
            }

            while (true)
            {
                Console.Write("Enter Gender (M/F/Other) (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Patient registration cancelled.";
                
                if (Enum.TryParse<GenderType>(input, true, out var parsedGender))
                    {
                        gender = parsedGender;
                        break;
                    }

                Console.WriteLine("Invalid gender");
            }

            while (true)
            {
                Console.Write("Enter Phone Number (or 'q' to quit): ");
                string? input = Console.ReadLine()?.Trim();

                if (input?.ToLower() == "q")
                    return "Patient registration cancelled.";

                if (!string.IsNullOrWhiteSpace(input) &&
                    input.Length == 10 &&
                    input.All(char.IsDigit))
                {
                    phone = input;
                    break;
                }

                Console.WriteLine("Phone must be exactly 10 digits.");
            }

            while (true)
            {
                Console.Write("Enter Email (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Patient registration cancelled.";

                if (!string.IsNullOrWhiteSpace(input) && input.Contains('@'))
                {
                    email = input.Trim();
                    break;
                }

                Console.WriteLine("Invalid email.");
            }

            while (true)
            {
                Console.Write("Enter Insurance ID (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Patient registration cancelled.";

                if (int.TryParse(input, out insuranceId) && insuranceId >= 0)
                    break;

                Console.WriteLine("Invalid Insurance ID.");
            }

            var patient = new Patient
            {
                FullName = fullName,
                DateOfBirth = dob,
                Gender = gender,
                PhoneNumber = phone,
                Email = email,
                InsuranceId = insuranceId
            };

            return _patientService.RegisterPatient(patient);
        }

        public string UpdatePatient()
        {
            int patientId;

            Console.Write("Enter ID of patient you wish to update (or 'q' to quit): ");
            string? input = Console.ReadLine();

            if (input?.ToLower() == "q")
                return "Update cancelled.";

            if (!int.TryParse(input, out patientId) || patientId <= 0)
                return "Invalid Patient ID";

            var existingPatient = _patientService.GetPatientById(patientId);
            if (existingPatient == null)
                return "Patient not found";
                
            Console.WriteLine("\nCurrent Patient Details:");
            Console.WriteLine($"Name: {existingPatient.FullName}");
            Console.WriteLine($"DOB: {existingPatient.DateOfBirth:dd-MM-yyyy}");
            Console.WriteLine($"Gender: {existingPatient.Gender}");
            Console.WriteLine($"Phone: {existingPatient.PhoneNumber}");
            Console.WriteLine($"Email: {existingPatient.Email}");
            Console.WriteLine($"Insurance ID: {existingPatient.InsuranceId}");
            Console.WriteLine("\nPress ENTER to keep existing value.\n");
            Console.Write("Enter Full Name: ");
            input = Console.ReadLine();

            string fullName = string.IsNullOrWhiteSpace(input) 
                ? existingPatient.FullName 
                : input.Trim();

            DateTime dob = existingPatient.DateOfBirth;
            while (true)
            {
                Console.Write("Enter Date of Birth (dd-mm-yyyy): ");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    break;
                if (DateTime.TryParse(input, out DateTime parsedDob) && parsedDob < DateTime.Today)
                {
                    dob = parsedDob;
                    break;
                }
                Console.WriteLine("Invalid Date of Birth.");
            }

            GenderType gender = existingPatient.Gender;
            while (true)
            {
                Console.Write("Enter Gender (M/F/Other): ");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    break;
                if (Enum.TryParse<GenderType>(input, true, out var parsedGender))
                {
                    gender = parsedGender;
                    break;
                }
                Console.WriteLine("Invalid input");
            }

            string phone = existingPatient.PhoneNumber;
            while (true)
            {
                Console.Write("Enter Phone Number: ");
                input = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(input))
                    break;
                if (input.Length == 10 && input.All(char.IsDigit))
                {
                    phone = input;
                    break;
                }
                Console.WriteLine("Phone must be exactly 10 digits and contain only numbers.");
            }

            string email = existingPatient.Email;
            while (true)
            {
                Console.Write("Enter Email: ");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    break;
                if (input.Contains('@'))
                {
                    email = input.Trim();
                    break;
                }
                Console.WriteLine("Invalid email.");
            }

            int insuranceId = existingPatient.InsuranceId;
            while (true)
            {
                Console.Write("Enter Insurance ID: ");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    break;
                if (int.TryParse(input, out int parsedId) && parsedId >= 0)
                {
                    insuranceId = parsedId;
                    break;
                }
                Console.WriteLine("Invalid Insurance ID.");
            }

            var updatedPatient = new Patient
            {
                PatientId = existingPatient.PatientId,
                FullName = fullName,
                DateOfBirth = dob,
                Gender = gender,
                PhoneNumber = phone,
                Email = email,
                InsuranceId = insuranceId
            };

            return _patientService.UpdatePatient(updatedPatient).GetProfileSummary();
        }
    }
}
