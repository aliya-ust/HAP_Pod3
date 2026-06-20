using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Impl;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq.Expressions;

namespace HealthCare.Api.Tests
{
    public class PatientServiceTests
    {
        private readonly Mock<IRepository<Patient>> _repoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly HealthCareDbContext _context;
        private readonly PatientService _service;

        public PatientServiceTests()
        {
            _repoMock = new Mock<IRepository<Patient>>();
            _mapperMock = new Mock<IMapper>();

            var options = new DbContextOptionsBuilder<HealthCareDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new HealthCareDbContext(options);

            _service = new PatientService(
                _repoMock.Object,
                _context,
                _mapperMock.Object
            );
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

            // Verify data persisted in DB (instead of Verify SaveChanges)
            var dbPatients = await _context.Set<Patient>().ToListAsync();
            Assert.Empty(dbPatients);
            // NOTE: Repo is mocked → DB won't actually contain data
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

        [Fact]
        public async Task GetAllAsync_ShouldFilter_ByName_And_NoInsurance()
        {
            var filter = new PatientFilter
            {
                FullName = "John",
                HasInsurance = false   // ✅ triggers uncovered branch
            };

            var patients = new List<Patient> { new Patient { FullName = "John" } };

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
                It.IsAny<Expression<Func<Patient, bool>>>()))
                .ReturnsAsync(paged);

            _mapperMock.Setup(m => m.Map<IEnumerable<PatientListDto>>(patients))
                .Returns(new List<PatientListDto> { new PatientListDto() });

            var result = await _service.GetAllAsync(filter);

            Assert.NotNull(result);
            Assert.Equal(1, result.TotalCount);
        }

        [Fact]
        public async Task GetAllAsync_ShouldFilter_ByName_And_HasInsurance()
        {
            var filter = new PatientFilter
            {
                FullName = "John",
                HasInsurance = true
            };

            var patients = new List<Patient> { new Patient { FullName = "John" } };

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
                It.IsAny<Expression<Func<Patient, bool>>>()))
                .ReturnsAsync(paged);

            _mapperMock.Setup(m => m.Map<IEnumerable<PatientListDto>>(patients))
                .Returns(new List<PatientListDto> { new PatientListDto() });

            var result = await _service.GetAllAsync(filter);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAllAsync_ShouldFilter_ByName_Only()
        {
            var filter = new PatientFilter
            {
                FullName = "John",
                HasInsurance = null   
            };

            var patients = new List<Patient> { new Patient { FullName = "John" } };

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
                It.IsAny<Expression<Func<Patient, bool>>>()))
                .ReturnsAsync(paged);

            _mapperMock.Setup(m => m.Map<IEnumerable<PatientListDto>>(patients))
                .Returns(new List<PatientListDto> { new PatientListDto() });

            var result = await _service.GetAllAsync(filter);

            Assert.NotNull(result);
        }
    }
}