<<<<<<< HEAD
﻿using HealthApp.ConsoleApp.Exceptions;
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
=======
using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using HealthApp.ConsoleApp.Services;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Exceptions;

namespace HealthApp.Tests.Services
{
    // Test class for DoctorService to validate doctor management functionalities
>>>>>>> 4d8a0e3f027eb90749388ec6177e69d6c9a087fb
    public class DoctorServiceTests
    {
        private readonly Mock<IDoctorRepository> _mockRepo;
        private readonly DoctorService _service;

        public DoctorServiceTests()
        {
            _mockRepo = new Mock<IDoctorRepository>();
            _service = new DoctorService(_mockRepo.Object);
        }

<<<<<<< HEAD
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
=======
        private static Doctor GetSampleDoctor(int id)
        {
            return new Doctor
            {
                DoctorId = id,
                Name = "Doctor " + id,
                Specialisation = "General"
            };
        }

        // AddDoctor
        [Fact]
        public void AddDoctor_ShouldAssignIdAndAddDoctor()
        {
            var doctors = new List<Doctor>
            {
                GetSampleDoctor(101),
                GetSampleDoctor(102)
            };

            var newDoctor = GetSampleDoctor(0);

            _mockRepo.Setup(r => r.GetAllDoctors()).Returns(doctors);
            _mockRepo.Setup(r => r.AddDoctor(It.IsAny<Doctor>()))
                     .Returns("Doctor added successfully");

            var result = _service.AddDoctor(newDoctor);

            Assert.Equal(103, newDoctor.DoctorId);
            Assert.Contains("successfully", result);
        }

        // GetDoctorById
        [Fact]
        public void GetDoctorById_ShouldReturnDoctor()
        {
            var doctor = GetSampleDoctor(101);

            _mockRepo.Setup(r => r.GetDoctorById(101)).Returns(doctor);

            var result = _service.GetDoctorById(101);

            Assert.NotNull(result);
            Assert.Equal(101, result.DoctorId);
        }

        // GetDoctorById - Exception
        [Fact]
        public void GetDoctorById_ShouldThrowException_WhenNotFound()
        {
            _mockRepo.Setup(r => r.GetDoctorById(999)).Returns((Doctor?)null);

            Assert.Throws<DoctorNotFoundException>(() => _service.GetDoctorById(999));
        }

        // GetDoctorsBySpecialisation
        [Fact]
        public void GetDoctorsBySpecialisation_ShouldReturnDoctors()
        {
            var doctors = new List<Doctor>
            {
                GetSampleDoctor(101),
                GetSampleDoctor(102)
            };

            _mockRepo.Setup(r => r.GetDoctorsBySpecialisation("General"))
                     .Returns(doctors);

            var result = _service.GetDoctorsBySpecialisation("General");

            Assert.Equal(2, result.Count);
        }

        // GetDoctorsBySpecialisation - Exception
        [Fact]
        public void GetDoctorsBySpecialisation_ShouldThrowException_WhenNoDoctors()
        {
            _mockRepo.Setup(r => r.GetDoctorsBySpecialisation("Cardiology"))
                     .Returns(new List<Doctor>());

            Assert.Throws<SpecialisationNotFoundException>(() =>
                _service.GetDoctorsBySpecialisation("Cardiology"));
        }

        // UpdateDoctor
        [Fact]
        public void UpdateDoctor_ShouldUpdateDoctor()
        {
            var existing = GetSampleDoctor(101);
            var updated = GetSampleDoctor(101);
            updated.Name = "Updated Name";

            _mockRepo.Setup(r => r.GetDoctorById(101)).Returns(existing);
            _mockRepo.Setup(r => r.UpdateDoctor(existing, updated)).Returns(updated);

            var result = _service.UpdateDoctor(updated);

            Assert.Equal("Updated Name", result.Name);
        }

        // UpdateDoctor - Exception
        [Fact]
        public void UpdateDoctor_ShouldThrowException_WhenDoctorNotFound()
        {
            var doctor = GetSampleDoctor(999);

            _mockRepo.Setup(r => r.GetDoctorById(999)).Returns((Doctor?)null);

            Assert.Throws<DoctorNotFoundException>(() => _service.UpdateDoctor(doctor));
        }

        // DoctorIdGenerator
        [Fact]
        public void DoctorIdGenerator_ShouldReturnNextId()
        {
            var doctors = new List<Doctor>
            {
                GetSampleDoctor(101),
                GetSampleDoctor(102)
            };

            var result = DoctorService.DoctorIdGenerator(doctors);

            Assert.Equal(103, result);
        }

        // DoctorIdGenerator - Empty List
        [Fact]
        public void DoctorIdGenerator_ShouldReturn101_WhenEmpty()
        {
            var doctors = new List<Doctor>();

            var result = DoctorService.DoctorIdGenerator(doctors);

            Assert.Equal(201, result);
>>>>>>> 4d8a0e3f027eb90749388ec6177e69d6c9a087fb
        }
    }
}