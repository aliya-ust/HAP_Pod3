using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Interfaces
{
    public interface IHealthRecordRepository
    {
        string AddHealthRecord(HealthRecord record);
        // string Delete(int recordId);
        // string Update(HealthRecord record);
        HealthRecord? GetRecordById(int id);
        List<HealthRecord> GetByPatientIdOrderByVisitDateDesc(int id);
        List<HealthRecord> GetByDoctorIdOrderByVisitDateDesc(int id);
        // List<HealthRecord> GetAll();
    }
}