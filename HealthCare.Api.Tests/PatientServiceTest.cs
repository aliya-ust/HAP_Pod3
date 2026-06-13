using HealthCare.Api;
using HealthCare.Shared;
using HealthCare.Shared.DTOs.Patient;
using HealthCareApi.Repositories.Interfaces;
using HealthCareApi.Services.Implementations;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace HealthCareApi.Tests.Services
{
    public class PatientServiceTest
    {
        private readonly Mock<IPatientRepository> _patientRepoMock;
        private readonly PatientService _patientService;

        public PatientServiceTest()
        {
            _patientRepoMock = new Mock<IPatientRepository>();
            _patientService = new PatientService(_patientRepoMock.Object);
        }

        // GET BY ID
        [Fact]
        public async Task GetPatientByIdAsync_ShouldReturnPatient_WhenExists()
        {
            // Arrange
            var patient = new Patient
            {
                PatientId = 1,
                FullName = "John Doe"
            };

            _patientRepoMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(patient);

            // Act
            var result = await _patientService.GetPatientByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.PatientId);
        }

        [Fact]
        public async Task GetPatientByIdAsync_ShouldReturnNull_WhenNotFound()
        {
            // Arrange
            _patientRepoMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((Patient)null);

            // Act
            var result = await _patientService.GetPatientByIdAsync(1);

            // Assert
            Assert.Null(result);
        }

        // PAGINATION
        [Fact]
        public async Task GetPaginatedPatientAsync_ShouldReturnPagedPatients()
        {
            // Arrange
            var pagedResult = new PagedResult<Patient>
            {
                Items = new List<Patient>
                {
                    new Patient { PatientId = 1 },
                    new Patient { PatientId = 2 }
                },
                PageNumber = 1,
                PageSize = 10
            };

            _patientRepoMock
                .Setup(r => r.GetPaginatedPatientsAsync(
                    "john",
                    1,
                    10))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await _patientService.GetPaginatedPatientAsync("john", 1, 10);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Items.Count);
        }

        // ADD PATIENT 
        [Fact]
        public async Task AddPatientAsync_ShouldSetActiveAndReturnPatient()
        {
            // Arrange
            var patient = new Patient
            {
                PatientId = 1,
                FullName = "Test Patient",
                IsActive = false
            };

            _patientRepoMock
                .Setup(r => r.AddAsync(patient))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _patientService.AddPatientAsync(patient);

            // Assert
            Assert.True(result.IsActive);

            _patientRepoMock.Verify(
                r => r.AddAsync(It.IsAny<Patient>()),
                Times.Once);
        }

        //  UPDATE PATIENT
        [Fact]
        public async Task UpdatePatientAsync_ShouldUpdatePatient_WhenExists()
        {
            // Arrange
            var existing = new Patient
            {
                PatientId = 1,
                FullName = "Old Name",
                Gender = "Male"
            };

            var updated = new Patient
            {
                PatientId = 1,
                FullName = "New Name",
                Gender = "Female"
            };

            _patientRepoMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(existing);

            // Act
            var result = await _patientService.UpdatePatientAsync(updated);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("New Name", result.FullName);
            Assert.Equal("Female", result.Gender);

            _patientRepoMock.Verify(
                r => r.UpdateAsync(It.IsAny<Patient>()),
                Times.Once);
        }

        [Fact]
        public async Task UpdatePatientAsync_ShouldReturnNull_WhenNotFound()
        {
            // Arrange
            var updated = new Patient
            {
                PatientId = 1
            };

            _patientRepoMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((Patient)null);

            // Act
            var result = await _patientService.UpdatePatientAsync(updated);

            // Assert
            Assert.Null(result);
        }

        // DELETE PATIENT 
        [Fact]
        public async Task DeletePatientAsync_ShouldReturnTrue_WhenPatientExists()
        {
            // Arrange
            var patient = new Patient
            {
                PatientId = 1,
                IsActive = true
            };

            _patientRepoMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(patient);

            // Act
            var result = await _patientService.DeletePatientAsync(1);

            // Assert
            Assert.True(result);
            Assert.False(patient.IsActive);

            _patientRepoMock.Verify(
                r => r.UpdateAsync(It.IsAny<Patient>()),
                Times.Once);
        }

        [Fact]
        public async Task DeletePatientAsync_ShouldReturnFalse_WhenNotFound()
        {
            // Arrange
            _patientRepoMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((Patient)null);

            // Act
            var result = await _patientService.DeletePatientAsync(1);

            // Assert
            Assert.False(result);
        }
    }
}