using HealthApp.ConsoleApp.Models;
using System;
using System.Collections.Generic;

namespace HealthApp.ConsoleApp.Interfaces
{
    public interface IDoctorService
    {
        void AddDoctor(Doctor doctor);
        List<Doctor> GetAllDoctors();
        List<Doctor> SearchBySpecialisation(string specialisation);
        Doctor GetDoctorById(int id);
    }
}