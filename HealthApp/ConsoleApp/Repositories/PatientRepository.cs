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
        private readonly PatientDb _patientsDb;

        public PatientRepository(PatientDb patientDb)
        {
            _patientsDb = patientDb;
        }

        public string RegisterPatient(Patient patient)
        {
            _patientsDb.Patients.Add(patient);
            return $"Patient ID {patient.PatientId} added successfully!";
        }

        // public bool Update(Patient patient)
        // {
        //     if (patient == null)
        //         return false;

        //     var existingPatient = _patients.FirstOrDefault(p => p.Id == patient.Id);
        //     if (existingPatient == null)
        //         return false;

        //     existingPatient.Name = patient.Name;
        //     existingPatient.Dob = patient.Dob;
        //     existingPatient.Gender = patient.Gender;
        //     existingPatient.PhoneNumber = patient.PhoneNumber;
        //     existingPatient.Email = patient.Email;
        //     existingPatient.InsuranceId = patient.InsuranceId;

        //     return true;
        // }

        // public bool Delete(int id)
        // {
        //     var patient = _patients.FirstOrDefault(p => p.Id == id);
        //     if (patient == null)
        //         return false;

        //     _patients.Remove(patient);
        //     return true;
        // }

        
        public Patient? GetPatientById(int id)
        {
            return _patientsDb.Patients.FirstOrDefault(p => p.PatientId == id);
        }

        // public List<Patient> GetAll()
        // {
        //     return _patients; 
        // }
    }
}
