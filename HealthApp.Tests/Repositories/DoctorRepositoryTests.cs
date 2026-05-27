<<<<<<< HEAD
﻿using HealthApp.ConsoleApp.Databases;
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
=======
using System;
using System.Collections.Generic;
using Xunit;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Databases;
using HealthApp.ConsoleApp.Exceptions;

namespace HealthApp.Tests.Repositories
{
    // Test class for DoctorRepository to validate doctor management functionalities
    public class DoctorRepositoryTests
    {
        private readonly DoctorDb _doctorDb;
>>>>>>> 4d8a0e3f027eb90749388ec6177e69d6c9a087fb
        private readonly DoctorRepository _repository;

        public DoctorRepositoryTests()
        {
<<<<<<< HEAD
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
=======
            _doctorDb = new DoctorDb
            {
                Doctors = new List<Doctor>()
            };

            _repository = new DoctorRepository(_doctorDb);
        }

        // AddDoctor - Success
        [Fact]
        public void AddDoctor_ShouldAddDoctor()
        {
            var doctor = new Doctor
            {
                DoctorId = 1,
                Name = "Dr. Smith",
                Specialisation = "Cardiology"
            };

            var result = _repository.AddDoctor(doctor);

            Assert.Single(_doctorDb.Doctors);
            Assert.Contains("added successfully", result);
        }

        // GetDoctorById - Success
        [Fact]
        public void GetDoctorById_ShouldReturnDoctor()
        {
            _doctorDb.Doctors.Add(new Doctor
            {
                DoctorId = 1,
                Name = "Dr. A",
                Specialisation = "Neurology"
            });

            var result = _repository.GetDoctorById(1);

            Assert.NotNull(result);
            Assert.Equal("Dr. A", result.Name);
        }

        // GetDoctorById - Not Found
        [Fact]
        public void GetDoctorById_ShouldReturnNull_WhenNotFound()
        {
            var result = _repository.GetDoctorById(99);

            Assert.Null(result);
        }

        // GetDoctorsBySpecialisation - Success
        [Fact]
        public void GetDoctorsBySpecialisation_ShouldReturnMatchingDoctors()
        {
            _doctorDb.Doctors.Add(new Doctor
            {
                DoctorId = 1,
                Name = "Dr. X",
                Specialisation = "Cardiology"
            });

            _doctorDb.Doctors.Add(new Doctor
            {
                DoctorId = 2,
                Name = "Dr. Y",
                Specialisation = "Neurology"
            });

            var result = _repository.GetDoctorsBySpecialisation("cardiology");

            Assert.Single(result);
        }

        // GetDoctorsBySpecialisation - No Matches
        [Fact]
        public void GetDoctorsBySpecialisation_ShouldReturnEmptyList_WhenNoMatch()
        {
            var result = _repository.GetDoctorsBySpecialisation("Oncology");

            Assert.Empty(result);
        }

        // UpdateDoctor - Success
        [Fact]
        public void UpdateDoctor_ShouldUpdateDoctorDetails()
        {
            var existing = new Doctor
            {
                DoctorId = 1,
                Name = "Old Name",
                Specialisation = "General"
            };

            var updated = new Doctor
            {
                DoctorId = 1,
                Name = "New Name",
                Specialisation = "Ortho",
                YearsOfExperience = 10,
                ConsultationFee = 500,
                IsActive = true
            };

            var result = _repository.UpdateDoctor(existing, updated);

            Assert.Equal("New Name", result.Name);
            Assert.Equal("Ortho", result.Specialisation);
            Assert.Equal(10, result.YearsOfExperience);
        }

        // GetAllDoctors - Success
        [Fact]
        public void GetAllDoctors_ShouldReturnAllDoctors()
        {
            _doctorDb.Doctors.Add(new Doctor
            {
                DoctorId = 1,
                Name = "Doc1",
                Specialisation = "General"
            });

            _doctorDb.Doctors.Add(new Doctor
            {
                DoctorId = 2,
                Name = "Doc2",
                Specialisation = "Cardiology"
            });

            var result = _repository.GetAllDoctors();

            Assert.Equal(2, result.Count);
        }

        // GetAllDoctors - Empty Case
        [Fact]
        public void GetAllDoctors_ShouldReturnEmptyList_WhenNoDoctors()
        {
            var result = _repository.GetAllDoctors();

            Assert.Empty(result);
>>>>>>> 4d8a0e3f027eb90749388ec6177e69d6c9a087fb
        }
    }
}