using System.Collections.Generic;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Exceptions;

namespace HealthApp.ConsoleApp.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepo;

        public PatientService(IPatientRepository patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public void Register(Patient patient)
        {
            if (patient == null)
                throw new PatientInvalidException();

            _patientRepo.Add(patient);
        }

        public void Update(Patient patient)
        {
            if (patient == null)
                throw new PatientInvalidException();

            _patientRepo.Update(patient);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new PatientInvalidException();

            _patientRepo.Delete(id);  
        }

        public Patient GetPatientById(int id)
        {
            if (id <= 0)
                throw new PatientInvalidException();

            return _patientRepo.GetById(id);
        }

        public List<Patient> GetAllPatients()
        {
            return _patientRepo.GetAll();
        }

        public int GetPatientAge(int patientId)
        {
            var patient = GetPatientById(patientId);
            return patient.Age; 
        }

        public string GetPatientProfileSummary(int patientId)
        {
            var patient = GetPatientById(patientId);
            return patient.GetProfileSummary();
        }
    }
}