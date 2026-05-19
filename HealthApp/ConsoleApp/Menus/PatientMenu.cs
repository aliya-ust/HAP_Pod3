using System;
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
            int patientId;
            string fullName;
            DateTime dob;
            GenderType gender;
            string phone;
            string email;
            int insuranceId;

            while (true)
            {
                Console.Write("Enter Patient ID (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Patient registration cancelled.";

                if (int.TryParse(input, out patientId) && patientId > 0)
                    break;

                Console.WriteLine("Invalid Patient ID.");
            }

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
                Console.Write("Enter Date of Birth (yyyy-mm-dd) (or 'q' to quit): ");
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

                switch (input?.Trim().ToLower())
                {
                    case "M":
                        gender = GenderType.Male;
                        break;
                    case "F":
                        gender = GenderType.Female;
                        break;
                    case "Other":
                        gender = GenderType.Other;
                        break;
                    default:
                        Console.WriteLine("Invalid gender.");
                        continue;
                }

                break;
            }

            while (true)
            {
                Console.Write("Enter Phone Number (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Patient registration cancelled.";

                if (!string.IsNullOrWhiteSpace(input) && input.All(char.IsDigit))
                {
                    phone = input;
                    break;
                }

                Console.WriteLine("Phone must contain only digits.");
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
                PatientId = patientId,
                FullName = fullName,
                DateOfBirth = dob,
                Gender = gender,
                PhoneNumber = phone,
                Email = email,
                InsuranceId = insuranceId
            };

            return _patientService.RegisterPatient(patient);
        }

        // private void ViewAll()
        // {
        //     var patients = _service.GetAllPatients();
        //     int c = 1;
        //     Console.WriteLine("------------------");
        //     Console.WriteLine("All Patients");
        //     foreach (var p in patients)
        //     {
        //         Console.WriteLine($" {c}.{p.Name}");
        //         c++;
        //     }
        // }

        // private void GetPatientProfileSummary()
        // {
        //     Console.WriteLine("Enter Patient Id: ");
        //     int id = Convert.ToInt32(Console.ReadLine());

        //     var summary = _service.GetPatientProfileSummary(id);
        //     if (!string.IsNullOrEmpty(summary))
        //     {
        //         Console.WriteLine("Patient Profile Summary:");
        //         Console.WriteLine(summary);
        //     }
        //     else
        //     {
        //         Console.WriteLine("Patient not found.");
        //     }

        // }
    }
}
