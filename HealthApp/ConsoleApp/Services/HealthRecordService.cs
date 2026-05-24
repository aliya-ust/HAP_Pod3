using System;
using System.Collections.Generic;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Exceptions;

namespace HealthApp.ConsoleApp.Services
{
    public class HealthRecordService : IHealthRecordService
    {
        private readonly IHealthRecordRepository _healthRecordRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;

        public HealthRecordService(
            IHealthRecordRepository healthRecordRepository,
            IDoctorRepository doctorRepository,
            IPatientRepository patientRepository)
        {
            _healthRecordRepository = healthRecordRepository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
        }

        public string AddRecord(HealthRecord record)
        {
            if (record == null)
                throw new ArgumentException("Record cannot be null");

            if (record.RecordId <= 0)
                throw new ArgumentException("Invalid Record ID");

            var existingRecord = _healthRecordRepository.GetByRecordId(record.RecordId);
            if (existingRecord != null)
                throw new HealthRecordExistsException("Record already exists");

            var patient = _patientRepository.GetById(record.Patient.Id);
            if (patient == null)
                throw new ArgumentException("Patient not found");

            var doctor = _doctorRepository.GetDoctorById(record.Doctor.DoctorId);
            if (doctor == null)
                throw new ArgumentException("Doctor not found");

            if (record.VisitDate > DateTime.Today)
                throw new ArgumentException("Visit date cannot be future");

            if (string.IsNullOrWhiteSpace(record.Diagnosis))
                throw new ArgumentException("Diagnosis required");

            if (string.IsNullOrWhiteSpace(record.Prescription))
                throw new ArgumentException("Prescription required");

            if (string.IsNullOrWhiteSpace(record.DoctorNotes))
                throw new ArgumentException("Doctor notes required");

            record.Patient = patient;
            record.Doctor = doctor;

            return _healthRecordRepository.Add(record);
        }

        public List<HealthRecord> GetByPatientIdOrderByVisitDateDesc(int patientId)
        {
            if (patientId <= 0)
                throw new ArgumentException("Invalid Patient ID");

            var patient = _patientRepository.GetById(patientId);
            if (patient == null)
                throw new ArgumentException("Patient not found");

            return _healthRecordRepository.GetByPatientIdOrderByVisitDateDesc(patientId);
        }

        public List<HealthRecord> GetByDoctorIdOrderByVisitDateDesc(int doctorId)
        {
            if (doctorId <= 0)
                throw new ArgumentException("Invalid Doctor ID");

            var doctor = _doctorRepository.GetDoctorById(doctorId);
            if (doctor == null)
                throw new ArgumentException("Doctor not found");

            return _healthRecordRepository.GetByDoctorIdOrderByVisitDateDesc(doctorId);
        }

        public string Update(HealthRecord updatedRecord)
        {
            if (updatedRecord == null)
                throw new ArgumentException("Invalid record data");

            var existing = _healthRecordRepository.GetByRecordId(updatedRecord.RecordId);
            if (existing == null)
                throw new HealthRecordNotFoundException("Record not found");

            var patient = _patientRepository.GetById(updatedRecord.Patient.Id);
            if (patient == null)
                throw new ArgumentException("Patient not found");

            var doctor = _doctorRepository.GetDoctorById(updatedRecord.Doctor.DoctorId);
            if (doctor == null)
                throw new ArgumentException("Doctor not found");

            if (string.IsNullOrWhiteSpace(updatedRecord.Diagnosis))
                throw new ArgumentException("Diagnosis required");

            if (string.IsNullOrWhiteSpace(updatedRecord.Prescription))
                throw new ArgumentException("Prescription required");

            if (string.IsNullOrWhiteSpace(updatedRecord.DoctorNotes))
                throw new ArgumentException("Doctor notes required");

            updatedRecord.Patient = patient;
            updatedRecord.Doctor = doctor;

            return _healthRecordRepository.Update(updatedRecord);
        }

        public HealthRecord GetByRecordId(int recordId)
        {
            if (recordId <= 0)
                throw new ArgumentException("Invalid Record ID");

            var record = _healthRecordRepository.GetByRecordId(recordId);

            if (record == null)
                throw new HealthRecordNotFoundException("Record not found");

            return record;
        }
    }
}