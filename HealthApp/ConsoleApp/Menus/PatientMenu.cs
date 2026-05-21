using System;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Exceptions;
using System.Data;

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
                Console.WriteLine("---------------------------------");
                Console.WriteLine("1. Register a new patient");
                Console.WriteLine("2. Update Patient Details");
                Console.WriteLine("3. Get Patient By Id");
                Console.WriteLine("4. Delete a patient");
                Console.WriteLine("5. View AllPatients");
                Console.WriteLine("6. View Patient Profile Summary");
                Console.WriteLine("7. Exit");
                Console.WriteLine("---------------------------------");

                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("------------------");
                        AddPatient();
                        break;

                    case 2:
                        Console.WriteLine("------------------");
                        UpdatePatient();
                        break;

                    case 3:
                        Console.WriteLine("------------------");
                        GetPatientProfileSummary();
                        break;

                    case 4:
                        Console.WriteLine("------------------");
                        GetPatientById();
                        break;

                    case 5:
                        Console.WriteLine("------------------");
                        ViewAll();
                        break;

                    case 6:
                        Console.WriteLine("------------------");
                        GetPatientById();
                        break;

                    case 7:
                        Console.WriteLine("------------------");
                        Exit();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }


        private void UpdatePatient()
        {
            Console.Write("Enter Patient ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            // Assuming you have a method to get patient by ID
            Patient p = _service.GetPatientById(id);

            if (p == null)
            {
                Console.WriteLine("Patient not found!");
                return;
            }

            Console.Write("Enter your Name: ");
            p.Name = Console.ReadLine();

            Console.Write("Enter your DOB(dd-MM-yyyy): ");
            string s = Console.ReadLine();
            DateTime dob = DateTime.ParseExact(s, "dd-MM-yyyy", null);
            p.Dob = dob;

            Console.Write("Enter your Gender: ");
            p.Gender = Console.ReadLine();

            Console.Write("Enter your Phone Number: ");
            p.PhoneNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter your Email: ");
            p.Email = Console.ReadLine();

            Console.Write("Enter your Insurance Id: ");
            p.InsuranceId = Convert.ToInt32(Console.ReadLine());

            _service.UpdatePatient(p);

            Console.WriteLine("Patient Updated Successfully");
        }


        private void AddPatient()
        {
            Patient p = new Patient();

            Console.Write("Enter your Name: ");
            p.Name = Console.ReadLine();

            Console.Write("Enter your DOB(dd-MM-yyyy): ");
            string s = Console.ReadLine();
            DateTime dob = DateTime.ParseExact(s, "dd-MM-yyyy", null);
            p.Dob = dob;

            Console.Write("Enter your Gender: ");
            p.Gender = Console.ReadLine();

            Console.Write("Enter your Phone Number: ");
            p.PhoneNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter your Email: ");
            p.Email = Console.ReadLine();

            Console.Write("Enter your Insurance Id: ");
            p.InsuranceId = Convert.ToInt32(Console.ReadLine());

            _service.AddPatient(p);

            Console.WriteLine("Patient Registered Successfully");
        }

        private void ViewAll()
        {
            var patients = _service.GetAllPatients();
            int c = 1;
            Console.WriteLine("------------------");
            Console.WriteLine("All Patients");
            foreach (var p in patients)
            {
                Console.WriteLine($" {c}.{p.Name}");
                c++;
            }
        }

        private void GetPatientProfileSummary()
        {
            Console.WriteLine("Enter Patient Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var summary = _service.GetPatientProfileSummary(id);
            if (!string.IsNullOrEmpty(summary))
            {
                Console.WriteLine("Patient Profile Summary:");
                Console.WriteLine(summary);
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }

        }
        public void GetPatientById()
        {
            try
            {
                Console.Write("Enter Patient Id: ");
                int id = Convert.ToInt32(Console.ReadLine());

                var patient = _service.GetPatientById(id);
                Console.WriteLine("Patient Details:");
                Console.WriteLine(patient.GetProfileSummary());
            }

            catch (PatientNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Exit()
        {
            Console.WriteLine("\nThank you for using Healthcare Management System");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }



    }
}
