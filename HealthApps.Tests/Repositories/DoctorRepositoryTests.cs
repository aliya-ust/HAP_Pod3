using Xunit;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Databases;
using HealthApp.ConsoleApp.Models;
using System;

namespace HealthApp.Tests
{
    public class DoctorRepositoryTests
    {
        private readonly DoctorRepository _repo;

        public DoctorRepositoryTests()
        {
            _repo = new DoctorRepository(new DoctorDb());
        }

        [Fact]
        public void GetAllDoctors_ShouldReturnData()
        {
            // Act
            var result = _repo.GetAllDoctors();

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetByDoctorId_ShouldReturnDoctor()
        {
            // Arrange
            int id = 201;

            // Act
            var result = _repo.GetByDoctorId(id);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetDoctorsBySpecialisation_ShouldFilter()
        {
            // Arrange
            string spec = "Cardiology";

            // Act
            var result = _repo.GetDoctorsBySpecialisation(spec);

            // Assert
            Assert.Contains(result, d => d.Specialisation == "Cardiology");
        }
    }
}