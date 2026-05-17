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
        public string AddRecord(CreateHealthRecordRequest request)
        {
            Patient patient = _patientRepository.GetById(request.PatientId);
            Doctor doctor = _doctorRepository.GetById(request.DoctorId);

            HealthRecord record = new HealthRecord
            {
                RecordId = request.RecordId,
                Patient = patient,
                Doctor = doctor,
                VisitDate = request.VisitDate,
                Diagnosis = request.Diagnosis,
                Prescription = request.Prescription,
                DoctorNotes = request.Notes,
            };

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
        public string Update(CreateHealthRecordRequest dto, HealthRecord record)
        {
            HealthRecord updatedRecord = new HealthRecord
            {
                Patient = (dto.PatientId == record.Patient.Id) ? record.Patient.Id : _patientRepository.GetById(dto.PatientId),
                Doctor = (dto.DoctorId == record.Doctor.DoctorId) ? record.Doctor.DoctorId : _doctorRepository.GetById(dto.DoctorId),

                Diagnosis = dto.Diagnosis,
                Prescription = dto.Prescription,
                DoctorNotes = dto.Notes
            };

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