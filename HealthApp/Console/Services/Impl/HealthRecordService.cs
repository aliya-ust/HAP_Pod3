using Console;
using Console.Services;
using HealthcareApp;

namespace Console.Services.Impl
{
    public class HealthRecordService : IHealthRecordService
    {
        // private IHealthRecordRepository _repo = new HealthRecordRepository(); Placeholder for when implemented

        //Add new record
        public string AddRecord(HealthRecord record)
        {
            
        }

        //Get records by patient ID in descending order of VisitDate
        public List<HealthRecord> GetByPatientIdOrderByVisitDateDesc(int patientId)
        {
            
        }

        //Get records by doctor ID in descending order of VisitDate
        public List<HealthRecord> GetByDoctorIdOrderByVisitDateDesc(int doctorId)
        {
            
        }
    }
}