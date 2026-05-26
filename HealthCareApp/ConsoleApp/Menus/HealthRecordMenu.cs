using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Services;
using HealthApp.ConsoleApp.Interfaces;
using System;
using System.Globalization;
using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Helpers;

namespace HealthApp.ConsoleApp.Menus
{
    public class HealthRecordMenu
    {
        private readonly IHealthRecordService _healthRecordService;
        private readonly IAppointmentService _appointmentService;

        public const string Continue = "\nPress any key to continue...";
        public const string HealthRecordCancelled = "Health record creation cancelled.";


        public HealthRecordMenu(IHealthRecordService healthRecordService,
                                IAppointmentService appointmentService)
        {
            _healthRecordService = healthRecordService;
            _appointmentService = appointmentService;
        }

        public string AddHealthRecord()
        {
            try
            {

                var appointmentIdInput = InputValidator.GetValidatedInput(
                    "Enter Appointment ID (or 'q' to quit): ",
                    InputValidator.IsValidId,
                    "Invalid Appointment ID.");

                int appointmentId = int.Parse(appointmentIdInput!);

                var appointment = _appointmentService.GetAppointmentById(appointmentId);
                if (appointment == null)
                    return "Appointment not found";

                appointment.Complete();

                var diagnosis = InputValidator.GetValidatedInput(
                    "Enter Diagnosis: ",
                    InputValidator.IsNonEmpty,
                    "Diagnosis cannot be empty.");

                var prescription = InputValidator.GetValidatedInput(
                    "Enter Prescription: ",
                    InputValidator.IsNonEmpty,
                    "Prescription cannot be empty.");

                var doctorNotes = InputValidator.GetValidatedInput(
                    "Enter Doctor Notes: ",
                    InputValidator.IsNonEmpty,
                    "Doctor Notes cannot be empty.");

                var record = new HealthRecord
                {
                    Patient = appointment.Patient,
                    Doctor = appointment.Doctor,
                    VisitDate = appointment.ScheduledDate,
                    Diagnosis = diagnosis!,
                    Prescription = prescription!,
                    DoctorNotes = doctorNotes!
                };

                string result = _healthRecordService.AddHealthRecord(record);

                // ✅ Return formatted SUCCESS message
                return $"SUCCESS : {result}";
            }
            catch (OperationCanceledException)
            {
                return "Operation Canceled";
            }
            catch (InvalidOperationException)
            {
                return "Cannot add health record for an appointment that's not been confirmed";
            }
        }

        public void ViewRecord()
        {

            Console.WriteLine("1. By Patient Id");
            Console.WriteLine("2. By Doctor Id");
            Console.WriteLine("3. By Record Id");
            Console.Write("Enter choice: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    HandleViewById("Patient", _healthRecordService.GetByPatientIdOrderByVisitDateDesc);
                    break;

                case "2":
                    HandleViewById("Doctor", _healthRecordService.GetByDoctorIdOrderByVisitDateDesc);
                    break;

                case "3":
                    HandleViewSingleRecord();
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    Console.ReadKey();
                    break;
            }
        }

        private static void HandleViewById(
            string entityName,
            Func<int, List<HealthRecord>> fetchFunc)
        {
            try
            {
                var idInput = InputValidator.GetValidatedInput(
                    $"Enter {entityName} Id: ",
                    InputValidator.IsValidId,
                    $"Invalid {entityName} Id.");

                int id = int.Parse(idInput!);

                var records = fetchFunc(id);

                Console.WriteLine("Health Records:");

                foreach (var r in records)
                    Console.WriteLine(r);
            }
            catch (PatientNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (HealthRecordNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void HandleViewSingleRecord()
        {
            try
            {
                var idInput = InputValidator.GetValidatedInput(
                    "Enter Record Id: ",
                    InputValidator.IsValidId,
                    "Invalid Record Id.");

                int recordId = int.Parse(idInput!);

                var record = _healthRecordService.GetRecordById(recordId);

                Console.WriteLine(record);
            }
            catch (HealthRecordNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string UpdateHealthRecord()
        {
            try
            {
                Console.Write("Enter Record ID (or 'q' to quit): ");
                var input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return HandleCancel();

                if (!int.TryParse(input, out int recordId) || recordId <= 0)
                    return "Invalid Record ID";

                var existing = _healthRecordService.GetRecordById(recordId);
                if (existing == null)
                    return "Record not found";

                Console.WriteLine("\nCurrent Record:");
                Console.WriteLine(existing);

                var dateInput = InputValidator.GetOptionalDate(
                    "Enter Visit Date (dd/MM/yyyy): ");

                var diagnosisInput = InputValidator.GetValidatedInput(
                    "Enter Diagnosis (Press ENTER to keep): ",
                    InputValidator.IsNonEmpty,
                    "Invalid diagnosis.",
                    allowEmpty: true);

                var prescriptionInput = InputValidator.GetValidatedInput(
                    "Enter Prescription (Press ENTER to keep): ",
                    InputValidator.IsNonEmpty,
                    "Invalid prescription.",
                    allowEmpty: true);

                var notesInput = InputValidator.GetValidatedInput(
                    "Enter Doctor Notes (Press ENTER to keep): ",
                    InputValidator.IsNonEmpty,
                    "Invalid notes.",
                    allowEmpty: true);

                var updated = new HealthRecord
                {
                    RecordId = existing.RecordId,
                    Patient = existing.Patient,
                    Doctor = existing.Doctor,
                    VisitDate = dateInput ?? existing.VisitDate,
                    Diagnosis = diagnosisInput ?? existing.Diagnosis,
                    Prescription = prescriptionInput ?? existing.Prescription,
                    DoctorNotes = notesInput ?? existing.DoctorNotes
                };

                return _healthRecordService.UpdateHealthRecord(updated).ToString();
            }
            catch (OperationCanceledException)
            {
                return HandleCancel();
            }
            catch (HealthRecordNotFoundException ex)
            {
                return ex.Message;
            }
        }


        private static string HandleCancel()
        {
            Console.WriteLine(HealthRecordCancelled);
            Console.WriteLine(Continue);
            Console.ReadKey();
            return "";
        }
    }
}