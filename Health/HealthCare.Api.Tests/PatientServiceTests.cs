using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace HealthCare.Tests.Services
{
    public class PatientServiceTests
    {
        private readonly Mock<IRepository<Patient>> _repository = new();
        private readonly Mock<IMapper> _mapper = new();
        private readonly Mock<ILogger<PatientService>> _logger = new();
        private readonly HealthCareDbContext _context;
        private readonly PatientService _service;

        public PatientServiceTests()
        {
            var options = new DbContextOptionsBuilder<HealthCareDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new HealthCareDbContext(options);

            _logger.Setup(x =>
                x.IsEnabled(It.IsAny<LogLevel>()))
                .Returns(true);

            _service = new PatientService(
                _repository.Object,
                _context,
                _mapper.Object,
                _logger.Object);
        }

        [Fact]
        public async Task AddAsync_Should_Add_Patient()
        {
            var dto = new CreatePatientDto();
            var patient = new Patient();

            _mapper.Setup(x => x.Map<Patient>(dto))
                .Returns(patient);

            await _service.AddAsync(dto);

            _repository.Verify(x => x.AddAsync(patient), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_Should_Update_Patient()
        {
            var patient = new Patient();

            _repository.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(patient);

            await _service.UpdateAsync(1, new UpdatePatientDto());

            _repository.Verify(x => x.UpdateAsync(patient), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_Should_Throw_When_NotFound()
        {
            _repository.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync((Patient)null!);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.UpdateAsync(1, new UpdatePatientDto()));
        }

        [Fact]
        public async Task UpdateStatusAsync_Should_Set_Status_True()
        {
            var patient = new Patient { IsActive = false };

            _repository.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(patient);

            await _service.UpdateStatusAsync(1, true);

            Assert.True(patient.IsActive);

            _repository.Verify(x => x.UpdateAsync(patient), Times.Once);
        }

        [Fact]
        public async Task UpdateStatusAsync_Should_Throw_When_NotFound()
        {
            _repository.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync((Patient)null!);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.UpdateStatusAsync(1, true));
        }

        [Fact]
        public async Task DeleteAsync_Should_Delete_Patient()
        {
            _repository.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(new Patient());

            await _service.DeleteAsync(1);

            _repository.Verify(x => x.DeleteAsync(1), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_Should_Throw_When_NotFound()
        {
            _repository.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync((Patient)null!);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.DeleteAsync(1));
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_Paged_Result()
        {
            var patients = new List<Patient>
            {
                new Patient { PatientId = 1 }
            };

            var dtoList = new List<PatientListDto>
            {
                new PatientListDto { PatientId = 1 }
            };

            var paged = new PagedResult<Patient>
            {
                Items = patients,
                PageNumber = 1,
                PageSize = 10,
                TotalCount = 1
            };

            _repository.Setup(x => x.GetAllAsync(
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<System.Linq.Expressions.Expression<Func<Patient, bool>>>()))
                .ReturnsAsync(paged);

            _mapper.Setup(x => x.Map<IEnumerable<PatientListDto>>(patients))
                .Returns(dtoList);

            var result = await _service.GetAllAsync(new PatientFilter());

            Assert.Single(result.Items);
            Assert.Equal(1, result.TotalCount);
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Profile()
        {
            _context.Users.Add(new User
            {
                Id = "u1",
                Email = "patient@test.com",
                UserName = "patient@test.com"
            });

            _context.Patients.Add(new Patient
            {
                PatientId = 1,
                UserId = "u1",
                FullName = "John",
                PhoneNumber = "9999999999",
                Gender = "Male"
            });

            await _context.SaveChangesAsync();

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("John", result.FullName);
            Assert.Equal("patient@test.com", result.Email);
        }

        [Fact]
        public async Task GetByIdAsync_Should_Throw_When_NotFound()
        {
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.GetByIdAsync(100));
        }
    }
}