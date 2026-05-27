using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Helpers;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Menus
{
    // Menu class to handle all appointment-related user interactions
    public class AppointmentMenu
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        // Constructor to inject required services for appointments, patients, and doctors
        private const string InvalidPositiveNumberMessage = "Please enter a valid positive number.";

        private const string ReturnToMainMenuMessage = "\nReturning to Main Menu...";
        public AppointmentMenu(IAppointmentService appointmentService,
                               IPatientService patientService,
                               IDoctorService doctorService)
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
            _doctorService = doctorService;
        }
        // Sub-menu to choose between confirm/cancel or complete
        public void UpdateAppointmentMenu()
        {

            Console.WriteLine("1.Confirm/Cancel Appointment  ");
            Console.WriteLine("2.Complete Appointment        ");

            Console.WriteLine("Enter choice :- ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ConfirmOrCancel(); break;

                case "2":
                    CompleteAppointment(); break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Console.ReadKey();
                    break;
            }
        }

        //// Book a new appointment for a patient with a chosen doctor and slot
        public void BookAppointment()
        {
            try
            {
                PrintHeader("BOOK APPOINTMENT");
                Console.WriteLine("Type 'q' or 'back' at any prompt to return.\n");

                // Get and validate patient ID
                string rawPatient = InputValidator.GetValidatedInput(
                    "Enter Patient ID : ",
                    InputValidator.IsValidId,
                    InvalidPositiveNumberMessage)!;

                Patient? patient = _patientService.GetPatientById(int.Parse(rawPatient));
                if (patient == null)
                {
                    PrintError("Patient not found.");
                    Pause();
                    return;
                }
                Console.WriteLine($"\n  Patient Found : {patient.Name}");

                // Display all available doctors for selection
                Console.WriteLine("\nAVAILABLE DOCTORS");
                Console.WriteLine(new string('-', 60));
                foreach (Doctor doc in _doctorService.GetAllDoctors())
                    Console.WriteLine($"  ID: {doc.DoctorId} | {doc.Name} | {doc.Specialisation} | " +
                                      $"Fee: Rs.{doc.ConsultationFee} | {(doc.IsActive ? "ACTIVE" : "INACTIVE")}");
                Console.WriteLine(new string('-', 60));

                // Get and validate doctor ID with active check
                Doctor? doctor = null;
                while (true)
                {
                    string rawDoctor = InputValidator.GetValidatedInput(
                        "\nEnter Doctor ID : ",
                        InputValidator.IsValidId,
                        InvalidPositiveNumberMessage)!;

                    doctor = _doctorService.GetDoctorById(int.Parse(rawDoctor));
                    if (doctor == null) { PrintError("Doctor not found. Try again."); continue; }
                    if (!doctor.IsActive) { PrintError($"Dr. {doctor.Name} is inactive."); continue; }
                    Console.WriteLine($"\n  Doctor Selected : {doctor.Name}");
                    break;
                }

                // Show doctor's available dates
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

                // Calculate which slots are still free
                var bookedSlots = _appointmentService
                    .GetAllAppointments()
                    .Where(a => a.ScheduledDate.Date == selectedDate.Date &&
                                a.Status != AppointmentStatus.Cancelled)
                    .Select(a => a.TimeSlot).ToList();

                var freeSlots = doctor.AvailableSlots.Except(bookedSlots).ToList();

                if (freeSlots.Count == 0)
                {
                    PrintError("No slots available on that date. Try a different date.");
                    Pause();
                    return;
                }

                // Display free slots for selection
                Console.WriteLine("\n  AVAILABLE SLOTS");
                Console.WriteLine("  " + new string('─', 25));
                for (int i = 0; i < freeSlots.Count; i++)
                    Console.WriteLine($"    {i + 1}.  {freeSlots[i]}");
                Console.WriteLine("  " + new string('─', 25));

                // Get and validate slot choice
                string selectedSlot = "";
                while (true)
                {
                    string rawSlot = InputValidator.GetValidatedInput(
                        "\nChoose Slot number : ",
                        InputValidator.IsValidId,
                        InvalidPositiveNumberMessage)!;

                    int idx = int.Parse(rawSlot);
                    if (idx < 1 || idx > freeSlots.Count)
                    { PrintError($"Enter a number between 1 and {freeSlots.Count}."); continue; }

                    selectedSlot = freeSlots[idx - 1];
                    break;
                }

                // show booking summary for confirmation
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

                // save the appointment
                var appt = _appointmentService.BookAppointment(
                    patient, doctor, selectedDate, selectedSlot);

                PrintSuccess("Appointment booked successfully!");
                Console.WriteLine($"\n{appt}");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine(ReturnToMainMenuMessage);
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
                PrintHeader("VIEW PATIENT APPOINTMENTS");
                Console.WriteLine("Type 'q' or 'back' to return.\n");

                // Get and validate patient ID
                string raw = InputValidator.GetValidatedInput(
                    "Enter Patient ID : ",
                    InputValidator.IsValidId,
                    InvalidPositiveNumberMessage)!;

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
                Console.WriteLine("  " + new string('─', 50));
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine(ReturnToMainMenuMessage);
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
            }

            Pause();
        }

        // Confirm or cancel a pending/confirmed upcoming appointment
        public void ConfirmOrCancel()
        {
            try
            {
                PrintHeader("CONFIRM / CANCEL APPOINTMENT");

                // Display all upcoming appointments
                var upcoming = _appointmentService.GetUpcomingAppointments();
                if (upcoming.Count == 0)
                {
                    PrintError("No upcoming appointments.");
                    Pause();
                    return;
                }

                Console.WriteLine($"  {upcoming.Count} upcoming appointment(s):\n");
                foreach (var a in upcoming)
                {
                    Console.WriteLine("  " + new string('─', 50));
                    Console.WriteLine(a.GetDetails());
                }
                Console.WriteLine("  " + new string('─', 50));

                // Get and validate appointment ID
                string raw = InputValidator.GetValidatedInput(
                    "\nEnter Appointment ID : ",
                    InputValidator.IsValidId,
                    InvalidPositiveNumberMessage)!;

                Appointment? appointment = _appointmentService.GetAppointmentById(int.Parse(raw));

                if (appointment == null)
                {
                    PrintError("Appointment not found.");
                    Pause();
                    return;
                }

                // choose action
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
                        "Reason cannot be empty.")!;

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
                Console.WriteLine(ReturnToMainMenuMessage);
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
                PrintHeader("COMPLETE APPOINTMENT");
                // Show only confirmed appointments eligible for completion
                var confirmed = _appointmentService.GetUpcomingAppointments()
                    .Where(a => a.Status == AppointmentStatus.Confirmed).ToList();

                if (confirmed.Count == 0)
                {
                    PrintError("No confirmed appointments to complete.");
                    Pause();
                    return;
                }

                Console.WriteLine();
                foreach (var a in confirmed)
                {
                    Console.WriteLine("  " + new string('─', 50));
                    Console.WriteLine(a.GetDetails());
                    
                }
                Console.WriteLine("  " + new string('─', 50));


                // Get and validate appointment ID
                string raw = InputValidator.GetValidatedInput(
                    "\nEnter Appointment ID to complete : ",
                    InputValidator.IsValidId,
                    InvalidPositiveNumberMessage)!;

                Appointment? appointment = _appointmentService.GetAppointmentById(int.Parse(raw));

                if (appointment == null)
                {
                    PrintError("Appointment not found.");
                    Pause();
                    return;
                }

                // Mark as completed — enables health record creation
                appointment.Complete();
                PrintSuccess($"Appointment {raw} marked as Completed.");
                Console.WriteLine("  You can now add a health record via option 7.");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine(ReturnToMainMenuMessage);
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

        private static void PrintHeader(string title)
        {
            Console.WriteLine($"\n  ╔══════════════════════════════════════════════════╗");
            Console.WriteLine($"  ║  {title,-48}║");
            Console.WriteLine($"  ╚══════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
        }


        private static void PrintError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{msg}");
            Console.ResetColor();
        }

        private static void PrintSuccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{msg}");
            Console.ResetColor();
        }

        private static void Pause()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n  Press any key to continue...");
            Console.ResetColor();
            Console.ReadKey(intercept: true);
        }
    }
}
