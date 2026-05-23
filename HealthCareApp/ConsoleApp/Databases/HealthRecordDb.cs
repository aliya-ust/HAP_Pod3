using System;
using System.Collections.Generic;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Databases
{
    public class HealthRecordDb
    {
        public List<HealthRecord> Records = new List<HealthRecord>()
        {
            new HealthRecord
            {
                RecordId = 301,
                Patient = new Patient
                {
                    PatientId = 101,
                    Name = "Arjun",
                    Dob = new DateTime(1995, 5, 20),
                    Gender = "Male",
                    PhoneNumber = "9876543210",
                    Email = "arjun@gmail.com",
                    InsuranceId = "INS101"
                },
                Doctor = new Doctor { DoctorId = 201, FullName = "Dr. Meera" },
                VisitDate = new DateTime(2026, 5, 10),
                Diagnosis = "Fever",
                Prescription = "Paracetamol 500mg",
                DoctorNotes = "Take rest and drink fluids"
            },

            new HealthRecord
            {
                RecordId = 302,
                Patient = new Patient
                {
                    PatientId = 101,
                    Name = "Arjun",
                    Dob = new DateTime(1995, 5, 20),
                    Gender = "Male",
                    PhoneNumber = "9876543210",
                    Email = "arjun@gmail.com",
                    InsuranceId = "INS101"
                },
                Doctor = new Doctor { DoctorId = 202, FullName = "Dr. Anjali" },
                VisitDate = new DateTime(2026, 5, 12),
                Diagnosis = "Skin Allergy",
                Prescription = "Antihistamine tablets",
                DoctorNotes = "Avoid dust and allergens"
            },

            new HealthRecord
            {
                RecordId = 303,
                Patient = new Patient
                {
                    PatientId = 101,
                    Name = "Arjun",
                    Dob = new DateTime(1995, 5, 20),
                    Gender = "Male",
                    PhoneNumber = "9876543210",
                    Email = "arjun@gmail.com",
                    InsuranceId = "INS101"
                },
                Doctor = new Doctor { DoctorId = 201, FullName = "Dr. Meera" },
                VisitDate = new DateTime(2026, 5, 8),
                Diagnosis = "Cold",
                Prescription = "Cough syrup",
                DoctorNotes = "Stay warm"
            },

            new HealthRecord
            {
                RecordId = 304,
                Patient = new Patient
                {
                    PatientId = 101,
                    Name = "Arjun",
                    Dob = new DateTime(1995, 5, 20),
                    Gender = "Male",
                    PhoneNumber = "9876543210",
                    Email = "arjun@gmail.com",
                    InsuranceId = "INS101"
                },
                Doctor = new Doctor { DoctorId = 203, FullName = "Dr. Kumar" },
                VisitDate = new DateTime(2026, 5, 12),
                Diagnosis = "Back Pain",
                Prescription = "Painkillers",
                DoctorNotes = "Avoid heavy lifting"
            },

            new HealthRecord
            {
                RecordId = 305,
                Patient = new Patient
                {
                    PatientId = 102,
                    Name = "Rahul",
                    Dob = new DateTime(1990, 3, 15),
                    Gender = "Male",
                    PhoneNumber = "9876543211",
                    Email = "rahul@gmail.com",
                    InsuranceId = "INS102"
                },
                Doctor = new Doctor { DoctorId = 201, FullName = "Dr. Meera" },
                VisitDate = new DateTime(2026, 5, 11),
                Diagnosis = "Headache",
                Prescription = "Ibuprofen",
                DoctorNotes = "Take rest"
            },

            new HealthRecord
            {
                RecordId = 306,
                Patient = new Patient
                {
                    PatientId = 103,
                    Name = "Sneha",
                    Dob = new DateTime(1998, 8, 10),
                    Gender = "Female",
                    PhoneNumber = "9876543212",
                    Email = "sneha@gmail.com",
                    InsuranceId = "INS103"
                },
                Doctor = new Doctor { DoctorId = 202, FullName = "Dr. Anjali" },
                VisitDate = new DateTime(2026, 5, 9),
                Diagnosis = "Acne",
                Prescription = "Topical gel",
                DoctorNotes = "Maintain skincare"
            }
        };
    }
}