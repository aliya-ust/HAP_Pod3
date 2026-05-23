using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Interfaces
{
    public interface IPatientRepository
    {
        string AddPatient(Patient patient);
        string UpdatePatient(Patient patient);
        string DeletePatient(int id);
        Patient GetPatientById(int id);
        List<Patient> GetAllPatients();
    }
}
