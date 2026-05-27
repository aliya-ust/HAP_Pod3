using HealthApp.ConsoleApp.Helpers;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Menus
{
    // Menu class to handle all patient-related user interactions
    public class PatientMenu
    {
        private readonly IPatientService _patientService;
        // Constructor to inject required service for patient management
        public PatientMenu(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // Patient sub-menu with full CRUD options
        public void ShowPatientMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("  ╔══════════════════════════════╗");
                Console.WriteLine("  ║        PATIENT MENU          ║");
                Console.WriteLine("  ╠══════════════════════════════╣");
                Console.WriteLine("  ║  1.  Register Patient        ║");
                Console.WriteLine("  ║  2.  View All Patients       ║");
                Console.WriteLine("  ║  3.  Search Patient by ID    ║");
                Console.WriteLine("  ║  4.  Update Patient          ║");
                Console.WriteLine("  ║  5.  Back                    ║");
                Console.WriteLine("  ╚══════════════════════════════╝");
                Console.Write("\n  Choose an option : ");

                switch (Console.ReadLine()?.Trim() ?? "")
                {
                    case "1": RegisterPatient(); break;
                    case "2": ViewAllPatients(); break;
                    case "3": GetPatientById(); break;
                    case "4": UpdatePatient(); break;
                    case "5": return;
                    default:
                        PrintError("Invalid choice.");
                        Thread.Sleep(800);
                        break;
                }
            }
        }

        // Register a new patient with full validation
        public void RegisterPatient()
        {
            try
            {
                Console.Clear();
                PrintHeader("REGISTER NEW PATIENT");
                Console.WriteLine("  Type 'q' or 'back' anytime to return.\n");

                // Get validated full name
                string name = InputValidator.GetValidatedInput(
                    "  Full Name              : ",
                    InputValidator.IsValidName,
                    "  Name cannot be empty or contain numbers.")!;

                // Get validated date of birth
                DateTime dob;
                while (true)
                {
                    dob = InputValidator.GetValidDate("  Date of Birth (dd/MM/yyyy) : ");
                    if (dob.Date < DateTime.Today) break;
                    PrintError("Date of birth cannot be today or in the future.");
                }

                // Get validated gender
                GenderType gender = InputValidator.GetValidGender(
                    "  Gender (Male/Female/Other) : ");

                // Get validated phone number
                string phone = InputValidator.GetValidatedInput(
                    "  Phone Number           : ",
                    InputValidator.IsValidPhone,
                    "  Must be 10 digits starting with 6-9.")!;

                // Get validated email address
                string email = InputValidator.GetValidatedInput(
                    "  Email                  : ",
                    InputValidator.IsValidEmail,
                    "  Invalid email. Example: john@email.com")!;

                // Get optional insurance ID
                string? insurance = InputValidator.GetValidatedInput(
                    "  Insurance ID (optional) : ",
                    InputValidator.IsValidInsuranceId,
                    "  Must contain Letters and numbers ",
                    allowEmpty: true);

                // Build and persist the patient
                Patient patient = new()
                {
                    Name = name,
                    Dob = dob,
                    Gender = gender,
                    PhoneNumber = phone,
                    Email = email,
                    InsuranceId = insurance ?? "",
                    CreatedAt = DateTime.Now
                };

                _patientService.RegisterPatient(patient);

                PrintSuccess("Patient Registered Successfully!");
                Console.WriteLine($"\n  {patient.GetProfileSummary()}");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\n  Returning to menu...");
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
            }

            Pause();
        }

        // Display all registered patients
        public void ViewAllPatients()
        {
            Console.Clear();
            PrintHeader("ALL PATIENTS");

            var patients = _patientService.GetAllPatients();

            if (patients.Count == 0)
            {
                PrintError("No patients registered yet.");
                Pause();
                return;
            }

            foreach (var p in patients)
            {
                Console.WriteLine($"  {p.GetProfileSummary()}");
                Console.WriteLine("  " + new string('─', 55));
            }

            Pause();
        }

        // Search and display a patient by their ID
        public void GetPatientById()
        {
            try
            {
                Console.Clear();
                PrintHeader("SEARCH PATIENT BY ID");
                Console.WriteLine("  Type 'q' or 'back' to return.\n");

                // Get validated patient ID
                string raw = InputValidator.GetValidatedInput(
                    "  Enter Patient ID : ",
                    InputValidator.IsValidId,
                    "  Please enter a valid positive number.")!;

                var patient = _patientService.GetPatientById(int.Parse(raw));

                if (patient == null)
                {
                    PrintError($"No patient found with ID {raw}.");
                    Pause();
                    return;
                }

                Console.WriteLine($"\n  {patient.GetProfileSummary()}");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\n  Returning to menu...");
            }

            Pause();
        }

        // Update an existing patient's details
        public void UpdatePatient()
        {
            try
            {
                Console.Clear();
                PrintHeader("UPDATE PATIENT");
                Console.WriteLine("  Type 'q' or 'back' anytime to return.\n");

                // Get validated patient ID
                string rawId = InputValidator.GetValidatedInput(
                    "  Enter Patient ID : ",
                    InputValidator.IsValidId,
                    "  Please enter a valid positive number.")!;

                var patient = _patientService.GetPatientById(int.Parse(rawId));

                if (patient == null)
                {
                    PrintError($"No patient found with ID {rawId}.");
                    Pause();
                    return;
                }

                Console.WriteLine("\n  Current Details:");
                Console.WriteLine("  " + new string('─', 70));
                Console.WriteLine($"  {patient.GetProfileSummary()}");
                Console.WriteLine("  " + new string('─', 70));
                Console.WriteLine("\n  Enter new details below (Press ENTER to keep existing value):\n");

                // Get each updated field with validation
                string name = InputValidator.GetValidatedInput(
                    "  Full Name             : ",
                    InputValidator.IsValidName,
                    "  Name cannot be empty or contain numbers.",
                    allowEmpty: true)!;

                DateTime? dob = InputValidator.GetOptionalDate("  Date of Birth (dd/MM/yyyy) : ");
                if (dob < DateTime.Today)
                {
                    PrintError("Date of birth cannot be today or in the future.");
                }

                GenderType? gender = InputValidator.GetOptionalGender(
                    "  Gender (Male/Female/Other) : ");

                string phone = InputValidator.GetValidatedInput(
                    "  Phone Number           : ",
                    InputValidator.IsValidPhone,
                    "  Must be 10 digits starting with 6-9.",
                    allowEmpty: true)!;

                string email = InputValidator.GetValidatedInput(
                    "  Email                  : ",
                    InputValidator.IsValidEmail,
                    "  Invalid email. Example: john@email.com",
                    allowEmpty: true)!;

                string? insurance = InputValidator.GetValidatedInput(
                    "  Insurance ID (optional) : ",
                    InputValidator.IsValidInsuranceId,
                    "  Must be a positive number.",
                    allowEmpty: true);

                // Apply all updates to the patient object
                patient.Name = name ?? patient.Name;
                patient.Dob = dob ?? patient.Dob;
                patient.Gender = gender ?? patient.Gender;
                patient.PhoneNumber = phone ?? patient.PhoneNumber;
                patient.Email = email ?? patient.Email;
                patient.InsuranceId = insurance ?? patient.InsuranceId;

                PrintSuccess("Patient Updated Successfully!");
                Console.WriteLine($"\n  {patient.GetProfileSummary()}");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\n  Returning to menu...");
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
            }

            Pause();
        }

        //  Helpers

        private static void PrintHeader(string title)
        {

            Console.WriteLine($"\n  ╔══════════════════════════════════════════════════╗");
            Console.WriteLine($"  ║  {title,-48}║");
            Console.WriteLine($"  ╚══════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
        }

        private static void PrintSuccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{msg}");
            Console.ResetColor();
        }

        private static void PrintError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{msg}");
            Console.ResetColor();
        }

        private static void Pause()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n  Press any key to continue...");
            Console.ResetColor();
            Console.ReadKey(intercept: true);
        }
    }
}