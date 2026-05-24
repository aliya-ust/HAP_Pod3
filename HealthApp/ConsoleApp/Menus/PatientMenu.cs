using System;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Helpers;

namespace HealthApp.ConsoleApp.Menus
{
    public class PatientMenu
    {
        private readonly IPatientService _service;

        public PatientMenu(IPatientService service)
        {
            _service = service;
        }

        private void Execute(Action action)
        {
            try
            {
                action();
            }
            catch (PatientInvalidException ex)
            {
                Console.WriteLine($"⚠️ {ex.Message}");
            }
            catch (PatientNotFoundException ex)
            {
                Console.WriteLine($"❌ {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ {ex.Message}");
            }
        }

        public void PatientRegisteration()
        {
            while (true)
            {
                Console.WriteLine("\n===== PATIENT MENU =====");
                Console.WriteLine("1. Register Patient");
                Console.WriteLine("2. Update Patient");
                Console.WriteLine("3. View All Patients");
                Console.WriteLine("4. Profile Summary By Id");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");

                

                if (!InputValidator.TryReadMenuChoice(out int choice))
                {
                    Console.WriteLine("Invalid choice");
                    continue;
                }

                switch (choice)
                {
                    case 1: Execute(AddPatient); break;
                    case 2: Execute(UpdatePatient); break;
                    case 3: Execute(ViewAll); break;
                    case 4: Execute(GetProfile); break;
                    case 5: return;

                }
            }
        }

        private void AddPatient()
        {
            InputValidator.TryReadName("Enter Name: ", out string name);
            InputValidator.TryReadPastDate("Enter DOB: ", out DateTime dob);

            string genderInput;
            do
            {
                Console.Write("Enter Gender: ");
                genderInput = Console.ReadLine() ?? "";
            }
            while (!InputValidator.TryValidateGender(genderInput, out genderInput));

            InputValidator.TryReadPhone("Enter Phone: ", out string phone);
            InputValidator.TryReadEmail("Enter Email: ", out string email);

            string insurance = InputValidator.ReadOptionalString("Enter Insurance Id: ");

            if (!InputValidator.TryValidateInsurance(insurance, out insurance))
            {
                Console.WriteLine("Invalid Insurance ID.");
                return;
            }

            var p = new Patient
            {
                Name = name,
                Dob = dob,
                Gender = Enum.Parse<Patient.GenderType>(genderInput, true),
                PhoneNumber = phone,
                Email = email,
                InsuranceId = insurance
            };

            _service.AddPatient(p);

            Console.WriteLine("\n✅ Patient Registered Successfully");
        }

        private void UpdatePatient()
        {
            InputValidator.TryReadInt("Enter Patient Id: ", out int id);
            var p = _service.GetPatientById(id);

            Console.WriteLine("\nPress ENTER to keep existing value\n");

            // ✅ NAME
            while (true)
            {
                string input = InputValidator.ReadOptionalString($"Name ({p.Name}): ");

                if (string.IsNullOrWhiteSpace(input)) break;

                if (InputValidator.TryValidateName(input, out string valid))
                {
                    p.Name = valid;
                    break;
                }

                Console.WriteLine("❌ Invalid name. Try again.");
            }

            // ✅ DOB
            while (true)
            {
                string input = InputValidator.ReadOptionalString($"DOB ({p.Dob:dd/MM/yyyy}): ");

                if (string.IsNullOrWhiteSpace(input)) break;

                if (InputValidator.TryValidatePastDate(input, out DateTime dob))
                {
                    p.Dob = dob;
                    break;
                }

                Console.WriteLine("❌ Invalid DOB. Use dd/MM/yyyy and past date.");
            }

            // ✅ GENDER
            while (true)
            {
                string input = InputValidator.ReadOptionalString($"Gender ({p.Gender}): ");

                if (string.IsNullOrWhiteSpace(input)) break;

                if (InputValidator.TryValidateGender(input, out string valid))
                {
                    p.Gender = Enum.Parse<Patient.GenderType>(valid, true);
                    break;
                }

                Console.WriteLine("❌ Invalid gender (Male/Female/Other).");
            }

            // ✅ PHONE
            while (true)
            {
                string input = InputValidator.ReadOptionalString($"Phone ({p.PhoneNumber}): ");

                if (string.IsNullOrWhiteSpace(input)) break;

                if (InputValidator.TryValidatePhone(input, out string valid))
                {
                    p.PhoneNumber = valid;
                    break;
                }

                Console.WriteLine("❌ Invalid phone (10 digits).");
            }

            // ✅ EMAIL
            while (true)
            {
                string input = InputValidator.ReadOptionalString($"Email ({p.Email}): ");

                if (string.IsNullOrWhiteSpace(input)) break;

                if (InputValidator.TryValidateEmail(input, out string valid))
                {
                    p.Email = valid;
                    break;
                }

                Console.WriteLine("❌ Invalid email.");
            }

            // ✅ INSURANCE
            while (true)
            {
                string input = InputValidator.ReadOptionalString($"Insurance Id ({p.InsuranceId}): ");

                if (string.IsNullOrWhiteSpace(input)) break;

                if (InputValidator.TryValidateInsurance(input, out string valid))
                {
                    p.InsuranceId = valid;
                    break;
                }

                Console.WriteLine("❌ Invalid Insurance ID.");
            }

            _service.UpdatePatient(p);

            Console.WriteLine("\n✅ Patient Updated Successfully");
        }
        private void ViewAll()
        {
            var patients = _service.GetAllPatients();

            foreach (var p in patients)
            {
                Console.WriteLine(p.GetProfileSummary());
            }
        }

        private void GetProfile()
        {
            InputValidator.TryReadInt("Enter Patient Id: ", out int id);
            Console.WriteLine(_service.GetPatientProfileSummary(id));
        }
    }
}