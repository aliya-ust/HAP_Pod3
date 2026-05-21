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

        // ✅ Default constructor (used in application)
        public PatientRepository(PatientDb db)
        {
            _patients = db.Patients;
        }

        // ✅ ADD
        public bool Add(Patient patient)
        {
            if (patient == null)
                return false;

            patient.Id = _patients.Count > 0 ? _patients.Max(p => p.Id) + 1 : 1;
            patient.CreatedAt = DateTime.Now;

            _patients.Add(patient);
            return true;
        }

        // ✅ UPDATE
        public bool Update(Patient patient)
        {
            if (patient == null)
                return false;

            var existingPatient = _patients.FirstOrDefault(p => p.Id == patient.Id);

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

        //DELETE
        public bool Delete(int id)
        {
            var patient = _patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
                return false;

            _patients.Remove(patient);
            return true;
        }

        //GET BY ID
        public Patient GetById(int id)
        {
            return _patients.FirstOrDefault(p => p.Id == id);
        }

        //GET ALL
        public List<Patient> GetAll()
        {
            return _patients;
        }
    }
}
