using HealthCare.Api;
using HealthCare.Shared;
using HealthCare.Shared.DTOs.Doctor;
using HealthCareApi.Repositories.Interfaces;
using HealthCareApi.Services.Implementations;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace HealthCareApi.Tests.Services
{
    public class DoctorServiceTest
    {
        private readonly Mock<IDoctorRepository> _doctorRepositoryMock;
        private readonly DoctorService _doctorService;

        public DoctorServiceTest()
        {
            _doctorRepositoryMock = new Mock<IDoctorRepository>();
            _doctorService = new DoctorService(_doctorRepositoryMock.Object);
        }

        [Fact]
        public async Task GetDoctorByIdAsync_ShouldReturnDoctor_WhenDoctorExists()
        {
            // Arrange
            var doctor = new Doctor
            {
                DoctorId = 1,
                FullName = "John Smith",
                Specialisation = "Cardiology"
            };

            _doctorRepositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(doctor);

            // Act
            var result = await _doctorService.GetDoctorByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.DoctorId);
            Assert.Equal("John Smith", result.FullName);
        }

        [Fact]
        public async Task GetDoctorByIdAsync_ShouldReturnNull_WhenDoctorNotFound()
        {
            // Arrange
            _doctorRepositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((Doctor)null);

            // Act
            var result = await _doctorService.GetDoctorByIdAsync(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetFilteredDoctorsAsync_ShouldReturnPagedDoctors()
        {
            // Arrange
            var pagedResult = new PagedResult<Doctor>
            {
                Items = new List<Doctor>
                {
                    new Doctor { DoctorId = 1, FullName = "Doctor A" },
                    new Doctor { DoctorId = 2, FullName = "Doctor B" }
                },
                PageNumber = 1,
                PageSize = 10
            };

            _doctorRepositoryMock
                .Setup(r => r.GetDoctorsAsync(
                    "Cardiology",
                    null,
                    true,
                    1,
                    10))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await _doctorService.GetFilteredDoctorsAsync(
                "Cardiology",
                null,
                true,
                1,
                10);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Items.Count);
        }

        [Fact]
        public async Task AddDoctorAsync_ShouldAddDoctorWithoutSlots()
        {
            // Arrange
            var doctorDto = new DoctorDto
            {
                FullName = "Dr Test",
                Specialisation = "Neurology",
                YearsOfExperience = 5,
                ConsultationFee = 1000,
                DoctorAvailableSlots = null
            };

            // Act
            var result = await _doctorService.AddDoctorAsync(doctorDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Dr Test", result.FullName);
            Assert.True(result.IsActive);

            _doctorRepositoryMock.Verify(
                r => r.AddAsync(It.IsAny<Doctor>()),
                Times.Once);
        }

        [Fact]
        public async Task AddDoctorAsync_ShouldAddDoctorWithSlots()
        {
            // Arrange
            var doctorDto = new DoctorDto
            {
                FullName = "Dr Test",
                Specialisation = "Orthopedic",
                YearsOfExperience = 8,
                ConsultationFee = 1500,
                DoctorAvailableSlots = new List<string>
                {
                    "09:00 AM",
                    "10:00 AM"
                }
            };

            _doctorRepositoryMock
                .Setup(r => r.AddAsync(It.IsAny<Doctor>()))
                .Callback<Doctor>(d => d.DoctorId = 1)
                .Returns(Task.CompletedTask);

            // Act
            var result = await _doctorService.AddDoctorAsync(doctorDto);

            // Assert
            Assert.NotNull(result);

            _doctorRepositoryMock.Verify(
                r => r.AddAsync(It.IsAny<Doctor>()),
                Times.Once);

            _doctorRepositoryMock.Verify(
                r => r.AddDoctorSlotAsync(
                    It.Is<List<DoctorAvailableSlot>>(s => s.Count == 2)),
                Times.Once);
        }

        [Fact]
        public async Task GetDoctorBySpecializationAsync_ShouldReturnDoctors()
        {
            // Arrange
            var doctors = new List<Doctor>
            {
                new Doctor
                {
                    DoctorId = 1,
                    FullName = "Doctor A",
                    Specialisation = "Cardiology"
                }
            };

            _doctorRepositoryMock
                .Setup(r => r.DoctorBySpecializationAsync("Cardiology"))
                .ReturnsAsync(doctors);

            // Act
            var result = await _doctorService
                .GetDoctorBySpecializationAsync("Cardiology");

            // Assert
            Assert.Single(result);
        }

        [Fact]
        public async Task UpdateDoctorAsync_ShouldUpdateDoctor_WhenDoctorExists()
        {
            // Arrange
            var existingDoctor = new Doctor
            {
                DoctorId = 1,
                FullName = "Old Name",
                Specialisation = "General",
                YearsOfExperience = 2,
                ConsultationFee = 500
            };

            var updatedDoctor = new Doctor
            {
                DoctorId = 1,
                FullName = "New Name",
                Specialisation = "Cardiology",
                YearsOfExperience = 10,
                ConsultationFee = 1500
            };

            _doctorRepositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(existingDoctor);

            // Act
            var result = await _doctorService.UpdateDoctorAsync(updatedDoctor);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("New Name", result.FullName);
            Assert.Equal("Cardiology", result.Specialisation);

            _doctorRepositoryMock.Verify(
                r => r.UpdateAsync(It.IsAny<Doctor>()),
                Times.Once);
        }

        [Fact]
        public async Task UpdateDoctorAsync_ShouldReturnNull_WhenDoctorNotFound()
        {
            // Arrange
            var updatedDoctor = new Doctor
            {
                DoctorId = 1
            };

            _doctorRepositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((Doctor)null);

            // Act
            var result = await _doctorService.UpdateDoctorAsync(updatedDoctor);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task DeleteDoctorAsync_ShouldReturnTrue_WhenDoctorExists()
        {
            // Arrange
            var doctor = new Doctor
            {
                DoctorId = 1,
                FullName = "Doctor A"
            };

            _doctorRepositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(doctor);

            // Act
            var result = await _doctorService.DeleteDoctorAsync(1);

            // Assert
            Assert.True(result);

            _doctorRepositoryMock.Verify(
                r => r.DeleteAsync(doctor),
                Times.Once);
        }

        [Fact]
        public async Task DeleteDoctorAsync_ShouldReturnFalse_WhenDoctorNotFound()
        {
            // Arrange
            _doctorRepositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((Doctor)null);

            // Act
            var result = await _doctorService.DeleteDoctorAsync(1);

            // Assert
            Assert.False(result);
        }
    }
}