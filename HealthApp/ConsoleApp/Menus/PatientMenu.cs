using System;
using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Helpers;
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
            try
            {
                Console.Clear();

                var fullName = InputValidator.GetValidatedInput(
                    "Enter Full Name (or 'q' to quit): ",
                    InputValidator.IsValidName,
                    "Name must not contain numbers");

                var dob = InputValidator.GetValidDate("Enter DOB (dd/MM/yyyy): ");
                var gender = InputValidator.GetValidGender("Enter Gender (M/F/Other): ");

                var phone = InputValidator.GetValidatedInput(
                    "Enter Phone: ",
                    InputValidator.IsValidPhone,
                    "Phone must be 10 digits");

                var email = InputValidator.GetValidatedInput(
                    "Enter Email: ",
                    InputValidator.IsValidEmail,
                    "Invalid email");

                var insuranceInput = InputValidator.GetValidatedInput(
                    "Enter Insurance ID: ",
                    InputValidator.IsValidInsuranceId,
                    "Invalid insurance ID");

                int insuranceId = int.Parse(insuranceInput!);

                var patient = new Patient
                {
                    FullName = fullName!,
                    DateOfBirth = dob,
                    Gender = gender,
                    PhoneNumber = phone!,
                    Email = email!,
                    InsuranceId = insuranceId
                };

                return _patientService.RegisterPatient(patient);
            }
            catch (OperationCanceledException)
            {
                return "Operation Canceled";
            }
        }

        public string UpdatePatient()
        {
            try
            {
                Console.Clear();

                Console.Write("Enter ID of patient you wish to update (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Update cancelled.";

                if (!int.TryParse(input, out int patientId) || patientId <= 0)
                    return "Invalid Patient ID";

                var existingPatient = _patientService.GetPatientById(patientId);
                if (existingPatient == null)
                    return "Patient not found";

                Console.WriteLine("\nCurrent Patient Details:");
                Console.WriteLine(existingPatient);

                var fullNameInput = InputValidator.GetValidatedInput(
                    "\nEnter Full Name (Press ENTER to keep existing value): ",
                    InputValidator.IsValidName,
                    "Full Name must not contain numbers.",
                    allowEmpty: true);

                var dobInput = InputValidator.GetOptionalDate(
                    "Enter DOB (dd/MM/yyyy) (Press ENTER to keep existing): ");

                var genderInput = InputValidator.GetOptionalGender(
                    "Enter Gender (M/F/Other) (Press ENTER to keep existing): ");


                var phoneInput = InputValidator.GetValidatedInput(
                    "Enter Phone (Press ENTER to keep existing value): ",
                    InputValidator.IsValidPhone,
                    "Phone must be 10 digits.",
                    allowEmpty: true);

                var emailInput = InputValidator.GetValidatedInput(
                    "Enter Email (Press ENTER to keep existing value): ",
                    InputValidator.IsValidEmail,
                    "Invalid email.",
                    allowEmpty: true);

                var insuranceInput = InputValidator.GetValidatedInput(
                    "Enter Insurance ID (Press ENTER to keep existing value): ",
                    InputValidator.IsValidInsuranceId,
                    "Invalid Insurance ID.",
                    allowEmpty: true);
                    
                var updatedPatient = new Patient
                {
                    PatientId = existingPatient.PatientId,
                    FullName = fullNameInput ?? existingPatient.FullName,
                    DateOfBirth = dobInput ?? existingPatient.DateOfBirth,
                    Gender = genderInput ?? existingPatient.Gender,
                    PhoneNumber = phoneInput ?? existingPatient.PhoneNumber,
                    Email = emailInput ?? existingPatient.Email,
                    InsuranceId = insuranceInput != null
                        ? int.Parse(insuranceInput)
                        : existingPatient.InsuranceId
                };

                Console.Clear();
                return _patientService.UpdatePatient(updatedPatient).GetProfileSummary();
            }
            catch (OperationCanceledException)
            {
                return "Update cancelled.";
            }
            catch (PatientNotFoundException ex)
            {
                return ex.Message;
            }
        }
    }
}