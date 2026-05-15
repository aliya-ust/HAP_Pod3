using HealthcareApp;

namespace Console.Services
{
    public interface IHealthRecordService
    {
        string AddRecord(CreateHealthRecordRequest request);
        List<HealthRecord> GetByPatientIdOrderByVisitDateDesc(int id);
        List<HealthRecord> GetByDoctorIdOrderByVisitDateDesc(int id);
    }
}