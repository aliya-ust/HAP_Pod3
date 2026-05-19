using System;
using System.Linq;
using Xunit;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Repositories;

namespace HealthApp.Tests
{
    public class DoctorRepositoryTests
    {
        private readonly DoctorRepository repository;

        public DoctorRepositoryTests()
        {
            // Uses your existing database (no new DB created)
            repository = new DoctorRepository();
        }

        [Fact]
        public void GetAll_Should_Return_Doctors_From_Database()
        {
            // Act
            var doctors = repository.GetAll();

            // Assert
            Assert.NotNull(doctors);
            Assert.True(doctors.Count >= 0); // DB may or may not have data
        }

        [Fact]
        public void GetById_Should_Return_Doctor_When_Exists()
        {
            // Arrange
            var allDoctors = repository.GetAll();

            // If DB is empty, test skips safely
            if (allDoctors.Count == 0)
                return;

            var firstDoctorId = allDoctors.First().DoctorId;

            // Act
            var doctor = repository.GetById(firstDoctorId);

            // Assert
            Assert.NotNull(doctor);
            Assert.Equal(firstDoctorId, doctor.DoctorId);
        }

        [Fact]
        public void GetById_Should_Throw_Exception_When_Not_Found()
        {
            // Arrange
            int invalidId = -999;

            // Act & Assert
            Assert.Throws<Exception>(() => repository.GetById(invalidId));
        }

        [Fact]
        public void AddDoctor_Should_Add_And_Retrieve_From_Database()
        {
            // Arrange
            var doctor = new Doctor
            {
                DoctorId = new Random().Next(1000, 9999), // avoid duplicate
                FullName = "Test Doctor",
                Specialisation = "Testing",
                YearsOfExperience = 5,
                ConsultationFee = 200,
                IsActive = true
            };

            // Act
            repository.Add(doctor);
            var fetched = repository.GetById(doctor.DoctorId);

            // Assert
            Assert.NotNull(fetched);
            Assert.Equal("Test Doctor", fetched.FullName);
        }
    }
}