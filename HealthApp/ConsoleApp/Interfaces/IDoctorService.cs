using System;
using System.Collections.Generic;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Interfaces
{
    public interface IDoctorService
    {
        void AddDoctor(Doctor doctor);
        List<Doctor> GetAllDoctors();
        List<Doctor> SearchBySpecialisation(string specialisation);
    }

    public interface IDoctorRepository
    {
        void AddDoctor(Doctor doctor);
        List<Doctor> GetAllDoctors();
        List<Doctor> GetDoctorsBySpecialisation(string specialisation);
    }
}