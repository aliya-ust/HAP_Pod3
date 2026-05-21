using System;
using System.Collections.Generic;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Repositories;


namespace HealthApp.ConsoleApp.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository patientRepo;

        public PatientService(IPatientRepository patientRepo)
        {
            this.patientRepo = patientRepo;
        }

        public bool Register(Patient patient)
        {
            if (patient == null)
                return false;

            return patientRepo.Add(patient);
        }

        public bool Update(Patient patient)
        {
            if (patient == null)
                return false;

            return patientRepo.Update(patient);
        }

        public bool Delete(int id)
        {
            return patientRepo.Delete(id);
        }

        public Patient GetPatientById(int id)
        {
            return patientRepo.GetById(id);
        }

        public List<Patient> GetAllPatients()
        {
            return patientRepo.GetAll();
        }

        public int GetPatientAge(int patientId)
        {
            var patient = GetPatientById(patientId);
            return patient?.GetAge() ?? -1;
        }

        public string GetPatientProfileSummary(int patientId)
        {
            var patient = GetPatientById(patientId);
            return patient?.GetProfileSummary() ?? string.Empty;
        }
    }
}
