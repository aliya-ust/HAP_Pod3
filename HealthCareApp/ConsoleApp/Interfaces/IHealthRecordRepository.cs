using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Interfaces
{
    // Repository interface for managing health records
    public interface IHealthRecordRepository
    {
        string AddHealthRecord(HealthRecord record);
        HealthRecord? GetRecordById(int id);
        List<HealthRecord> GetByPatientIdOrderByVisitDateDesc(int id);
        List<HealthRecord> GetByDoctorIdOrderByVisitDateDesc(int id);
        HealthRecord UpdateHealthRecord(HealthRecord existingHealthRecord, HealthRecord record);
        List<HealthRecord> GetAllRecords();
    }
}