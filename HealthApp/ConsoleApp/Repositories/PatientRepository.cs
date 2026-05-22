
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Databases;

namespace HealthApp.ConsoleApp.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientDb _patients;

        public PatientRepository(PatientDb db)
        {
            _patients = db;
        }

        public void AddPatient(Patient patient)
        {
            patient.Id = _patients.Patients.Any()
                ? _patients.Patients.Max(p => p.Id) + 1
                : 1;

            _patients.Patients.Add(patient);
        }

        public void UpdatePatient(Patient patient)
        {
            var existing = _patients.Patients
                .FirstOrDefault(p => p.Id == patient.Id);

            if (existing != null)
            {
                existing.Name = patient.Name;
                existing.Dob = patient.Dob;
                existing.Gender = patient.Gender;
                existing.PhoneNumber = patient.PhoneNumber;
                existing.Email = patient.Email;
                existing.InsuranceId = patient.InsuranceId;
            }
            // if not found → do nothing (service handles it)
        }

        public void DeletePatient(int id)
        {
            var patient = _patients.Patients
                .FirstOrDefault(p => p.Id == id);

            if (patient != null)
            {
                _patients.Patients.Remove(patient);
            }
        }

        public Patient GetPatientById(int id)
        {
            return _patients.Patients
                .FirstOrDefault(p => p.Id == id);
        }

        public List<Patient> GetAllPatients()
        {
            return _patients.Patients.ToList();
        }
    }
}
