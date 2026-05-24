using Xunit;
using HealthApp.ConsoleApp.Databases;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Repositories;
using System;

namespace HealthApp.Tests
{
    public class PatientRepositoryTests
    {
        private readonly PatientRepository _repo;

        public PatientRepositoryTests()
        {
            _repo = new PatientRepository(new PatientDb());
        }

        [Fact]
        public void Add_ShouldAddPatient()
        {
            // Arrange
            var patient = new Patient
            {
                Name = "Test",
                Gender = "Male",
                PhoneNumber = "9999999999",
                Email = "test@gmail.com",
                InsuranceId = "INS999",
                Dob = DateTime.Now.AddYears(-20)
            };

            // Act
            var result = _repo.Add(patient);
            var patients = _repo.GetAll();

            // Assert
            Assert.True(result);
            Assert.Contains(patients, p => p.Name == "Test");
        }

        [Fact]
        public void GetById_ShouldReturnPatient()
        {
            // Arrange
            int id = 101;

            // Act
            var result = _repo.GetById(id);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Update_ShouldModifyPatient()
        {
            // Arrange
            var patient = _repo.GetById(101);
            patient.Name = "Updated";

            // Act
            var result = _repo.Update(patient);

            // Assert
            Assert.True(result);
            Assert.Equal("Updated", _repo.GetById(101).Name);
        }
    }
}