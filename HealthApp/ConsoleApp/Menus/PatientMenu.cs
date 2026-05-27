using HealthApp.ConsoleApp.Helpers;
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
        public void ViewPatientMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("        PATIENT MENU             ");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Register Patient");
                Console.WriteLine("2. View All Patients");
                Console.WriteLine("3. Get Patient Summary by ID");
                Console.WriteLine("4. Update Patient");
                Console.WriteLine("5. Back");
                Console.WriteLine("=================================");

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        RegisterPatient();
                        break;

                    case "2":
                        ViewAllPatients();
                        break;

                    case "3":
                        GetPatientById();
                        break;

                    case "4":
                        UpdatePatient();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        Pause();
                        break;
                }
            }
        }

        // Register a new patient
        public void RegisterPatient()
        {
            try
            {
                PrintHeader("Register New Patient");
                Console.WriteLine("Type 'q' or 'back' anytime to return.\n");

                // Get and validate full name
                string name = InputValidator.GetValidatedInput(
                    "Full Name           : ",
                    InputValidator.IsValidName,
                    "Name cannot be empty or contain numbers.")!;

                // Get and validate date of birth (must be in the past)
                DateTime dob;
                while (true)
                {
                    dob = InputValidator.GetValidDate("Date Of Birth (dd/MM/yyyy) : ");
                    if (dob.Date < DateTime.Today) break;
                    PrintError("Date of birth cannot be today or in the future.");
                }

                // Get and validate gender
                GenderType gender = InputValidator.GetValidGender(
                    "Gender (Male/Female/Other) : ");

                // Get and validate phone number
                string phone = InputValidator.GetValidatedInput(
                    "Phone Number        : ",
                    InputValidator.IsValidPhone,
                    "Phone must be 10 digits starting with 6-9.")!;

                // Get and validate email
                string email = InputValidator.GetValidatedInput(
                    "Email               : ",
                    InputValidator.IsValidEmail,
                    "Invalid email. Example: john@email.com")!;

                // Get optional insurance ID
                string? insuranceId = InputValidator.GetValidatedInput(
                    "Insurance ID (Optional, press Enter to skip) : ",
                    InputValidator.IsValidInsuranceId,
                    "Insurance ID must be a positive number.",
                    allowEmpty: true);

                // Build and save patient
                Patient patient = new()
                {
                    Name = name,
                    Dob = dob,
                    Gender = gender,
                    PhoneNumber = phone,
                    Email = email,
                    InsuranceId = insuranceId ?? "",
                    CreatedAt = DateTime.Now
                };

                _patientService.RegisterPatient(patient);

                PrintSuccess("Patient Registered Successfully!");
                Console.WriteLine($"\n{patient.GetProfileSummary()}");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\nReturning to Main Menu...");
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
            }

            Pause();
        }

        // Search and display a patient by ID
        public void GetPatientById()
        {
            try
            {
                PrintHeader("Search Patient");
                Console.WriteLine("Type 'q' or 'back' to return.\n");

                // Get and validate patient ID
                string raw = InputValidator.GetValidatedInput(
                    "Enter Patient ID : ",
                    InputValidator.IsValidId,
                    "Please enter a valid positive number.")!;

                int patientId = int.Parse(raw);
                Patient? patient = _patientService.GetPatientById(patientId);

                if (patient == null)
                {
                    PrintError("Patient not found.");
                    Pause();
                    return;
                }

                Console.WriteLine($"\n{patient.GetProfileSummary()}");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\nReturning to Main Menu...");
            }

            Pause();
        }

        // Display all registered patients
        public void ViewAllPatients()
        {
            PrintHeader("All Patients");

            List<Patient> patients = _patientService.GetAllPatients();

            if (patients.Count == 0)
            {
                PrintError("No patients found.");
                Pause();
                return;
            }

            foreach (Patient patient in patients)
            {
                Console.WriteLine(patient.GetProfileSummary());
                Console.WriteLine(new string('-', 50));
            }

            Pause();
        }

        // Update an existing patient's details
        public void UpdatePatient()
        {
            try
            {
                PrintHeader("Update Patient");
                Console.WriteLine("Type 'q' or 'back' anytime to return.\n");

                // Get and validate patient ID
                string rawId = InputValidator.GetValidatedInput(
                    "Enter Patient ID : ",
                    InputValidator.IsValidId,
                    "Please enter a valid positive number.")!;

                Patient? patient = _patientService.GetPatientById(int.Parse(rawId));

                if (patient == null)
                {
                    PrintError("Patient not found.");
                    Pause();
                    return;
                }

                Console.WriteLine("\nCurrent Details:");
                Console.WriteLine(new string('-', 44));
                Console.WriteLine(patient.GetProfileSummary());
                Console.WriteLine("\nEnter New Details:");
                Console.WriteLine(new string('-', 44));

                // Get updated name
                string name = InputValidator.GetValidatedInput(
                    "Full Name           : ",
                    InputValidator.IsValidName,
                    "Name cannot be empty or contain numbers or special character.")!;

                // Get updated date of birth
                DateTime dob;
                while (true)
                {
                    dob = InputValidator.GetValidDate("Date Of Birth (dd/MM/yyyy) : ");
                    if (dob.Date < DateTime.Today) break;
                    PrintError("Date of birth cannot be today or in the future.");
                }

                // Get updated gender
                GenderType gender = InputValidator.GetValidGender("Gender (Male/Female/Other) : ");

                // Get updated phone
                string phone = InputValidator.GetValidatedInput(
                    "Phone Number        : ",
                    InputValidator.IsValidPhone,
                    "Phone must be 10 digits starting with 6-9.")!;

                // Get updated email
                string email = InputValidator.GetValidatedInput(
                    "Email               : ",
                    InputValidator.IsValidEmail,
                    "Invalid email. Example: john@email.com")!;

                // Get updated insurance (optional)
                string? insurance = InputValidator.GetValidatedInput(
                    "Insurance ID (Optional) : ",
                    InputValidator.IsValidInsuranceId,
                    "Insurance ID must be a positive number.",
                    allowEmpty: true);

                // Apply updates
                patient.Name = name;
                patient.Dob = dob;
                patient.Gender = gender;
                patient.PhoneNumber = phone;
                patient.Email = email;
                patient.InsuranceId = insurance ?? "";

                PrintSuccess("Patient Updated Successfully!");
                Console.WriteLine($"\n{patient.GetProfileSummary()}");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\nReturning to Main Menu...");
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
            }

            Pause();
        }

        // ── Helpers ──────────────────────────────────────────────────────────────

        private static void PrintHeader(string title)
        {
            Console.WriteLine();
            Console.WriteLine($"========== {title.ToUpper()} ==========");
            Console.WriteLine();
        }

        private static void PrintSuccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        private static void PrintError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        private static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(intercept: true);
        }
    }
}