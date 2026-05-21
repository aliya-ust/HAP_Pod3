using System.Collections.Generic;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Interfaces
{
    public interface IPatientRepository
    {
        void Add(Patient patient);

        void Update(Patient patient);

        void Delete(int id);

        Patient GetById(int id);

        List<Patient> GetAll();
    }
}
