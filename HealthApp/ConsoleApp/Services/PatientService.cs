using System;
using System.Collections.Generic;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Exceptions;


namespace HealthApp.ConsoleApp.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository patientRepo;

        public PatientService(IPatientRepository patientRepo)
        {
            this.patientRepo = patientRepo;
        }

        public void AddPatient (Patient patient)
        {
            if (patient == null)
                throw new PatientInvalidException();

            patientRepo.AddPatient(patient);
        }

        public void UpdatePatient(Patient patient)
        {
            if (patient == null)
                throw new PatientInvalidException();

             patientRepo.UpdatePatient(patient);
        }

        public void DeletePatient(int id)
        {
            if(id<0)
              throw new PatientInvalidException();
             patientRepo.DeletePatient(id);
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
            return patient.GetAge();
        }
        public string GetPatientProfileSummary(int patientId)
        {
            var patient = GetPatientById(patientId);
            return patient.GetProfileSummary();
        }
    }
}
