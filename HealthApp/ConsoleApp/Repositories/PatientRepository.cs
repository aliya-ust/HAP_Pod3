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

        public bool Add(Patient patient)
        {
            if (patient == null)
                return false;

            patient.PatientId = _patients.Count > 0 ? _patients.Max(p => p.PatientId) + 1 : 1;
            patient.CreatedAt = DateTime.Now;

            _patients.Add(patient);
            return true;
        }

        public bool Update(Patient patient)
        {
            if (patient == null)
                return false;

            var existingPatient = _patients.FirstOrDefault(p => p.PatientId == patient.PatientId);
            if (existingPatient == null)
                return false;

            existingPatient.Name = patient.Name;
            existingPatient.Dob = patient.Dob;
            existingPatient.Gender = patient.Gender;
            existingPatient.PhoneNumber = patient.PhoneNumber;
            existingPatient.Email = patient.Email;
            existingPatient.InsuranceId = patient.InsuranceId;

            return true;
        }

        public bool Delete(int id)
        {
            var patient = _patients.FirstOrDefault(p => p.PatientId == id);
            if (patient == null)
                return false;

            _patients.Remove(patient);
            return true;
        }

        public Patient GetById(int id)
        {
            return _patients.FirstOrDefault(p => p.PatientId == id);
        }

        public List<Patient> GetAll()
        {
            return _patients; 
        }
    }
}
