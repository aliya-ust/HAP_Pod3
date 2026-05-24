using Xunit;
using System;
using HealthApp.ConsoleApp.Databases;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Services;
using HealthApp.ConsoleApp.Exceptions;

namespace HealthApp.Tests
{
    public class HealthRecordServiceTests
    {
        private readonly HealthRecordService _service;

        public HealthRecordServiceTests()
        {
            _service = new HealthRecordService(
                new HealthRecordRepository(new HealthRecordDb()),
                new DoctorRepository(new DoctorDb()),
                new PatientRepository(new PatientDb())
            );
        }

        [Fact]
        public void GetByPatientId_ShouldReturnRecords()
        {
            // Arrange
            int patientId = 101;

            // Act
            var result = _service.GetByPatientIdOrderByVisitDateDesc(patientId);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetRecordById_ShouldReturnRecord()
        {
            // Arrange
            int recordId = 301;

            // Act
            var result = _service.GetRecordById(recordId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(301, result.RecordId);
        }

        [Fact]
        public void AddHealthRecord_ShouldSucceed()
        {
            // Arrange
            var record = new HealthRecord
            {
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
                Doctor = new Doctor
                {
                    DoctorId = 201,
                    FullName = "Dr. Meera",
                    Specialisation = "General"
                },
                VisitDate = DateTime.Today,
                Diagnosis = "Test Diagnosis",
                Prescription = "Test Medicine",
                DoctorNotes = "Test Notes"
            };

            // Act
            var result = _service.AddHealthRecord(record);

            // Assert
            Assert.Contains("added successfully", result);
        }

        [Fact]
        public void GetByPatientId_InvalidPatient_ShouldThrow()
        {
            // Arrange
            int invalidId = 999;

            // Act & Assert
            Assert.Throws<PatientNotFoundException>(() =>
                _service.GetByPatientIdOrderByVisitDateDesc(invalidId));
        }

        [Fact]
        public void GetByDoctorId_InvalidDoctor_ShouldThrow()
        {
            // Arrange
            int invalidDoctorId = 999;

            // Act & Assert
            Assert.Throws<DoctorNotFoundException>(() =>
                _service.GetByDoctorIdOrderByVisitDateDesc(invalidDoctorId));
        }

        [Fact]
        public void UpdateHealthRecord_ShouldUpdate()
        {
            // Arrange
            var existing = _service.GetRecordById(301);

            var updatedRecord = new HealthRecord
            {
                RecordId = existing.RecordId,
                Patient = existing.Patient,
                Doctor = existing.Doctor,
                VisitDate = existing.VisitDate,
                Diagnosis = "Updated Diagnosis",
                Prescription = "Updated Prescription",
                DoctorNotes = "Updated Notes"
            };

            // Act
            var result = _service.UpdateHealthRecord(updatedRecord);

            // Assert
            Assert.Equal("Updated Diagnosis", result.Diagnosis);
        }
    }
}