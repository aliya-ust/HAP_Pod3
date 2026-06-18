//using HealthCare.Api.Models;
//using HealthCare.Api.Repositories.Interfaces;
//using HealthCare.Api.Services.Interfaces;

//namespace HealthCare.Api.Services.Implementation
//{
//    public class HealthRecordService : IHealthRecordService
//    {
//        private readonly IHealthRecordRepository _healthRecordRepository;

//        public HealthRecordService(IHealthRecordRepository healthRecordRepository)
//        {
//            _healthRecordRepository = healthRecordRepository;
//        }

//        public Task<HealthRecord> CreateAsync(HealthRecord record, CancellationToken ct = default)
//            => _healthRecordRepository.CreateAsync(record, ct);

//        public Task<HealthRecord> UpdateAsync(int id, HealthRecord record, CancellationToken ct = default)
//            => _healthRecordRepository.UpdateAsync(id, record, ct);

//        public Task<HealthRecord> DeleteAsync(HealthRecord record, CancellationToken ct = default)
//            => _healthRecordRepository.DeleteAsync(record, ct);

//        public Task<List<HealthRecord>> GetAllAsync(CancellationToken ct = default)
//            => _healthRecordRepository.GetAllAsync(ct);

//        public Task<HealthRecord> GetByIdAsync(int id, CancellationToken ct = default)
//            => _healthRecordRepository.GetByIdAsync(id, ct);

//        public Task<HealthRecord?> GetByAppointmentIdAsync(int appointmentId, CancellationToken ct = default)
//            => _healthRecordRepository.GetByAppointmentIdAsync(appointmentId, ct);

//        public Task<List<HealthRecord>> GetByPatientIdAsync(int patientId, CancellationToken ct = default)
//            => _healthRecordRepository.GetByPatientIdAsync(patientId, ct);
//    }
//}
