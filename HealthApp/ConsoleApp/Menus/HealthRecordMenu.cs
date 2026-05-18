using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Services;
using System;

namespace HealthApp.ConsoleApp.Menus
{
    public class HealthRecordMenu
    {
        private readonly IHealthRecordService _healthRecordService;

        public HealthRecordMenu (IHealthRecordService healthRecordService)
        {
            _healthRecordService = healthRecordService;
        }

        public string AddRecord()
        {
            HealthRecord record = new HealthRecord();
            
            System.Console.Write("Enter Record Id: ");
            record.RecordId = Convert.ToInt32(System.Console.ReadLine());

            System.Console.Write("Enter Patient Id: ");
            record.Patient.Id = Convert.ToInt32(System.Console.ReadLine());

            System.Console.Write("Enter Doctor Id: ");
            record.Doctor.DoctorId = Convert.ToInt32(System.Console.ReadLine());

            System.Console.Write("Enter Visit Date (dd/mm/yyyy): ");
            string visitDate = System.Console.ReadLine();

            System.Console.Write("Enter Diagnosis: ");
            record.Diagnosis = System.Console.ReadLine();

            System.Console.Write("Enter Prescription: ");
            record.Prescription = System.Console.ReadLine();

            System.Console.Write("Enter Doctor Notes: ");
            record.DoctorNotes = System.Console.ReadLine();

            if (!DateTime.TryParseExact(
                visitDate,
                "dd-MM-yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime visitDateParsed
            ))
            {
                return "Visit date not entered in the correct format";
            } 

            if (visitDateParsed.Date > DateTime.Today)
            {
                return "Visit Date can't be in the future";
            }

            record.VisitDate = visitDateParsed;

            return _healthRecordService.AddRecord(record);
        }

        public List<HealthRecord> ViewRecord()
        {
            System.Console.WriteLine("1. View records by Patient Id");
            System.Console.WriteLine("2. View records by Doctor Id");
            System.Console.Write("Enter choice: ");

            string choice = System.Console.ReadLine();

            switch (choice)
            {
                case "1":
                    System.Console.Write("Enter Patient Id: ");
                    int patientId = Convert.ToInt32(System.Console.ReadLine());

                    return _healthRecordService.GetByPatientIdOrderByVisitDateDesc(patientId);
                case "2":
                    System.Console.Write("Enter Doctor Id: ");
                    int doctorId = Convert.ToInt32(System.Console.ReadLine());

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
            System.Console.WriteLine("Enter Record Id: ");
            int recordId = Convert.ToInt32(System.Console.ReadLine());

            return _healthRecordService.Delete(recordId);
        }

        public string Update()
        {
            HealthRecord record = new HealthRecord();
            string input;

            System.Console.WriteLine("Enter Id of record to be updated: ");
            record.RecordId = Convert.ToInt32(System.Console.ReadLine());

            HealthRecord recordToView = _healthRecordService.GetByRecordId(record.RecordId);
            System.Console.WriteLine(recordToView);

            System.Console.WriteLine("Enter updated patient Id (Press enter if there's no change): ");
            record.Patient.Id = int.TryParse(System.Console.ReadLine(), out int pval) ? pval : recordToView.Patient.Id;

            System.Console.WriteLine("Enter updated doctor Id (Press enter if there's no change): ");
            record.Doctor.DoctorId = int.TryParse(System.Console.ReadLine(), out int dval) ? dval : recordToView.Doctor.DoctorId;

            System.Console.WriteLine("Enter updated diagnosis (Press enter if there's no change): ");
            record.Diagnosis = string.IsNullOrWhiteSpace(input = System.Console.ReadLine()) ? recordToView.Diagnosis : input;

            System.Console.WriteLine("Enter updated prescription (Press enter if there's no change): ");
            record.Prescription = string.IsNullOrWhiteSpace(input = System.Console.ReadLine()) ? recordToView.Prescription : input;

            System.Console.WriteLine("Enter updated prescription (Press enter if there's no change): ");
            record.DoctorNotes = string.IsNullOrWhiteSpace(input = System.Console.ReadLine()) ? recordToView.DoctorNotes : input;

            return _healthRecordService.Update(record);
        }
    }
}
