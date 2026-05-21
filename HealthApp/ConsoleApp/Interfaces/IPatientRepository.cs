using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Interfaces
{
    public interface IPatientRepository
    {
        string RegisterPatient(Patient patient);
        Patient UpdatePatient(Patient patient);
        string DeletePatient(int id);
        Patient? GetPatientById(int id);
    }
}
