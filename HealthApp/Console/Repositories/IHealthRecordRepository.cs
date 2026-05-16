using System.Collections.Generic;
using HealthcareApp.Console.Models;

namespace HealthcareApp.Repository
{
    public interface IHealthRecordRepository
    {
        string Add(HealthRecord record);
        string Delete(int recordId);
        string Update(HealthRecord record);
        HealthRecord GetByPatientIdOrderByVisitDateDesc(int patientId);
        HealthRecord GetByDoctorIdOrderByVisitDateDesc(int doctorId);
        HealthRecord GetByRecordId(int recordId);
        List<HealthRecord> GetAll();
    }
}