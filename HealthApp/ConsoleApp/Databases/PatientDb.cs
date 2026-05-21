using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Databases;

public class PatientDb
{
    public static List<Patient> Patients = new List<Patient>

    {
       new Patient {Id = 1,Name = "Arjun ",Dob = new DateTime(1995, 5, 20),Gender= "Male",PhoneNumber = 987654321,Email = "arjun@gmail.com",InsuranceId = 101,CreatedAt = DateTime.Now},

       new Patient {Id = 2,Name = "Kevin ",Dob = new DateTime(1998, 8, 15),Gender = "Male",PhoneNumber = 912345678,Email = "kevinn@gmail.com",InsuranceId = 102,CreatedAt = DateTime.Now},

       new Patient {Id = 3, Name = "Abi", Dob = new DateTime(1992, 3, 10),Gender = "Male",  PhoneNumber = 998877665, Email = "abi@gmail.com", InsuranceId = 103,CreatedAt = DateTime.Now},

    };
}
