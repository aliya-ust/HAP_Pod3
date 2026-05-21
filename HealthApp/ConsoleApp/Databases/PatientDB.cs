using System;
using System.Collections.Generic;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Databases
{
    public class PatientDb
    {
        public static List<Patient> Patients = new List<Patient>
        {
            new Patient
            {
                Id = 1,
                Name = "Priya",
                Dob = new DateTime(1995, 5, 20),
                Gender = "Female",
                PhoneNumber = 9876543210,   
                Email = "priya@gmail.com",
                InsuranceId = 101
            },

            new Patient
            {
                Id = 2,
                Name = "Abu",
                Dob = new DateTime(1998, 8, 15),
                Gender = "Male",
                PhoneNumber = 9123456780,
                Email = "abu@gmail.com",
                InsuranceId = 102
            },

            new Patient
            {
                Id = 3,
                Name = "Manu",
                Dob = new DateTime(1992, 3, 10),
                Gender = "Male",
                PhoneNumber = 9988776655,
                Email = "manu@gmail.com",
                InsuranceId = 103
            }
        };
    }
}