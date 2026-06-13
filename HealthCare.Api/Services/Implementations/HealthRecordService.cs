using HealthCare.Api;
using HealthCare.Shared;
using HealthCareApi.Repositories.Interfaces;
using HealthCareApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace HealthCareApi.Services.Implementations
{
    public class HealthRecordService : IHealthRecordService
    {
        private readonly IHealthRecordRepository _healthRecordRepository;

        public HealthRecordService(
            IHealthRecordRepository healthRecordRepository)
        {
            _healthRecordRepository = healthRecordRepository;
        }

        // ADD HEALTH RECORD
        public async Task<HealthRecord> CreateAsync(HealthRecord record)
        {
            var exists = await _healthRecordRepository
                .HealthRecordExistsAsync(record.AppointmentId);

            if (exists)
                throw new Exception("Health record already exists for this appointment");           

            await _healthRecordRepository.AddAsync(record);

            return record;
        }

        // GET PATIENT HEALTH HISTORY
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

        public async Task<IEnumerable<HealthRecord>> GetAllAsync()
        {
            return await _healthRecordRepository.GetAllAsync();
        }

    }
}