// using HealthApp.ConsoleApp.Models;
// using HealthApp.ConsoleApp.Services;
// using HealthApp.ConsoleApp.Interfaces;
// using System;
// using System.Globalization;

// namespace HealthApp.ConsoleApp.Menus
// {
//     public class HealthRecordMenu
//     {
//         private readonly IHealthRecordService _healthRecordService;

//         public HealthRecordMenu(IHealthRecordService healthRecordService)
//         {
//             _healthRecordService = healthRecordService;
//         }

//         public string AddRecord()
//         {
//             HealthRecord record = new HealthRecord();

//             Console.Clear();

//             Console.Write("Enter Record Id: ");
//             string? input = Console.ReadLine();
//             if (string.IsNullOrWhiteSpace(input)) return "Invalid input";
//             if (!int.TryParse(input, out int recordId)) return "Invalid number";
//             record.RecordId = recordId;

//             Console.Write("\nEnter Patient Id: ");
//             input = Console.ReadLine();
//             if (string.IsNullOrWhiteSpace(input)) return "Invalid input";
//             if (!int.TryParse(input, out int patientId)) return "Invalid number";
//             record.Patient.Id = patientId;

//             Console.Write("\nEnter Doctor Id: ");
//             input = Console.ReadLine();
//             if (string.IsNullOrWhiteSpace(input)) return "Invalid input";
//             if (!int.TryParse(input, out int doctorId)) return "Invalid number";
//             record.Doctor.DoctorId = doctorId;

//             Console.Write("\nEnter Visit Date (dd/mm/yyyy): ");
//             string? visitDate = Console.ReadLine();
//             if (string.IsNullOrWhiteSpace(visitDate)) return "Invalid input";

//             Console.Write("\nEnter Diagnosis: ");
//             record.Diagnosis = Console.ReadLine();
//             if (string.IsNullOrWhiteSpace(record.Diagnosis)) return "Invalid input";

//             Console.Write("\nEnter Prescription: ");
//             record.Prescription = Console.ReadLine();
//             if (string.IsNullOrWhiteSpace(record.Prescription)) return "Invalid input";

//             Console.Write("\nEnter Doctor Notes: ");
//             record.DoctorNotes = Console.ReadLine();
//             if (string.IsNullOrWhiteSpace(record.DoctorNotes)) return "Invalid input";

//             if (!TryParseVisitDate(visitDate, out DateTime parsed, out string error))
//             {
//                 return error;
//             }

//             record.VisitDate = parsed;

//             return _healthRecordService.AddRecord(record);
//         }

//         public void ViewRecord()
//         {
//             Console.Clear();

//             Console.WriteLine("1. View records by Patient Id");
//             Console.WriteLine("2. View records by Doctor Id");
//             Console.WriteLine("3. Go back");
//             Console.Write("Enter choice: ");

//             string? choice = Console.ReadLine();

//             if (string.IsNullOrWhiteSpace(choice))
//             {
//                 Console.WriteLine("Invalid input.");
//                 Console.ReadKey();
//                 return;
//             }

//             Console.Clear();

//             switch (choice)
//             {
//                 case "1":
//                 {
//                     Console.Write("Enter Patient Id: ");
//                     string? input = Console.ReadLine();

//                     if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int patientId))
//                     {
//                         Console.WriteLine("Invalid Patient Id.");
//                         Console.ReadKey();
//                         return;
//                     }

//                     List<HealthRecord> records = _healthRecordService
//                         .GetByPatientIdOrderByVisitDateDesc(patientId);

//                     foreach (HealthRecord r in records)
//                     {
//                         Console.WriteLine(r);
//                     }

//                     Console.ReadKey();
//                     break;
//                 }

//                 case "2":
//                 {
//                     Console.Write("Enter Doctor Id: ");
//                     string? input = Console.ReadLine();

//                     if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int doctorId))
//                     {
//                         Console.WriteLine("Invalid Doctor Id.");
//                         Console.ReadKey();
//                         return;
//                     }

//                     List<HealthRecord> records = _healthRecordService
//                         .GetByDoctorIdOrderByVisitDateDesc(doctorId);

//                     foreach (HealthRecord r in records)
//                     {
//                         Console.WriteLine(r);
//                     }

//                     Console.ReadKey();
//                     break;
//                 }

//                 case "3":
//                     return;

//                 default:
//                     Console.WriteLine("Invalid choice.");
//                     Console.ReadKey();
//                     return;
//             }
//         }

//         public string GetSummary()
//         {
//             Console.Clear();
//             Console.Write("Enter your Record Id: ");

//             string? input = Console.ReadLine();

//             if (string.IsNullOrWhiteSpace(input))
//             {
//                 return "Invalid input";
//             }

//             if (!int.TryParse(input, out int recordId))
//             {
//                 return "Invalid Record Id";
//             }

//             return _healthRecordService.GetByRecordId(recordId).GetSummary();
//         }

//         public void Delete()
//         {
//             Console.Clear();

//             Console.Write("Enter Record Id: ");
//             string? input = Console.ReadLine();

//             if (string.IsNullOrWhiteSpace(input))
//             {
//                 Console.WriteLine("Invalid input");
//                 return;
//             }

//             if (!int.TryParse(input, out int recordId))
//             {
//                 Console.WriteLine("Invalid Record Id");
//                 return;
//             }

//             Console.WriteLine(_healthRecordService.Delete(recordId));
//         }

//         public string Update()
//         {
//             Console.Clear();

//             HealthRecord record = new HealthRecord();

//             Console.Write("Enter Id of record to be updated: ");
//             string? input = Console.ReadLine();

//             if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int recordId))
//             {
//                 return "Invalid Record Id";
//             }
//             record.RecordId = recordId;

//             var recordToView = _healthRecordService.GetByRecordId(recordId);
//             Console.WriteLine(recordToView);

//             Console.Write("\nEnter updated patient Id (Press enter if no change): ");
//             input = Console.ReadLine();

//             if (string.IsNullOrWhiteSpace(input))
//             {
//                 record.Patient.Id = recordToView.Patient.Id;
//             }
//             else if (!int.TryParse(input, out int pval))
//             {
//                 return "Invalid Patient Id";
//             }
//             else
//             {
//                 record.Patient.Id = pval;
//             }

//             Console.Write("\nEnter updated doctor Id (Press enter if no change): ");
//             input = Console.ReadLine();

//             if (string.IsNullOrWhiteSpace(input))
//             {
//                 record.Doctor.DoctorId = recordToView.Doctor.DoctorId;
//             }
//             else if (!int.TryParse(input, out int dval))
//             {
//                 return "Invalid Doctor Id";
//             }
//             else
//             {
//                 record.Doctor.DoctorId = dval;
//             }

//             Console.Write("\nEnter updated visit date (Press enter if no change): ");
//             input = Console.ReadLine();

//             if (string.IsNullOrWhiteSpace(input))
//             {
//                 record.VisitDate = recordToView.VisitDate;
//             }
//             else if (!TryParseVisitDate(input, out DateTime parsedDate, out string error))
//             {
//                 return error;
//             }
//             else
//             {
//                 record.VisitDate = parsedDate;
//             }

//             Console.Write("\nEnter updated diagnosis (Press enter if no change): ");
//             input = Console.ReadLine();
//             record.Diagnosis = string.IsNullOrWhiteSpace(input) ? recordToView.Diagnosis : input;

//             Console.Write("\nEnter updated prescription (Press enter if no change): ");
//             input = Console.ReadLine();
//             record.Prescription = string.IsNullOrWhiteSpace(input) ? recordToView.Prescription : input;

//             Console.Write("\nEnter updated doctor notes (Press enter if no change): ");
//             input = Console.ReadLine();
//             record.DoctorNotes = string.IsNullOrWhiteSpace(input) ? recordToView.DoctorNotes : input;

//             return _healthRecordService.Update(record);
//         }

//         public bool TryParseVisitDate(string visitDate, out DateTime result, out string error)
//         {
//             result = default;
//             error = null;

//             if (!DateTime.TryParseExact(
//                 visitDate,
//                 "dd-MM-yyyy",
//                 CultureInfo.InvariantCulture,
//                 DateTimeStyles.None,
//                 out DateTime visitDateParsed))
//             {
//                 error = "Visit date not entered in the correct format";
//                 return false;
//             }

//             if (visitDateParsed.Date > DateTime.Today)
//             {
//                 error = "Visit Date can't be in the future";
//                 return false;
//             }

//             result = visitDateParsed;
//             return true;
//         }
//     }
// }
using System;
using System.Collections.Generic;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Helpers;

namespace HealthApp.ConsoleApp.Menus
{
    
    public class HealthRecordMenu
    {
        private readonly IHealthRecordService _healthRecordService;
        private readonly IPatientService      _patientService;
        private readonly IDoctorService       _doctorService;

        // DI injects all three services
        public HealthRecordMenu(
            IHealthRecordService healthRecordService,
            IPatientService      patientService,
            IDoctorService       doctorService)
        {
            _healthRecordService = healthRecordService;
            _patientService      = patientService;
            _doctorService       = doctorService;
        }

        public void Show()
        {
            int choice;

            do
            {
                Console.WriteLine();
                Console.WriteLine("╔══════════════════════════════════════════╗");
                Console.WriteLine("║          HEALTH RECORDS MENU             ║");
                Console.WriteLine("╠══════════════════════════════════════════╣");
                Console.WriteLine("║  1. Add a Health Record (Post-Visit)     ║");
                Console.WriteLine("║  2. View Health History for a Patient    ║");
                Console.WriteLine("║  0. Back to Main Menu                    ║");
                Console.WriteLine("╚══════════════════════════════════════════╝");
                Console.Write("  Choice: ");

                if (!InputValidator.TryReadMenuChoice(out choice))
                {
                    Console.WriteLine("   Invalid input. Enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1: AddHealthRecord();    break;
                    case 2: ViewHealthHistory();  break;
                    case 0: Console.WriteLine("  Returning to main menu..."); break;
                    default:
                        Console.WriteLine("  Invalid choice. Try again.");
                        break;
                }

            } while (choice != 0);
        }

        // (7) Add a health record after a completed appointment
        
        private void AddHealthRecord()
        {
            Console.WriteLine("\n  --- Add Health Record (Post-Consultation) ---");

            // --- Patient ---
            if (!InputValidator.TryReadInt("  Patient ID  : ", out int patientId))
                return;

            Patient? patient = _patientService.GetPatientById(patientId);
            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }
            Console.WriteLine($"Patient  : {patient.GetProfileSummary()}");

            // --- Doctor ---
            if (!InputValidator.TryReadInt("  Doctor ID   : ", out int doctorId))
                return;

            Doctor? doctor = _doctorService.GetByDoctorId(doctorId);
            if (doctor == null)
            {
                Console.WriteLine(" Doctor not found.");
                return;
            }
            Console.WriteLine($"  Doctor   : {doctor.FullName} ({doctor.Specialisation})");

            // --- Diagnosis ---
            if (!InputValidator.TryReadString("  Diagnosis   : ", out string diagnosis))
                return;

            // --- Prescription ---
            if (!InputValidator.TryReadString("  Prescription: ", out string prescription))
                return;

            // // --- Notes (optional) ---
            // Console.Write("  Notes (optional, press Enter to skip): ");
            // string notes = Console.ReadLine()?.Trim() ?? string.Empty;

            var record = new HealthRecord
            {
                Patient      = patient,
                Doctor       = doctor,
                VisitDate    = DateTime.Today,   // visit date is today
                Diagnosis    = diagnosis,
                Prescription = prescription,
              //  Notes        = notes
            };

            _healthRecordService.AddRecord(record);

            Console.WriteLine("\n  Health record saved!");
            Console.WriteLine($"  {record.GetSummary()}");
            Console.WriteLine($"  Prescription : {record.Prescription}");

            // if (!string.IsNullOrWhiteSpace(record.Notes))
             //   Console.WriteLine($"  Notes        : {record.Notes}");
        }

        // (8) View health history for a patient
      
        private void ViewHealthHistory()
        {
            Console.WriteLine("\n  --- Health History for a Patient ---");

            if (!InputValidator.TryReadInt("  Patient ID: ", out int patientId))
                return;

            List<HealthRecord> records = _healthRecordService.GetByPatientIdOrderByVisitDateDesc(patientId);

            if (records.Count == 0)
            {
                Console.WriteLine("  No health records found for this patient.");
                return;
            }

            Console.WriteLine($"\n  Health history — {records.Count} record(s), most recent first:\n");

            foreach (HealthRecord r in records)
            {
                Console.WriteLine($"  {r.GetSummary()}");
                Console.WriteLine($"  Prescription : {r.Prescription}");

                // if (!string.IsNullOrWhiteSpace(r.Notes))
                //     Console.WriteLine($"  Notes        : {r.Notes}");

                // Console.WriteLine("  " + new string('─', 55));
            }
        }
    }
}
