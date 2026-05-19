using System;
using Xunit;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Databases;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.Tests.Repositories
{
    public class PatientRepositoryTests
    {
        private readonly PatientDb _patientDb;
        private readonly PatientRepository _repository;

        public PatientRepositoryTests()
        {
            _patientDb = new PatientDb();
            _repository = new PatientRepository(_patientDb);
        }

        [Fact]
        public void RegisterPatient_ShouldAddPatient_ToDatabase()
        {
            var patient = new Patient
            {
                PatientId = 1,
                FullName = "John Doe",
                PhoneNumber = "9876543210",
                Email = "john.doe@email.com"
            };

            var result = _repository.RegisterPatient(patient);

            Assert.Single(_patientDb.Patients);
            Assert.Equal(patient, _patientDb.Patients[0]);
            Assert.Equal("Patient ID 1 added successfully!", result);
        }

        [Fact]
        public void RegisterPatient_ShouldAllow_MultiplePatients()
        {
            var patient1 = new Patient
            {
                PatientId = 1,
                FullName = "John Doe",
                PhoneNumber = "9876543210",
                Email = "john@email.com"
            };

            var patient2 = new Patient
            {
                PatientId = 2,
                FullName = "Jane Smith",
                PhoneNumber = "9123456780",
                Email = "jane@email.com"
            };

            _repository.RegisterPatient(patient1);
            _repository.RegisterPatient(patient2);

            Assert.Equal(2, _patientDb.Patients.Count);
        }

        [Fact]
        public void GetPatientById_ShouldReturnPatient_WhenExists()
        {
            var patient = new Patient
            {
                PatientId = 1,
                FullName = "John Doe",
                PhoneNumber = "9876543210",
                Email = "john@email.com"
            };

            _patientDb.Patients.Add(patient);

            var result = _repository.GetPatientById(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.PatientId);
            Assert.Equal("John Doe", result.FullName);
            Assert.Equal("9876543210", result.PhoneNumber);
            Assert.Equal("john@email.com", result.Email);
        }

        [Fact]
        public void GetPatientById_ShouldReturnNull_WhenNotFound()
        {
            _patientDb.Patients.Add(new Patient
            {
                PatientId = 1,
                FullName = "Existing User",
                PhoneNumber = "9999999999",
                Email = "existing@email.com"
            });

            var result = _repository.GetPatientById(999);

            Assert.Null(result);
        }

        [Fact]
        public void GetPatientById_ShouldReturnFirstMatch_WhenDuplicateIdsExist()
        {
            var patient1 = new Patient
            {
                PatientId = 1,
                FullName = "First Entry",
                PhoneNumber = "1111111111",
                Email = "first@email.com"
            };

            var patient2 = new Patient
            {
                PatientId = 1,
                FullName = "Second Entry",
                PhoneNumber = "2222222222",
                Email = "second@email.com"
            };

            _patientDb.Patients.Add(patient1);
            _patientDb.Patients.Add(patient2);

            var result = _repository.GetPatientById(1);

            Assert.NotNull(result);
            Assert.Equal("First Entry", result.FullName);
        }
    }
}