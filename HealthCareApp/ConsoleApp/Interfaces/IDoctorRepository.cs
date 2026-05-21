using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Interfaces
{
    public interface IDoctorRepository
    {
        void AddDoctor(Doctor doctor);
        List<Doctor> GetAllDoctors();
        List<Doctor> GetDoctorsBySpecialisation(string specialisation);
        Doctor GetDoctorById(int id);
    }
}