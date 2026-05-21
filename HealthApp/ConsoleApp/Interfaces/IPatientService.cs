using System;
using HealthApp.ConsoleApp.Models;
using System.Collections.Generic;

namespace HealthApp.ConsoleApp.Interfaces
{
    public interface IPatientService
    {
        string RegisterPatient(Patient patient);
        Patient UpdatePatient(Patient patient);
        string DeletePatient(int id);
        Patient? GetPatientById(int id); 
    }
}
