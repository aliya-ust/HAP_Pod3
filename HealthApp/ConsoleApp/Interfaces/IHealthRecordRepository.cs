using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Interfaces
{
    public interface IHealthRecordRepository
    {
        string Add(HealthRecord record);
        string Delete(int recordId);
        string Update(HealthRecord record);
        HealthRecord GetByRecordId(int recordId);
        List<HealthRecord> GetByPatientIdOrderByVisitDateDesc(int patientId);
        List<HealthRecord> GetByDoctorIdOrderByVisitDateDesc(int doctorId);
        List<HealthRecord> GetAll();
    }
}