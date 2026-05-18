using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Services;
using HealthApp.ConsoleApp.Interfaces;
using System;

namespace HealthApp.ConsoleApp.Menus
{
    public class HealthRecordMenu
    {
        private readonly IHealthRecordService _healthRecordService;

        public HealthRecordMenu(IHealthRecordService healthRecordService)
        {
            _healthRecordService = healthRecordService;
        }

        public string AddRecord()
        {
            HealthRecord record = new HealthRecord();

            System.Console.Clear();

            System.Console.Write("Enter Record Id: ");
            record.RecordId = Convert.ToInt32(System.Console.ReadLine());

            System.Console.Write("\nEnter Patient Id: ");
            record.Patient.Id = Convert.ToInt32(System.Console.ReadLine());

            System.Console.Write("\nEnter Doctor Id: ");
            record.Doctor.DoctorId = Convert.ToInt32(System.Console.ReadLine());

            System.Console.Write("\nEnter Visit Date (dd/mm/yyyy): ");
            string visitDate = System.Console.ReadLine();

            System.Console.Write("\nEnter Diagnosis: ");
            record.Diagnosis = System.Console.ReadLine();

            System.Console.Write("\nEnter Prescription: ");
            record.Prescription = System.Console.ReadLine();

            System.Console.Write("\nEnter Doctor Notes: ");
            record.DoctorNotes = System.Console.ReadLine();

            if (TryParseVisitDate(visitDate, out DateTime visitDateParsed, out string error))
            {
                record.VisitDate = visitDateParsed;
            }
            else
            {
                return error;
            }

            return _healthRecordService.AddRecord(record);
        }

        public void ViewRecord()
        {
            System.Console.Clear();

            System.Console.WriteLine("1. View records by Patient Id");
            System.Console.WriteLine("2. View records by Doctor Id");
            System.Console.WriteLine("3. Go back");
            System.Console.Write("Enter choice: ");

            string choice = System.Console.ReadLine();

            System.Console.Clear();

            switch (choice)
            {
                case "1":
                    {
                        System.Console.Write("Enter Patient Id: ");
                        int patientId = Convert.ToInt32(System.Console.ReadLine());

                        List<HealthRecord> records = _healthRecordService.GetByPatientIdOrderByVisitDateDesc(patientId);
                        foreach (HealthRecord r in records)
                        {
                            System.Console.WriteLine(r);
                        }
                        break;
                    }
                case "2":
                    {
                        System.Console.Write("\nEnter Doctor Id: ");
                        int doctorId = Convert.ToInt32(System.Console.ReadLine());


                        List<HealthRecord> records = _healthRecordService.GetByDoctorIdOrderByVisitDateDesc(doctorId);
                        foreach (HealthRecord r in records)
                        {
                            System.Console.WriteLine(r);
                        }
                        break;
                    }
                case "3":
                    break;

                    return _healthRecordService.GetByDoctorIdOrderByVisitDateDesc(doctorId);

                default:
                    return [];

            }
        }

        public string GetSummary()
        {
            Console.WriteLine("Enter your Record Id");
            int recordId = Convert.ToInt32(System.Console.ReadLine());

            return _healthRecordService.GetByRecordId(recordId).GetSummary();
        }

        public string Delete()
        {
            System.Console.Clear();

            System.Console.Write("Enter Record Id: ");
            int recordId = Convert.ToInt32(System.Console.ReadLine());

            return _healthRecordService.Delete(recordId);
        }

        public string Update()
        {
            System.Console.Clear();

            HealthRecord record = new HealthRecord();
            string input;

            System.Console.Write("Enter Id of record to be updated: ");
            record.RecordId = Convert.ToInt32(System.Console.ReadLine());

            HealthRecord recordToView = _healthRecordService.GetByRecordId(record.RecordId);
            System.Console.WriteLine(recordToView);

            System.Console.Write("\nEnter updated patient Id (Press enter if there's no change): ");
            record.Patient.Id = int.TryParse(System.Console.ReadLine(), out int pval) ? pval : recordToView.Patient.Id;

            System.Console.Write("\nEnter updated doctor Id (Press enter if there's no change): ");
            record.Doctor.DoctorId = int.TryParse(System.Console.ReadLine(), out int dval) ? dval : recordToView.Doctor.DoctorId;

            System.Console.Write("\nEnter updated visit date (Press enter if there's no change): ");
            input = System.Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                record.VisitDate = recordToView.VisitDate;
            }
            else
            {
                if (TryParseVisitDate(input, out DateTime parsedDate, out string error))
                {
                    record.VisitDate = parsedDate;
                }
                else
                {
                    System.Console.WriteLine(error);
                }
            }

            System.Console.Write("\nEnter updated diagnosis (Press enter if there's no change): ");
            record.Diagnosis = string.IsNullOrWhiteSpace(input = System.Console.ReadLine()) ? recordToView.Diagnosis : input;

            System.Console.Write("\nEnter updated prescription (Press enter if there's no change): ");
            record.Prescription = string.IsNullOrWhiteSpace(input = System.Console.ReadLine()) ? recordToView.Prescription : input;

            System.Console.Write("\nEnter updated prescription (Press enter if there's no change): ");
            record.DoctorNotes = string.IsNullOrWhiteSpace(input = System.Console.ReadLine()) ? recordToView.DoctorNotes : input;

            return _healthRecordService.Update(record);
        }

        public bool TryParseVisitDate(string visitDate, out DateTime result, out string error)
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
