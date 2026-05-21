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

        public Patient UpdatePatient(Patient patient)
        {
            var existingPatient = _patientsDb.Patients.FirstOrDefault(p => p.PatientId == patient.PatientId);
            if (existingPatient == null)
                throw new PatientNotFoundException("Patient with this ID does not exist");

            existingPatient.FullName = patient.FullName;
            existingPatient.DateOfBirth = patient.DateOfBirth;
            existingPatient.Gender = patient.Gender;
            existingPatient.PhoneNumber = patient.PhoneNumber;
            existingPatient.Email = patient.Email;
            existingPatient.InsuranceId = patient.InsuranceId;

            return existingPatient;
        }

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
