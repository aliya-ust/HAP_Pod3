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
            Console.Clear();
            Console.WriteLine("  ╔══════════════════════════════════╗");
            Console.WriteLine("  ║     UPDATE APPOINTMENT STATUS    ║");
            Console.WriteLine("  ╠══════════════════════════════════╣");
            Console.WriteLine("  ║  1.  Confirm / Cancel            ║");
            Console.WriteLine("  ║  2.  Mark as Completed           ║");
            Console.WriteLine("  ║  3.  Back                        ║");
            Console.WriteLine("  ╚══════════════════════════════════╝");
            Console.Write("\n  Choose an option : ");

            switch (Console.ReadLine()?.Trim() ?? "")
            {
                case "1": ConfirmOrCancel(); break;
                case "2": CompleteAppointment(); break;
                case "3": return;
                default:
                    PrintError("Invalid choice.");
                    Thread.Sleep(800);
                    break;
            }
        }

        // Book a new appointment for a patient with a chosen doctor and slot
        public void BookAppointment()
        {
            try
            {
                Console.Clear();
                PrintHeader("BOOK APPOINTMENT");
                Console.WriteLine("  Type 'q' or 'back' at any prompt to return.\n");

                // Get and validate patient ID
                string rawPatient = InputValidator.GetValidatedInput(
                    "  Enter Patient ID : ",
                    InputValidator.IsValidId,
                    "  Please enter a valid positive number.")!;

                var patient = _patientService.GetPatientById(int.Parse(rawPatient));
                if (patient == null)
                {
                    PrintError($"No patient found with ID {rawPatient}.");
                    Pause();
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n     Patient : {patient.Name}");
                Console.ResetColor();

                // Display all doctors for selection
                Console.WriteLine("\n  AVAILABLE DOCTORS");
                Console.WriteLine("  " + new string('─', 65));
                foreach (var doc in _doctorService.GetAllDoctors())
                    Console.WriteLine($"  [{doc.DoctorId}]  {doc.Name}  |  {doc.Specialisation}  |  " +
                                      $"Rs.{doc.ConsultationFee}  |  " +
                                      $"{(doc.IsActive ? "ACTIVE" : "INACTIVE")}");
                Console.WriteLine("  " + new string('─', 65));

                // Get and validate doctor ID with active check
                Doctor? doctor = null;
                while (true)
                {
                    string rawDoctor = InputValidator.GetValidatedInput(
                        "\n  Enter Doctor ID : ",
                        InputValidator.IsValidId,
                        "  Please enter a valid positive number.")!;

                    doctor = _doctorService.GetDoctorById(int.Parse(rawDoctor));
                    if (doctor == null) { PrintError("Doctor not found. Try again."); continue; }
                    if (!doctor.IsActive) { PrintError($"Dr. {doctor.Name} is inactive."); continue; }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n     Doctor : {doctor.Name}  ({doctor.Specialisation})");
                    Console.ResetColor();
                    break;
                }

                // Show doctor's available dates
                Console.WriteLine("\n  AVAILABLE DAYS");
                Console.WriteLine("  " + new string('─', 30));
                for (int i = 0; i < doctor.AvailableDates.Count; i++)
                    Console.WriteLine($"    {i + 1}.  {doctor.AvailableDates[i]:dd/MM/yyyy  ddd}");
                Console.WriteLine("  " + new string('─', 30));

                // Get and validate appointment date
                DateTime selectedDate;
                while (true)
                {
                    selectedDate = InputValidator.GetValidDate(
                        "\n  Appointment Date (dd/MM/yyyy) : ");

                    if (selectedDate.Date < DateTime.Today)
                    { PrintError("Date cannot be in the past."); continue; }

                    if (!doctor.AvailableDates.Any(d => d.Date == selectedDate.Date))
                    { PrintError("Doctor not available on that date. Choose from the list."); continue; }

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
                        "\n  Choose slot number : ",
                        InputValidator.IsValidId,
                        "  Please enter a valid positive number.")!;

                    int idx = int.Parse(rawSlot);
                    if (idx < 1 || idx > freeSlots.Count)
                    { PrintError($"Enter a number between 1 and {freeSlots.Count}."); continue; }

                    selectedSlot = freeSlots[idx - 1];
                    break;
                }

                // Show booking summary for confirmation
                Console.WriteLine("\n  " + new string('─', 40));
                Console.WriteLine("  BOOKING SUMMARY");
                Console.WriteLine("  " + new string('─', 40));
                Console.WriteLine($"  Patient : {patient.Name}");
                Console.WriteLine($"  Doctor  : {doctor.Name}  ({doctor.Specialisation})");
                Console.WriteLine($"  Date    : {selectedDate:dd/MM/yyyy}");
                Console.WriteLine($"  Slot    : {selectedSlot}");
                Console.WriteLine("  " + new string('─', 40));
                Console.Write("\n  Confirm booking? (Y/N) : ");

                if (Console.ReadLine()?.Trim().ToUpper() != "Y")
                {
                    Console.WriteLine("\n  Booking cancelled.");
                    Pause();
                    return;
                }

                // Save the appointment
                var appt = _appointmentService.BookAppointment(
                    patient, doctor, selectedDate, selectedSlot);

                PrintSuccess("Appointment booked successfully!");
                Console.WriteLine($"\n{appt}");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\n  Returning to menu...");
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
                PrintHeader("PATIENT APPOINTMENTS");
                Console.WriteLine("  Type 'q' or 'back' to return.\n");

                // Get and validate patient ID
                string raw = InputValidator.GetValidatedInput(
                    "  Enter Patient ID : ",
                    InputValidator.IsValidId,
                    "  Please enter a valid positive number.")!;

                var appointments = _appointmentService.GetAppointmentsByPatientId(int.Parse(raw));

                if (appointments.Count == 0)
                {
                    PrintError($"No appointments found for patient ID {raw}.");
                    Pause();
                    return;
                }

                Console.WriteLine($"\n  {appointments.Count} appointment(s) found:\n");

                foreach (var appt in appointments)
                {
                    Console.WriteLine("  " + new string('─', 50));
                    Console.WriteLine(appt);
                }

                Console.WriteLine("  " + new string('─', 50));
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\n  Returning to menu...");
            }

            Pause();
        }

        // Confirm or cancel a pending/confirmed upcoming appointment
        public void ConfirmOrCancel()
        {
            try
            {
                Console.Clear();
                PrintHeader("CONFIRM / CANCEL APPOINTMENT");

                // Show all upcoming appointments
                var upcoming = _appointmentService.GetUpcomingAppointments();

                if (upcoming.Count == 0)
                {
                    PrintError("No upcoming appointments found.");
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
                    "\n  Enter Appointment ID : ",
                    InputValidator.IsValidId,
                    "  Please enter a valid positive number.")!;

                var appointment = _appointmentService.GetAppointmentById(int.Parse(raw));

                // Choose action
                Console.Write("\n  [C] Confirm   [X] Cancel : ");
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
                        "  Reason for cancellation : ",
                        InputValidator.IsNonEmpty,
                        "  Reason cannot be empty.")!;

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
                Console.WriteLine("\n  Returning to menu...");
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

                // Show only confirmed appointments eligible for completion
                var confirmed = _appointmentService.GetUpcomingAppointments()
                    .Where(a => a.Status == AppointmentStatus.Confirmed).ToList();

                if (confirmed.Count == 0)
                {
                    PrintError("No confirmed appointments to complete.");
                    Pause();
                    return;
                }

                Console.WriteLine($"  {confirmed.Count} confirmed appointment(s):\n");
                foreach (var a in confirmed)
                {
                    Console.WriteLine("  " + new string('─', 50));
                    Console.WriteLine(a.GetDetails());
                }
                Console.WriteLine("  " + new string('─', 50));

                // Get and validate appointment ID
                string raw = InputValidator.GetValidatedInput(
                    "\n  Enter Appointment ID : ",
                    InputValidator.IsValidId,
                    "  Please enter a valid positive number.")!;

                var appointment = _appointmentService.GetAppointmentById(int.Parse(raw));

                // Mark as completed — enables health record creation
                appointment.Complete();
                PrintSuccess($"Appointment {raw} marked as Completed.");
                Console.WriteLine("  You can now add a health record via option 7.");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\n  Returning to menu...");
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

        //  Helpers

        private static void PrintHeader(string title)
        {
            Console.WriteLine($"\n  ╔══════════════════════════════════════════════════╗");
            Console.WriteLine($"  ║  {title,-48}║");
            Console.WriteLine($"  ╚══════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
        }

        private static void PrintSuccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{msg}");
            Console.ResetColor();
        }

        private static void PrintError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
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