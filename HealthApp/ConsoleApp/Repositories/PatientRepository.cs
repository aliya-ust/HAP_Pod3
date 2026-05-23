using System;
using System.Collections.Generic;
using System.Linq;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Databases;

namespace HealthApp.ConsoleApp.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly List<Patient> _patients;

        public PatientRepository(PatientDb patientDb)
        {
            _patients = patientDb.Patients;
        }

        public string AddPatient(Patient patient)
        {
            if (patient == null)
                return "Invalid patient data.";

            patient.PatientId = _patients.Count > 0 ? _patients.Max(p => p.PatientId) + 1 : 1;
            patient.CreatedAt = DateTime.Now;

            _patients.Add(patient);
            return "Patient added successfully.";
        }

        public string UpdatePatient(Patient patient)
        {
            if (patient == null)
                return "Invalid patient data.";

            var existingPatient = _patients.FirstOrDefault(p => p.PatientId == patient.PatientId);
            if (existingPatient == null)
                return "Patient not found.";

            existingPatient.Name = patient.Name;
            existingPatient.Dob = patient.Dob;
            existingPatient.Gender = patient.Gender;
            existingPatient.PhoneNumber = patient.PhoneNumber;
            existingPatient.Email = patient.Email;
            existingPatient.InsuranceId = patient.InsuranceId;

            return "Patient updated successfully.";
        }

        public string DeletePatient(int id)
        {
            var patient = _patients.FirstOrDefault(p => p.PatientId == id);
            if (patient == null)
                return "Patient not found.";

            _patients.Remove(patient);
            return "Patient deleted successfully.";
        }

        public Patient GetPatientById(int id)
        {
            return _patients.FirstOrDefault(p => p.PatientId == id);
        }

        public List<Patient> GetAllPatients()
        {
            return _patients; 
        }
    }
}
