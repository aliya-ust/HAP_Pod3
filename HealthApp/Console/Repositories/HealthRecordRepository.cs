using System;
using System.Collections.Generic;
using HealthApp.Console.Models;
using HealthcareApp.Data;

namespace HealthcareApp.Repository
{
    public class HealthRecordRepository : IHealthRecordRepository
    {
        public string Add(HealthRecord record)
        {
            HealthRecord recordToAdd = GetByRecordId(record.RecordId);
            if (recordToAdd is not null)
            {
                throw new HealthRecordExistsException("Health Record already exist");
            }
            Database.Records.Add(record);

            return "Record added successfully!";
        }

        public string Delete(int recordId)
        {
            HealthRecord record= GetByRecordId(recordId);
            if (record is null)
            {
                throw new HealthRecordNotFoundException("Health Record doesn't Exist");
            }
            Database.Records.Remove(record);

            return "Record have deleted Successfully";
        }
        public string Update(HealthRecord record)
        {

            HealthRecord recordToUpdate = GetByRecordId(record.RecordId);
            if (recordToUpdate is null)
            {
                throw new HealthRecordNotFoundException("Health Record doesn't Exist");
            }
            recordToUpdate.VisitDate = record.VisitDate;
            recordToUpdate.Diagnosis = record.Diagnosis;
            recordToUpdate.Prescription = record.Prescription;
            recordToUpdate.DoctorNotes = record.DoctorNotes;

            return "Record have been updated";
        }

        public List<HealthRecord> GetAll()
        {
            if (!Database.Records.Any())
            {
                throw new HealthRecordNotFoundException("There is no Health Records Available");
            }
            return Database.Records.ToList();
        }

        public HealthRecord GetByPatientIdOrderByVisitDateDesc(int patientId)
        {
            HealthRecord record = GetByRecordId(id);
            if (record is null)
            {
                throw default;
            }
            return record;
        }

        public HealthRecord GetByDoctorIdOrderByVisitDateDesc(int doctorId)
        {
            HealthRecord record = GetByRecordId(id);
            if (record is null)
            {
                throw default;
            }
            return record;
        }
        public HealthRecord GetByRecordId(int recordId)
        {
            HealthRecord record = Database.Records.Find(r => r.recordId == recordId);
            if (record is null)
            {
                throw new HealthRecordNotFoundException("There is no Health Records Available");
            }
            return record;
        }
    }
}