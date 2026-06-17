using HealthCare.Api.Models;

namespace HealthCare.Api.Repositories.Interfaces
{
    public interface IHealthRecordRepository : IRepository<HealthRecord>
    {
        Task<HealthRecord?> GetByAppointmentIdAsync(
            int appointmentId,
            CancellationToken ct = default);

        Task<List<HealthRecord>> GetByPatientIdAsync(
            int patientId,
            CancellationToken ct = default);
    }
}
