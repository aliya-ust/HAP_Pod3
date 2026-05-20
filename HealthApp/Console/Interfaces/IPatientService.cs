using System.Collections.Generic;
using HealthApp.Console.Models;

namespace HealthApp.Console.Interfaces
{
    public interface IPatientService
    {
        void Register(Patient patient);

        void Update(Patient patient);

        void Delete(int id);

        Patient GetPatientById(int id);

        List<Patient> GetAllPatients();

        int GetPatientAge(int patientId);

        string GetPatientProfileSummary(int patientId);
    }
}