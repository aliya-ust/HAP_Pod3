using System.Globalization;
using Console;
using Console.Exceptions;
using Console.Services;
using HealthApp.Console.Models;
using HealthcareApp;

namespace Console.Services.Impl
{
    public class HealthRecordService : IHealthRecordService
    {
        // private IHealthRecordRepository _repo = new HealthRecordRepository(); Placeholder for when implemented
        // private IPatientRepository _patientRepo = new PatientRepository(); Placeholder for when implemented
        // private IDoctorRepository _doctorRepo = new DoctorRepository(); Placeholder for when implemented

        //Add new record
        public string AddRecord(CreateHealthRecordRequest request)
        {
            if (!DateTime.TryParseExact(
                request.VisitDate,
                "dd-MM-yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime visitDate
            ))
            {
                throw new HealthRecordInvalidVisitDateException("Visit date not entered in the correct format");
            }

            // Patient patient = _patientRepo.GetById(request.PatientId);
            // Doctor doctor = _doctorRepo.GetById(request.DoctorId);

            HealthRecord record = new HealthRecord
            {
                // RecordId = request.RecordId,
                // Patient = patient,
                // Doctor = doctor,
                VisitDate = visitDate,
                Diagnosis = request.Diagnosis,
                Prescription = request.Prescription,
                DoctorNotes = request.Notes,
            };

            // return _repo.Add(record);
            return default;
        }

        //Get records by patient ID in descending order of VisitDate
        public List<HealthRecord> GetByPatientIdOrderByVisitDateDesc(int patientId)
        {
            // Patient patient = _patientRepo.GetById(request.PatientId);
            return default;
        }

        //Get records by doctor ID in descending order of VisitDate
        public List<HealthRecord> GetByDoctorIdOrderByVisitDateDesc(int doctorId)
        {
            // Doctor doctor = _doctorRepo.GetById(request.DoctorId);
            return default;
        }
    }
}