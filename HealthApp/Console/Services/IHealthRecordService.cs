using HealthcareApp;

namespace Console.Services
{
    public interface IHealthRecordService
    {
        string AddRecord(HealthRecord record);
        List<HealthRecord> GetByPatientIdOrderByVisitDateDesc(int id);
        List<HealthRecord> GetByDoctorIdOrderByVisitDateDesc(int id);
    }
}