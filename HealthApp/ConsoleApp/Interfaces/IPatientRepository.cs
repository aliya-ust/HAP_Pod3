using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Interfaces
{
    public interface IPatientRepository
    {
        string RegisterPatient(Patient patient);
        // bool Update(Patient patient);
        // bool Delete(int id);
        Patient? GetPatientById(int id);
        // List<Patient> GetAll();
    }
}
