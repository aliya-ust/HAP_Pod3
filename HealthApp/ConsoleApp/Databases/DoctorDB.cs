using System;
using System.Collections.Generic;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Databases
{
    public class DoctorDb
    {
        public List<Doctor> Doctors { get; set; }

        public DoctorDb()
        {
            Doctors = new List<Doctor>
            {
                new Doctor
                {
                    DoctorId = 1,
                    FullName = "Dr. Ananya Iyer",
                    Specialisation = "Cardiology",
                    YearsOfExperience = 16,
                    ConsultationFee = 750,
                    IsActive = true,
                    Appointments = new List<DateTime>
                    {
                        DateTime.Today,
                        DateTime.Today.AddDays(1),
                        DateTime.Today.AddDays(2)
                    }
                },

                new Doctor
                {
                    DoctorId = 2,
                    FullName = "Dr. Rohit Sharma",
                    Specialisation = "Neurology",
                    YearsOfExperience = 11,
                    ConsultationFee = 650,
                    IsActive = true,
                    Appointments = new List<DateTime>
                    {
                        DateTime.Today,
                        DateTime.Today,
                        DateTime.Today.AddDays(3)
                    }
                },

                new Doctor
                {
                    DoctorId = 3,
                    FullName = "Dr. Kavya Nair",
                    Specialisation = "Orthopedics",
                    YearsOfExperience = 9,
                    ConsultationFee = 500,
                    IsActive = false,
                    Appointments = new List<DateTime>
                    {
                        DateTime.Today,
                        DateTime.Today.AddDays(2)
                    }
                },

                new Doctor
                {
                    DoctorId = 4,
                    FullName = "Dr. Aravind Menon",
                    Specialisation = "Pediatrics",
                    YearsOfExperience = 6,
                    ConsultationFee = 350,
                    IsActive = true,
                    Appointments = new List<DateTime>()
                },

                new Doctor
                {
                    DoctorId = 5,
                    FullName = "Dr. Neha Kapoor",
                    Specialisation = "Dermatology",
                    YearsOfExperience = 8,
                    ConsultationFee = 450,
                    IsActive = true,
                    Appointments = new List<DateTime>
                    {
                        DateTime.Today.AddDays(4),
                        DateTime.Today.AddDays(5)
                    }
                },

                new Doctor
                {
                    DoctorId = 6,
                    FullName = "Dr. Sandeep Varma",
                    Specialisation = "General Medicine",
                    YearsOfExperience = 5,
                    ConsultationFee = 300,
                    IsActive = true,
                    Appointments = new List<DateTime>
                    {
                        DateTime.Today,
                        DateTime.Today.AddDays(1),
                        DateTime.Today.AddDays(2)
                    }
                }
            };
        }
    }
}
