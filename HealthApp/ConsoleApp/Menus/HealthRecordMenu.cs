using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Helpers;

namespace HealthApp.ConsoleApp.Menus
{
    public class HealthRecordMenu
    {
        private readonly IHealthRecordService _healthRecordService;
        private readonly IAppointmentService  _appointmentService;

        public HealthRecordMenu(IHealthRecordService healthRecordService,
                                IAppointmentService appointmentService)
        {
            _healthRecordService = healthRecordService;
            _appointmentService  = appointmentService;
        }

        // Add a health record linked to a completed appointment
        public void AddHealthRecord()
        {
            try
            {
                Console.Clear();
                PrintHeader("ADD HEALTH RECORD");
                Console.WriteLine("Type 'q' or 'back' to return.\n");

                // Show all completed appointments so user knows valid IDs
                var completed = _appointmentService
                    .GetUpcomingAppointments()
                    .Where(a => a.Status == AppointmentStatus.Completed)
                    .ToList();

                // Also check ALL appointments (including past) for completed ones
                // GetUpcomingAppointments only returns future — completed ones are past
                // so we need to get all and filter
                var allCompleted = _appointmentService
                    .GetAllAppointments()
                    .Where(a => a.Status == AppointmentStatus.Completed)
                    .ToList();

                if (allCompleted.Count == 0)
                {
                    PrintError("No completed appointments found. " +
                               "Please complete an appointment first (option 7).");
                    Pause();
                    return;
                }

                Console.WriteLine("COMPLETED APPOINTMENTS");
                Console.WriteLine(new string('-', 40));
                foreach (var a in allCompleted)
                {
                    Console.WriteLine($"  ID: {a.AppointmentId} | " +
                                      $"Patient: {a.Patient?.Name} | " +
                                      $"Doctor: {a.Doctor?.Name} | " +
                                      $"Date: {a.ScheduledDate:dd MMM yyyy}");
                }
                Console.WriteLine(new string('-', 40) + "\n");

                // Get and validate appointment ID
                string rawId = InputValidator.GetValidatedInput(
                    "Enter Appointment ID : ",
                    InputValidator.IsValidId,
                    "Please enter a valid positive number.")!;

                int appointmentId = int.Parse(rawId);

                // Fetch appointment — catches AppointmentNotFoundException
                Appointment? appointment;
                try
                {
                    appointment = _appointmentService.GetAppointmentById(appointmentId);
                }
                catch (AppointmentNotFoundException)
                {
                    PrintError($"No appointment found with ID {appointmentId}.");
                    Pause();
                    return;
                }

                // FIX: Do NOT call Complete() here — appointment must already be Completed
                // Complete() is called from AppointmentMenu.CompleteAppointment() (option 7)
                // Calling it here throws InvalidOperationException if already Completed
                if (appointment?.Status != AppointmentStatus.Completed)
                {
                    PrintError($"Appointment {appointmentId} is not completed yet. " +
                               $"Current status: {appointment?.Status}. " +
                               "Please use option 6 to mark it as completed first.");
                    Pause();
                    return;
                }

                // Get diagnosis
                string diagnosis = InputValidator.GetValidatedInput(
                    "Diagnosis    : ",
                    InputValidator.IsNonEmpty,
                    "Diagnosis cannot be empty.")!;

                // Get prescription
                string prescription = InputValidator.GetValidatedInput(
                    "Prescription : ",
                    InputValidator.IsNonEmpty,
                    "Prescription cannot be empty.")!;

                // Get doctor notes
                string doctorNotes = InputValidator.GetValidatedInput(
                    "Doctor Notes : ",
                    InputValidator.IsNonEmpty,
                    "Doctor notes cannot be empty.")!;

                // Build and save the health record
                var record = new HealthRecord
                {
                    Patient      = appointment.Patient,
                    Doctor       = appointment.Doctor,
                    VisitDate    = appointment.ScheduledDate,
                    Diagnosis    = diagnosis,
                    Prescription = prescription,
                    DoctorNotes  = doctorNotes
                };

                string result = _healthRecordService.AddHealthRecord(record);
                PrintSuccess(result);
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

        // View health records by patient, doctor, or record ID
        public void ViewRecord()
        {
            try
            {
                Console.Clear();
                PrintHeader("VIEW HEALTH RECORDS");
                Console.WriteLine("Type 'q' or 'back' to return.\n");

                Console.WriteLine("  1. By Patient ID");
                Console.WriteLine("  2. By Doctor ID");
                Console.WriteLine("  3. By Record ID");
                Console.Write("\nEnter choice : ");

                string choice = Console.ReadLine()?.Trim() ?? "";

                switch (choice)
                {
                    case "1":
                        ViewByEntity("Patient",
                            _healthRecordService.GetByPatientIdOrderByVisitDateDesc);
                        break;

                    case "2":
                        ViewByEntity("Doctor",
                            _healthRecordService.GetByDoctorIdOrderByVisitDateDesc);
                        break;

                    case "3":
                        ViewSingleRecord();
                        break;

                    default:
                        PrintError("Invalid choice.");
                        break;
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\nReturning to Main Menu...");
            }

            Pause();
        }

        // Update an existing health record's fields
        public void UpdateHealthRecord()
        {
            try
            {
                Console.Clear();
                PrintHeader("UPDATE HEALTH RECORD");
                Console.WriteLine("Type 'q' or 'back' to return.\n");

                // Get and validate record ID
                string rawId = InputValidator.GetValidatedInput(
                    "Enter Record ID : ",
                    InputValidator.IsValidId,
                    "Please enter a valid positive number.")!;

                HealthRecord existing;
                try
                {
                    existing = _healthRecordService.GetRecordById(int.Parse(rawId))!;
                }
                catch (HealthRecordNotFoundException ex)
                {
                    PrintError(ex.Message);
                    Pause();
                    return;
                }

                // Show current record before editing
                Console.WriteLine("\nCurrent Record:");
                Console.WriteLine(existing.GetSummary());
                Console.WriteLine("\nPress ENTER to keep existing value.\n");

                // Get optional updated visit date
                DateTime? dateInput = InputValidator.GetOptionalDate(
                    "Visit Date (dd/MM/yyyy) : ");

                // Get optional updated diagnosis
                string? diagnosis = InputValidator.GetValidatedInput(
                    "Diagnosis    : ",
                    InputValidator.IsNonEmpty,
                    "Invalid input.",
                    allowEmpty: true);

                // Get optional updated prescription
                string? prescription = InputValidator.GetValidatedInput(
                    "Prescription : ",
                    InputValidator.IsNonEmpty,
                    "Invalid input.",
                    allowEmpty: true);

                // Get optional updated doctor notes
                string? doctorNotes = InputValidator.GetValidatedInput(
                    "Doctor Notes : ",
                    InputValidator.IsNonEmpty,
                    "Invalid input.",
                    allowEmpty: true);

                // Build updated record keeping old values where user pressed Enter
                var updated = new HealthRecord
                {
                    RecordId     = existing.RecordId,
                    Patient      = existing.Patient,
                    Doctor       = existing.Doctor,
                    VisitDate    = dateInput     ?? existing.VisitDate,
                    Diagnosis    = diagnosis     ?? existing.Diagnosis,
                    Prescription = prescription  ?? existing.Prescription,
                    DoctorNotes  = doctorNotes   ?? existing.DoctorNotes
                };

                string result = _healthRecordService.UpdateHealthRecord(updated).GetSummary();
                PrintSuccess("Record updated successfully!");
                Console.WriteLine(result);
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

        // ── Private helpers ───────────────────────────────────────────────────────

        // Fetch and display a list of records by patient or doctor ID
        private static void ViewByEntity(string entityName,
            Func<int, List<HealthRecord>> fetchFunc)
        {
            try
            {
                string rawId = InputValidator.GetValidatedInput(
                    $"Enter {entityName} ID : ",
                    InputValidator.IsValidId,
                    "Please enter a valid positive number.")!;

                var records = fetchFunc(int.Parse(rawId));

                if (records.Count == 0)
                {
                    Console.WriteLine($"No records found for {entityName} ID {rawId}.");
                    return;
                }

                Console.WriteLine($"\n  {records.Count} record(s) found:\n");
                foreach (var r in records)
                {
                    Console.WriteLine(r.GetSummary());
                    Console.WriteLine(new string('-', 50));
                }
            }
            catch (PatientNotFoundException ex)      { Console.WriteLine(ex.Message); }
            catch (DoctorNotFoundException ex)       { Console.WriteLine(ex.Message); }
            catch (HealthRecordNotFoundException ex) { Console.WriteLine(ex.Message); }
        }

        // Fetch and display a single record by record ID
        private void ViewSingleRecord()
        {
            try
            {
                string rawId = InputValidator.GetValidatedInput(
                    "Enter Record ID : ",
                    InputValidator.IsValidId,
                    "Please enter a valid positive number.")!;

                var record = _healthRecordService.GetRecordById(int.Parse(rawId));

                Console.WriteLine();
                Console.WriteLine(record!.GetSummary());
            }
            catch (HealthRecordNotFoundException ex) { Console.WriteLine(ex.Message); }
        }

        private static void PrintHeader(string title)
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine(title);
            Console.WriteLine(new string('=', 40));
            Console.WriteLine();
        }

        private static void PrintSuccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nSUCCESS : {msg}");
            Console.ResetColor();
        }

        private static void PrintError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nERROR : {msg}");
            Console.ResetColor();
        }

        private static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(intercept: true);
        }
    }
}