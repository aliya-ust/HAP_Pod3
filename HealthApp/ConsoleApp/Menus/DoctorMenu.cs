using System;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Exceptions;

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
                Console.WriteLine("2. Search Doctor By Specialisation");
                Console.WriteLine("3. Get Doctor By Id");
                Console.WriteLine("4. Update Doctor");
                Console.WriteLine("5. Exit");
                Console.WriteLine("===================================");

                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input");
                    Pause();
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            AddDoctor();
                            break;

                        case 2:
                            SearchDoctorBySpecialisation();
                            break;

                        case 3:
                            GetDoctorById();
                            break;

                        case 4:
                            UpdateDoctor();
                            break;

                        case 5:
                            Console.WriteLine("Exiting");
                            return;

                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                catch (SpecialisationNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                Pause();

            } while (choice != 5);
        }

        private void AddDoctor()
        {
            Console.Write("Enter Doctor ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Console.WriteLine("Invalid Doctor ID");
                return;
            }

            Console.Write("Enter Full Name: ");
            string name = Console.ReadLine()?.Trim() ?? "";
            if (!IsValidText(name))
            {
                Console.WriteLine("Invalid name");
                return;
            }

            Console.Write("Enter Specialisation: ");
            string spec = Console.ReadLine()?.Trim() ?? "";
            if (!IsValidText(spec))
            {
                Console.WriteLine("Invalid specialisation");
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

        private void SearchDoctorBySpecialisation()
        {
            Console.Write("Enter Specialisation: ");
            string spec = Console.ReadLine()?.Trim() ?? "";

            if (!IsValidText(spec))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            var doctors = _doctorService.SearchBySpecialisation(spec);

            foreach (var doctor in doctors)
            {
                Console.WriteLine(doctor.GetDoctorDetails());
                Console.WriteLine("Availability: " + doctor.CheckAvailability(DateTime.Today));
                Console.WriteLine("-----------------------------------");
            }
        }

        private void GetDoctorById()
        {
            Console.Write("Enter Doctor ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Console.WriteLine("Invalid Doctor ID");
                return;
            }

            var doctor = _doctorService.GetDoctorById(id);

            Console.WriteLine(doctor.GetDoctorDetails());
            Console.WriteLine("Availability: " + doctor.CheckAvailability(DateTime.Today));
        }

        private void UpdateDoctor()
        {
            Console.Write("Enter Doctor ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Console.WriteLine("Invalid Doctor ID");
                return;
            }

            var existing = _doctorService.GetDoctorById(id);

            Doctor updated = new Doctor
            {
                DoctorId = id
            };

            Console.Write("New Name (leave blank to keep same): ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
                updated.FullName = existing.FullName;
            else if (IsValidText(name))
                updated.FullName = name;
            else
            {
                Console.WriteLine("Invalid name");
                return;
            }

            Console.Write("New Specialisation: ");
            string spec = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(spec))
                updated.Specialisation = existing.Specialisation;
            else if (IsValidText(spec))
                updated.Specialisation = spec;
            else
            {
                Console.WriteLine("Invalid specialisation");
                return;
            }

            Console.Write("New Experience: ");
            string expInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(expInput))
                updated.YearsOfExperience = existing.YearsOfExperience;
            else if (int.TryParse(expInput, out int exp) && exp >= 0)
                updated.YearsOfExperience = exp;
            else
            {
                Console.WriteLine("Invalid experience");
                return;
            }

            Console.Write("New Fee: ");
            string feeInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(feeInput))
                updated.ConsultationFee = existing.ConsultationFee;
            else if (decimal.TryParse(feeInput, out decimal fee) && fee >= 0)
                updated.ConsultationFee = fee;
            else
            {
                Console.WriteLine("Invalid fee");
                return;
            }

            Console.Write("Is Active (true/false): ");
            string activeInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(activeInput))
                updated.IsActive = existing.IsActive;
            else if (bool.TryParse(activeInput, out bool isActive))
                updated.IsActive = isActive;
            else
            {
                Console.WriteLine("Invalid input");
                return;
            }

            _doctorService.UpdateDoctor(updated);
            Console.WriteLine("Doctor updated successfully");
        }

        private bool IsValidText(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            foreach (char c in value)
            {
                if (!char.IsLetter(c) && c != ' ' && c != '.')
                    return false;
            }

            return true;
        }

        private void Pause()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}