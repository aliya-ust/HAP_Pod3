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
        private readonly List<Patient> _patients;

        public PatientRepository()
        {
            _patients = PatientDb.Patients;
        }

        public void Add(Patient patient)
        {
            if (patient == null)
                throw new PatientInvalidException();

            patient.Id = _patients.Count > 0
                ? _patients.Max(p => p.Id) + 1
                : 1;

            _patients.Add(patient);
        }

        public void Update(Patient patient)
        {
            if (patient == null)
                throw new PatientInvalidException();

            var existingPatient = _patients.FirstOrDefault(p => p.Id == patient.Id);

            if (existingPatient == null)
                throw new PatientNotFoundException(patient.Id);

            existingPatient.Name = patient.Name;
            existingPatient.Dob = patient.Dob;
            existingPatient.Gender = patient.Gender;
            existingPatient.PhoneNumber = patient.PhoneNumber;
            existingPatient.Email = patient.Email;
            existingPatient.InsuranceId = patient.InsuranceId;
        }

        public void Delete(int id)
        {
            var patient = _patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
                throw new PatientNotFoundException(id);

            _patients.Remove(patient);
        }

        public Patient GetById(int id)
        {
            var patient = _patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
                throw new PatientNotFoundException(id);

            return patient;
        }

        public List<Patient> GetAll()
        {
            return new List<Patient>(_patients);
        }
    }
}