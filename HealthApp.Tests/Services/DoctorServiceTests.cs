using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Timers;
using Xunit;

namespace HealthApp.Tests.Services
{
    public class DoctorServiceTests
    {
        private readonly Mock<IDoctorRepository> _mockRepo;
        private readonly DoctorService _service;

        public DoctorServiceTests()
        {
            _mockRepo = new Mock<IDoctorRepository>();
            _service = new DoctorService(_mockRepo.Object);
        }

        [Fact]
        public void AddDoctor_Should_Add_When_Id_Is_Unique()
        {
            // Arrange
            var doctors = new List<Doctor>();

            _mockRepo.Setup(r => r.GetAllDoctors()).Returns(doctors);

            var newDoctor = new Doctor
            {
                DoctorId = 10,
                FullName = "Test Doctor"
            };

            // Act
            _service.AddDoctor(newDoctor);

            // Assert
            _mockRepo.Verify(r => r.AddDoctor(newDoctor), Times.Once);
        }

        [Fact]
        public void AddDoctor_Should_Throw_Exception_When_Id_Exists()
        {
            // Arrange
            var doctors = new List<Doctor>
            {
                new Doctor { DoctorId = 1, FullName = "Existing Doctor" }
            };

            _mockRepo.Setup(r => r.GetAllDoctors()).Returns(doctors);

            var duplicateDoctor = new Doctor
            {
                DoctorId = 1
            };

            // Act & Assert
            Assert.Throws<DoctorAlreadyExistsException>(() =>
                _service.AddDoctor(duplicateDoctor)
            );
        }

        [Fact]
        public void GetAllDoctors_Should_Return_List()
        {
            // Arrange
            var doctors = new List<Doctor>
            {
                new Doctor { DoctorId = 1 },
                new Doctor { DoctorId = 2 }
            };

            _mockRepo.Setup(r => r.GetAllDoctors()).Returns(doctors);

            // Act
            var result = _service.GetAllDoctors();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void SearchBySpecialisation_Should_Return_Doctors()
        {
            // Arrange
            var doctors = new List<Doctor>
            {
                new Doctor { DoctorId = 1, Specialisation = "Skin" }
            };

            _mockRepo.Setup(r => r.GetDoctorsBySpecialisation("Skin"))
                     .Returns(doctors);

            // Act
            var result = _service.SearchBySpecialisation("Skin");

            // Assert
            Assert.Single(result);
        }

        [Fact]
        public void SearchBySpecialisation_Should_Throw_When_Not_Found()
        {
            // Arrange
            _mockRepo.Setup(r => r.GetDoctorsBySpecialisation("XYZ"))
                     .Returns(new List<Doctor>());

            // Act & Assert
            Assert.Throws<SpecialisationNotFoundException>(() =>
                _service.SearchBySpecialisation("XYZ")
            );
        }

        [Fact]
        public void GetById_Should_Return_Doctor_When_Exists()
        {
            // Arrange
            var doctor = new Doctor { DoctorId = 1 };

            _mockRepo.Setup(r => r.GetById(1)).Returns(doctor);

            // Act
            var result = _service.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.DoctorId);
        }

        [Fact]
        public void GetById_Should_Throw_When_Not_Found()
        {
            // Arrange
            _mockRepo.Setup(r => r.GetById(999)).Returns((Doctor)null);

            // Act & Assert
            Assert.Throws<Exception>(() =>
                _service.GetById(999)
            );
        }
    }
}