using Moq;
using HealthCare.Api.Repositories.Interfaces;
using AutoMapper;
using HealthCare.Api.Models;
using HealthCare.Api.Data;
using HealthCare.Api.Services.Implementations;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.DTOs;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

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
            _contextMock = new Mock<HealthCareDbContext>();

            _service = new PatientService(
                _repoMock.Object,
                _contextMock.Object,
                _mapperMock.Object
            );
        }

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

        [Fact]
        public async Task GetByIdAsync_ShouldThrow_WhenPatientNotFound()
        {
            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Patient?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.GetByIdAsync(1));
        }

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
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Expression<Func<Patient, bool>>?>()))
                .ReturnsAsync(paged);

            _mapperMock.Setup(m => m.Map<IEnumerable<PatientListDto>>(patients))
                .Returns(new List<PatientListDto> { new PatientListDto() });

            var filter = new PatientFilter { PageNumber = 1, PageSize = 10 };

            var result = await _service.GetAllAsync(filter);

            Assert.NotNull(result);
            Assert.Equal(1, result.TotalCount);
        }

        [Fact]
        public async Task AddAsync_ShouldAddPatient()
        {
            var dto = new CreatePatientDto();
            var patient = new Patient();

            _mapperMock.Setup(m => m.Map<Patient>(dto)).Returns(patient);

            await _service.AddAsync(dto);

            _repoMock.Verify(r => r.AddAsync(patient), Times.Once);
            _contextMock.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdatePatient()
        {
            var patient = new Patient();

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(patient);

            var dto = new UpdatePatientDto();

            await _service.UpdateAsync(1, dto);

            _repoMock.Verify(r => r.UpdateAsync(patient), Times.Once);
            _contextMock.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrow_WhenPatientNotFound()
        {
            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Patient?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.UpdateAsync(1, new UpdatePatientDto()));
        }

        [Fact]
        public async Task UpdateStatusAsync_ShouldUpdateStatus()
        {
            var patient = new Patient { IsActive = true };

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(patient);

            await _service.UpdateStatusAsync(1, false);

            Assert.False(patient.IsActive);

            _repoMock.Verify(r => r.UpdateAsync(patient), Times.Once);
            _contextMock.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeletePatient()
        {
            var patient = new Patient();

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(patient);

            await _service.DeleteAsync(1);

            _repoMock.Verify(r => r.DeleteAsync(1), Times.Once);
            _contextMock.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrow_WhenPatientNotFound()
        {
            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Patient?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.DeleteAsync(1));
        }

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
