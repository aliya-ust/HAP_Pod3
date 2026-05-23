using HealthApp.ConsoleApp.Services;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Exceptions;
namespace HealthApp.ConsoleApp.Services
{
    public class HealthRecordService : IHealthRecordService
    {
        //Injecting HealthRecord, Doctor and Patient dependencies
        private readonly IHealthRecordRepository _healthRecordRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;

        public HealthRecordService(IHealthRecordRepository healthRecordRepository,
                                    IDoctorRepository doctorRepository,
                                    IPatientRepository patientRepository)
        {
            _healthRecordRepository = healthRecordRepository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
        }

        public string AddHealthRecord(HealthRecord record)
        {
            List<HealthRecord> records = _healthRecordRepository.GetAllRecords();
            record.RecordId = RecordIdGenerator(records);

            return _healthRecordRepository.AddHealthRecord(record);
        }

        public List<HealthRecord> GetByPatientIdOrderByVisitDateDesc(int id)
        {
            var patient = _patientRepository.GetById(id);

            if (patient == null)
            {
                throw new PatientNotFoundException(id);
            }

            var records = _healthRecordRepository
                .GetByPatientIdOrderByVisitDateDesc(id);

            if (records == null || records.Count == 0)
            {
                throw new HealthRecordNotFoundException("No health records found for this patient ID.");
            }

            return records;
        }

        public List<HealthRecord> GetByDoctorIdOrderByVisitDateDesc(int id)
        {
            var doctor = _doctorRepository.GetByDoctorId(id);

            if (doctor == null)
            {
                throw new DoctorNotFoundException("Doctor of this id has not been found.");
            }

            var records = _healthRecordRepository
                .GetByDoctorIdOrderByVisitDateDesc(id);

            if (records == null || records.Count == 0)
            {
                throw new HealthRecordNotFoundException("No health records found for this doctor ID.");
            }

            return records;
        }

        public HealthRecord UpdateHealthRecord(HealthRecord record)
        {
            HealthRecord? existingHealthRecord = GetRecordById(record.RecordId);

            if (existingHealthRecord is null)
            {
                throw new HealthRecordNotFoundException($"Health Record of ID {record.RecordId} does not exist");
            }
            return _healthRecordRepository.UpdateHealthRecord(existingHealthRecord, record);
        }

        public HealthRecord? GetRecordById(int recordId)
        {
            HealthRecord? record = _healthRecordRepository.GetRecordById(recordId);
            if (record is null)
            {
                throw new HealthRecordNotFoundException($"Health Record of ID {recordId} does not exist");
            }
            return record;
        }

        public int RecordIdGenerator(List<HealthRecord> records)
        {
            return records.Any()
                ? records.Max(r => r.RecordId) + 1
                : 101;
        }
        public List<HealthRecord> GetAllRecords()
        {
            return _healthRecordRepository.GetAllRecords();
        }
    }
}