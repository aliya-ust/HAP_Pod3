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
                    DoctorId = 201,
                    Name = "John Smith",
                    Specialisation = "Cardiology",
                    YearsOfExperience = 15,
                    ConsultationFee = 500,
                    IsActive = true,

                    AvailableSlots = new List<string>
                    {
                        "10:00 AM",
                        "11:00 AM",
                        "03:00 PM"
                    },
                    AvailableDates = new List<DateTime>
                    {
                        DateTime.Today,
                        DateTime.Today.AddDays(1),
                    
                    }
                },

                new Doctor
                {
                    DoctorId = 202,
                    Name = "Emily Davis",
                    Specialisation = "Dermatology",
                    YearsOfExperience = 10,
                    ConsultationFee = 400,
                    IsActive = true,

                    AvailableSlots =
                    [
                        "09:00 AM",
                        "12:00 PM",
                        "04:00 PM"
                    ],
                    AvailableDates =
                    [
                        DateTime.Today.AddDays(1),
                        DateTime.Today.AddDays(2),
                        DateTime.Today.AddDays(3)
                    ]   
                },
                new Doctor
                {
                    DoctorId = 203,
                    Name = "Michael Brown",
                    Specialisation = "Orthopedics",
                    YearsOfExperience = 20,
                    ConsultationFee = 600,
                    IsActive = false,
                    AvailableSlots =
                    [
                        "09:00 AM",
                        "12:00 PM",
                        "04:00 PM"
                    ],
                    AvailableDates =
                    [
                        DateTime.Today,
                        DateTime.Today.AddDays(1),
                        DateTime.Today.AddDays(3)
                    ]
                },

                new Doctor
                {
                    DoctorId = 204,
                    Name = "Sarah Johnson",
                    Specialisation = "Pediatrics",
                    YearsOfExperience = 8,
                    ConsultationFee = 300,
                    IsActive = true,
                    AvailableSlots =
                    [
                        "10:00 AM",
                        "01:00 PM",
                        "03:00 PM"
                    ],
                    AvailableDates =
                    [
                        DateTime.Today.AddDays(2),
                        DateTime.Today.AddDays(4)
                    ]
                },

                new Doctor
                {
                    DoctorId = 205,
                    Name = "David Wilson",
                    Specialisation = "Neurology",
                    YearsOfExperience = 12,
                    ConsultationFee = 550,
                    IsActive = true,
                   AvailableSlots =
                    [
                        "09:00 AM",
                        "11:00 AM",
                        "02:00 PM"
                    ],
                    AvailableDates =
                    [
                        DateTime.Today.AddDays(5),
                        DateTime.Today.AddDays(7)
                    ]
                },

                new Doctor
                {
                    DoctorId = 206,
                    Name = "Loki",
                    Specialisation = "Skin",
                    YearsOfExperience = 3,
                    ConsultationFee = 400,
                    IsActive = true,
                    AvailableSlots =
                    [
                        "09:00 AM",
                        "12:00 PM",
                        "04:00 PM"
                    ],
                    AvailableDates =
                    [
                        DateTime.Today,
                        DateTime.Today.AddDays(1),
                        DateTime.Today.AddDays(3)
                    ]
                }
            };
        }
    }
}

// namespace HealthApp.ConsoleApp.Databases
// {
//     public class DoctorDb
//     {
//         public List<Doctor> Doctors { get; set; }

//         public DoctorDb()
//         {
//             Doctors = new List<Doctor>
//             {
//                 new Doctor
//                 {
//                     DoctorId = 201,
//                     Name = "Dr. John Smith",
//                     Specialisation = "Cardiology",
//                     YearsOfExperience = 15,
//                     ConsultationFee = 500,
//                     IsActive = true,
//                     Appointments = new List<DateTime>
//                     {
//                         DateTime.Today,
//                         DateTime.Today,
//                         DateTime.Today,
//                         DateTime.Today,
//                         DateTime.Today
//                     }
//                 },

//                 new Doctor
//                 {
//                     DoctorId = 202,
//                     Name = "Dr. Emily Davis",
//                     Specialisation = "Dermatology",
//                     YearsOfExperience = 10,
//                     ConsultationFee = 400,
//                     IsActive = true,
//                     Appointments = new List<DateTime>
//                     {
//                         DateTime.Today.AddDays(1),
//                         DateTime.Today.AddDays(2),
//                         DateTime.Today.AddDays(3)
//                     }
//                 },

//                 new Doctor
//                 {
//                     DoctorId = 203,
//                     Name = "Dr. Michael Brown",
//                     Specialisation = "Orthopedics",
//                     YearsOfExperience = 20,
//                     ConsultationFee = 600,
//                     IsActive = false,
//                     Appointments = new List<DateTime>
//                     {
//                         DateTime.Today,
//                         DateTime.Today,
//                         DateTime.Today,
//                         DateTime.Today,
//                         DateTime.Today,
//                         DateTime.Today,
//                         DateTime.Today.AddDays(3)
//                     }
//                 },

//                 new Doctor
//                 {
//                     DoctorId = 204,
//                     Name = "Dr. Sarah Johnson",
//                     Specialisation = "Pediatrics",
//                     YearsOfExperience = 8,
//                     ConsultationFee = 300,
//                     IsActive = true,
//                     Appointments = new List<DateTime>()
//                 },

//                 new Doctor
//                 {
//                     DoctorId = 205,
//                     Name = "Dr. David Wilson",
//                     Specialisation = "Neurology",
//                     YearsOfExperience = 12,
//                     ConsultationFee = 550,
//                     IsActive = true,
//                     Appointments = new List<DateTime>
//                     {
//                         DateTime.Today.AddDays(5),
//                         DateTime.Today.AddDays(7)
//                     }
//                 },

//                 new Doctor
//                 {
//                     DoctorId = 206,
//                     Name = "Dr. Loki",
//                     Specialisation = "Skin",
//                     YearsOfExperience = 3,
//                     ConsultationFee = 400,
//                     IsActive = true,
//                     Appointments = new List<DateTime>
//                     {
//                         DateTime.Today,
//                         DateTime.Today.AddDays(1),
//                         DateTime.Today.AddDays(3)
//                     }
//                 }
//             };  
//         }
//     }
// }