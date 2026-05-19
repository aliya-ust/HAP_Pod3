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
    public class DoctorServiceTests
    {
        private readonly Mock<IDoctorRepository> _mockRepo;
        private readonly DoctorService _service;

        public DoctorServiceTests()
        {
            _mockRepo = new Mock<IDoctorRepository>();
            _service = new DoctorService(_mockRepo.Object);
        }

        private Doctor CreateValidDoctor(int id, string name, string specialisation)
        {
            return new Doctor
            {
                DoctorId = id,
                FullName = name,
                Specialisation = specialisation,
                YearsOfExperience = 10,
                ConsultationFee = 500m,
                IsActive = true
            };
        }

        [Fact]
        public void AddDoctor_ShouldAddDoctor_WhenNotExists()
        {
            var doctor = CreateValidDoctor(1, "Dr. John", "Cardiology");

            _mockRepo.Setup(r => r.GetDoctorById(1))
                     .Returns((Doctor?)null);

            _mockRepo.Setup(r => r.AddDoctor(doctor))
                     .Returns("Doctor ID 1 added successfully!");

            var result = _service.AddDoctor(doctor);

            Assert.Equal("Doctor ID 1 added successfully!", result);
            _mockRepo.Verify(r => r.AddDoctor(doctor), Times.Once);
        }

        [Fact]
        public void AddDoctor_ShouldThrowException_WhenDoctorExists()
        {
            var doctor = CreateValidDoctor(1, "Dr. John", "Cardiology");

            _mockRepo.Setup(r => r.GetDoctorById(1))
                     .Returns(doctor);

            Assert.Throws<DoctorAlreadyExistsException>(
                () => _service.AddDoctor(doctor)
            );

            _mockRepo.Verify(r => r.AddDoctor(It.IsAny<Doctor>()), Times.Never);
        }

        [Fact]
        public void GetDoctorById_ShouldReturnDoctor_WhenExists()
        {
            var doctor = CreateValidDoctor(1, "Dr. John", "Cardiology");

            _mockRepo.Setup(r => r.GetDoctorById(1))
                     .Returns(doctor);

            var result = _service.GetDoctorById(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.DoctorId);
            Assert.Equal("Dr. John", result.FullName);
        }

        [Fact]
        public void GetDoctorById_ShouldReturnNull_WhenNotFound()
        {
            _mockRepo.Setup(r => r.GetDoctorById(1))
                     .Returns((Doctor?)null);

            var result = _service.GetDoctorById(1);

            Assert.Null(result);
        }

        [Fact]
        public void GetDoctorsBySpecialisation_ShouldReturnDoctors_WhenFound()
        {
            var doctors = new List<Doctor>
            {
                CreateValidDoctor(1, "Dr. A", "Cardiology"),
                CreateValidDoctor(2, "Dr. B", "Cardiology")
            };

            _mockRepo.Setup(r => r.GetDoctorsBySpecialisation("Cardiology"))
                     .Returns(doctors);

            var result = _service.GetDoctorsBySpecialisation("Cardiology");

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetDoctorsBySpecialisation_ShouldThrowException_WhenEmptyList()
        {
            _mockRepo.Setup(r => r.GetDoctorsBySpecialisation("Cardiology"))
                     .Returns(new List<Doctor>());

            Assert.Throws<SpecialisationNotFoundException>(
                () => _service.GetDoctorsBySpecialisation("Cardiology")
            );
        }
    }
}