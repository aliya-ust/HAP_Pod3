using System;
using System.Collections.Generic;
using Xunit;
using HealthApp.ConsoleApp.Repositories.impl;
using HealthApp.ConsoleApp.Database;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.Tests.Repositories
{
    public class DoctorRepositoryTests
    {
        private readonly DoctorDb _doctorDb;
        private readonly DoctorRepository _repository;

        public DoctorRepositoryTests()
        {
            _doctorDb = new DoctorDb();
            _repository = new DoctorRepository(_doctorDb);
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
        public void AddDoctor_ShouldAddDoctor_ToDatabase()
        {
            var doctor = CreateValidDoctor(1, "Dr. John Smith", "Cardiology");

            var result = _repository.AddDoctor(doctor);

            Assert.Single(_doctorDb.Doctors);
            Assert.Equal(doctor, _doctorDb.Doctors[0]);
            Assert.Equal("Doctor ID 1 added successfully!", result);
        }

        [Fact]
        public void GetDoctorById_ShouldReturnDoctor_WhenExists()
        {
            var doctor = CreateValidDoctor(1, "Dr. John Smith", "Cardiology");
            _doctorDb.Doctors.Add(doctor);

            var result = _repository.GetDoctorById(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.DoctorId);
            Assert.Equal("Dr. John Smith", result.FullName);
            Assert.Equal("Cardiology", result.Specialisation);
        }

        [Fact]
        public void GetDoctorById_ShouldReturnNull_WhenNotFound()
        {
            _doctorDb.Doctors.Add(CreateValidDoctor(1, "Dr. Existing", "Orthopedics"));

            var result = _repository.GetDoctorById(999);

            Assert.Null(result);
        }

        [Fact]
        public void GetDoctorsBySpecialisation_ShouldReturnMatchingDoctors()
        {
            _doctorDb.Doctors.Add(CreateValidDoctor(1, "Dr. A", "Cardiology"));
            _doctorDb.Doctors.Add(CreateValidDoctor(2, "Dr. B", "Cardiology"));
            _doctorDb.Doctors.Add(CreateValidDoctor(3, "Dr. C", "Neurology"));

            var result = _repository.GetDoctorsBySpecialisation("Cardiology");

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetDoctorsBySpecialisation_ShouldBeCaseInsensitive()
        {
            _doctorDb.Doctors.Add(CreateValidDoctor(1, "Dr. A", "Cardiology"));

            var result = _repository.GetDoctorsBySpecialisation("cardiology");

            Assert.Single(result);
        }

        [Fact]
        public void GetDoctorsBySpecialisation_ShouldReturnEmptyList_WhenNoMatch()
        {
            _doctorDb.Doctors.Add(CreateValidDoctor(1, "Dr. A", "Orthopedics"));

            var result = _repository.GetDoctorsBySpecialisation("Cardiology");

            Assert.Empty(result);
        }
    }
}