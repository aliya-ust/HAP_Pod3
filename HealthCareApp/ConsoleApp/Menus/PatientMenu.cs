using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using System;

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
                Console.WriteLine("------------------");
                Console.WriteLine("1. Register Patient");
                Console.WriteLine("2. View Patients");
                Console.WriteLine("3. View Patient Profile Summary");
                Console.WriteLine("4. Exit");
                Console.WriteLine("------------------");

                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("------------------");
                        AddPatient();
                        break;

                    case 2:
                        Console.WriteLine("------------------");
                        ViewAll();
                        break;

                    case 3:
                        Console.WriteLine("------------------");
                        GetPatientProfileSummary();
                        break;



                    case 4:
                        Console.WriteLine("------------------");
                        Exit();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
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

            _service.Register(p);

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



        private void Exit()
        {
            Console.WriteLine("\nThank you for using Healthcare Management System");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }



    }
}
