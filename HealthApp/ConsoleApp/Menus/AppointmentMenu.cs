using System;
using System.Collections.Generic;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Exceptions;

namespace HealthApp
{
    public class AppointmentMenu
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;

        public AppointmentMenu(IAppointmentService appointmentService,
                                IPatientService patientService,
                                IDoctorService doctorService)
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
            _doctorService = doctorService;
        }

        public string BookAppointment()
        {
            int appointmentId;
            int patientId;
            int doctorId;
            Patient? patient;
            Doctor? doctor;
            DateTime date;
            string slot;

            while (true)
            {
                Console.Write("Enter Appointment ID (or 'q' to quit): ");
                var input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Booking cancelled.";

                if (int.TryParse(input, out appointmentId) && appointmentId > 0)
                    break;

                Console.WriteLine("Invalid Appointment ID.");
            }

            while (true)
            {
                Console.Write("Enter Patient ID (or 'q' to quit): ");
                var input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Booking cancelled.";

                if (int.TryParse(input, out patientId) && patientId > 0)
                {
                    patient = _patientService.GetPatientById(patientId);
                    if (patient != null) 
                    {
                        break;
                    }
                }

                Console.WriteLine("Invalid Patient ID.");
            }

            while (true)
            {
                Console.Write("Enter Doctor ID (or 'q' to quit): ");
                var input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Booking cancelled.";

                if (int.TryParse(input, out doctorId) && doctorId > 0)
                {
                    doctor = _doctorService.GetDoctorById(patientId);
                    if (doctor != null) 
                    {
                        break;
                    }
                }

                Console.WriteLine("Invalid Doctor ID.");
            }

            while (true)
            {
                Console.Write("Enter Appointment Date (dd-mm-yyyy) (or 'q' to quit): ");
                var input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Booking cancelled.";

                if (DateTime.TryParse(input, out date))
                    break;

                Console.WriteLine("Invalid date format.");
            }

            
            Console.WriteLine();
            Console.WriteLine("  Available time slots:");
            Console.WriteLine("    [1] 09:00 AM    [2] 10:00 AM    [3] 11:00 AM");
            Console.WriteLine("    [4] 02:00 PM    [5] 03:00 PM    [6] 04:00 PM");

            int slotChoice;
            while (true)
            {
                Console.Write("  Choose slot (1-6): ");
                var input = Console.ReadLine();

                if (!int.TryParse(input, out slotChoice) || slotChoice < 1 || slotChoice > 6)
                {
                    Console.WriteLine("Please enter a number between 1 and 6.");
                    continue;
                }

                break;
            }

            string[] slots = {
                "09:00 AM", "10:00 AM", "11:00 AM",
                "02:00 PM", "03:00 PM", "04:00 PM"
            };

            slot = slots[slotChoice - 1];

            try
            {
                return _appointmentService
                    .BookAppointment(patient, doctor, date, slot);
            }
            catch (PastDateException ex)
            {
                return $"{ex.Message}";
            }
            catch (AppointmentConflictException ex)
            {
                return $"{ex.Message}";
            }
            catch (DoctorUnavailableException ex)
            {
                return $"{ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Unexpected error: {ex.Message}";
            }
        }

        public void ViewAppointments()
        {
            Console.WriteLine("1. View appointments by Patient Id");
            Console.WriteLine("2. View appointments by Doctor Id");
            Console.WriteLine("3. Go back");
            Console.Write("Enter choice: ");

            string? choice = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(choice))
            {
                Console.WriteLine("Invalid input.");
                Console.ReadKey();
                return;
            }

            Console.Clear();

            switch (choice)
            {
                case "1":
                {
                    var appointments = GetAppointmentsByPatientId();

                    if (appointments == null)
                    {
                        Console.ReadKey();
                        return;
                    }

                    if (appointments.Count == 0)
                    {
                        Console.WriteLine("No appointments found.");
                        Console.ReadKey();
                        return;
                    }

                    Console.WriteLine("\n=== Appointments ===\n");

                    foreach (var a in appointments)
                    {
                        Console.WriteLine(a.GetDetails());
                    }

                    Console.ReadKey();
                    break;
                }

                case "2":
                {
                    var appointments = GetAppointmentsByDoctorId();

                    if (appointments == null)
                    {
                        Console.ReadKey();
                        return;
                    }

                    if (appointments.Count == 0)
                    {
                        Console.WriteLine("No appointments found.");
                        Console.ReadKey();
                        return;
                    }

                    Console.WriteLine("\n=== Appointments ===\n");

                    foreach (var a in appointments)
                    {
                        Console.WriteLine(a.GetDetails());
                    }

                    Console.ReadKey();
                    break;
                }

                case "3":
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    Console.ReadKey();
                    return;
            }
        }

        public List<Appointment>? GetAppointmentsByPatientId()
        {
            int patientId;

            while (true)
            {
                Console.Write("Enter Patient ID (or 'q' to quit): ");
                var input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return null;

                if (int.TryParse(input, out patientId) && patientId > 0)
                    break;

                Console.WriteLine("Invalid Patient ID.");
            }

            var patient = _patientService.GetPatientById(patientId);

            if (patient == null)
            {
                Console.WriteLine("Patient does not exist.");
                return null;
            }

            return _appointmentService.GetAppointmentsByPatientId(patientId);
        }

        public List<Appointment>? GetAppointmentsByDoctorId()
        {
            int doctorId;

            while (true)
            {
                Console.Write("Enter Doctor ID (or 'q' to quit): ");
                var input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return null;

                if (int.TryParse(input, out doctorId) && doctorId > 0)
                    break;

                Console.WriteLine("Invalid Doctor ID.");
            }

            var doctor = _doctorService.GetDoctorById(doctorId);

            if (doctor == null)
            {
                Console.WriteLine("Doctor does not exist.");
                return null;
            }

            return _appointmentService.GetAppointmentsByDoctorId(doctorId);
        }
    }
}
