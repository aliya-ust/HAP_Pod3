using System.Collections.Generic;
using HealthApp.Console.Models;

namespace HealthApp.Console.Interfaces
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
