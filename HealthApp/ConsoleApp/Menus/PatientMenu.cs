using System;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Exceptions;
using System.Globalization;

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
                    Console.WriteLine("Invalid input! Press any key...");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine("----------------------------------");

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
                        Console.WriteLine("Invalid choice. Try again!");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private void AddPatient()
        {
            try
            {
                Patient p = new Patient();

                Console.Write("Enter Name: ");
                p.Name = Console.ReadLine();

                Console.Write("Enter DOB (dd-MM-yyyy): ");
                string inputDob = Console.ReadLine();

                if (!DateTime.TryParseExact(inputDob, "dd-MM-yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime dob))
                {
                    Console.WriteLine("Invalid Date Format!");
                    return;
                }
                p.Dob = dob;

                Console.Write("Enter Gender: ");
                p.Gender = Console.ReadLine();

                Console.Write("Enter Phone Number: ");
                if (!long.TryParse(Console.ReadLine(), out long phone))
                {
                    Console.WriteLine("Invalid Phone Number!");
                    return;
                }
                p.PhoneNumber = phone;

                Console.Write("Enter Email: ");
                p.Email = Console.ReadLine();

                Console.Write("Enter Insurance Id: ");
                if (!int.TryParse(Console.ReadLine(), out int insuranceId))
                {
                    Console.WriteLine("Invalid Insurance Id!");
                    return;
                }
                p.InsuranceId = insuranceId;

                _service.Register(p);

                Console.WriteLine("Patient Registered Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while adding patient: " + ex.Message);
            }
        }

        private void ViewAll()
        {
            var patients = _service.GetAllPatients();

            if (patients == null || patients.Count == 0)
            {
                Console.WriteLine("No patients found.");
                return;
            }

            Console.WriteLine("------ Patient List ------");

            int count = 1;
            foreach (var p in patients)
            {
                Console.WriteLine($"{count++}. {p.Name}");
            }
        }

        private void GetPatientProfileSummary()
        {
            Console.Write("Enter Patient Id: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Id!");
                return;
            }

            var summary = _service.GetPatientProfileSummary(id);

            if (!string.IsNullOrEmpty(summary))
            {
                Console.WriteLine("\n----- Patient Profile Summary -----");
                Console.WriteLine(summary);
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }

        private void GetPatientById()
        {
            try
            {
                Console.Write("Enter Patient Id: ");

                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid Id!");
                    return;
                }

                var patient = _service.GetPatientById(id);

                Console.WriteLine("\n----- Patient Details -----");
                Console.WriteLine(patient.GetProfileSummary());
            }
            catch (PatientNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}