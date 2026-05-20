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
            int recordId;
            int patientId;
            int doctorId;
            DateTime visitDate;
            string? diagnosis;
            string? prescription;
            string? doctorNotes;

            while (true)
            {
                Console.Write("Enter Record ID (or 'q' to quit): ");
                var input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    return "Health record creation cancelled.";

                if (int.TryParse(input, out recordId) && recordId > 0)
                    break;

                Console.WriteLine("Invalid Record ID.");
            }

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
                Console.Write("Enter Visit Date (dd-mm-yyyy) (or 'q' to quit): ");
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
                RecordId = recordId,
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
                        Console.WriteLine(r);
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
                        Console.WriteLine(r);
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

        // public string GetSummary()
        // {
        //     Console.Clear();
        //     Console.Write("Enter your Record Id: ");

        //     string? input = Console.ReadLine();

        //     if (string.IsNullOrWhiteSpace(input))
        //     {
        //         return "Invalid input";
        //     }

        //     if (!int.TryParse(input, out int recordId))
        //     {
        //         return "Invalid Record Id";
        //     }

        //     return _healthRecordService.GetByRecordId(recordId).GetSummary();
        // }

        // public void Delete()
        // {
        //     Console.Clear();

        //     Console.Write("Enter Record Id: ");
        //     string? input = Console.ReadLine();

        //     if (string.IsNullOrWhiteSpace(input))
        //     {
        //         Console.WriteLine("Invalid input");
        //         return;
        //     }

        //     if (!int.TryParse(input, out int recordId))
        //     {
        //         Console.WriteLine("Invalid Record Id");
        //         return;
        //     }

        //     Console.WriteLine(_healthRecordService.Delete(recordId));
        // }

        // public string Update()
        // {
        //     Console.Clear();

        //     HealthRecord record = new HealthRecord();

        //     Console.Write("Enter Id of record to be updated: ");
        //     string? input = Console.ReadLine();

        //     if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int recordId))
        //     {
        //         return "Invalid Record Id";
        //     }
        //     record.RecordId = recordId;

        //     var recordToView = _healthRecordService.GetByRecordId(recordId);
        //     Console.WriteLine(recordToView);

        //     Console.Write("\nEnter updated patient Id (Press enter if no change): ");
        //     input = Console.ReadLine();

        //     if (string.IsNullOrWhiteSpace(input))
        //     {
        //         record.Patient.Id = recordToView.Patient.Id;
        //     }
        //     else if (!int.TryParse(input, out int pval))
        //     {
        //         return "Invalid Patient Id";
        //     }
        //     else
        //     {
        //         record.Patient.Id = pval;
        //     }

        //     Console.Write("\nEnter updated doctor Id (Press enter if no change): ");
        //     input = Console.ReadLine();

        //     if (string.IsNullOrWhiteSpace(input))
        //     {
        //         record.Doctor.DoctorId = recordToView.Doctor.DoctorId;
        //     }
        //     else if (!int.TryParse(input, out int dval))
        //     {
        //         return "Invalid Doctor Id";
        //     }
        //     else
        //     {
        //         record.Doctor.DoctorId = dval;
        //     }

        //     Console.Write("\nEnter updated visit date (Press enter if no change): ");
        //     input = Console.ReadLine();

        //     if (string.IsNullOrWhiteSpace(input))
        //     {
        //         record.VisitDate = recordToView.VisitDate;
        //     }
        //     else if (!TryParseVisitDate(input, out DateTime parsedDate, out string error))
        //     {
        //         return error;
        //     }
        //     else
        //     {
        //         record.VisitDate = parsedDate;
        //     }

        //     Console.Write("\nEnter updated diagnosis (Press enter if no change): ");
        //     input = Console.ReadLine();
        //     record.Diagnosis = string.IsNullOrWhiteSpace(input) ? recordToView.Diagnosis : input;

        //     Console.Write("\nEnter updated prescription (Press enter if no change): ");
        //     input = Console.ReadLine();
        //     record.Prescription = string.IsNullOrWhiteSpace(input) ? recordToView.Prescription : input;

        //     Console.Write("\nEnter updated doctor notes (Press enter if no change): ");
        //     input = Console.ReadLine();
        //     record.DoctorNotes = string.IsNullOrWhiteSpace(input) ? recordToView.DoctorNotes : input;

        //     return _healthRecordService.Update(record);
        // }

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
