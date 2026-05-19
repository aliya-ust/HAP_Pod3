using System;
using System.Collections.Generic;
using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Repositories;


namespace HealthApp.ConsoleApp.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepo;

        public PatientService(IPatientRepository patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public string RegisterPatient(Patient patient)
        {
            var existingPatient = GetPatientById(patient.PatientId);

            if (existingPatient != null)
            {
                throw new PatientAlreadyExistsException("Patient already exists.");
            }

            return _patientRepo.RegisterPatient(patient);
        }

        // public bool Update(Patient patient)
        // {
        //     if (patient == null)
        //         return false;

        //     return patientRepo.Update(patient);
        // }

        // public bool Delete(int id)
        // {
        //     return patientRepo.Delete(id);
        // }

        public Patient? GetPatientById(int id)
        {
            return _patientRepo.GetPatientById(id);
        }

        // public List<Patient> GetAllPatients()
        // {
        //     return patientRepo.GetAll();
        // }

        // public int GetPatientAge(int patientId)
        // {
        //     var patient = GetPatientById(patientId);
        //     return patient?.GetAge() ?? -1;
        // }

        // public string GetPatientProfileSummary(int patientId)
        // {
        //     var patient = GetPatientById(patientId);
        //     return patient?.GetProfileSummary() ?? string.Empty;
        // }
    }
}
