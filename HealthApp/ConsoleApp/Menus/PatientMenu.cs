
using System;
using System.Text.RegularExpressions;
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

        public void PatientRegisteration()
        {
            while (true)
            {
                Console.WriteLine("================================================");
                Console.WriteLine("                PATIENT MENU");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("        1. Register a new patient");
                Console.WriteLine("        2. Update Patient Details");
                Console.WriteLine("        3. Get Patient By Id");
                Console.WriteLine("        4. Delete a patient");
                Console.WriteLine("        5. View All Patients");
                Console.WriteLine("        6. View Patient Profile Summary");
                Console.WriteLine("        7. Exit");
                Console.WriteLine("------------------------------------------------");

                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input! Enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1: AddPatient(); break;
                    case 2: UpdatePatient(); break;
                    case 3: GetPatientById(); break;
                    case 4: DeletePatient(); break;
                    case 5: ViewAll(); break;
                    case 6: GetPatientProfileSummary(); break;
                    case 7: return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }


        private string ReadNonEmpty(string message)
        {
            string input;
            do
            {
                Console.Write(message);
                input = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        private int ReadInt(string message)
        {
            int value;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out value))
                    return value;

                Console.WriteLine("Invalid number. Try again.");
            }
        }
        private DateTime ReadDate(string message)
        {
            DateTime date;
            while (true)
            {
                Console.Write(message);
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null,
                    System.Globalization.DateTimeStyles.None, out date))
                {
                    if (date > DateTime.Now)
                    {
                        Console.WriteLine("DOB cannot be in the future.");
                        continue;
                    }
                    return date;
                }

                Console.WriteLine("Invalid format! Use dd/MM/yyyy.");
            }
        }

        private string ReadEmail()
        {
            string email;
            while (true)
            {
                Console.Write("Enter Email: ");
                email = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(email) &&
                    Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    return email;

                Console.WriteLine("Invalid email format.");
            }
        }

        private string ReadGender()
        {
            while (true)
            {
                Console.Write("Enter Gender (Male/Female/Other): ");
                var gender = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(gender) &&
                    (gender.Equals("Male", StringComparison.OrdinalIgnoreCase) ||
                     gender.Equals("Female", StringComparison.OrdinalIgnoreCase) ||
                     gender.Equals("Other", StringComparison.OrdinalIgnoreCase)))
                    return gender;

                Console.WriteLine("Invalid gender.");
            }
        }

        private string ReadPhone()
        {
            while (true)
            {
                Console.Write("Enter Phone Number (10 digits): ");
                string phone = Console.ReadLine();

                if (Regex.IsMatch(phone, @"^\d{10}$"))
                    return phone;

                Console.WriteLine("Invalid phone number.");
            }
        }

        private void AddPatient()
        {
            Patient p = new Patient();

            p.Name = ReadNonEmpty("Enter Name: ");
            p.Dob = ReadDate("Enter DOB (dd/MM/yyyy): ");
            p.Gender = ReadGender();
            p.PhoneNumber = Convert.ToInt32(ReadPhone());
            p.Email = ReadEmail();
            p.InsuranceId = ReadInt("Enter Insurance Id: ");

            _service.AddPatient(p);
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            Console.WriteLine(" Patient Registered Successfully");
            Console.WriteLine("+++++++++++++++++++++++++++++++++");

            Console.WriteLine("----- Patient Details -----");
            Console.WriteLine($"Id: {p.Id}");
            Console.WriteLine($"Name: {p.Name}");
            Console.WriteLine($"DOB: {p.Dob:dd/MM/yyyy}");
            Console.WriteLine($"Gender: {p.Gender}");
            Console.WriteLine($"Phone: {p.PhoneNumber}");
            Console.WriteLine($"Email: {p.Email}");
            Console.WriteLine($"Insurance Id: {p.InsuranceId}");
            Console.WriteLine("----------------------------------");
        }

        private void UpdatePatient()
        {
            Console.Write("Enter Patient ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Patient p = _service.GetPatientById(id);

            if (p == null)
            {
                Console.WriteLine("Patient not found!");
                return;
            }

            Console.WriteLine("Leave field empty to keep existing value");

            Console.Write($"Enter Name ({p.Name}): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                p.Name = name;

            Console.Write($"Enter DOB (dd/MM/yyyy) ({p.Dob:dd/MM/yyyy}): ");
            string dobInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(dobInput))
            {
                DateTime dob;
                while (!DateTime.TryParseExact(dobInput, "dd/MM/yyyy", null,
                    System.Globalization.DateTimeStyles.None, out dob))
                {
                    Console.Write("Invalid format! Enter DOB (dd/MM/yyyy): ");
                    dobInput = Console.ReadLine();
                }
                p.Dob = dob;
            }

            Console.Write($"Enter Gender ({p.Gender}): ");
            string gender = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(gender))
                p.Gender = gender;

            Console.Write($"Enter Phone Number ({p.PhoneNumber}): ");
            string phoneInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(phoneInput))
            {
                int phone;
                while (!int.TryParse(phoneInput, out phone))
                {
                    Console.Write("Invalid number. Enter Phone Number: ");
                    phoneInput = Console.ReadLine();
                }
                p.PhoneNumber = phone;
            }

            Console.Write($"Enter Email ({p.Email}): ");
            string email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email))
                p.Email = email;

            Console.Write($"Enter Insurance Id ({p.InsuranceId}): ");
            string insInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(insInput))
            {
                int ins;
                while (!int.TryParse(insInput, out ins))
                {
                    Console.Write("Invalid number. Enter Insurance Id: ");
                    insInput = Console.ReadLine();
                }
                p.InsuranceId = ins;
            }

            _service.UpdatePatient(p);

            Console.WriteLine("✅ Patient Updated Successfully");
        }

        private void DeletePatient()
        {
            int id = ReadInt("Enter Patient ID to delete: ");

            try
            {
                _service.DeletePatient(id);

                Console.WriteLine("Patient deleted successfully.");
            }
            catch (PatientNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ViewAll()
        {
            var patients = _service.GetAllPatients();

            Console.WriteLine("---- All Patients ----");

            if (patients.Count == 0)
            {
                Console.WriteLine("No patients found.");
                return;
            }

            foreach (var p in patients)
            {
                Console.WriteLine($"----- Patient Details of Id {p.Id}-----");
                Console.WriteLine($"       Id: {p.Id}");
                Console.WriteLine($"       Name: {p.Name}");
                Console.WriteLine($"       DOB: {p.Dob:dd/MM/yyyy}");
                Console.WriteLine($"       Gender: {p.Gender}");
                Console.WriteLine($"       Phone: {p.PhoneNumber}");
                Console.WriteLine($"       Email: {p.Email}");
                Console.WriteLine($"       Insurance Id: {p.InsuranceId}");
                Console.WriteLine("--------------------------------------------------");
            }
        }

        private void GetPatientProfileSummary()
        {
            int id = ReadInt("Enter Patient Id: ");

            var summary = _service.GetPatientProfileSummary(id);

            if (!string.IsNullOrEmpty(summary))
            {
                Console.WriteLine("Patient Profile Summary:");
                Console.WriteLine("------------------------");
                Console.WriteLine(summary);
            }
            else
            {
                Console.WriteLine("❌ Patient not found.");
            }
        }

       
        public void GetPatientById()
        {
            try
            {
                int id = ReadInt("Enter Patient Id: ");

                var patient = _service.GetPatientById(id);

                Console.WriteLine("Patient Details:");
                Console.WriteLine(patient.GetProfileSummary());
            }
            catch (PatientNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
