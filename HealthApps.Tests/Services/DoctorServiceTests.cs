using Moq;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Services;
using HealthApp.ConsoleApp.Exceptions;

namespace HealthApp.Tests
{
    public class DoctorServiceTests
    {
        private readonly Mock<IDoctorRepository> _mockRepo;
        private readonly DoctorService _service;

        public DoctorServiceTests()
        {
            _mockRepo = new Mock<IDoctorRepository>();
            _service = new DoctorService(_mockRepo.Object);
        }

        [Fact]
        public void GetAllDoctors_ShouldReturnData()
        {
            // Arrange
            var doctors = new List<Doctor>
            {
                new Doctor
                {
                    DoctorId = 201,
                    FullName = "Dr.Test",
                    Specialisation = "Cardiology"
                }
            };

            _mockRepo.Setup(r => r.GetAllDoctors())
                     .Returns(doctors);

            // Act
            var result = _service.GetAllDoctors();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void SearchBySpecialisation_ShouldThrowIfNotFound()
        {
            // Arrange
            _mockRepo.Setup(r => r.GetDoctorsBySpecialisation("Unknown"))
                     .Returns(new List<Doctor>());

            // Act & Assert
            Assert.Throws<SpecialisationNotFoundException>(() =>
                _service.SearchBySpecialisation("Unknown"));
        }

        [Fact]
        public void AddDoctor_ShouldAdd()
        {
            // Arrange
            var doctor = new Doctor
            {
                FullName = "Test Doctor",
                Specialisation = "Test",
                ConsultationFee = 100,
                YearsOfExperience = 5,
                IsActive = true
            };

            _mockRepo.Setup(r => r.GetAllDoctors())
                     .Returns(new List<Doctor>());

            _mockRepo.Setup(r => r.AddDoctor(It.IsAny<Doctor>()));

            // Act
            _service.AddDoctor(doctor);

            // Assert
            _mockRepo.Verify(r => r.AddDoctor(It.IsAny<Doctor>()), Times.Once);
        }

        [Fact]
        public void GetByDoctorId_ShouldReturnNull_WhenNotFound()
        {
            // Arrange
            _mockRepo.Setup(r => r.GetAllDoctors())
                     .Returns(new List<Doctor>());

            // Act
            var result = _service.GetByDoctorId(999);

            // Assert
            Assert.Null(result);
        }
    }
}