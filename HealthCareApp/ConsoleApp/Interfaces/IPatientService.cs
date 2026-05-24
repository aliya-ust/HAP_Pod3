using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Interfaces
{
    public interface IPatientService
    {
        bool Register(Patient patient);
        bool Update(Patient patient);
        List<Patient> GetAllPatients();
        string GetPatientProfileSummaryById(int patientId);
        Patient? GetPatientById(int id);

    }
}