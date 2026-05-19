using System;
using HealthApp.ConsoleApp.Models;
using System.Collections.Generic;

namespace HealthApp.ConsoleApp.Interfaces
{
    public interface IPatientService
    {
        string RegisterPatient(Patient patient);
        // bool Update(Patient patient);
        // bool Delete(int id);
        Patient? GetPatientById(int id);
        // List<Patient> GetAllPatients();
        // int GetPatientAge(int patientId);
        // string GetPatientProfileSummary(int patientId);
        
    }
}
