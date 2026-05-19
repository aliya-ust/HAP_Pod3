using System;
using Xunit;
using Moq;
using HealthApp.ConsoleApp.Services;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Exceptions;

namespace HealthApp.Tests.Services
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

        private Patient CreateValidPatient(int id, string name)
        {
            return new Patient
            {
                PatientId = id,
                FullName = name,
                PhoneNumber = "9999999999",
                Email = $"{name.Replace(" ", "").ToLower()}@email.com"
            };
        }

        [Fact]
        public void RegisterPatient_ShouldAddPatient_WhenNotExists()
        {
            var patient = CreateValidPatient(1, "John Doe");

            _mockRepo.Setup(repo => repo.GetPatientById(1))
                     .Returns((Patient?)null);

            _mockRepo.Setup(repo => repo.RegisterPatient(patient))
                     .Returns("Patient ID 1 added successfully!");

            var result = _service.RegisterPatient(patient);

            // Assert
            Assert.Equal("Patient ID 1 added successfully!", result);

            _mockRepo.Verify(r => r.RegisterPatient(patient), Times.Once);
        }

        [Fact]
        public void RegisterPatient_ShouldThrowException_WhenPatientExists()
        {
            var patient = CreateValidPatient(1, "John Doe");

            _mockRepo.Setup(repo => repo.GetPatientById(1))
                     .Returns(patient);

            Assert.Throws<PatientAlreadyExistsException>(
                () => _service.RegisterPatient(patient)
            );

            _mockRepo.Verify(r => r.RegisterPatient(It.IsAny<Patient>()), Times.Never);
        }


        [Fact]
        public void GetPatientById_ShouldReturnPatient_WhenExists()
        {
            var patient = CreateValidPatient(1, "John Doe");

            _mockRepo.Setup(repo => repo.GetPatientById(1))
                     .Returns(patient);

            var result = _service.GetPatientById(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.PatientId);
            Assert.Equal("John Doe", result.FullName);
        }

        [Fact]
        public void GetPatientById_ShouldReturnNull_WhenNotFound()
        {
            _mockRepo.Setup(repo => repo.GetPatientById(1))
                     .Returns((Patient?)null);

            var result = _service.GetPatientById(1);

            Assert.Null(result);
        }
    }
}
