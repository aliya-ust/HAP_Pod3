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
            CreateHealthRecordRequest dto = new CreateHealthRecordRequest();
            
            Console.Write("Enter Record Id: ");
            dto.RecordId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Patient Id: ");
            dto.PatientId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Doctor Id: ");
            dto.DoctorId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Visit Date (dd/mm/yyyy): ");
            string visitDate = Console.ReadLine();

            Console.Write("Enter Diagnosis: ");
            dto.Diagnosis = Console.ReadLine();

            Console.Write("Enter Prescription: ");
            dto.Prescription = Console.ReadLine();

            Console.Write("Enter Doctor Notes: ");
            dto.Notes = Console.ReadLine();

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

            dto.VisitDate = visitDateParsed;

            return _healthRecordService.AddRecord(dto);
        }

        public List<HealthRecord> ViewRecord()
        {
            Console.WriteLine("1. View records by Patient Id");
            Console.WriteLine("2. View records by Doctor Id");
            Console.Write("Enter choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Patient Id: ");
                    int patientId = Convert.ToInt32(Console.ReadLine());

                    return _healthRecordService.GetByPatientIdOrderByVisitDateDesc(patientId);
                case "2":
                    Console.Write("Enter Doctor Id: ");
                    int doctorId = Convert.ToInt32(Console.ReadLine());

                    return _healthRecordService.GetByDoctorIdOrderByVisitDateDesc(doctorId);
                default: 
                    return [];
            }
        }

        public string Delete()
        {
            Console.WriteLine("Enter Record Id: ");
            int recordId = Convert.ToInt32(Console.ReadLine());

            return _healthRecordService.Delete(recordId);
        }

        public string Update()
        {
            CreateHealthRecordRequest dto = new CreateHealthRecordRequest();
            string input;

            Console.WriteLine("Enter Id of record to be updated: ");
            dto.RecordId = Console.ReadLine();

            HealthRecord record = _healthRecordService.GetByRecordId(dto.RecordId);
            Console.WriteLine(record);

            Console.WriteLine("Enter updated patient Id (Press enter if there's no change): ");
            dto.PatientId = int.TryParse(Console.ReadLine(), out int pval) ? pval : record.Patient.Id;

            Console.WriteLine("Enter updated doctor Id (Press enter if there's no change): ");
            dto.DoctorId = int.TryParse(Console.ReadLine(), out int dval) ? dval : record.Doctor.Id;

            Console.WriteLine("Enter updated diagnosis (Press enter if there's no change): ");
            dto.Diagnosis = string.IsNullOrWhiteSpace(input = Console.ReadLine()) ? record.Diagnosis : input;

            Console.WriteLine("Enter updated prescription (Press enter if there's no change): ");
            dto.Prescription = string.IsNullOrWhiteSpace(input = Console.ReadLine()) ? record.Prescription : input;

            Console.WriteLine("Enter updated prescription (Press enter if there's no change): ");
            dto.Notes = string.IsNullOrWhiteSpace(input = Console.ReadLine()) ? record.DoctorNotes : input;

            return _healthRecordService.Update(dto, record);
        }
    }
}
