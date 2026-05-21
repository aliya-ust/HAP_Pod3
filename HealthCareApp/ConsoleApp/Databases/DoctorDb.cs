using HealthApp.ConsoleApp.Models;
using System;
using System.Collections.Generic;

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
                    Id = 1,
                    FullName = "Dr. John Smith",
                    Specialisation = "Cardiology",
                    YearsOfExperience = 15,
                    ConsultationFee = 500,
                    IsActive = true,
                    Appointments = new List<DateTime>
                    {
                        DateTime.Today,
                        DateTime.Today,
                        DateTime.Today,
                        DateTime.Today,
                        DateTime.Today
                    }
                },

                new Doctor
                {
                    Id = 2,
                    FullName = "Dr. Emily Davis",
                    Specialisation = "Dermatology",
                    YearsOfExperience = 10,
                    ConsultationFee = 400,
                    IsActive = true,
                    Appointments = new List<DateTime>
                    {
                        DateTime.Today.AddDays(1),
                        DateTime.Today.AddDays(2),
                        DateTime.Today.AddDays(3)
                    }
                },

                new Doctor
                {
                    Id = 3,
                    FullName = "Dr. Michael Brown",
                    Specialisation = "Orthopedics",
                    YearsOfExperience = 20,
                    ConsultationFee = 600,
                    IsActive = false,
                    Appointments = new List<DateTime>
                    {
                        DateTime.Today,
                        DateTime.Today,
                        DateTime.Today,
                        DateTime.Today,
                        DateTime.Today,
                        DateTime.Today,
                        DateTime.Today.AddDays(3)
                    }
                },

                new Doctor
                {
                    Id = 4,
                    FullName = "Dr. Sarah Johnson",
                    Specialisation = "Pediatrics",
                    YearsOfExperience = 8,
                    ConsultationFee = 300,
                    IsActive = true,
                    Appointments = new List<DateTime>()
                },

                new Doctor
                {
                    Id = 5,
                    FullName = "Dr. David Wilson",
                    Specialisation = "Neurology",
                    YearsOfExperience = 12,
                    ConsultationFee = 550,
                    IsActive = true,
                    Appointments = new List<DateTime>
                    {
                        DateTime.Today.AddDays(5),
                        DateTime.Today.AddDays(7)
                    }
                },

                new Doctor
                {
                    Id = 6,
                    FullName = "Loki",
                    Specialisation = "Skin",
                    YearsOfExperience = 3,
                    ConsultationFee = 400,
                    IsActive = true,
                    Appointments = new List<DateTime>
                    {
                        DateTime.Today,
                        DateTime.Today.AddDays(1),
                        DateTime.Today.AddDays(3)
                    }
                }
            };
        }
    }
}