using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Databases;

public class PatientDb
{
    public  List<Patient> Patients = new List<Patient>

    {
       new Patient { Id = 1,Name = "Arjun",Dob = new DateTime(1995, 5, 20),Gender=Patient.GenderType.Male,PhoneNumber = "987654321",Email = "arjun@gmail.com",InsuranceId = "A101",CreatedAt = DateTime.Now},

       new Patient {Id = 2,Name = "Kevin",Dob = new DateTime(1998, 8, 15),Gender =Patient.GenderType.Male,PhoneNumber = "912345678",Email = "kevinn@gmail.com",InsuranceId = "B102",CreatedAt = DateTime.Now},

       new Patient { Id = 3, Name = "Abi", Dob = new DateTime(1992, 3, 10),Gender = Patient.GenderType.Male,  PhoneNumber = "998877665", Email = "abi@gmail.com", InsuranceId = "C103",CreatedAt = DateTime.Now},

    };
}
