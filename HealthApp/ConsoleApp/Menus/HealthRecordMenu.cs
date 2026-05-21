using System;
using System.Collections.Generic;
using System.Globalization;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Menus
{
    public class HealthRecordMenu
    {
        private readonly IHealthRecordService _healthRecordService;

        public HealthRecordMenu(IHealthRecordService healthRecordService)
        {
            _healthRecordService = healthRecordService;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("----- Health Record Menu -----");
                Console.WriteLine("1. Add Record");
                Console.WriteLine("2. View Records");
                Console.WriteLine("3. Get Summary");
                Console.WriteLine("4. Update Record");
                Console.WriteLine("5. Delete Record");
                Console.WriteLine("6. Back");

                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine(AddRecord());
                        break;
                    case 2:
                        ViewRecord();
                        break;
                    case 3:
                        Console.WriteLine(GetSummary());
                        break;
                    case 4:
                        Console.WriteLine(Update());
                        break;
                    case 5:
                        Delete();
                        break;
                    case 6:
                        return;
                }

                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }
        }

        public string AddRecord()
        {
            try
            {
                HealthRecord record = new HealthRecord
                {
                    Patient = new Patient(),
                    Doctor = new Doctor()
                };

                Console.Write("Enter Record Id: ");
                if (!int.TryParse(Console.ReadLine(), out int recordId))
                    return "Invalid Record Id";
                record.RecordId = recordId;

                Console.Write("Enter Patient Id: ");
                if (!int.TryParse(Console.ReadLine(), out int patientId))
                    return "Invalid Patient Id";
                record.Patient.Id = patientId;

                Console.Write("Enter Doctor Id: ");
                if (!int.TryParse(Console.ReadLine(), out int doctorId))
                    return "Invalid Doctor Id";
                record.Doctor.DoctorId = doctorId;

                Console.Write("Enter Visit Date (dd-MM-yyyy): ");
                string dateInput = Console.ReadLine();

                if (!TryParseVisitDate(dateInput, out DateTime visitDate, out string error))
                    return error;

                record.VisitDate = visitDate;

                Console.Write("Enter Diagnosis: ");
                record.Diagnosis = Console.ReadLine();

                Console.Write("Enter Prescription: ");
                record.Prescription = Console.ReadLine();

                Console.Write("Enter Doctor Notes: ");
                record.DoctorNotes = Console.ReadLine();

                return _healthRecordService.AddRecord(record);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public void ViewRecord()
        {
            Console.WriteLine("1. By Patient Id");
            Console.WriteLine("2. By Doctor Id");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter Patient Id: ");
                if (!int.TryParse(Console.ReadLine(), out int patientId))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                var records = _healthRecordService.GetByPatientIdOrderByVisitDateDesc(patientId);

                if (records.Count == 0)
                {
                    Console.WriteLine("No records found");
                    return;
                }

                foreach (var r in records)
                    Console.WriteLine(r);
            }
            else if (choice == "2")
            {
                Console.Write("Enter Doctor Id: ");
                if (!int.TryParse(Console.ReadLine(), out int doctorId))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                var records = _healthRecordService.GetByDoctorIdOrderByVisitDateDesc(doctorId);

                if (records.Count == 0)
                {
                    Console.WriteLine("No records found");
                    return;
                }

                foreach (var r in records)
                    Console.WriteLine(r);
            }
        }

        public string GetSummary()
        {
            Console.Write("Enter Record Id: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
                return "Invalid Record Id";

            return _healthRecordService.GetByRecordId(id).GetSummary();
        }

        public void Delete()
        {
            Console.Write("Enter Record Id: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Console.WriteLine(_healthRecordService.Delete(id));
        }

        public string Update()
        {
            try
            {
                Console.Write("Enter Record Id: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                    return "Invalid Record Id";

                var existing = _healthRecordService.GetByRecordId(id);

                HealthRecord record = new HealthRecord
                {
                    RecordId = id,
                    Patient = new Patient(),
                    Doctor = new Doctor()
                };

                Console.Write("New Patient Id: ");
                if (!int.TryParse(Console.ReadLine(), out int pid))
                    pid = existing.Patient.Id;

                record.Patient.Id = pid;

                Console.Write("New Doctor Id: ");
                if (!int.TryParse(Console.ReadLine(), out int did))
                    did = existing.Doctor.DoctorId;

                record.Doctor.DoctorId = did;

                record.VisitDate = existing.VisitDate;
                record.Diagnosis = existing.Diagnosis;
                record.Prescription = existing.Prescription;
                record.DoctorNotes = existing.DoctorNotes;

                return _healthRecordService.Update(record);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool TryParseVisitDate(string input, out DateTime result, out string error)
        {
            result = default;
            error = "";

            if (!DateTime.TryParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime parsed))
            {
                error = "Invalid date format (dd-MM-yyyy required)";
                return false;
            }

            if (parsed > DateTime.Today)
            {
                error = "Future date not allowed";
                return false;
            }

            result = parsed;
            return true;
        }
    }
}
