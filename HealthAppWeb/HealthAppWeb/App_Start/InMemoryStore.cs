using HealthAppWeb.Models;
using System;
using System.Collections.Generic;

namespace HealthAppWeb.App_Start
{
    public static class InMemoryStore
    {
        public static List<User> Users = new List<User>
        {
            new User { UserId = 1, Email = "admin@hospital.com",   PasswordHash = "admin123",   Role = "Admin",   FullName = "Admin User" },
            new User { UserId = 2, Email = "doctor@hospital.com",  PasswordHash = "doctor123",  Role = "Doctor",  FullName = "Dr. Smith"  },
            new User { UserId = 3, Email = "patient@hospital.com", PasswordHash = "patient123", Role = "Patient", FullName = "John Doe"   }
        };

        public static List<Patient> Patients = new List<Patient>
        {
            new Patient
            {
                PatientId   = 1,
                UserId      = 3,
                FullName    = "John Doe",
                DateOfBirth = new DateTime(1990, 5, 15),
                Gender      = "Male",
                PhoneNumber = "9876543210",
                Email       = "patient@hospital.com",
                InsuranceId = "INS001",
                CreatedDate = DateTime.Now
            }
        };

        public static List<Doctor> Doctors = new List<Doctor>
        {
            new Doctor
            {
                DoctorId          = 1,
                UserId            = 2,
                FullName          = "Dr. Smith",
                Specialisation    = "Cardiology",
                YearsOfExperience = 10,
                ConsultationFee   = 500,
                IsActive          = true,
                CreatedDate       = DateTime.Now
            }
        };

        public static List<Appointment> Appointments = new List<Appointment>
        {
            new Appointment
            {
                AppointmentId = 1,
                PatientId     = 1,
                DoctorId      = 1,
                ScheduledDate = DateTime.Today,
                TimeSlot      = "10:00 AM",
                Status        = "Pending",
                CreatedDate   = DateTime.Now
            }
        };

        public static List<HealthRecord> HealthRecords = new List<HealthRecord>();
        public static List<DoctorAvailableSlot> DoctorAvailableSlots = new List<DoctorAvailableSlot>
        {
            new DoctorAvailableSlot { Id = 1, DoctorId = 1, TimeSlot = "09:00 AM" },
            new DoctorAvailableSlot { Id = 2, DoctorId = 1, TimeSlot = "10:00 AM" },
            new DoctorAvailableSlot { Id = 3, DoctorId = 1, TimeSlot = "11:00 AM" },
            new DoctorAvailableSlot { Id = 4, DoctorId = 1, TimeSlot = "02:00 PM" }
        };
        public static List<DoctorLeave> DoctorLeaves = new List<DoctorLeave>();

        public static int NextUserId = 4;
        public static int NextPatientId = 2;
        public static int NextDoctorId = 2;
        public static int NextAppointmentId = 2;
        public static int NextHealthRecordId = 1;
        public static int NextSlotId = 5;
    }
}