using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Helpers;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;

namespace HealthApp.ConsoleApp.Menus
{
    public class DoctorMenu
    {
        private IDoctorService doctorService;

        public DoctorMenu(IDoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        public void ShowMenu()
        {
            int choice;

            do
            {
                Console.WriteLine("\n===== DOCTOR MENU =====");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. View All Doctors");
                Console.WriteLine("3. Search Doctor By Specialisation");
                Console.WriteLine("4. Get Doctor By ID");
                Console.WriteLine("5. Exit");

                Console.Write("Enter choice: ");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("Invalid choice. Enter again: ");
                }

                switch (choice)
                {
                    case 1:
                        AddDoctor();
                        break;

                    case 2:
                        ViewDoctors();
                        break;

                    case 3:
                        SearchDoctorBySpecialisation();
                        break;

                    case 4:
                        GetDoctorById();
                        break;

                    case 5:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

            } while (choice != 5);
        }

        private void AddDoctor()
        {
            try
            {
                if (!InputValidator.TryReadPositiveInt("Enter Doctor ID: ", out int id))
                    return;

                if (!InputValidator.TryReadDoctorName("Enter Full Name: ", out string name))
                    return;

                if (!InputValidator.TryReadSpecialisation("Enter Specialisation: ", out string spec))
                    return;

                if (!InputValidator.TryReadExperience("Enter Years of Experience: ", out int exp))
                    return;

                if (!InputValidator.TryReadConsultationFee("Enter Consultation Fee: ", out decimal fee))
                    return;

                if (!InputValidator.TryReadIsActive("Is Active (yes/no): ", out bool isActive))
                    return;

                Doctor doctor = new Doctor
                {
                    Id = id,
                    FullName = name,
                    Specialisation = spec,
                    YearsOfExperience = exp,
                    ConsultationFee = fee,
                    IsActive = isActive
                };

                doctorService.AddDoctor(doctor);

                Console.WriteLine("✅ Doctor Added Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void ViewDoctors()
        {
            var doctors = doctorService.GetAllDoctors();

            if (doctors.Count == 0)
            {
                Console.WriteLine("No Doctors Found");
                return;
            }

            Console.WriteLine("\n=== Doctor List ===\n");

            foreach (var doctor in doctors)
            {
                Console.WriteLine(doctor.GetDoctorDetails());
                Console.WriteLine(doctor.IsAvailable(DateTime.Today));

                if (!doctor.IsActive)
                {
                    Console.WriteLine("-----------------------------------");
                    continue;
                }

                Console.WriteLine(doctor.GetScheduleSummary());

                var upcoming = doctor.GetUpcomingAppointments();

                if (upcoming.Count > 0)
                {
                    Console.WriteLine("Dates are:");
                    foreach (var date in upcoming)
                    {
                        Console.WriteLine(date.ToString("yyyy-MM-dd"));
                    }
                }

                Console.WriteLine("-----------------------------------");
            }
        }

        private void SearchDoctorBySpecialisation()
        {
            Console.Write("Enter Specialisation: ");
            string specialisation = Console.ReadLine() ?? "";

            try
            {
                var doctors = doctorService.SearchBySpecialisation(specialisation);

                Console.WriteLine("\n=== Matching Doctors ===\n");

                foreach (var doctor in doctors)
                {
                    Console.WriteLine(doctor.GetDoctorDetails());
                    Console.WriteLine(doctor.IsAvailable(DateTime.Today));
                    Console.WriteLine(doctor.GetScheduleSummary());

                    var upcoming = doctor.GetUpcomingAppointments();

                    if (upcoming.Count > 0)
                    {
                        Console.WriteLine("Dates are:");
                        foreach (var date in upcoming)
                        {
                            Console.WriteLine(date.ToString("yyyy-MM-dd"));
                        }
                    }

                    Console.WriteLine("-----------------------------------");
                }
            }
            catch (SpecialisationNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void GetDoctorById()
        {
            Console.Write("Enter Doctor ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            try
            {
                var doctor = doctorService.GetDoctorById(id);

                Console.WriteLine(doctor.GetDoctorDetails());
                Console.WriteLine(doctor.IsAvailable(DateTime.Today));
                Console.WriteLine(doctor.GetScheduleSummary());

                var upcoming = doctor.GetUpcomingAppointments();

                if (upcoming.Count > 0)
                {
                    Console.WriteLine("Dates are:");
                    foreach (var date in upcoming)
                    {
                        Console.WriteLine(date.ToString("yyyy-MM-dd"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}