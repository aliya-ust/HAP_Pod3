using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Interfaces
{
    public interface IHealthRecordService
    {
        string AddHealthRecord(HealthRecord record);
        // string Update(HealthRecord record);
        // string Delete(int recordId);
        HealthRecord? GetRecordById(int recordId);
        List<HealthRecord> GetByPatientIdOrderByVisitDateDesc(int id);
        List<HealthRecord> GetByDoctorIdOrderByVisitDateDesc(int id);
    }
}