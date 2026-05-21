using System;
using System.Collections.Generic;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Databases
{
    public class HealthRecordDB
    {
        public List<HealthRecord> Records = new List<HealthRecord>()
        {
            new HealthRecord
            {
                Id = 1,
                Patient = new Patient { Id = 1, Name = "Priya" },
                Doctor = new Doctor { Id = 1, FullName = "Dr. Ananya Iyer" },
                VisitDate = new DateTime(2026, 5, 10),
                Diagnosis = "Fever and cold",
                Prescription = "Paracetamol, Rest",
                DoctorNotes = "Mild viral infection"
            },

            new HealthRecord
            {
                Id = 2,
                Patient = new Patient { Id = 1, Name = "Priya" },
                Doctor = new Doctor { Id = 2, FullName = "Dr. Rohit Sharma" },
                VisitDate = new DateTime(2026, 5, 12),
                Diagnosis = "Skin allergy",
                Prescription = "Antihistamines, Ointment",
                DoctorNotes = "Avoid allergens"
            },

            new HealthRecord
            {
                Id = 3,
                Patient = new Patient { Id = 1, Name = "Priya" },
                Doctor = new Doctor { Id = 1, FullName = "Dr. Ananya Iyer" },
                VisitDate = new DateTime(2026, 5, 8),
                Diagnosis = "Headache",
                Prescription = "Pain reliever",
                DoctorNotes = "Monitor sleep pattern"
            },

            new HealthRecord
            {
                Id = 4,
                Patient = new Patient { Id = 1, Name = "Priya" },
                Doctor = new Doctor { Id = 3, FullName = "Dr. Kavya Nair" },
                VisitDate = new DateTime(2026, 5, 12),
                Diagnosis = "Back pain",
                Prescription = "Muscle relaxant",
                DoctorNotes = "Physiotherapy recommended"
            },

            new HealthRecord
            {
                Id = 5,
                Patient = new Patient { Id = 2, Name = "Abu" },
                Doctor = new Doctor { Id = 1, FullName = "Dr. Ananya Iyer" },
                VisitDate = new DateTime(2026, 5, 11),
                Diagnosis = "Diabetes",
                Prescription = "Insulin, Diet control",
                DoctorNotes = "Regular sugar check required"
            },

        };
    }
}