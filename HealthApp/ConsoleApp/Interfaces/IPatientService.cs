using System;
using HealthApp.ConsoleApp.Models;
using System.Collections.Generic;

namespace HealthApp.ConsoleApp.Interfaces
{
    public interface IPatientService
    {
        string  AddPatient(Patient patient);
        string  UpdatePatient(Patient patient);
        string  DeletePatient(int id);
        Patient GetPatientById(int id);
        List<Patient> GetAllPatients();
        int GetPatientAge(int patientId);
        string GetPatientProfileSummary(int patientId);
        
    }
}
