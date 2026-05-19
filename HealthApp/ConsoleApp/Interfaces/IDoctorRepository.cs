using HealthApp.ConsoleApp.Models;

public interface IDoctorRepository
{
    string AddDoctor(Doctor doctor);
    Doctor? GetDoctorById(int id);
    List<Doctor> GetDoctorsBySpecialisation(string specialisation);
    // List<Doctor> GetAllDoctors();
}