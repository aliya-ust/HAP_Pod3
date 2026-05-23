using HealthApp.ConsoleApp.Models;

public interface IDoctorRepository
{
    void AddDoctor(Doctor doctor);
    List<Doctor> GetAllDoctors();
    List<Doctor> GetDoctorsBySpecialisation(string specialisation);
    Doctor GetByDoctorId(int id);

}