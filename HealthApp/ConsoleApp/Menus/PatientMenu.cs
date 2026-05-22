using System;
using System.Globalization;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Exceptions;

namespace HealthApp.ConsoleApp.Menus
{
    public class PatientMenu
    {
        private readonly IPatientService _service;

        public PatientMenu(IPatientService service)
        {
            _service = service;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==================================");
                Console.WriteLine("     PATIENT MANAGEMENT MENU      ");
                Console.WriteLine("==================================");
                Console.WriteLine("1. Register Patient");
                Console.WriteLine("2. View All Patients");
                Console.WriteLine("3. View Patient Profile Summary");
                Console.WriteLine("4. Get Patient By Id");
                Console.WriteLine("5. Exit");
                Console.WriteLine("==================================");

                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddPatient();
                        break;
                    case 2:
                        ViewAll();
                        break;
                    case 3:
                        GetPatientProfileSummary();
                        break;
                    case 4:
                        GetPatientById();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

        private void AddPatient()
        {
            try
            {
                Patient p = new Patient();

                Console.Write("Enter Name: ");
                string name = Console.ReadLine()?.Trim() ?? "";

                if (!IsValidName(name))
                {
                    Console.WriteLine("Invalid name. Only letters allowed");
                    return;
                }
                p.Name = name;

                Console.Write("Enter DOB (dd-MM-yyyy): ");
                string inputDob = Console.ReadLine();

                if (!DateTime.TryParseExact(inputDob, "dd-MM-yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime dob))
                {
                    Console.WriteLine("Invalid Date Format");
                    return;
                }

                if (dob > DateTime.Today)
                {
                    Console.WriteLine("DOB cannot be in future");
                    return;
                }

                p.Dob = dob;

                Console.Write("Enter Gender (Male/Female): ");
                string gender = Console.ReadLine()?.Trim() ?? "";

                if (!IsValidGender(gender))
                {
                    Console.WriteLine("Invalid gender");
                    return;
                }

                p.Gender = gender;

                Console.Write("Enter Phone Number: ");
                string phoneInput = Console.ReadLine();

                if (!IsValidPhone(phoneInput, out long phone))
                {
                    Console.WriteLine("Invalid phone number");
                    return;
                }

                p.PhoneNumber = phone;

                Console.Write("Enter Email: ");
                string email = Console.ReadLine()?.Trim() ?? "";

                if (!IsValidEmail(email))
                {
                    Console.WriteLine("Invalid email format");
                    return;
                }

                p.Email = email;

                Console.Write("Enter Insurance Id: ");
                if (!int.TryParse(Console.ReadLine(), out int insuranceId) || insuranceId <= 0)
                {
                    Console.WriteLine("Invalid Insurance Id");
                    return;
                }

                p.InsuranceId = insuranceId;

                _service.Register(p);

                Console.WriteLine("Patient Registered Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ViewAll()
        {
            var patients = _service.GetAllPatients();

            if (patients == null || patients.Count == 0)
            {
                Console.WriteLine("No patients found");
                return;
            }

            int count = 1;
            foreach (var p in patients)
            {
                Console.WriteLine($"{count++}. {p.Name}");
            }
        }

        private void GetPatientProfileSummary()
        {
            Console.Write("Enter Patient Id: ");

            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Console.WriteLine("Invalid Id");
                return;
            }

            var summary = _service.GetPatientProfileSummary(id);

            if (!string.IsNullOrEmpty(summary))
                Console.WriteLine(summary);
            else
                Console.WriteLine("Patient not found");
        }

        private void GetPatientById()
        {
            try
            {
                Console.Write("Enter Patient Id: ");

                if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
                {
                    Console.WriteLine("Invalid Id");
                    return;
                }

                var patient = _service.GetPatientById(id);
                Console.WriteLine(patient.GetProfileSummary());
            }
            catch (PatientNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;

            foreach (char c in name)
            {
                if (!char.IsLetter(c) && c != ' ')
                    return false;
            }
            return true;
        }

        private bool IsValidGender(string gender)
        {
            return gender.Equals("Male", StringComparison.OrdinalIgnoreCase) ||
                   gender.Equals("Female", StringComparison.OrdinalIgnoreCase);
        }

        private bool IsValidPhone(string input, out long phone)
        {
            phone = 0;

            if (!long.TryParse(input, out phone))
                return false;

            return input.Length == 10;
        }

        private bool IsValidEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }
    }
}