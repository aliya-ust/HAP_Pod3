using System;
using System.Collections.Generic;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Repositories;

namespace HealthApp.ConsoleApp.Menus
{
    public class DoctorMenu
    {
        private readonly IDoctorService _doctorService;

        public DoctorMenu(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public void ShowMenu()
        {
            int choice;

            do
            {
                Console.Clear();
                Console.WriteLine("===================================");
                Console.WriteLine("DOCTOR MENU");
                Console.WriteLine("===================================");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. View All Doctors");
                Console.WriteLine("3. Search Doctor By Specialisation");
                Console.WriteLine("4. Get Doctor By Id");
                Console.WriteLine("5. Exit");
                Console.WriteLine("===================================");

                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input");
                    Pause();
                    continue;
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
                        Console.WriteLine("Exiting");
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

                Pause();

            } while (choice != 4);
        }

        private void AddDoctor()
        {
            try
            {
                Console.Write("Enter Doctor ID: ");
                if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
                {
                    Console.WriteLine("Invalid Doctor ID");
                    return;
                }

                var existingDoctors = _doctorService.GetAllDoctors();
                foreach (var d in existingDoctors)
                {
                    if (d.DoctorId == id)
                        throw new DoctorAlreadyExistsException("Doctor ID already exists");
                }

                Console.Write("Enter Full Name: ");
                string name = Console.ReadLine()?.Trim() ?? "";
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty");
                    return;
                }

                Console.Write("Enter Specialisation: ");
                string spec = Console.ReadLine()?.Trim() ?? "";
                if (string.IsNullOrWhiteSpace(spec))
                {
                    Console.WriteLine("Specialisation cannot be empty");
                    return;
                }

                Console.Write("Enter Years Of Experience: ");
                if (!int.TryParse(Console.ReadLine(), out int exp) || exp < 0)
                {
                    Console.WriteLine("Invalid experience");
                    return;
                }

                Console.Write("Enter Consultation Fee: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal fee) || fee < 0)
                {
                    Console.WriteLine("Invalid fee");
                    return;
                }

                Console.Write("Is Active (true/false): ");
                if (!bool.TryParse(Console.ReadLine(), out bool isActive))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                Doctor doctor = new Doctor
                {
                    DoctorId = id,
                    FullName = name,
                    Specialisation = spec,
                    YearsOfExperience = exp,
                    ConsultationFee = fee,
                    IsActive = isActive
                };

                _doctorService.AddDoctor(doctor);

                Console.WriteLine("Doctor added successfully");
            }
            catch (DoctorAlreadyExistsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ViewDoctors()
        {
            var doctors = _doctorService.GetAllDoctors();

            if (doctors.Count == 0)
            {
                Console.WriteLine("No doctors found");
                return;
            }

            foreach (var doctor in doctors)
            {
                Console.WriteLine(doctor.GetDoctorDetails());
                Console.WriteLine("Availability: " + doctor.CheckAvailability(DateTime.Today));

                if (!doctor.IsActive)
                {
                    Console.WriteLine("-----------------------------------");
                    continue;
                }

                Console.WriteLine(doctor.GetScheduleSummary());

                var upcoming = doctor.GetUpcomingAppointments();

                if (upcoming.Count > 0)
                {
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
            string spec = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(spec))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            try
            {
                var doctors = _doctorService.SearchBySpecialisation(spec);

                foreach (var doctor in doctors)
                {
                    Console.WriteLine(doctor.GetDoctorDetails());
                    Console.WriteLine("Availability: " + doctor.CheckAvailability(DateTime.Today));
                    Console.WriteLine(doctor.GetScheduleSummary());
                    Console.WriteLine("-----------------------------------");
                }
            }
            catch (SpecialisationNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
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
                var doctor = _doctorService.GetDoctorById(id);

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


        private void Pause()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}