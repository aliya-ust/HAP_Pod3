using HealthCare.Api.DTOs.HealthRecord;
using HealthCare.Api.Models;

namespace HealthCare.Api.Repositories.Interfaces
{
    public interface IHealthRecordRepository : IRepository<HealthRecord>
    {
        Task<List<HealthRecordListDto>> GetPatientHealthRecords(int patientId);
        Task<List<HealthRecordListDto>> GetHealthRecordByAppointment(int id);
    }
}