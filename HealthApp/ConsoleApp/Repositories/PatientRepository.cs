using System;
using System.Collections.Generic;
using System.Linq;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Databases;
using HealthApp.ConsoleApp.Exceptions;

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
            if (patient == null)
               
            throw new PatientInvalidException();


            patient.Id = _patients.Patients.Count > 0 ? _patients.Patients.Max(p => p.Id) + 1 : 1;
            patient.CreatedAt = DateTime.Now;

            _patients.Patients.Add(patient);
        
        }

        public void UpdatePatient(Patient patient)
        {
            if (patient == null)
                throw new PatientInvalidException();

            var existingPatient = _patients.Patients.FirstOrDefault(p => p.Id == patient.Id);

            if (existingPatient == null)
                throw new PatientNotFoundException(patient.Id);


            existingPatient.Name = patient.Name;
            existingPatient.Dob = patient.Dob;
            existingPatient.Gender = patient.Gender;
            existingPatient.PhoneNumber = patient.PhoneNumber;
            existingPatient.Email = patient.Email;
            existingPatient.InsuranceId = patient.InsuranceId;
        }

        public void DeletePatient(int id)
        {
            var patient = _patients.Patients.FirstOrDefault(p => p.Id == id);
            if (patient == null)
                throw new PatientNotFoundException(id);

            _patients.Patients.Remove(patient);
        }

        public Patient GetPatientById(int id)
        {
            var patient = _patients.Patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
                throw new PatientNotFoundException(id);

            return patient;
        }

        public List<Patient> GetAllPatients()
        {
            return _patients.Patients.ToList(); 
        }
    }
}
