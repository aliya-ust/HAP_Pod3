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

        public List<Patient> GetAllPatients()
        {
            return _patientsDb.Patients.ToList();
        }

        public Patient UpdatePatient(Patient existingPatient, Patient patient)
        {
            existingPatient.Name = patient.Name;
            existingPatient.Dob = patient.Dob;
            existingPatient.Gender = patient.Gender;
            existingPatient.PhoneNumber = patient.PhoneNumber;
            existingPatient.Email = patient.Email;
            existingPatient.InsuranceId = patient.InsuranceId;

            return existingPatient;
        }

        public Patient? GetPatientById(int id)
        {
            return _patientsDb.Patients.FirstOrDefault(p => p.PatientId == id);
        }
    }
}