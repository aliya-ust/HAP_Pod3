
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
                    Console.WriteLine("  ✖  Invalid input. Enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1: AddHealthRecord();    break;
                    case 2: ViewHealthHistory();  break;
                    case 0: Console.WriteLine("  Returning to main menu..."); break;
                    default:
                        Console.WriteLine("  ✖  Invalid choice. Try again.");
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
                Console.WriteLine("  ✖  Patient not found.");
                return;
            }
            Console.WriteLine($"  ✔  Patient  : {patient.GetProfileSummary()}");

            // --- Doctor ---
            if (!InputValidator.TryReadInt("  Doctor ID   : ", out int doctorId))
                return;

            Doctor? doctor = _doctorService.GetByDoctorId(doctorId);
            if (doctor == null)
            {
                Console.WriteLine("  ✖  Doctor not found.");
                return;
            }
            Console.WriteLine($"  ✔  Doctor   : Dr. {doctor.FullName} ({doctor.Specialisation})");

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

            Console.WriteLine("\n  ✔  Health record saved!");
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
