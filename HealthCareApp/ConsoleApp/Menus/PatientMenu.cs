using HealthApp.ConsoleApp.Helpers;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using System;
using System.Collections.Generic;

namespace HealthApp.ConsoleApp.Menus
{
    public class PatientMenu
    {
        private readonly IPatientService _patientService;

        public PatientMenu(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // ✅ MAIN MENU
        public void PatientRegisteration()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("PATIENT MENU");
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
                        GetPatientSummary();
                        break;

                    case "4":
                        UpdatePatient();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        InputValidator.Pause();
                        break;
                }
            }
        }

        // ✅ REGISTER
        public void RegisterPatient()
        {
            //Console.Clear();
            Console.WriteLine("---- Register Patient ----");

            if (!InputValidator.TryReadName("Name: ", out string name))
                return;

            if (!InputValidator.TryReadPastDate("DOB: ", out DateTime dob))
                return;

            if (!InputValidator.TryReadString("Gender: ", out string gender))
                return;

            if (!InputValidator.TryReadPhone("Phone: ", out string phone))
                return;

            if (!InputValidator.TryReadEmail("Email: ", out string email))
                return;

            string insurance = InputValidator.ReadOptionalString("Insurance ID: ");

            var patient = new Patient
            {
                Name = name,
                Dob = dob,
                Gender = gender,
                PhoneNumber = phone,
                Email = email,
                InsuranceId = insurance
            };

            bool result = _patientService.Register(patient);

            Console.WriteLine(result ? "Patient Registered!" : "❌ Failed");
            InputValidator.Pause();
        }

        // ✅ VIEW ALL
        public void ViewAllPatients()
        {
            Console.WriteLine("---- All Patients ----");

            List<Patient> patients = _patientService.GetAllPatients();

            if (patients.Count == 0)
            {
                Console.WriteLine("No patients found.");
            }
            else
            {
                foreach (var p in patients)
                {
                    Console.WriteLine(p.GetProfileSummary());
                }
            }

            InputValidator.Pause();
        }

        // ✅ GET BY ID
        public void GetPatientSummary()
        {

            if (!InputValidator.TryReadPositiveInt("Enter Patient ID: ", out int id))
                return;

            string summary = _patientService.GetPatientProfileSummaryById(id);

            if (string.IsNullOrEmpty(summary))
                Console.WriteLine("Patient not found.");
            else
                Console.WriteLine(summary);

            InputValidator.Pause();
        }

        // ✅ UPDATE
        public void UpdatePatient()
        {
            Console.WriteLine("---- Update Patient ----");

            Patient existing;

            // ✅ STEP 1: VALIDATE PATIENT ID
            while (true)
            {
                if (!InputValidator.TryReadPositiveInt("Enter Patient ID: ", out int id))
                {
                    continue;
                }

                existing = _patientService.GetAllPatients().FirstOrDefault(p => p.PatientId == id);

                if (existing == null)
                {
                    Console.WriteLine("Patient not found. Try again.");
                    continue;
                }

                break;
            }

            Console.WriteLine("\nPress ENTER to keep existing value\n");

            // ✅ NAME
            while (true)
            {
                Console.Write($"Name ({existing.Name}): ");
                string nameInput = Console.ReadLine() ?? "";

                // ✅ ENTER → keep old value
                if (string.IsNullOrWhiteSpace(nameInput))
                    break;

                // ✅ Validate
                if (InputValidator.TryValidateName(nameInput, out string name))
                {
                    existing.Name = name;
                    break;
                }

                Console.WriteLine("Invalid name. Try again.");
            }
            // ✅ DOB
            while (true)
            {
                Console.Write($"DOB ({existing.Dob:dd-MM-yyyy}): ");
                string input = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(input))
                    break;

                if (InputValidator.TryValidatePastDate(input, out DateTime dob))
                {
                    existing.Dob = dob;
                    break;
                }

                Console.WriteLine("❌ Invalid DOB. Try again.");
            }

            // ✅ GENDER
            while (true)
            {
                Console.Write($"Gender ({existing.Gender}): ");
                string input = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(input))
                    break;

                if (InputValidator.TryValidateGender(input, out string gender))
                {
                    existing.Gender = gender;
                    break;
                }

                Console.WriteLine("❌ Invalid gender (Male/Female/Other).");
            }

            // ✅ PHONE
            while (true)
            {
                Console.Write($"Phone ({existing.PhoneNumber}): ");
                string input = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(input))
                    break;

                if (InputValidator.TryValidatePhone(input, out string phone))
                {
                    existing.PhoneNumber = phone;
                    break;
                }

                Console.WriteLine("❌ Invalid phone. Try again.");
            }


            // ✅ EMAIL
            while (true)
            {
                Console.Write($"Email ({existing.Email}): ");
                string input = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(input))
                    break;

                if (InputValidator.TryValidateEmail(input, out string email))
                {
                    existing.Email = email;
                    break;
                }

                Console.WriteLine("❌ Invalid email. Try again.");
            }

            // ✅ INSURANCE
            Console.Write($"Insurance ID ({existing.InsuranceId}): ");
            string insuranceInput = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(insuranceInput))
                existing.InsuranceId = insuranceInput.Trim();

            // ✅ SAVE
            bool result = _patientService.Update(existing);

            Console.WriteLine(result ? "\n✅ Updated successfully!" : "\n❌ Failed");
            InputValidator.Pause();
        }
    }
}