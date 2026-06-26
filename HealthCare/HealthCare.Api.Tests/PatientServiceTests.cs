using Moq;
using AutoMapper;
using HealthCare.Api.Models;
using HealthCare.Api.Data;
using HealthCare.Api.Services.Implementations;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Patient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using HealthCare.Shared.DTOs;

namespace HealthCare.Api.Tests
{
    public class PatientServiceTests
    {
        private readonly Mock<IRepository<Patient>> _repoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<HealthCareDbContext> _contextMock;

        private readonly PatientService _service;

        public PatientServiceTests()
        {
            _repoMock = new Mock<IRepository<Patient>>();
            _mapperMock = new Mock<IMapper>();

            var options = new DbContextOptions<HealthCareDbContext>();
            _contextMock = new Mock<HealthCareDbContext>(options);

            _service = new PatientService(
                _repoMock.Object,
                _contextMock.Object,
                _mapperMock.Object);
        }

        // GetById - Success
        [Fact]
        public async Task GetByIdAsync_ShouldReturnPatient_WhenExists()
        {
            var patient = new Patient { PatientId = 1 };
            var dto = new PatientListDto();

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(patient);
            _mapperMock.Setup(m => m.Map<PatientListDto>(patient)).Returns(dto);

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
        }

        // GetById - Not found
        [Fact]
        public async Task GetByIdAsync_ShouldThrow_WhenPatientNotFound()
        {
            _repoMock.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((Patient?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.GetByIdAsync(1));
        }

        // GetAll
        [Fact]
        public async Task GetAllAsync_ShouldReturnPagedResult()
        {
            var patients = new List<Patient> { new Patient() };

            var paged = new PagedResult<Patient>
            {
                Items = patients,
                PageNumber = 1,
                PageSize = 10,
                TotalCount = 1
            };

            _repoMock.Setup(r => r.GetAllAsync(
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<Expression<Func<Patient, bool>>?>()))
                .ReturnsAsync(paged);

            _mapperMock.Setup(m => m.Map<IEnumerable<PatientListDto>>(patients))
                .Returns(new List<PatientListDto> { new PatientListDto() });

            var result = await _service.GetAllAsync(new PatientFilter());

            Assert.NotNull(result);
            Assert.Equal(1, result.TotalCount);
        }

        // AddAsync (IMPORTANT FIX)
        [Fact]
        public async Task AddAsync_ShouldAddPatient()
        {
            var dto = new CreatePatientDto { FullName = "Test" };
            var patient = new Patient { FullName = "Test" };

            _mapperMock.Setup(m => m.Map<Patient>(dto)).Returns(patient);

            await _service.AddAsync(dto);

            // Verify repo call
            _repoMock.Verify(r => r.AddAsync(patient), Times.Once);

           
        }

        // UpdateAsync
        [Fact]
        public async Task UpdateAsync_ShouldUpdatePatient()
        {
            var patient = new Patient();

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(patient);

            await _service.UpdateAsync(1, new UpdatePatientDto());

            _repoMock.Verify(r => r.UpdateAsync(patient), Times.Once);
        }

        // UpdateAsync - Not found
        [Fact]
        public async Task UpdateAsync_ShouldThrow_WhenPatientNotFound()
        {
            _repoMock.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((Patient?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.UpdateAsync(1, new UpdatePatientDto()));
        }

        // UpdateStatus
        [Fact]
        public async Task UpdateStatusAsync_ShouldUpdateStatus()
        {
            var patient = new Patient { IsActive = true };

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(patient);

            await _service.UpdateStatusAsync(1, false);

            Assert.False(patient.IsActive);
            _repoMock.Verify(r => r.UpdateAsync(patient), Times.Once);
        }

        // DeleteAsync
        [Fact]
        public async Task DeleteAsync_ShouldDeletePatient()
        {
            var patient = new Patient();

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(patient);

            await _service.DeleteAsync(1);

            _repoMock.Verify(r => r.DeleteAsync(1), Times.Once);
        }

        // DeleteAsync - Not found
        [Fact]
        public async Task DeleteAsync_ShouldThrow_WhenPatientNotFound()
        {
            _repoMock.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((Patient?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.DeleteAsync(1));
        }

        // DeleteAsync - DB exception
        [Fact]
        public async Task DeleteAsync_ShouldThrow_WhenDbFails()
        {
            var patient = new Patient();

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(patient);

            _repoMock.Setup(r => r.DeleteAsync(1))
                .ThrowsAsync(new DbUpdateException());

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.DeleteAsync(1));
        }
    }
}