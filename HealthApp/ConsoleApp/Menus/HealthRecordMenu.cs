using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Services;
using HealthApp.ConsoleApp.Interfaces;
using System;
using System.Globalization;

namespace HealthApp.ConsoleApp.Menus
{
    public class HealthRecordMenu
    {
        private readonly IHealthRecordService _healthRecordService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;

        public HealthRecordMenu(IHealthRecordService healthRecordService,
                                IPatientService patientService,
                                IDoctorService doctorService)
        {
            _healthRecordService = healthRecordService;
            _patientService = patientService;
            _doctorService = doctorService;
        }

        public string AddHealthRecord()
        {
            int patientId;
            int doctorId;
            DateTime visitDate;
            string? diagnosis;
            string? prescription;
            string? doctorNotes;

            Patient? patient;
            while (true)
            {
                Console.Write("Enter Patient ID (or 'q' to quit): ");
                var input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Health record creation cancelled.";

                if (int.TryParse(input, out patientId) && patientId > 0)
                {
                    patient = _patientService.GetPatientById(patientId);
                    if (patient != null)
                        break;

                    Console.WriteLine("Patient not found.");
                }
                else
                {
                    Console.WriteLine("Invalid Patient ID.");
                }
            }

            Doctor? doctor;
            while (true)
            {
                Console.Write("Enter Doctor ID (or 'q' to quit): ");
                var input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Health record creation cancelled.";

                if (int.TryParse(input, out doctorId) && doctorId > 0)
                {
                    doctor = _doctorService.GetDoctorById(doctorId);
                    if (doctor != null)
                        break;

                    Console.WriteLine("Doctor not found.");
                }
                else
                {
                    Console.WriteLine("Invalid Doctor ID.");
                }
            }

            while (true)
            {
                Console.Write("Enter Visit Date (dd/mm/yyyy) (or 'q' to quit): ");
                var input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Health record creation cancelled.";

                if (DateTime.TryParse(input, out visitDate))
                    break;

                Console.WriteLine("Invalid date format.");
            }

            while (true)
            {
                Console.Write("Enter Diagnosis (or 'q' to quit): ");
                var input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Health record creation cancelled.";

                if (!string.IsNullOrWhiteSpace(input))
                {
                    diagnosis = input.Trim();
                    break;
                }

                Console.WriteLine("Diagnosis cannot be empty.");
            }

            while (true)
            {
                Console.Write("Enter Prescription (or 'q' to quit): ");
                var input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Health record creation cancelled.";

                if (!string.IsNullOrWhiteSpace(input))
                {
                    prescription = input.Trim();
                    break;
                }

                Console.WriteLine("Prescription cannot be empty.");
            }

            while (true)
            {
                Console.Write("Enter Doctor Notes (or 'q' to quit): ");
                var input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Health record creation cancelled.";

                if (!string.IsNullOrWhiteSpace(input))
                {
                    doctorNotes = input.Trim();
                    break;
                }

                Console.WriteLine("Doctor Notes cannot be empty.");
            }

            var record = new HealthRecord
            {
                Patient = patient,
                Doctor = doctor,
                VisitDate = visitDate,
                Diagnosis = diagnosis,
                Prescription = prescription,
                DoctorNotes = doctorNotes
            };

            return _healthRecordService.AddHealthRecord(record);
        }

        public void ViewRecord()
        {
            Console.WriteLine("1. View records by Patient Id");
            Console.WriteLine("2. View records by Doctor Id");
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
                    Console.Write("Enter Patient Id: ");
                    string? input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int patientId))
                    {
                        Console.WriteLine("Invalid Patient Id.");
                        Console.ReadKey();
                        return;
                    }

                    List<HealthRecord> records = _healthRecordService
                        .GetByPatientIdOrderByVisitDateDesc(patientId);

                    foreach (HealthRecord r in records)
                    {
                        Console.WriteLine(r.GetSummary());
                    }

                    Console.ReadKey();
                    break;
                }

                case "2":
                {
                    Console.Write("Enter Doctor Id: ");
                    string? input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int doctorId))
                    {
                        Console.WriteLine("Invalid Doctor Id.");
                        Console.ReadKey();
                        return;
                    }

                    List<HealthRecord> records = _healthRecordService
                        .GetByDoctorIdOrderByVisitDateDesc(doctorId);

                    foreach (HealthRecord r in records)
                    {
                        Console.WriteLine(r.GetSummary());
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

        public string UpdateHealthRecord()
        {
            int recordId;

            Console.Write("Enter Record ID to update (or 'q' to quit): ");
            string? input = Console.ReadLine();

            if (input?.ToLower() == "q")
                return "Update cancelled.";

            if (!int.TryParse(input, out recordId) || recordId <= 0)
                return "Invalid Record ID";

            var existingRecord = _healthRecordService.GetRecordById(recordId);

            if (existingRecord == null)
                return "Record not found";

            Console.WriteLine("\nCurrent Record Details:");
            Console.WriteLine($"Patient Id: {existingRecord.Patient.PatientId}");
            Console.WriteLine($"Doctor Id: {existingRecord.Doctor.DoctorId}");
            Console.WriteLine($"Visit Date: {existingRecord.VisitDate:dd-MM-yyyy}");
            Console.WriteLine($"Diagnosis: {existingRecord.Diagnosis}");
            Console.WriteLine($"Prescription: {existingRecord.Prescription}");
            Console.WriteLine($"Doctor Notes: {existingRecord.DoctorNotes}");
            Console.WriteLine("\nPress ENTER to keep existing value.\n");

            DateTime visitDate = existingRecord.VisitDate;
            while (true)
            {
                Console.Write("Enter Visit Date (dd/mm/yyyy): ");
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    break;

                if (DateTime.TryParse(input, out DateTime parsedDate) && parsedDate <= DateTime.Today)
                {
                    visitDate = parsedDate;
                    break;
                }

                Console.WriteLine("Invalid visit date.");
            }

            Console.Write("Enter Diagnosis: ");
            input = Console.ReadLine();
            string diagnosis = string.IsNullOrWhiteSpace(input)
                ? existingRecord.Diagnosis
                : input.Trim();

            Console.Write("Enter Prescription: ");
            input = Console.ReadLine();
            string prescription = string.IsNullOrWhiteSpace(input)
                ? existingRecord.Prescription
                : input.Trim();

            Console.Write("Enter Doctor Notes: ");
            input = Console.ReadLine();
            string doctorNotes = string.IsNullOrWhiteSpace(input)
                ? existingRecord.DoctorNotes
                : input.Trim();

            var updatedRecord = new HealthRecord
            {
                RecordId = existingRecord.RecordId,
                Patient = existingRecord.Patient,
                Doctor = existingRecord.Doctor,
                VisitDate = visitDate,
                Diagnosis = diagnosis,
                Prescription = prescription,
                DoctorNotes = doctorNotes
            };

            return _healthRecordService.UpdateHealthRecord(updatedRecord).ToString();
        }

        public bool TryParseVisitDate(string visitDate, out DateTime result, out string? error)
        {
            result = default;
            error = null;

            if (!DateTime.TryParseExact(
                visitDate,
                "dd-MM-yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime visitDateParsed))
            {
                error = "Visit date not entered in the correct format";
                return false;
            }

            if (visitDateParsed.Date > DateTime.Today)
            {
                error = "Visit Date can't be in the future";
                return false;
            }

            result = visitDateParsed;
            return true;
        }
    }
}
