using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Services
{
    public interface IHealthRecordService
    {
        string AddRecord(CreateHealthRecordRequest request);
        string Update(CreateHealthRecordRequest dto, HealthRecord record);
        HealthRecord GetByRecordId(int recordId);
        List<HealthRecord> GetByPatientIdOrderByVisitDateDesc(int id);
        List<HealthRecord> GetByDoctorIdOrderByVisitDateDesc(int id);
    }
}