using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthCareApi.Services.Interfaces
{
    public interface IHealthRecordService
    {
        Task<HealthRecord> AddHealthRecordAsync(HealthRecord record);
        Task<IEnumerable<vw_PatientHealthHistory>> GetPatientHealthHistoryAsync(
            int patientId,
            int pageNumber = 1,
            int pageSize = 10);
    }
}