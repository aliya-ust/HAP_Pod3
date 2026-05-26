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

        public void BookAppointment()
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

                Console.WriteLine($"\nPatient Found: {patient.FullName}");

                Console.WriteLine("\nAvailable Doctors:");
                Console.WriteLine(new string('-', 50));

                var doctors = _doctorService.GetAllDoctors();

                foreach (var doc in doctors.Where(d => d.IsActive))
                {
                    Console.WriteLine(
                        $"ID: {doc.DoctorId} | {doc.FullName} | {doc.Specialisation} | " +
                        $"Fee: Rs.{doc.ConsultationFee}"
                    );
                }

                Console.WriteLine(new string('-', 50));

                Doctor doctor;
                while (true)
                {
                    var doctorIdInput = InputValidator.GetValidatedInput(
                        "\nEnter Doctor ID: ",
                        InputValidator.IsValidId,
                        "Invalid Doctor ID.");

                    int doctorId = int.Parse(doctorIdInput!);

                    doctor = _doctorService.GetDoctorById(doctorId);

                    if (!doctor.IsActive)
                    {
                        Console.WriteLine($"Doctor {doctor.FullName} is inactive.");
                        continue;
                    }

                    Console.WriteLine($"\nDoctor Selected: {doctor.FullName}");
                    break;
                }

                Console.WriteLine("\n=== Available Dates ===\n");

                for (int i = 0; i < doctor.AvailableDates.Count; i++)
                {
                    Console.WriteLine($"  [{i + 1}] {doctor.AvailableDates[i]:ddd, dd MMM yyyy}");
                }

                DateTime selectedDate;

                while (true)
                {
                    selectedDate = InputValidator.GetValidDate(
                        "\nEnter Appointment Date (dd/MM/yyyy): ");

                    if (selectedDate.Date < DateTime.Today)
                    {
                        Console.WriteLine("Date cannot be in the past.");
                        continue;
                    }

                    if (!doctor.AvailableDates.Any(d => d.Date == selectedDate.Date))
                    {
                        Console.WriteLine("Doctor is not available on this date.");
                        continue;
                    }

                    break;
                }

                List<string> bookedSlots = new();

                try
                {
                    var appointments = _appointmentService.GetAppointmentsByDoctorId(doctor.DoctorId);

                    bookedSlots = appointments
                        .Where(a => a.ScheduledDate.Date == selectedDate.Date &&
                                    a.Status != AppointmentStatus.Cancelled)
                        .Select(a => a.TimeSlot)
                        .ToList();
                }
                catch (AppointmentNotFoundException) {}

                var availableSlots = doctor.AvailableSlots
                    .Except(bookedSlots)
                    .ToList();

                if (availableSlots.Count == 0)
                    Console.WriteLine("No slots available on selected date.");

                Console.WriteLine("\nAvailable Slots:");

                for (int i = 0; i < availableSlots.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {availableSlots[i]}");
                }

                string selectedSlot;

                while (true)
                {
                    var slotInput = InputValidator.GetValidatedInput(
                        "\nChoose slot number: ",
                        InputValidator.IsValidId,
                        "Invalid input.");

                    int choice = int.Parse(slotInput!);

                    if (choice < 1 || choice > availableSlots.Count)
                    {
                        Console.WriteLine($"Enter a number between 1 and {availableSlots.Count}");
                        continue;
                    }

                    selectedSlot = availableSlots[choice - 1];
                    break;
                }

                Console.WriteLine("\n--- Confirm Appointment ---");
                Console.WriteLine($"Patient : {patient.FullName}");
                Console.WriteLine($"Doctor  : {doctor.FullName}");
                Console.WriteLine($"Date    : {selectedDate:dd MMM yyyy}");
                Console.WriteLine($"Slot    : {selectedSlot}");

                Console.Write("\nProceed? (Y/N): ");
                if (Console.ReadLine()?.Trim().ToUpper() != "Y")
                    Console.WriteLine("Booking cancelled.");

                Console.WriteLine(_appointmentService.BookAppointment(
                    patient,
                    doctor,
                    selectedDate,
                    selectedSlot
                ));
            }
            catch (PatientNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return; 
            }
            catch (DoctorNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            catch (OperationCanceledException)
            {
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
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

        private Appointment? SelectAppointment()
        {
            try
            {
                Console.Clear();

                var appointments = _appointmentService.GetUpcomingAppointments();

                if (appointments.Count == 0)
                {
                    Console.WriteLine("No upcoming appointments.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return null;
                }

                Console.WriteLine("\nUpcoming Appointments:\n");

                foreach (var appt in appointments)
                {
                    Console.WriteLine(appt.GetDetails());
                    Console.WriteLine(new string('-', 32));
                }

                var input = InputValidator.GetValidatedInput(
                    "\nEnter Appointment ID: ",
                    InputValidator.IsValidId,
                    "Invalid Appointment ID.");

                int id = int.Parse(input!);

                return _appointmentService.GetAppointmentById(id);
            }
            catch (AppointmentNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return null;
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
                var appointment = SelectAppointment();

                if (appointment == null)
                    return "No appointment selected.";

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
                var appointment = SelectAppointment();

                if (appointment == null)
                    return "No appointment selected.";

                var reason = InputValidator.GetValidatedInput(
                    "Enter cancellation reason: ",
                    InputValidator.IsNonEmpty,
                    "Reason cannot be empty.");

                return _appointmentService.CancelAppointment(
                    appointment.AppointmentId,
                    reason!
                );
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
