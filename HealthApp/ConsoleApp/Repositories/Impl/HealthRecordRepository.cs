using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Databases;

namespace HealthApp.ConsoleApp.Repositories.Impl
{
    public class HealthRecordRepository : IHealthRecordRepository
    {
        public string Add(HealthRecord recordToAdd)
        {
            HealthRecord record = GetByRecordId(recordToAdd.RecordId);
            if (recordToAdd is not null)
            {
                throw new HealthRecordExistsException("Health Record already exist");
            }
            Database.Records.Add(record);

            return $"Record ID {recordToAdd.RecordId} added successfully!";
        }

        public string Delete(int recordId)
        {
            HealthRecord record = GetByRecordId(recordId);
            if (record is null)
            {
                throw new HealthRecordNotFoundException("Health Record doesn't Exist");
            }
            Database.Records.Remove(record);

            return $"Record ID {recordId} has been deleted successfully";
        }
        public string Update(HealthRecord record)
        {

            HealthRecord recordToUpdate = GetByRecordId(record.RecordId);
            if (recordToUpdate is null)
            {
                throw new HealthRecordNotFoundException("Health Record doesn't Exist");
            }

            return $"Record {record.RecordId} has been updated";
        }

        public List<HealthRecord> GetAll()
        {
            if (!Database.Records.Any())
            {
                throw new HealthRecordNotFoundException("There is no Health Records Available");
            }
            return Database.Records.ToList();
        }

        public List<HealthRecord> GetByPatientIdOrderByVisitDateDesc(int patientId)
        {
            return Database.Records
                    .Where(r => r.Patient != null && r.Patient.Id == patientId)
                    .OrderByDescending(r => r.VisitDate)
                    .ToList();
        }

        public List<HealthRecord> GetByDoctorIdOrderByVisitDateDesc(int doctorId)
        {
            return Database.Records
                    .Where(r => r.Doctor != null && r.Doctor.DoctorId == doctorId)
                    .OrderByDescending(r => r.VisitDate)
                    .ToList();
        }

        public HealthRecord GetByRecordId(int recordId)
        {
            HealthRecord record = Database.Records.Find(r => r.RecordId == recordId);
            if (record is null)
            {
                throw new HealthRecordNotFoundException("There is no Health Records Available");
            }
            return record;
        }
    }
}