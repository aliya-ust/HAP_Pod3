using HealthCare.Shared.DTOs.HealthRecord;
using HealthCare.Api.Models;

namespace HealthCare.Api.Repositories.Interfaces
{
    public interface IHealthRecordRepository : IRepository<HealthRecord>
    {
        Task<List<HealthRecordListDto>> GetHealthRecordByPatient(int id);
        Task<List<HealthRecordListDto>> GetHealthRecordByAppointment(int id);
    }
}