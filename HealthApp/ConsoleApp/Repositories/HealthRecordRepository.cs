using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Exceptions;
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

        public string AddHealthRecord(HealthRecord record)
        {
            _healthRecordDb.Records.Add(record);
            return $"Record ID {record.RecordId} added successfully!";
        }

        // public string Delete(int recordId)
        // {
        //     HealthRecord record = GetByRecordId(recordId);
        //     if (record is null)
        //     {
        //         throw new HealthRecordNotFoundException("Health Record doesn't Exist");
        //     }
        //     _healthRecordDb.Records.Remove(record);

        //     return $"Record ID {recordId} has been deleted successfully";
        // }
        // public string Update(HealthRecord record)
        // {

        //     HealthRecord recordToUpdate = GetByRecordId(record.RecordId);
        //     if (recordToUpdate is null)
        //     {
        //         throw new HealthRecordNotFoundException("Health Record doesn't Exist");
        //     }

        //     recordToUpdate.RecordId = record.RecordId;
        //     recordToUpdate.Patient = record.Patient;
        //     recordToUpdate.Doctor = record.Doctor;
        //     recordToUpdate.Diagnosis = record.Diagnosis;
        //     recordToUpdate.Prescription = record.Prescription;
        //     recordToUpdate.DoctorNotes = record.DoctorNotes;

        //     return $"Record {record.RecordId} has been updated";
        // }

        // public List<HealthRecord> GetAll()
        // {
        //     if (!_healthRecordDb.Records.Any())
        //     {
        //         throw new HealthRecordNotFoundException("There is no Health Records Available");
        //     }
        //     return _healthRecordDb.Records.ToList();
        // }

        public List<HealthRecord> GetByPatientIdOrderByVisitDateDesc(int id)
        {
            return _healthRecordDb.Records
                    .Where(r => r.Patient != null && r.Patient.PatientId == id)
                    .OrderByDescending(r => r.VisitDate)
                    .ToList();
        }

        public List<HealthRecord> GetByDoctorIdOrderByVisitDateDesc(int id)
        {
            return _healthRecordDb.Records
                    .Where(r => r.Doctor != null && r.Doctor.DoctorId == id)
                    .OrderByDescending(r => r.VisitDate)
                    .ToList();
        }

        public HealthRecord? GetRecordById(int id)
        {
            return _healthRecordDb.Records.FirstOrDefault(r => r.RecordId == id);
        }
    }
}