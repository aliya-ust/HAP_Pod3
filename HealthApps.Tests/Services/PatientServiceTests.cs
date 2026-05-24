using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace HealthApp.Tests
{
    public class PatientServiceTests
    {
        private readonly Mock<IPatientRepository> _mockRepo;
        private readonly PatientService _service;

        public PatientServiceTests()
        {
            _mockRepo = new Mock<IPatientRepository>();

            _service = new PatientService(_mockRepo.Object);
        }

        [Fact]
        public void Register_ShouldSucceed()
        {
            // Arrange
            var patient = new Patient
            {
                Name = "Test",
                Gender = "Male",
                PhoneNumber = "9999999999",
                Email = "test@gmail.com",
                InsuranceId = "INS222",
                Dob = DateTime.Now.AddYears(-25)
            };

            _mockRepo
                .Setup(r => r.Add(It.IsAny<Patient>()))
                .Returns(true);

            // Act
            var result = _service.Register(patient);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GetPatientById_ShouldReturnPatient()
        {
            // Arrange
            int id = 101;

            var patient = new Patient
            {
                PatientId = 101,
                Name = "Arjun",
                Dob = new DateTime(1995, 5, 20),
                Gender = "Male",
                PhoneNumber = "9876543210",
                Email = "arjun@gmail.com",
                InsuranceId = "INS101",
                CreatedAt = DateTime.Now
            };

            _mockRepo
                .Setup(r => r.GetById(id))
                .Returns(patient);

            // Act
            var result = _service.GetPatientById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Arjun", result.Name);
        }

        [Fact]
        public void Update_InvalidPatient_ShouldReturnFalse()
        {
            // Arrange
            Patient patient = null;

            // Act
            var result = _service.Update(patient);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetPatientProfileSummaryById_NotFound_ShouldReturnEmpty()
        {
            // Arrange
            int id = 999;

            _mockRepo
                .Setup(r => r.GetById(id))
                .Returns((Patient)null);

            // Act
            var result = _service.GetPatientProfileSummaryById(id);

            // Assert
            Assert.Equal(string.Empty, result);
        }
    }
}