using System.Collections.Generic;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Interfaces
{
    public interface IDoctorRepository
    {
        void AddDoctor(Doctor doctor);

        void UpdateDoctor(Doctor doctor);

        Doctor GetDoctorById(int id);

        List<Doctor> GetAllDoctors();

        List<Doctor> GetDoctorsBySpecialisation(string specialisation);
    }
}