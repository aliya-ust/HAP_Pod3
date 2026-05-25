using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Helpers;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Menus
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
        public void UpdateAppointmentMenu()
        {
            Console.Clear();

            Console.WriteLine("1.Confirm/Cancel Appointment  ");
            Console.WriteLine("2.Complete Appointment        ");

            Console.WriteLine("Enter choice :- ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ConfirmOrCancel();break;

                case "2":
                    CompleteAppointment(); break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Console.ReadKey();
                    break;
            }
        }

        // Book a new appointment for a patient with a doctor
        public void BookAppointment()
        {
            try
            {
                Console.Clear();
                PrintHeader("BOOK APPOINTMENT");
                Console.WriteLine("Type 'q' or 'back' at any prompt to return.\n");

                // Get and validate patient ID
                string rawPatient = InputValidator.GetValidatedInput(
                    "Enter Patient ID : ",
                    InputValidator.IsValidId,
                    "Please enter a valid positive number.")!;

                Patient? patient = _patientService.GetPatientById(int.Parse(rawPatient));
                if (patient == null)
                {
                    PrintError("Patient not found.");
                    Pause();
                    return;
                }
                Console.WriteLine($"\n  Patient Found : {patient.Name}");

                // Display all available doctors
                Console.WriteLine("\nAVAILABLE DOCTORS");
                Console.WriteLine(new string('-', 60));
                foreach (Doctor doc in _doctorService.GetAllDoctors())
                    Console.WriteLine($"  ID: {doc.DoctorId} | {doc.Name} | {doc.Specialisation} | " +
                                      $"Fee: Rs.{doc.ConsultationFee} | {(doc.IsActive ? "ACTIVE" : "INACTIVE")}");
                Console.WriteLine(new string('-', 60));

                // Get and validate doctor ID
                Doctor? doctor = null;
                while (true)
                {
                    string rawDoctor = InputValidator.GetValidatedInput(
                        "\nEnter Doctor ID : ",
                        InputValidator.IsValidId,
                        "Please enter a valid positive number.")!;

                    doctor = _doctorService.GetDoctorById(int.Parse(rawDoctor));
                    if (doctor == null) { PrintError("Doctor not found. Try again."); continue; }
                    if (!doctor.IsActive) { PrintError($"Dr. {doctor.Name} is inactive."); continue; }
                    Console.WriteLine($"\n  Doctor Selected : {doctor.Name}");
                    break;
                }

                // Display available dates for the selected doctor
                Console.WriteLine("\nAVAILABLE DAYS");
                for (int i = 0; i < doctor.AvailableDates.Count; i++)
                    Console.WriteLine($"  {i + 1}. {doctor.AvailableDates[i]:dd MMM yyyy}");

                // Get and validate appointment date
                DateTime selectedDate;
                while (true)
                {
                    selectedDate = InputValidator.GetValidDate(
                        "\nEnter Appointment Date (dd/MM/yyyy) : ");

                    if (selectedDate.Date < DateTime.Today)
                    { PrintError("Date cannot be in the past."); continue; }
                    if (!doctor.AvailableDates.Any(d => d.Date == selectedDate.Date))
                    { PrintError("Doctor is not available on that date."); continue; }
                    break;
                }

                // Find and display remaining available slots
                var bookedSlots = _appointmentService
                    .GetAppointmentsByDoctorId(doctor.DoctorId)
                    .Where(a => a.ScheduledDate.Date == selectedDate.Date &&
                                a.Status != AppointmentStatus.Cancelled)
                    .Select(a => a.TimeSlot).ToList();

                var availableSlots = doctor.AvailableSlots.Except(bookedSlots).ToList();

                if (availableSlots.Count == 0)
                {
                    PrintError("No slots available on that date. Try a different date.");
                    Pause();
                    return;
                }

                Console.WriteLine("\nAVAILABLE SLOTS");
                for (int i = 0; i < availableSlots.Count; i++)
                    Console.WriteLine($"  {i + 1}. {availableSlots[i]}");

                // Get and validate slot selection
                string selectedSlot = "";
                while (true)
                {
                    string rawSlot = InputValidator.GetValidatedInput(
                        "\nChoose Slot number : ",
                        InputValidator.IsValidId,
                        "Please enter a valid positive number.")!;

                    int slotChoice = int.Parse(rawSlot);
                    if (slotChoice < 1 || slotChoice > availableSlots.Count)
                    { PrintError($"Enter a number between 1 and {availableSlots.Count}."); continue; }

                    selectedSlot = availableSlots[slotChoice - 1];
                    break;
                }

                // Show confirmation summary before booking
                Console.WriteLine("\n  CONFIRM APPOINTMENT");
                Console.WriteLine(new string('-', 34));
                Console.WriteLine($"  Patient : {patient.Name}");
                Console.WriteLine($"  Doctor  : {doctor.Name}");
                Console.WriteLine($"  Date    : {selectedDate:dd MMM yyyy}");
                Console.WriteLine($"  Slot    : {selectedSlot}");
                Console.Write("\n  Proceed? (Y/N) : ");

                if (Console.ReadLine()?.Trim().ToUpper() != "Y")
                {
                    Console.WriteLine("\n  Booking cancelled.");
                    Pause();
                    return;
                }

                // Book the appointment
                var result = _appointmentService.BookAppointment(
                    patient, doctor, selectedDate, selectedSlot);

                PrintSuccess("Appointment booked successfully!");
                Console.WriteLine($"\n{result}");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\nReturning to Main Menu...");
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
            }

            Pause();
        }

        // View all appointments for a specific patient
        public void ViewPatientAppointments()
        {
            try
            {
                Console.Clear();
                PrintHeader("VIEW PATIENT APPOINTMENTS");
                Console.WriteLine("Type 'q' or 'back' to return.\n");

                // Get and validate patient ID
                string raw = InputValidator.GetValidatedInput(
                    "Enter Patient ID : ",
                    InputValidator.IsValidId,
                    "Please enter a valid positive number.")!;

                var appointments = _appointmentService.GetAppointmentsByPatientId(int.Parse(raw));

                if (appointments.Count == 0)
                {
                    PrintError($"No appointments found for patient ID {raw}.");
                    Pause();
                    return;
                }

                Console.WriteLine();
                foreach (var appt in appointments)
                {
                    Console.WriteLine(appt.GetDetails());
                    Console.WriteLine(new string('-', 36));
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\nReturning to Main Menu...");
            }

            Pause();
        }

        // Confirm or cancel an upcoming appointment
        public void ConfirmOrCancel()
        {
            try
            {
                Console.Clear();
                PrintHeader("CONFIRM / CANCEL APPOINTMENT");

                // Display all upcoming appointments
                var appointments = _appointmentService.GetUpcomingAppointments();
                if (appointments.Count == 0)
                {
                    PrintError("No upcoming appointments.");
                    Pause();
                    return;
                }

                Console.WriteLine();
                foreach (var appt in appointments)
                {
                    Console.WriteLine(appt.GetDetails());
                    Console.WriteLine(new string('-', 32));
                }

                // Get and validate appointment ID
                string raw = InputValidator.GetValidatedInput(
                    "\nEnter Appointment ID : ",
                    InputValidator.IsValidId,
                    "Please enter a valid positive number.")!;

                Appointment appointment = _appointmentService.GetAppointmentById(int.Parse(raw));

                // Get action — confirm or cancel
                Console.Write("\n[C] Confirm   [X] Cancel : ");
                string action = Console.ReadLine()?.Trim().ToUpper() ?? "";

                if (action == "C")
                {
                    appointment.Confirm();
                    PrintSuccess("Appointment confirmed.");
                }
                else if (action == "X")
                {
                    // Get cancellation reason
                    string reason = InputValidator.GetValidatedInput(
                        "Reason for cancellation : ",
                        InputValidator.IsNonEmpty,
                        "Reason cannot be empty.") ?? "No reason given";

                    _appointmentService.CancelAppointment(appointment.AppointmentId, reason);
                    PrintSuccess("Appointment cancelled.");
                }
                else
                {
                    PrintError("Invalid action. Enter C or X.");
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\nReturning to Main Menu...");
            }
            catch (AppointmentNotFoundException ex)
            {
                PrintError(ex.Message);
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
            }

            Pause();
        }

        // Mark a confirmed appointment as completed so a health record can be added
        public void CompleteAppointment()
        {
            try
            {
                Console.Clear();
                PrintHeader("COMPLETE APPOINTMENT");

                // Display all confirmed upcoming appointments
                var confirmed = _appointmentService.GetUpcomingAppointments()
                    .Where(a => a.Status == AppointmentStatus.Confirmed).ToList();

                if (confirmed.Count == 0)
                {
                    PrintError("No confirmed appointments to complete.");
                    Pause();
                    return;
                }

                Console.WriteLine();
                foreach (var appt in confirmed)
                {
                    Console.WriteLine(appt.GetDetails());
                    Console.WriteLine(new string('-', 32));
                }

                // Get and validate appointment ID
                string raw = InputValidator.GetValidatedInput(
                    "\nEnter Appointment ID to complete : ",
                    InputValidator.IsValidId,
                    "Please enter a valid positive number.")!;

                Appointment appointment = _appointmentService.GetAppointmentById(int.Parse(raw));

                // Mark the appointment as completed
                appointment.Complete();
                PrintSuccess($"Appointment {raw} marked as Completed. You can now add a health record.");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\nReturning to Main Menu...");
            }
            catch (AppointmentNotFoundException ex)
            {
                PrintError(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                PrintError(ex.Message);
            }

            Pause();
        }

        // ── Helpers ──────────────────────────────────────────────────────────────

        private static void PrintHeader(string t)
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine(t);
            Console.WriteLine(new string('=', 40));
        }

        private static void PrintError(string m)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nERROR : {m}");
            Console.ResetColor();
        }

        private static void PrintSuccess(string m)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nSUCCESS : {m}");
            Console.ResetColor();
        }

        private static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(intercept: true);
        }
    }
}