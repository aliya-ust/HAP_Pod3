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

        public string AddPatient(Patient patient)
        {
            if (patient == null)
                return "Invalid patient data.";

            return patientRepo.AddPatient(patient);
        }

        public string UpdatePatient(Patient patient)
        {
            if (patient == null)
                return "Invalid patient data.";

            return patientRepo.UpdatePatient(patient);
        }

        public string DeletePatient(int id)
        {
            return patientRepo.DeletePatient(id);
        }

        public Patient GetPatientById(int id)
        {
            return patientRepo.GetPatientById(id);
        }

        public List<Patient> GetAllPatients()
        {
            return patientRepo.GetAllPatients();
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
