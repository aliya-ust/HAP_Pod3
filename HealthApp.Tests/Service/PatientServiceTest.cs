using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using HealthApp.ConsoleApp.Services;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.Tests.Service
{
    public class PatientServiceTest
    {
        private Mock<PatientRepository> _mockRepo;
        private PatientService _patientService;

        public PatientServiceTest()
        {
            _mockRepo = new Mock<PatientRepository>();
            _patientService=new PatientService(_mockRepo.Object);
        }

        [Fact]
        public void AddPatient_ShouldAddPatient()
        {
            // Arrange
            var patient = new Patient { Name = "Arjun" };
            _mockRepo.Setup(repo => repo.Add(patient)).Verifiable();
            // Act
            _patientService.Register(patient);
            // Assert
            _mockRepo.Verify(repo => repo.Add(patient), Times.Once);
        }

        [Fact]
        public void UpdatePatient_ShouldUpdatePatient()
        {
            // Arrange
            var patient = new Patient { PatientId = 1, Name = "Arjun" };
            _mockRepo.Setup(repo => repo.Update(patient)).Verifiable();
            // Act
            _patientService.Update(patient);
            // Assert
            _mockRepo.Verify(repo => repo.Update(patient), Times.Once);
        }

        [Fact]
        public void DeletePatient_ShouldDeletePatient()
        {
            // Arrange
            int patientId = 1;
            _mockRepo.Setup(repo => repo.Delete(patientId)).Verifiable();
            // Act
            _patientService.Delete(patientId);
            // Assert
            _mockRepo.Verify(repo => repo.Delete(patientId), Times.Once);
        }

        [Fact]
        public void GetPatientById_ShouldReturnPatient()
        {
            // Arrange
            var patient = new Patient { PatientId = 1, Name = "Arjun" };
            _mockRepo.Setup(repo => repo.GetById(1)).Returns(patient);
        }

        [Fact]
        public void GetAllPatients_ShouldReturnAllPatients()
        {
            // Arrange
            var patients = new List<Patient>
            {
                new Patient { PatientId = 1, Name = "Arjun" },
                new Patient { PatientId = 2, Name = "kevin" }
            };
            _mockRepo.Setup(repo => repo.GetAll()).Returns(patients);
            // Act

            var result = _patientService.GetAllPatients();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Arjun", result[0].Name);
        }

    }
}
