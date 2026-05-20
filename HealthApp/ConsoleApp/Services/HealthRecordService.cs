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
            var existingRecord = GetRecordById(record.RecordId);

            if (existingRecord != null)
            {
                throw new Exception("Health record already exists.");
            }

            return _healthRecordRepository.AddHealthRecord(record);
        }

        public List<HealthRecord> GetByPatientIdOrderByVisitDateDesc(int id)
        {
            var patient = _patientRepository.GetPatientById(id);

            if (patient == null)
            {
                throw new PatientNotFoundException("Patient of this id has not been found.");
            }

            var records = _healthRecordRepository
                .GetByPatientIdOrderByVisitDateDesc(id);

            if (records == null || records.Count == 0)
            {
                throw new HealthRecordNotFoundException("No health records found for this patient.");
            }

            return records;
        }

        public List<HealthRecord> GetByDoctorIdOrderByVisitDateDesc(int id)
        {
            var doctor = _doctorRepository.GetDoctorById(id);

            if (doctor == null)
            {
                throw new DoctorNotFoundException("Doctor of this id has not been found.");
            }

            var records = _healthRecordRepository
                .GetByDoctorIdOrderByVisitDateDesc(id);

            if (records == null || records.Count == 0)
            {
                throw new HealthRecordNotFoundException("No health records found for this doctor.");
            }

            return records;
        }

        // //Update records by record Id if not same
        // public string Update(HealthRecord updatedRecord)
        // {
        //     updatedRecord.Patient = _patientRepository.GetById(updatedRecord.Patient.Id);
        //     updatedRecord.Doctor = _doctorRepository.GetById(updatedRecord.Doctor.DoctorId);

        //     return _healthRecordRepository.Update(updatedRecord);
        // }

        public HealthRecord? GetRecordById(int recordId)
        {
            return _healthRecordRepository.GetRecordById(recordId);
        }

        // public string Delete(int recordId)
        // {
        //     return _healthRecordRepository.Delete(recordId);
        // }
    }
}