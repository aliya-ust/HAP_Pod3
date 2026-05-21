using System;
using HealthApp.ConsoleApp.Models;
using System.Collections.Generic;

namespace HealthApp.ConsoleApp.Interfaces
{
    public interface IPatientService
    {
        void AddPatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(int id);
        Patient GetPatientById(int id);
        List<Patient> GetAllPatients();
        int GetPatientAge(int patienId);
        string GetPatientProfileSummary(int patientId);
        
    }
}
