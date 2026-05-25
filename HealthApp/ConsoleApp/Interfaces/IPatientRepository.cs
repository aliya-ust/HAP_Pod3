using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Interfaces
{
    public interface IPatientRepository
    {
        string RegisterPatient(Patient patient);
        Patient UpdatePatient(Patient existingPatient, Patient patient);
        Patient GetPatientById(int id);
        List<Patient> GetAllPatients();
    }
}
