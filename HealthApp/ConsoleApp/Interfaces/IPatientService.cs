using System.Collections.Generic;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Interfaces
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