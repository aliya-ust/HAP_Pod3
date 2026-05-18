using HealthApp.ConsoleApp.Services;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Services.Impl
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

        //Add new record
        public string AddRecord(HealthRecord record)
        {
            Patient patient = _patientRepository.GetById(record.Patient.Id);
            Doctor doctor = _doctorRepository.GetById(record.Doctor.DoctorId);

            record.Patient = patient;
            record.Doctor = doctor;

            return _healthRecordRepository.Add(record);
        }

        //Get records by patient ID in descending order of VisitDate
        public List<HealthRecord> GetByPatientIdOrderByVisitDateDesc(int patientId)
        {
            Patient patient = _patientRepository.GetById(patientId);
            return _healthRecordRepository.GetByPatientIdOrderByVisitDateDesc(patientId);
        }

        //Get records by doctor ID in descending order of VisitDate
        public List<HealthRecord> GetByDoctorIdOrderByVisitDateDesc(int doctorId)
        {
            Doctor doctor = _doctorRepository.GetById(doctorId);
            return _healthRecordRepository.GetByDoctorIdOrderByVisitDateDesc(doctorId);
        }

        //Update records by record Id if not same
        public string Update(HealthRecord updatedRecord)
        {
            updatedRecord.Patient = _patientRepository.GetById(updatedRecord.Patient.Id);
            updatedRecord.Doctor = _doctorRepository.GetById(updatedRecord.Doctor.DoctorId);

            return _healthRecordRepository.Update(updatedRecord);
        }

        public HealthRecord GetByRecordId(int recordId)
        {
            return _healthRecordRepository.GetByRecordId(recordId);
        }

        public string Delete(int recordId)
        {
            return _healthRecordRepository.Delete(recordId);
        }
    }
}