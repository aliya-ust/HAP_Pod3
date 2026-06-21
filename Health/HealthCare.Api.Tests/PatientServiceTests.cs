using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace HealthCare.Tests.Services
{
    public class PatientServiceTest
    {
        private readonly Mock<IRepository<Patient>> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<HealthCareDbContext> _contextMock;
        private readonly PatientService _service;

        public PatientServiceTest()
        {
            _repositoryMock = new Mock<IRepository<Patient>>();
            _mapperMock = new Mock<IMapper>();

            var options = new DbContextOptions<HealthCareDbContext>();
            _contextMock = new Mock<HealthCareDbContext>(options);

            _service = new PatientService(
                _repositoryMock.Object,
                _contextMock.Object,
                _mapperMock.Object);
        }

        // ================= GET BY ID =================

        [Fact]
        public async Task GetById_ShouldReturnPatient_WhenExists()
        {
            var patient = new Patient { PatientId = 1 };
            var dto = new PatientListDto();

            _repositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(patient);
            _mapperMock.Setup(m => m.Map<PatientListDto>(patient)).Returns(dto);

            var result = await _service.GetByIdAsync(1);

            Assert.Equal(dto, result);
        }

        [Fact]
        public async Task GetById_ShouldThrow_WhenNotFound()
        {
            _repositoryMock.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((Patient)null!);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.GetByIdAsync(1));
        }

        // ================= ADD =================

        [Fact]
        public async Task Add_ShouldCallRepositoryAndSave()
        {
            var dto = new CreatePatientDto();
            var patient = new Patient();

            _mapperMock.Setup(m => m.Map<Patient>(dto)).Returns(patient);
            _repositoryMock.Setup(r => r.AddAsync(patient)).Returns(Task.CompletedTask);
            _contextMock.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            await _service.AddAsync(dto);

            _repositoryMock.Verify(r => r.AddAsync(patient), Times.Once);
            _contextMock.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task Add_ShouldCallMapper()
        {
            var dto = new CreatePatientDto();
            var patient = new Patient();

            _mapperMock.Setup(m => m.Map<Patient>(dto)).Returns(patient);

            await _service.AddAsync(dto);

            _mapperMock.Verify(m => m.Map<Patient>(dto), Times.Once);
        }

        // ================= UPDATE =================

        [Fact]
        public async Task Update_ShouldUpdate_WhenExists()
        {
            var patient = new Patient { PatientId = 1 };
            var dto = new UpdatePatientDto();

            _repositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(patient);
            _repositoryMock.Setup(r => r.UpdateAsync(patient)).Returns(Task.CompletedTask);
            _contextMock.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            await _service.UpdateAsync(1, dto);

            _mapperMock.Verify(m => m.Map(dto, patient), Times.Once);
            _repositoryMock.Verify(r => r.UpdateAsync(patient), Times.Once);
        }

        [Fact]
        public async Task Update_ShouldThrow_WhenNotFound()
        {
            _repositoryMock.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((Patient)null!);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.UpdateAsync(1, new UpdatePatientDto()));
        }

        // ================= STATUS =================

        [Fact]
        public async Task UpdateStatus_ShouldChangeValue()
        {
            var patient = new Patient { IsActive = false };

            _repositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(patient);
            _repositoryMock.Setup(r => r.UpdateAsync(patient)).Returns(Task.CompletedTask);
            _contextMock.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            await _service.UpdateStatusAsync(1, true);

            Assert.True(patient.IsActive);
        }

        [Fact]
        public async Task UpdateStatus_ShouldThrow_WhenNotFound()
        {
            _repositoryMock.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((Patient)null!);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.UpdateStatusAsync(1, true));
        }

        // ================= DELETE =================

        [Fact]
        public async Task Delete_ShouldCallRepository()
        {
            var patient = new Patient { PatientId = 1 };

            _repositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(patient);
            _repositoryMock.Setup(r => r.DeleteAsync(1)).Returns(Task.CompletedTask);
            _contextMock.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            await _service.DeleteAsync(1);

            _repositoryMock.Verify(r => r.DeleteAsync(1), Times.Once);
        }

        [Fact]
        public async Task Delete_ShouldThrow_WhenNotFound()
        {
            _repositoryMock.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((Patient)null!);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.DeleteAsync(1));
        }

        [Fact]
        public async Task Delete_ShouldThrowWrappedException_WhenDbFails()
        {
            var patient = new Patient { PatientId = 1 };

            _repositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(patient);
            _repositoryMock.Setup(r => r.DeleteAsync(1))
                .ThrowsAsync(new DbUpdateException());

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.DeleteAsync(1));
        }

        // ================= PAGED RESULT =================

        [Fact]
        public async Task GetAll_ShouldReturnMappedResult()
        {
            var filter = new PatientFilter
            {
                PageNumber = 1,
                PageSize = 10
            };

            var patients = new List<Patient> { new Patient() };

            _repositoryMock.Setup(r =>
                r.GetAllAsync(1, 10, It.IsAny<System.Linq.Expressions.Expression<System.Func<Patient, bool>>>()))
                .ReturnsAsync(new PagedResult<Patient>
                {
                    Items = patients,
                    PageNumber = 1,
                    PageSize = 10,
                    TotalCount = 1
                });

            _mapperMock.Setup(m =>
                m.Map<IEnumerable<PatientListDto>>(patients))
                .Returns(new List<PatientListDto> { new PatientListDto() });

            var result = await _service.GetAllAsync(filter);

            Assert.Equal(1, result.TotalCount);
        }

        [Fact]
        public async Task GetAll_ShouldReturnEmpty_WhenNoPatients()
        {
            var filter = new PatientFilter
            {
                PageNumber = 1,
                PageSize = 10
            };

            _repositoryMock.Setup(r =>
                r.GetAllAsync(1, 10, It.IsAny<System.Linq.Expressions.Expression<System.Func<Patient, bool>>>()))
                .ReturnsAsync(new PagedResult<Patient>
                {
                    Items = new List<Patient>(),
                    TotalCount = 0
                });

            _mapperMock.Setup(m =>
                m.Map<IEnumerable<PatientListDto>>(It.IsAny<IEnumerable<Patient>>()))
                .Returns(new List<PatientListDto>());

            var result = await _service.GetAllAsync(filter);

            Assert.Empty(result.Items);
        }
    }
}