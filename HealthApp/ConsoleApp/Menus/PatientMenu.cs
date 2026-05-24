using HealthApp.ConsoleApp.Helpers;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Exceptions;
namespace HealthApp.ConsoleApp.Menus
{
    public class PatientMenu
    {
        private readonly IPatientService _patientService;

        public PatientMenu(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // =====================================================
        // REGISTER PATIENT
        // =====================================================

        public void RegisterPatient()
        {
            try
            {
                PrintHeader("Register New Patient");

                Console.WriteLine
                (
                    "Type 'back' anytime to return.\n"
                );

                // NAME
                if (!InputValidator.TryReadName(
                    "Full Name           : ",
                    out string name))
                {
                    return;
                }

                // DOB
                if (!InputValidator.TryReadPastDate(
                    "Date Of Birth       : ",
                    out DateTime dob))
                {
                    return;
                }

                // GENDER
                if (!InputValidator.TryReadGender(
                    "Gender(Male/Feamle/Other): ",
                    out Gender gender))
                {
                    return;
                }

                // PHONE
                if (!InputValidator.TryReadPhone(
                    "Phone Number        : ",
                    out string phone))
                {
                    return;
                }

                // EMAIL
                if (!InputValidator.TryReadEmail(
                    "Email               : ",
                    out string email))
                {
                    return;
                }

                // OPTIONAL INSURANCE
                string insuranceId =
                    InputValidator.ReadOptionalString(
                        "Insurance ID (Optional) : ");

                // CREATE PATIENT
                Patient patient = new()
                {
                    Name = name,
                    Dob = dob,
                    Gender = gender,
                    PhoneNumber = phone,
                    Email = email,
                    InsuranceId = insuranceId,
                    CreatedAt = DateTime.Now
                };

                _patientService.AddPatient(patient);

                Console.WriteLine();

                PrintSuccess
                (
                    "Patient Registered Successfully!"
                );

                Console.WriteLine();

                Console.WriteLine
                (
                    patient.GetProfileSummary()
                );
            }

            catch (UserExitException)
            {
                Console.WriteLine
                (
                    "\nReturning to Main Menu..."
                );
            }

            catch (Exception ex)
            {
                PrintError(ex.Message);
            }

            InputValidator.Pause();
        }

        // =====================================================
        // GET PATIENT BY ID
        // =====================================================

        public void GetPatientById()
        {
            PrintHeader("Search Patient");

            try
            {
                if (!InputValidator.TryReadPositiveInt(
                    "Enter Patient ID : ",
                    out int patientId))
                {
                    return;
                }

                Patient? patient =
                    _patientService.GetPatientById(patientId);

                if (patient == null)
                {
                    PrintError("Patient not found.");
                    InputValidator.Pause();
                    return;
                }

                Console.WriteLine();

                Console.WriteLine
                (
                    patient.GetProfileSummary()
                );
            }

            catch (UserExitException)
            {
                Console.WriteLine
                (
                    "\nReturning to Main Menu..."
                );
            }

            InputValidator.Pause();
        }

        // =====================================================
        // VIEW ALL PATIENTS
        // =====================================================

        public void ViewAllPatients()
        {
            PrintHeader("All Patients");

            List<Patient> patients =
                _patientService.GetAllPatients();

            if (patients.Count == 0)
            {
                PrintError("No patients found.");

                InputValidator.Pause();

                return;
            }

            foreach (Patient patient in patients)
            {
                Console.WriteLine
                (
                    patient.GetProfileSummary()
                );

                Console.WriteLine
                (
                    new string('-', 50)
                );
            }

            InputValidator.Pause();
        }

        // =====================================================
        // UPDATE  DETAILS
        // =====================================================
        public void UpdatePatient()
        {
            PrintHeader("Update Patient");

            try
            {
                // =====================================================
                // PATIENT ID
                // =====================================================

                if (!InputValidator.TryReadPositiveInt(
                    "Enter Patient ID : ",
                    out int patientId))
                {
                    return;
                }

                Patient? patient =
                    _patientService.GetPatientById(patientId);

                if (patient == null)
                {
                    PrintError("Patient not found.");

                    InputValidator.Pause();

                    return;
                }

                Console.WriteLine();
                Console.WriteLine("Current Details:");
                Console.WriteLine(patient.GetProfileSummary());

                Console.WriteLine();
                Console.WriteLine("Enter New Details");
                Console.WriteLine("----------------------");

                // =====================================================
                // NAME
                // =====================================================

                if (!InputValidator.TryReadName(
                    "Full Name           : ",
                    out string name))
                {
                    return;
                }

                // =====================================================
                // DOB
                // =====================================================

                if (!InputValidator.TryReadPastDate(
                    "Date Of Birth       : ",
                    out DateTime dob))
                {
                    return;
                }

                // =====================================================
                // GENDER
                // =====================================================

                if (!InputValidator.TryReadGender(
                    "Gender              : ",
                    out Gender gender))
                {
                    return;
                }

                // =====================================================
                // PHONE
                // =====================================================

                if (!InputValidator.TryReadPhone(
                    "Phone Number        : ",
                    out string phone))
                {
                    return;
                }

                // =====================================================
                // EMAIL
                // =====================================================

                if (!InputValidator.TryReadEmail(
                    "Email               : ",
                    out string email))
                {
                    return;
                }

                // =====================================================
                // INSURANCE
                // =====================================================

                string insurance =
                    InputValidator.ReadOptionalString(
                        "Insurance ID        : ");

                // =====================================================
                // UPDATE OBJECT
                // =====================================================

                patient.Name = name;
                patient.Dob = dob;
                patient.Gender = gender;
                patient.PhoneNumber = phone;
                patient.Email = email;
                patient.InsuranceId = insurance;

                Console.WriteLine();

                PrintSuccess
                (
                    "Patient Updated Successfully!"
                );

                Console.WriteLine();

                Console.WriteLine
                (
                    patient.GetProfileSummary()
                );
            }

            catch (UserExitException)
            {
                Console.WriteLine
                (
                    "\nReturning to Main Menu..."
                );
            }

            catch (Exception ex)
            {
                PrintError(ex.Message);
            }

            InputValidator.Pause();
        }



        // =====================================================
        // HEADER
        // =====================================================

        private static void PrintHeader(string title)
        {
            Console.WriteLine();
            Console.WriteLine
            (
                $"========== {title.ToUpper()} =========="
            );

            Console.WriteLine();
        }

        // =====================================================
        // SUCCESS
        // =====================================================

        private static void PrintSuccess(string msg)
        {
            Console.ForegroundColor =
                ConsoleColor.Green;

            Console.WriteLine(msg);

            Console.ResetColor();
        }

        // =====================================================
        // ERROR
        // =====================================================

        private static void PrintError(string msg)
        {
            Console.ForegroundColor =
                ConsoleColor.Red;

            Console.WriteLine(msg);

            Console.ResetColor();
        }
    }
}