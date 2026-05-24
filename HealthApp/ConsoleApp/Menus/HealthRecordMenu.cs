using System;
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
                Console.WriteLine("===================================");
                Console.WriteLine("Health Record Menu");
                Console.WriteLine("===================================");
                Console.WriteLine("1. Add Record");
                Console.WriteLine("2. View Records");
                Console.WriteLine("3. Get Summary");
                Console.WriteLine("4. Update Record");
                Console.WriteLine("5. Back");

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
                if (!int.TryParse(Console.ReadLine(), out int recordId) || recordId <= 0)
                    return "Invalid Record Id";
                record.RecordId = recordId;

                Console.Write("Enter Patient Id: ");
                if (!int.TryParse(Console.ReadLine(), out int patientId) || patientId <= 0)
                    return "Invalid Patient Id";
                record.Patient.Id = patientId;

                Console.Write("Enter Doctor Id: ");
                if (!int.TryParse(Console.ReadLine(), out int doctorId) || doctorId <= 0)
                    return "Invalid Doctor Id";
                record.Doctor.DoctorId = doctorId;

                Console.Write("Enter Visit Date (dd-MM-yyyy): ");
                if (!TryParseVisitDate(Console.ReadLine(), out DateTime visitDate, out string error))
                    return error;
                record.VisitDate = visitDate;

                Console.Write("Enter Diagnosis: ");
                string diagnosis = Console.ReadLine()?.Trim() ?? "";
                if (!IsValidTextInput(diagnosis))
                    return "Invalid diagnosis. Must contain letters.";
                record.Diagnosis = diagnosis;

                Console.Write("Enter Prescription: ");
                string prescription = Console.ReadLine()?.Trim() ?? "";
                if (!IsValidTextInput(prescription))
                    return "Invalid prescription. Must contain letters.";
                record.Prescription = prescription;

                Console.Write("Enter Doctor Notes: ");
                string notes = Console.ReadLine()?.Trim() ?? "";
                if (!IsValidTextInput(notes))
                    return "Invalid doctor notes. Must contain letters.";
                record.DoctorNotes = notes;

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

            try
            {
                if (choice == "1")
                {
                    Console.Write("Enter Patient Id: ");
                    if (!int.TryParse(Console.ReadLine(), out int patientId) || patientId <= 0)
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
                    if (!int.TryParse(Console.ReadLine(), out int doctorId) || doctorId <= 0)
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
                else
                {
                    Console.WriteLine("Invalid choice");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string GetSummary()
        {
            Console.Write("Enter Record Id: ");

            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
                return "Invalid Record Id";

            return _healthRecordService.GetByRecordId(id).GetSummary();
        }

        public string Update()
        {
            try
            {
                Console.Write("Enter Record Id: ");
                if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
                    return "Invalid Record Id";

                var existing = _healthRecordService.GetByRecordId(id);

                HealthRecord record = new HealthRecord
                {
                    RecordId = id,
                    Patient = new Patient(),
                    Doctor = new Doctor(),
                    VisitDate = existing.VisitDate
                };

                Console.Write("New Patient Id: ");
                if (!int.TryParse(Console.ReadLine(), out int pid) || pid <= 0)
                    pid = existing.Patient.Id;
                record.Patient.Id = pid;

                Console.Write("New Doctor Id: ");
                if (!int.TryParse(Console.ReadLine(), out int did) || did <= 0)
                    did = existing.Doctor.DoctorId;
                record.Doctor.DoctorId = did;

                Console.Write("New Diagnosis: ");
                string diagnosis = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(diagnosis))
                    record.Diagnosis = existing.Diagnosis;
                else if (IsValidTextInput(diagnosis))
                    record.Diagnosis = diagnosis;
                else
                    return "Invalid diagnosis input";

                Console.Write("New Prescription: ");
                string prescription = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(prescription))
                    record.Prescription = existing.Prescription;
                else if (IsValidTextInput(prescription))
                    record.Prescription = prescription;
                else
                    return "Invalid prescription input";

                Console.Write("New Doctor Notes: ");
                string notes = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(notes))
                    record.DoctorNotes = existing.DoctorNotes;
                else if (IsValidTextInput(notes))
                    record.DoctorNotes = notes;
                else
                    return "Invalid doctor notes input";

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
                error = "Invalid date format";
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

        private bool IsValidTextInput(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            foreach (char c in value)
            {
                if (char.IsLetter(c))
                    return true;
            }

            return false;
        }
    }
}