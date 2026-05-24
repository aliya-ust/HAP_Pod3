
using Moq;
using Xunit;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Exceptions;

namespace HealthApp.Tests.Service
{
    public class PatientServiceTest
    {
        private readonly Mock<IPatientRepository> _mockRepo;
        private readonly PatientService _service;

        public PatientServiceTest()
        {
            _mockRepo = new Mock<IPatientRepository>();
            _service = new PatientService(_mockRepo.Object);
        }

        // ADD
        [Fact]
        public void AddPatient_Should_CallRepository()
        {
            var patient = new Patient { Name = "Arjun", Dob = DateTime.Now.AddYears(-20) };

            _service.AddPatient(patient);

            _mockRepo.Verify(r => r.AddPatient(patient), Times.Once);
        }

        //  UPDATE SUCCESS
        [Fact]
        public void UpdatePatient_Should_CallRepository_WhenValid()
        {
            var patient = new Patient
            {
                Id = 1,
                Name = "Arjun",
                Dob = DateTime.Now.AddYears(-20)
            };

            _mockRepo.Setup(r => r.GetPatientById(1))
                     .Returns(patient);

            _service.UpdatePatient(patient);

            _mockRepo.Verify(r => r.UpdatePatient(patient), Times.Once);
        }

        //  UPDATE INVALID (Validation fails)
        [Fact]
        public void UpdatePatient_Should_ThrowException_WhenInvalid()
        {
            var patient = new Patient
            {
                Id = 1,
                Name = "", // invalid
                Dob = DateTime.Now.AddYears(-20)
            };

            Assert.Throws<PatientInvalidException>(() =>
                _service.UpdatePatient(patient));
        }

        // DELETE SUCCESS
        [Fact]
        public void DeletePatient_Should_Delete_WhenExists()
        {
            _mockRepo.Setup(r => r.GetPatientById(1))
                     .Returns(new Patient { Id = 1 });

            _service.DeletePatient(1);

            _mockRepo.Verify(r => r.DeletePatient(1), Times.Once);
        }

        //  DELETE - NOT FOUND
        [Fact]
        public void DeletePatient_Should_Throw_NotFound()
        {
            _mockRepo.Setup(r => r.GetPatientById(1))
                     .Returns((Patient)null);

            Assert.Throws<PatientNotFoundException>(() =>
                _service.DeletePatient(1));
        }

        // DELETE - INVALID ID
        [Fact]
        public void DeletePatient_Should_Throw_Invalid_WhenIdZero()
        {
            Assert.Throws<PatientInvalidException>(() =>
                _service.DeletePatient(0));
        }

        //  GET BY ID SUCCESS
        [Fact]
        public void GetPatientById_Should_ReturnPatient()
        {
            var patient = new Patient { Id = 1, Name = "Arjun" };

            _mockRepo.Setup(r => r.GetPatientById(1))
                     .Returns(patient);

            var result = _service.GetPatientById(1);

            Assert.NotNull(result);
            Assert.Equal("Arjun", result.Name);
        }

        // GET BY ID NOT FOUND
        [Fact]
        public void GetPatientById_Should_Throw_WhenNotFound()
        {
            _mockRepo.Setup(r => r.GetPatientById(1))
                     .Returns((Patient)null);

            Assert.Throws<PatientNotFoundException>(() =>
                _service.GetPatientById(1));
        }

        //  GET ALL
        [Fact]
        public void GetAllPatients_Should_ReturnList()
        {
            var patients = new List<Patient>
            {
                new Patient { Id = 1, Name = "Arjun" },
                new Patient { Id = 2, Name = "Kevin" }
            };

            _mockRepo.Setup(r => r.GetAllPatients())
                     .Returns(patients);

            var result = _service.GetAllPatients();

            Assert.Equal(2, result.Count);
        }

        // AGE CALCULATION
        [Fact]
        public void GetPatientAge_Should_ReturnAge()
        {
            var patient = new Patient
            {
                Id = 1,
                Dob = DateTime.Now.AddYears(-25)
            };

            _mockRepo.Setup(r => r.GetPatientById(1))
                     .Returns(patient);

            var age = _service.GetPatientAge(1);

            Assert.True(age >= 24); // safe check
        }

        //  PROFILE SUMMARY
        [Fact]
        public void GetPatientProfileSummary_Should_ReturnSummary()
        {
            var patient = new Patient
            {
                Id = 1,
                Name = "Arjun",
                Dob = DateTime.Now.AddYears(-20)
            };

            _mockRepo.Setup(r => r.GetPatientById(1))
                     .Returns(patient);

            var result = _service.GetPatientProfileSummary(1);

            Assert.NotNull(result);
        }
    }
}
