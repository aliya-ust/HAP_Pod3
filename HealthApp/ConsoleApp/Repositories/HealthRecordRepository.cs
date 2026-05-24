using System.Collections.Generic;
using System.Linq;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Databases;
using HealthApp.ConsoleApp.Interfaces;

namespace HealthApp.ConsoleApp.Repositories
{
    public class HealthRecordRepository : IHealthRecordRepository
    {
        private readonly HealthRecordDB _healthRecordDb;

        public HealthRecordRepository(HealthRecordDB healthRecordDB)
        {
            _healthRecordDb = healthRecordDB;
        }

        public string Add(HealthRecord record)
        {
            _healthRecordDb.Records.Add(record);
            return $"Record ID {record.RecordId} added successfully!";
        }

        public string Update(HealthRecord record)
        {
            var existing = _healthRecordDb.Records
                .FirstOrDefault(r => r.RecordId == record.RecordId);

            if (existing != null)
            {
                existing.Patient = record.Patient;
                existing.Doctor = record.Doctor;
                existing.Diagnosis = record.Diagnosis;
                existing.Prescription = record.Prescription;
                existing.DoctorNotes = record.DoctorNotes;
            }

            return $"Record {record.RecordId} updated";
        }

        public List<HealthRecord> GetAll()
        {
            return _healthRecordDb.Records.ToList();
        }

        public List<HealthRecord> GetByPatientIdOrderByVisitDateDesc(int patientId)
        {
            return _healthRecordDb.Records
                .Where(r => r.Patient != null && r.Patient.Id == patientId)
                .OrderByDescending(r => r.VisitDate)
                .ToList();
        }

        public List<HealthRecord> GetByDoctorIdOrderByVisitDateDesc(int doctorId)
        {
            return _healthRecordDb.Records
                .Where(r => r.Doctor != null && r.Doctor.DoctorId == doctorId)
                .OrderByDescending(r => r.VisitDate)
                .ToList();
        }

        public HealthRecord GetByRecordId(int recordId)
        {
            return _healthRecordDb.Records
                .FirstOrDefault(r => r.RecordId == recordId);
        }
    }
}