using HealthCare.Shared;
using HealthCareApi.Repositories.Interfaces;
using HealthCareApi.Services.Interfaces;
using System.Threading.Tasks;

namespace HealthCareApi.Services.Implementations
{
    public class HealthRecordService : IHealthRecordService
    {
        private readonly IHealthRecordRepository _healthRecordRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public HealthRecordService(
            IHealthRecordRepository healthRecordRepository,
            IAppointmentRepository appointmentRepository)
        {
            _healthRecordRepository = healthRecordRepository;
            _appointmentRepository = appointmentRepository;
        }

        // ADD HEALTH RECORD
        public async Task<HealthRecord> AddHealthRecordAsync(HealthRecord record)
        {
            var appointment = await _appointmentRepository
                .GetByIdAsync(record.AppointmentId);

            if (appointment == null)
                return null;

            var exists = await _healthRecordRepository
                .HealthRecordExistsAsync(record.AppointmentId);

            if (exists)
                return null;

            record.VisitDate = appointment.ScheduledDate;

            await _healthRecordRepository.AddAsync(record);

            return record;
        }

        // GET PATIENT HEALTH HISTORY (VIEW)
        public async Task<PagedResult<vw_PatientHealthHistory>> GetPatientHealthHistoryAsync(
            int patientId,
            int pageNumber = 1,
            int pageSize = 10)
        {
            return await _healthRecordRepository
                .GetPatientHealthHistoryAsync(patientId, pageNumber, pageSize);
        }

        public async Task<HealthRecord> GetByAppointmentIdAsync(int id)
        {
            return await _healthRecordRepository.GetByAppointmentIdAsync(id);
        }

        public async Task<HealthRecord> GetByIdAsync(int id)
        {
            return await _healthRecordRepository.GetByIdAsync(id);
        }
    }
}