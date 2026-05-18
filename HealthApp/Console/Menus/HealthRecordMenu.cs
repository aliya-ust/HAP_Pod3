using HealthApp.Console.Services;
using System;

namespace HealthApp.Console.Menus
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
            
            System.Console.Write("Enter Record Id: ");
            dto.RecordId = Convert.ToInt32(System.Console.ReadLine());

            System.Console.Write("Enter Patient Id: ");
            dto.PatientId = Convert.ToInt32(System.Console.ReadLine());

            System.Console.Write("Enter Doctor Id: ");
            dto.DoctorId = Convert.ToInt32(System.Console.ReadLine());

            System.Console.Write("Enter Visit Date (dd/mm/yyyy): ");
            string visitDate = System.Console.ReadLine();

            System.Console.Write("Enter Diagnosis: ");
            dto.Diagnosis = System.Console.ReadLine();

            System.Console.Write("Enter Prescription: ");
            dto.Prescription = System.Console.ReadLine();

            System.Console.Write("Enter Doctor Notes: ");
            dto.Notes = System.Console.ReadLine();

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
            }
        }

        public string Delete()
        {
            System.Console.WriteLine("Enter Record Id: ");
            int recordId = Convert.ToInt32(System.Console.ReadLine());

            return _healthRecordService.DeleteById(recordId);
        }

        public string Update()
        {
            CreateHealthRecordRequest dto = new CreateHealthRecordRequest();
            string input;

            System.Console.WriteLine("Enter Id of record to be updated: ");
            dto.RecordId = System.Console.ReadLine();

            HealthRecord record = _healthRecordService.GetById(dto.RecordId);
            System.Console.WriteLine(record);

            System.Console.WriteLine("Enter updated patient Id (Press enter if there's no change): ");
            dto.PatientId = int.TryParse(System.Console.ReadLine(), out int pval) ? pval : record.Patient.Id;

            System.Console.WriteLine("Enter updated doctor Id (Press enter if there's no change): ");
            dto.DoctorId = int.TryParse(System.Console.ReadLine(), out int dval) ? dval : record.Doctor.Id;

            System.Console.WriteLine("Enter updated diagnosis (Press enter if there's no change): ");
            dto.Diagnosis = string.IsNullOrWhiteSpace(input = System.Console.ReadLine()) ? record.Diagnosis : input;

            System.Console.WriteLine("Enter updated prescription (Press enter if there's no change): ");
            dto.Prescription = string.IsNullOrWhiteSpace(input = System.Console.ReadLine()) ? record.Prescription : input;

            System.Console.WriteLine("Enter updated prescription (Press enter if there's no change): ");
            dto.Notes = string.IsNullOrWhiteSpace(input = System.Console.ReadLine()) ? record.DoctorNotes : input;

            return _healthRecordService.Update(dto, record);
        }
    }
}
