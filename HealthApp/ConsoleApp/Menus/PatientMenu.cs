using System;
using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Menus
{
    public class PatientMenu
    {
        private readonly IPatientService _patientService;
        
        public const string Continue = "\nPress any key to continue...";
        public const string PatientRegistrationCancelled = "Patient registration cancelled.";


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

            Console.Clear();
            while (true)
            {
                Console.Write("Enter Full name of patient (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                {
                    Console.WriteLine(PatientRegistrationCancelled);
                    Console.WriteLine(Continue);
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
                Console.Write("Enter Date of Birth (dd/mm/yyyy) (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                {
                    Console.WriteLine(PatientRegistrationCancelled);
                    Console.WriteLine(Continue);
                    Console.ReadKey();
                    return "";            
                }

                if (DateTime.TryParseExact(
                        input,
                        "dd/MM/yyyy",
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None,
                        out dob))
                {
                    break;
                }

                Console.WriteLine("Invalid Date of Birth.\n");
            }

            while (true)
            {
                Console.Write("Enter Gender (M/F/Other) (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                {
                    Console.WriteLine(PatientRegistrationCancelled);
                    Console.WriteLine(Continue);
                    Console.ReadKey();
                    return "";            
                }
                
                if (Enum.TryParse<GenderType>(input, true, out var parsedGender))
                    {
                        gender = parsedGender;
                        break;
                    }

                Console.WriteLine("Invalid gender\n");
            }

            while (true)
            {
                Console.Write("Enter Phone Number (or 'q' to quit): ");
                string? input = Console.ReadLine()?.Trim();

                if (input?.ToLower() == "q")
                {
                    Console.WriteLine(PatientRegistrationCancelled);
                    Console.WriteLine(Continue);
                    Console.ReadKey();
                    return "";            
                }

                if (!string.IsNullOrWhiteSpace(input) &&
                    input.Length == 10 &&
                    input.All(char.IsDigit))
                {
                    phone = input;
                    break;
                }

                Console.WriteLine("Phone must be exactly 10 digits.\n");
            }

            while (true)
            {
                Console.Write("Enter Email (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                {
                    Console.WriteLine(PatientRegistrationCancelled);
                    Console.WriteLine(Continue);
                    Console.ReadKey();
                    return "";            
                }

                if (!string.IsNullOrWhiteSpace(input) && input.Contains('@'))
                {
                    email = input.Trim();
                    break;
                }

                Console.WriteLine("Invalid email.\n");
            }

            while (true)
            {
                Console.Write("Enter Insurance ID (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                {
                    Console.WriteLine(PatientRegistrationCancelled);
                    Console.WriteLine(Continue);
                    Console.ReadKey();
                    return "";            
                }

                if (int.TryParse(input, out insuranceId) && insuranceId >= 0)
                    break;

                Console.WriteLine("Invalid Insurance ID.\n");
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
            try
            {
                int patientId;

                Console.Clear();
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
                Console.WriteLine(existingPatient);

                string fullName = existingPatient.FullName;
                while (true)
                {
                    Console.Write("\nEnter Full Name (Press ENTER to keep existing value): ");
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

                DateTime dob = existingPatient.DateOfBirth;
                while (true)
                {
                    Console.Write("Enter Date of Birth (dd-mm-yyyy) (Press ENTER to keep existing value): ");
                    input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                        break;
                    if (DateTime.TryParseExact(
                            input,
                            "dd/MM/yyyy",
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None,
                            out dob))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid Date of Birth.");
                }

                GenderType gender = existingPatient.Gender;
                while (true)
                {
                    Console.Write("Enter Gender (M/F/Other) (Press ENTER to keep existing value): ");
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
                    Console.Write("Enter Phone Number (Press ENTER to keep existing value): ");
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
                    Console.Write("Enter Email (Press ENTER to keep existing value): ");
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
                    Console.Write("Enter Insurance ID (Press ENTER to keep existing value): ");
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

                Console.Clear();
                return _patientService.UpdatePatient(updatedPatient).GetProfileSummary();
            } catch (PatientNotFoundException ex)
            {
                return ex.Message;
            }
        }
    }
}