using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Interfaces
{
    public interface IPatientRepository
    {
        bool Add(Patient patient);
        bool Update(Patient patient);
        Patient GetById(int id);
        List<Patient> GetAll();
    }
}