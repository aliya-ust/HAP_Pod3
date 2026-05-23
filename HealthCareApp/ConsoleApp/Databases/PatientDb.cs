using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Databases;

public class PatientDb
{
    public List<Patient> Patients = new List<Patient>

    {
       new Patient { PatientId = 101,Name = "Arjun ",Dob = new DateTime(1995, 5, 20),Gender = "Male",PhoneNumber = "987654321",Email = "arjun@gmail.com",InsuranceId = "Ins101",CreatedAt = DateTime.Now},

       new Patient { PatientId = 102,Name = "Kevin ",Dob = new DateTime(1998, 8, 15),Gender = "Male",PhoneNumber = "912345678",Email = "kevinn@gmail.com",InsuranceId = "wer102",CreatedAt = DateTime.Now},

       new Patient { PatientId = 103, Name = "Abi", Dob = new DateTime(1992, 3, 10),Gender = "Male",  PhoneNumber = "998877665", Email = "abi@gmail.com", InsuranceId = "adb103",CreatedAt = DateTime.Now},

 };
}