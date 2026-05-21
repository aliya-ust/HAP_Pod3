using HealthApp.ConsoleApp.Databases;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Repositories;
using System;
using System.Linq;
using System.Numerics;
using Xunit;

namespace HealthApp.Tests.Repositories
{
    public class DoctorRepositoryTests
    {
        private readonly DoctorDb _db;
        private readonly DoctorRepository _repository;

        public DoctorRepositoryTests()
        {
            _db = new DoctorDb();
            _repository = new DoctorRepository(_db);
        }

        // ✅ Test GetAllDoctors
        [Fact]
        public void GetAllDoctors_Should_Return_All_Doctors()
        {
            // Act
            var result = _repository.GetAllDoctors();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Count > 0);
        }

        // ✅ Test GetById (Valid)
        [Fact]
        public void GetById_Valid_Id_Should_Return_Doctor()
        {
            // Arrange
            var doctor = _db.Doctors.First();

            // Act
            var result = _repository.GetById(doctor.DoctorId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(doctor.DoctorId, result.DoctorId);
        }

        // ✅ Test GetById (Invalid)
        [Fact]
        public void GetById_Invalid_Id_Should_Return_Null()
        {
            // Act
            var result = _repository.GetById(-999);

            // Assert
            Assert.Null(result);
        }

        // ✅ Test GetDoctorsBySpecialisation
        [Fact]
        public void GetDoctorsBySpecialisation_Valid_Should_Return_Matching_Doctors()
        {
            // Arrange
            string specialisation = "Cardiology";

            // Act
            var result = _repository.GetDoctorsBySpecialisation(specialisation);

            // Assert
            Assert.NotNull(result);
            Assert.All(result, d =>
                Assert.Equal(specialisation, d.Specialisation, ignoreCase: true));
        }

        // ✅ Test GetDoctorsBySpecialisation (No Match)
        [Fact]
        public void GetDoctorsBySpecialisation_Invalid_Should_Return_Empty_List()
        {
            // Act
            var result = _repository.GetDoctorsBySpecialisation("UnknownSpec");

            // Assert
            Assert.NotNull(result);
        }

        // ✅ Test AddDoctor
        [Fact]
        public void AddDoctor_Should_Add_Doctor_To_Database()
        {
            // Arrange
            int initialCount = _db.Doctors.Count;

            var newDoctor = new Doctor
            {
                DoctorId = 999,
                FullName = "New Doctor",
                Specialisation = "Testing",
                YearsOfExperience = 5,
                ConsultationFee = 200,
                IsActive = true
            };

            // Act
            _repository.AddDoctor(newDoctor);

            // Assert

            var addedDoctor = _db.Doctors.FirstOrDefault(d => d.DoctorId == 999);
            Assert.NotNull(addedDoctor);
            Assert.Equal("New Doctor", addedDoctor.FullName);
        }
    }
}