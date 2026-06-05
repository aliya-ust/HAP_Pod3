using HealthCareApi.Data.Context;
using HealthCareApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace HealthCareApi.Data.Seed
{
    public class HealthCareDbInitializer : CreateDatabaseIfNotExists<HealthCareDbContext>
    {
        protected override void Seed(HealthCareDbContext context)
        {
            // ── Doctors ──────────────────────────────────────────────
            var doctors = new List<Doctor>
            {
                new Doctor { FullName = "Dr. Arjun Mehta",    Specialisation = "Cardiology",      YearsOfExperience = 12, ConsultationFee = 800, IsActive = true, CreatedDate = DateTime.UtcNow },
                new Doctor { FullName = "Dr. Priya Ramesh",   Specialisation = "Dermatology",     YearsOfExperience = 8,  ConsultationFee = 600, IsActive = true, CreatedDate = DateTime.UtcNow },
                new Doctor { FullName = "Dr. Karthik Nair",   Specialisation = "Orthopedics",     YearsOfExperience = 15, ConsultationFee = 900, IsActive = true, CreatedDate = DateTime.UtcNow },
                new Doctor { FullName = "Dr. Sneha Iyer",     Specialisation = "Neurology",       YearsOfExperience = 10, ConsultationFee = 1000, IsActive = true, CreatedDate = DateTime.UtcNow },
                new Doctor { FullName = "Dr. Rahul Sharma",   Specialisation = "General Practice",YearsOfExperience = 5,  ConsultationFee = 400, IsActive = true, CreatedDate = DateTime.UtcNow }
            };
            context.Doctors.AddRange(doctors);
            context.SaveChanges();

            // ── Patients ─────────────────────────────────────────────
            var patients = new List<Patient>
            {
                new Patient { FullName = "Ananya Krishnan", DateOfBirth = new DateTime(1990, 4, 12), Gender = "Female", PhoneNumber = "9876543210", Email = "ananya@example.com", InsuranceId = "INS001", CreatedDate = DateTime.UtcNow },
                new Patient { FullName = "Vikram Patel",    DateOfBirth = new DateTime(1985, 9, 23), Gender = "Male",   PhoneNumber = "9123456780", Email = "vikram@example.com",  InsuranceId = "INS002", CreatedDate = DateTime.UtcNow },
                new Patient { FullName = "Meena Subramanian", DateOfBirth = new DateTime(1998, 1, 5), Gender = "Female", PhoneNumber = "9988776655", Email = "meena@example.com",  InsuranceId = "INS003", CreatedDate = DateTime.UtcNow }
            };
            context.Patients.AddRange(patients);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}