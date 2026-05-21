using HealthApp.ConsoleApp.Models;

public interface IDoctorRepository
{
    string AddDoctor(Doctor doctor);
    Doctor? GetDoctorById(int id);
    List<Doctor> GetDoctorsBySpecialisation(string specialisation);
    Doctor UpdateDoctor(Doctor doctor);
    string DeleteDoctor(int id);
    // List<Doctor> GetAllDoctors();
}