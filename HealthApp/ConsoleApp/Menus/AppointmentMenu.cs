using System;
using System.Collections.Generic;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Helpers;

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
            try
            {
                Console.Clear();

                var patientIdInput = InputValidator.GetValidatedInput(
                    "Enter Patient ID (or 'q' to quit): ",
                    InputValidator.IsValidId,
                    "Invalid Patient ID.");

                int patientId = int.Parse(patientIdInput!);
                var patient = _patientService.GetPatientById(patientId);
                if (patient == null) return "Patient not found";

                var doctorIdInput = InputValidator.GetValidatedInput(
                    "Enter Doctor ID (or 'q' to quit): ",
                    InputValidator.IsValidId,
                    "Invalid Doctor ID.");

                int doctorId = int.Parse(doctorIdInput!);
                var doctor = _doctorService.GetDoctorById(doctorId);
                if (doctor == null) return "Doctor not found";

                var date = InputValidator.GetValidDate("Enter Appointment Date (dd/MM/yyyy): ");

                Console.WriteLine("\nAvailable Slots:");
                Console.WriteLine("[1] 09:00 AM  [2] 10:00 AM  [3] 11:00 AM");
                Console.WriteLine("[4] 02:00 PM  [5] 03:00 PM  [6] 04:00 PM");

                var slotChoiceInput = InputValidator.GetValidatedInput(
                    "Choose slot (1-6): ",
                    input => int.TryParse(input, out int s) && s >= 1 && s <= 6,
                    "Invalid slot.");

                int slotChoice = int.Parse(slotChoiceInput!);

                string[] slots =
                {
                    "09:00 AM", "10:00 AM", "11:00 AM",
                    "02:00 PM", "03:00 PM", "04:00 PM"
                };

                string slot = slots[slotChoice - 1];

                return _appointmentService.BookAppointment(patient, doctor, date, slot);
            }
            catch (OperationCanceledException)
            {
                return HandleCancel("Booking cancelled.");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Appointment> ViewAppointments()
        {
            Console.Clear();

            Console.WriteLine("1. By Patient Id");
            Console.WriteLine("2. By Doctor Id");
            Console.WriteLine("3. By Appointment Id");
            Console.WriteLine("4. Back");
            Console.Write("Enter choice: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewById("Patient", _appointmentService.GetAppointmentsByPatientId);
                    break;

                case "2":
                    ViewById("Doctor", _appointmentService.GetAppointmentsByDoctorId);
                    break;

                case "3":
                    ViewSingleAppointment();
                    break;

                default:
                    return [];
            }

            return [];
        }

        private static void ViewById(string entity, Func<int, List<Appointment>> fetchFunc)
        {
            try 
            {
                var idInput = InputValidator.GetValidatedInput(
                    $"Enter {entity} Id: ",
                    InputValidator.IsValidId,
                    $"Invalid {entity} Id.");

                int id = int.Parse(idInput!);

                var appointments = fetchFunc(id);

                Console.Clear();
                Console.WriteLine("\n=== Appointments ===\n");

                foreach (var a in appointments)
                    Console.WriteLine(a.GetDetails());

                Pause();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Pause();
            }
        }

        private void ViewSingleAppointment()
        {
            try
            {
                var idInput = InputValidator.GetValidatedInput(
                    "Enter Appointment Id: ",
                    InputValidator.IsValidId,
                    "Invalid Appointment Id.");

                int id = int.Parse(idInput!);

                var appointment = _appointmentService.GetAppointmentById(id);

                Console.Clear();
                Console.WriteLine(appointment?.GetDetails());

                Pause();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Pause();
            }
        }

        public string ConfirmCancelAppointment()
        {
            Console.Clear();

            Console.WriteLine("1. Confirm Appointment");
            Console.WriteLine("2. Cancel Appointment");
            Console.WriteLine("3. Back");
            Console.Write("Enter choice: ");

            var choice = Console.ReadLine();

            return choice switch
            {
                "1" => ConfirmAppointment(),
                "2" => CancelAppointment(),
                _ => "Invalid choice."
            };
        }

        private string ConfirmAppointment()
        {
            try
            {
                var input = InputValidator.GetValidatedInput(
                    "Enter Appointment Id: ",
                    InputValidator.IsValidId,
                    "Invalid Appointment Id.");

                int id = int.Parse(input!);

                var appointment = _appointmentService.GetAppointmentById(id);
                if (appointment == null)
                    return "Appointment not found.";

                appointment.Confirm();

                return "Appointment confirmed successfully.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private string CancelAppointment()
        {
            try
            {
                var idInput = InputValidator.GetValidatedInput(
                    "Enter Appointment Id: ",
                    InputValidator.IsValidId,
                    "Invalid Appointment Id.");

                int id = int.Parse(idInput!);

                var reason = InputValidator.GetValidatedInput(
                    "Enter cancellation reason: ",
                    InputValidator.IsNonEmpty,
                    "Reason cannot be empty.");

                return _appointmentService.CancelAppointment(id, reason!);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static string HandleCancel(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
            return "";
        }

        private static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
