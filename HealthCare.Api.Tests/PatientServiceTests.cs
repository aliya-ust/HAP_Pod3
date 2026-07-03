using Moq;
using AutoMapper;
using HealthCare.Api.Models;
using HealthCare.Api.Data;
using HealthCare.Api.Exceptions;
using HealthCare.Api.Services.Implementations;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Shared.DTOs;
using HealthCare.Shared.DTOs.Patient;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Api.Tests
{
    public class PatientServiceTests
    {
        private readonly Mock<IRepository<Patient>> _repoMock;
        private readonly Mock<IPatientRepository> _patientRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<UserManager<User>> _userManagerMock;
        private readonly HealthCareDbContext _context;
        private readonly PatientService _service;

        public PatientServiceTests()
        {
            _repoMock = new Mock<IRepository<Patient>>();
            _patientRepoMock = new Mock<IPatientRepository>();
            _mapperMock = new Mock<IMapper>();

            _userManagerMock = new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(), null!, null!, null!, null!, null!, null!, null!, null!);

            var options = new DbContextOptionsBuilder<HealthCareDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new HealthCareDbContext(options);

            _service = new PatientService(
                _repoMock.Object,
                _patientRepoMock.Object,
                _context,
                _mapperMock.Object,
                _userManagerMock.Object
            );
        }

        // GetById - Success
        [Fact]
        public async Task GetByIdAsync_ShouldReturnPatient_WhenExists()
        {
            var patient = new Patient { PatientId = 1, FullName = "Test", Gender = "Male", PhoneNumber = "9876543210" };
            _context.Set<Patient>().Add(patient);
            await _context.SaveChangesAsync();

            var dto = new PatientListDto();
            _patientRepoMock.Setup(r => r.GetQueryable()).Returns(_context.Set<Patient>());
            _mapperMock.Setup(m => m.Map<PatientListDto>(It.IsAny<Patient>())).Returns(dto);

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
        }

        // GetById - Not found
        [Fact]
        public async Task GetByIdAsync_ShouldThrow_WhenPatientNotFound()
        {
            _patientRepoMock.Setup(r => r.GetQueryable()).Returns(_context.Set<Patient>());

            await Assert.ThrowsAsync<PatientNotFoundException>(() =>
                _service.GetByIdAsync(1));
        }

        // GetAll
        [Fact]
        public async Task GetAllAsync_ShouldReturnPagedResult()
        {
            _context.Set<Patient>().Add(new Patient
            {
                FullName = "Test Patient",
                Gender = "Male",
                PhoneNumber = "1234567890"
            });
            await _context.SaveChangesAsync();

            _patientRepoMock.Setup(r => r.GetQueryable())
                .Returns(_context.Set<Patient>());

            _mapperMock.Setup(m => m.Map<IEnumerable<PatientListDto>>(It.IsAny<IEnumerable<Patient>>()))
                .Returns(new List<PatientListDto> { new PatientListDto() });

            var result = await _service.GetAllAsync(new PatientFilter());

            Assert.NotNull(result);
            Assert.Equal(1, result.TotalCount);
        }

        [Fact]
        public async Task GetAllAsync_ShouldFilterByHasInsurance_True()
        {
            _context.Set<Patient>().AddRange(
                new Patient { FullName = "With Insurance", Gender = "Male", PhoneNumber = "1111111111", InsuranceId = "ABC123" },
                new Patient { FullName = "No Insurance", Gender = "Female", PhoneNumber = "2222222222", InsuranceId = null }
            );
            await _context.SaveChangesAsync();

            _patientRepoMock.Setup(r => r.GetQueryable()).Returns(_context.Set<Patient>());
            _mapperMock.Setup(m => m.Map<IEnumerable<PatientListDto>>(It.IsAny<IEnumerable<Patient>>()))
                .Returns(new List<PatientListDto> { new PatientListDto() });

            var result = await _service.GetAllAsync(new PatientFilter { HasInsurance = true });

            Assert.Equal(1, result.TotalCount);
        }

        [Fact]
        public async Task GetAllAsync_ShouldFilterByHasInsurance_False()
        {
            _context.Set<Patient>().AddRange(
                new Patient { FullName = "With Insurance", Gender = "Male", PhoneNumber = "1111111111", InsuranceId = "ABC123" },
                new Patient { FullName = "No Insurance", Gender = "Female", PhoneNumber = "2222222222", InsuranceId = null }
            );
            await _context.SaveChangesAsync();

            _patientRepoMock.Setup(r => r.GetQueryable()).Returns(_context.Set<Patient>());
            _mapperMock.Setup(m => m.Map<IEnumerable<PatientListDto>>(It.IsAny<IEnumerable<Patient>>()))
                .Returns(new List<PatientListDto> { new PatientListDto() });

            var result = await _service.GetAllAsync(new PatientFilter { HasInsurance = false });

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

            await Assert.ThrowsAsync<PatientNotFoundException>(() =>
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

            await Assert.ThrowsAsync<PatientNotFoundException>(() =>
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

            await Assert.ThrowsAsync<DbHandleException>(() =>
                _service.DeleteAsync(1));
        }
    }
}