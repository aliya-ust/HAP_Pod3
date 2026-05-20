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

        public void Register(Patient patient)
        {
            if (patient == null)
                throw new PatientInvalidException();

            patientRepo.Add(patient);
        }

        public void Update(Patient patient)
        {
            if (patient == null)
                throw new PatientInvalidException();

             patientRepo.Update(patient);
        }

        // public void Delete(int id)
        // {
        //     if(id<0)
        //       throw new PatientInvalidException();
        //     return patientRepo.Delete(id);
        // }

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
            return patient.GetAge();
        }
        public string GetPatientProfileSummary(int patientId)
        {
            var patient = GetPatientById(patientId);
            return patient.GetProfileSummary();
        }
    }
}
