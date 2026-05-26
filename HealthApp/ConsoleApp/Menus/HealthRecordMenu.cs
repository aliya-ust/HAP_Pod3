using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Helpers;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Menus
{
    // Menu class to handle all health record-related user interactions
    public class HealthRecordMenu
    {
        private readonly IHealthRecordService _healthRecordService;
        private readonly IAppointmentService _appointmentService;
        // Constructor to inject required services for health record management and appointments
        public HealthRecordMenu(IHealthRecordService healthRecordService,
                                IAppointmentService appointmentService)
        {
            _healthRecordService = healthRecordService;
            _appointmentService = appointmentService;
        }

        // Add a health record tied to a completed appointment
        public void AddHealthRecord()
        {
            try
            {
                Console.Clear();
                PrintHeader("ADD HEALTH RECORD");
                Console.WriteLine("  Type 'q' or 'back' to return.\n");

                // Show all completed appointments to help user find the right ID
                var allCompleted = _appointmentService.GetAllAppointments()
                    .Where(a => a.Status == AppointmentStatus.Completed).ToList();

                if (allCompleted.Count == 0)
                {
                    PrintError("No completed appointments found.");
                    Console.WriteLine("  Use option 6 → Mark as Completed first.");
                    Pause();
                    return;
                }

                Console.WriteLine("  COMPLETED APPOINTMENTS");
                Console.WriteLine("  " + new string('─', 60));
                foreach (var a in allCompleted)
                    Console.WriteLine($"  [{a.AppointmentId}]  {a.Patient.Name}  →  " +
                                      $"Dr. {a.Doctor.Name}  |  {a.ScheduledDate:dd MMM yyyy}");
                Console.WriteLine("  " + new string('─', 60) + "\n");

                // Get and validate appointment ID
                string rawId = InputValidator.GetValidatedInput(
                    "  Enter Appointment ID : ",
                    InputValidator.IsValidId,
                    "  Please enter a valid positive number.")!;

                Appointment appointment;
                appointment = _appointmentService.GetAppointmentById(int.Parse(rawId));

                // Validate the appointment is actually completed
                if (appointment.Status != AppointmentStatus.Completed)
                {
                    PrintError($"Appointment {rawId} status is '{appointment.Status}'.");
                    Console.WriteLine("  Use option 6 → Mark as Completed before adding a record.");
                    Pause();
                    return;
                }

                // Get diagnosis
                string diagnosis = InputValidator.GetValidatedInput(
                    "  Diagnosis    : ",
                    InputValidator.IsValidDiagnosis,
                    "  Diagnosis cannot be empty.")!;

                // Get prescription
                string prescription = InputValidator.GetValidatedInput(
                    "  Prescription : ",
                    InputValidator.IsValidPrescription,
                    "  Prescription cannot be empty.")!;

                // Get doctor notes
                string doctorNotes = InputValidator.GetValidatedInput(
                    "  Doctor Notes : ",
                    InputValidator.IsValidDoctorNotes,
                    "  Doctor notes cannot be empty.")!;

                // Build and persist the health record
                var record = new HealthRecord
                {
                    Patient = appointment.Patient,
                    Doctor = appointment.Doctor,
                    VisitDate = appointment.ScheduledDate,
                    Diagnosis = diagnosis,
                    Prescription = prescription,
                    DoctorNotes = doctorNotes
                };

                string result = _healthRecordService.AddHealthRecord(record);
                PrintSuccess(result);
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

        // View health records by patient, doctor, or record ID
        public void ViewRecord()
        {
            try
            {
                Console.Clear();
                PrintHeader("VIEW HEALTH RECORDS");
                Console.WriteLine("  Type 'q' or 'back' to return.\n");
                Console.WriteLine("  ╔══════════════════════════════╗");
                Console.WriteLine("  ║  1.  By Patient ID           ║");
                Console.WriteLine("  ║  2.  By Doctor ID            ║");
                Console.WriteLine("  ║  3.  By Record ID            ║");
                Console.WriteLine("  ║  4.  Back                    ║");
                Console.WriteLine("  ╚══════════════════════════════╝");
                Console.Write("\n  Choose an option : ");

                switch (Console.ReadLine()?.Trim() ?? "")
                {
                    case "1":
                        ViewByEntity("Patient", _healthRecordService.GetByPatientIdOrderByVisitDateDesc);
                        break;
                    case "2":
                        ViewByEntity("Doctor", _healthRecordService.GetByDoctorIdOrderByVisitDateDesc);
                        break;
                    case "3":
                        ViewSingleRecord();
                        break;
                    case "4":
                        return;
                    default:
                        PrintError("Invalid choice.");
                        break;
                }
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

        // Update an existing health record keeping old values where not changed
        public void UpdateHealthRecord()
        {
            try
            {
                Console.Clear();
                PrintHeader("UPDATE HEALTH RECORD");
                Console.WriteLine("  Type 'q' or 'back' to return.\n");

                // Get and validate record ID
                string rawId = InputValidator.GetValidatedInput(
                    "  Enter Record ID : ",
                    InputValidator.IsValidId,
                    "  Please enter a valid positive number.")!;

                HealthRecord existing;
                existing = _healthRecordService.GetRecordById(int.Parse(rawId))!;
                // Show current record before editing
                Console.WriteLine("\n  Current Record:");
                Console.WriteLine("  " + new string('─', 55));
                Console.WriteLine($"  {existing.GetSummary()}");
                Console.WriteLine("  " + new string('─', 55));
                Console.WriteLine("\n  Press ENTER to keep existing value.\n");

                // Get optional updated fields
                DateTime? newDate = InputValidator.GetOptionalDate(
                    "  Visit Date (dd/MM/yyyy) : ");

                string? newDiagnosis = InputValidator.GetValidatedInput(
                    "  Diagnosis    : ",
                    InputValidator.IsValidDiagnosis,
                    "  Invalid input.", allowEmpty: true);

                string? newPrescription = InputValidator.GetValidatedInput(
                    "  Prescription : ",
                    InputValidator.IsValidPrescription,
                    "  Invalid input.", allowEmpty: true);

                string? newNotes = InputValidator.GetValidatedInput(
                    "  Doctor Notes : ",
                    InputValidator.IsValidDoctorNotes,
                    "  Invalid input.", allowEmpty: true);

                // Build updated record — fall back to existing values where unchanged
                var updated = new HealthRecord
                {
                    RecordId = existing.RecordId,
                    Patient = existing.Patient,
                    Doctor = existing.Doctor,
                    VisitDate = newDate ?? existing.VisitDate,
                    Diagnosis = newDiagnosis ?? existing.Diagnosis,
                    Prescription = newPrescription ?? existing.Prescription,
                    DoctorNotes = newNotes ?? existing.DoctorNotes
                };

                var result = _healthRecordService.UpdateHealthRecord(updated);
                PrintSuccess("Record updated successfully!");
                Console.WriteLine($"  {result.GetSummary()}");
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


        // Fetch and display records by patient or doctor ID
        private static void ViewByEntity(string entityName, Func<int, List<HealthRecord>> fetch)
        {
            try
            {
                string rawId = InputValidator.GetValidatedInput(
                    $"  Enter {entityName} ID : ",
                    InputValidator.IsValidId,
                    "  Please enter a valid positive number.")!;

                var records = fetch(int.Parse(rawId));

                Console.WriteLine($"\n  {records.Count} record(s) found:\n");

                foreach (var r in records)
                {
                    Console.WriteLine("  " + new string('─', 55));
                    Console.WriteLine($"  {r.GetSummary()}");
                }

                Console.WriteLine("  " + new string('─', 55));
            }
            catch (Exception ex) { PrintError(ex.Message); }

            static void PrintError(string m)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n {m}");
                Console.ResetColor();
            }
        }

        // Fetch and display a single record by record ID
        private void ViewSingleRecord()
        {
            try
            {
                string rawId = InputValidator.GetValidatedInput(
                    "  Enter Record ID : ",
                    InputValidator.IsValidId,
                    "  Please enter a valid positive number.")!;

                var record = _healthRecordService.GetRecordById(int.Parse(rawId));

                Console.WriteLine("\n  " + new string('─', 55));
                Console.WriteLine($"  {record!.GetSummary()}");
                Console.WriteLine("  " + new string('─', 55));
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
            }
        }
        // Helpers
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