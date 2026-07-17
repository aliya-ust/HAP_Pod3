using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Implementations;
using HealthCare.Shared.DTOs.Patient;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace HealthCare.Api.Tests;

public class PatientServiceTests
{
    private readonly Mock<IRepository<Patient>> _repositoryMock;
    private readonly Mock<IPatientRepository> _patientRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;

    private readonly HealthCareDbContext _context;
    private readonly PatientService _service;

    public PatientServiceTests()
    {
        _repositoryMock = new Mock<IRepository<Patient>>();
        _patientRepositoryMock = new Mock<IPatientRepository>();
        _mapperMock = new Mock<IMapper>();

        var options = new DbContextOptionsBuilder<HealthCareDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new HealthCareDbContext(options);

        SeedData();

        _service = new PatientService(
            _repositoryMock.Object,
            _patientRepositoryMock.Object,
            _context,
            _mapperMock.Object
        );
    }

    private void SeedData()
    {
        _context.Users.AddRange(
            new User
            {
                Id = "user-1",
                UserName = "patient1@test.com",
                Email = "patient1@test.com"
            },
            new User
            {
                Id = "user-2",
                UserName = "patient2@test.com",
                Email = "patient2@test.com"
            }
        );

        _context.Patients.AddRange(
            new Patient
            {
                PatientId = 1,
                FullName = "Test Patient One",
                UserId = "user-1",
                PhoneNumber = "9999999999",
                DateOfBirth = DateOnly.FromDateTime(DateTime.Today.AddYears(-25)),
                Gender = "Female",
                InsuranceId = "INS001",
                IsActive = true,
                CreatedDate = DateTimeOffset.UtcNow
            },
            new Patient
            {
                PatientId = 2,
                FullName = "Test Patient Two",
                UserId = "user-2",
                PhoneNumber = "8888888888",
                DateOfBirth = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)),
                Gender = "Male",
                InsuranceId = null,
                IsActive = false,
                CreatedDate = DateTimeOffset.UtcNow
            }
        );

        _context.SaveChanges();
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsPatientDto_WhenPatientExists()
    {
        // Arrange
        var patient = new Patient
        {
            PatientId = 1,
            FullName = "Test Patient One",
            PhoneNumber = "9999999999",
            InsuranceId = "INS001",
            IsActive = true
        };

        var patientDto = new PatientListDto();

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(patient);

        _mapperMock
            .Setup(m => m.Map<PatientListDto>(patient))
            .Returns(patientDto);

        // Act
        var result = await _service.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Same(patientDto, result);

        _repositoryMock.Verify(
            r => r.GetByIdAsync(1),
            Times.Once
        );

        _mapperMock.Verify(
            m => m.Map<PatientListDto>(patient),
            Times.Once
        );
    }

    [Fact]
    public async Task GetByIdAsync_Throws_WhenPatientNotFound()
    {
        // Arrange
        _repositoryMock
            .Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((Patient?)null);

        // Act
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.GetByIdAsync(99));

        // Assert
        Assert.Equal("Patient not found.", exception.Message);

        _mapperMock.Verify(
            m => m.Map<PatientListDto>(It.IsAny<Patient>()),
            Times.Never
        );
    }

    [Fact]
    public async Task GetMyProfileAsync_ReturnsProfile_WhenPatientExists()
    {
        // Arrange
        var patientId = 1;

        // Act
        var result = await _service.GetMyProfileAsync(patientId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.PatientId);
        Assert.Equal("Test Patient One", result.FullName);
        Assert.Equal("patient1@test.com", result.Email);
        Assert.Equal("9999999999", result.PhoneNumber);
        Assert.Equal("Female", result.Gender);
        Assert.Equal("INS001", result.InsuranceId);
    }

    [Fact]
    public async Task GetMyProfileAsync_ReturnsNull_WhenPatientDoesNotExist()
    {
        // Act
        var result = await _service.GetMyProfileAsync(999);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsPagedPatients()
    {
        // Arrange
        var filter = new PatientFilter
        {
            PageNumber = 1,
            PageSize = 10
        };

        _patientRepositoryMock
            .Setup(r => r.GetQueryable())
            .Returns(_context.Patients.AsQueryable());

        _mapperMock
            .Setup(m => m.Map<IEnumerable<PatientListDto>>(It.IsAny<object>()))
            .Returns(new List<PatientListDto>
            {
                new PatientListDto(),
                new PatientListDto()
            });

        // Act
        var result = await _service.GetAllAsync(filter);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.PageNumber);
        Assert.Equal(10, result.PageSize);
        Assert.Equal(2, result.TotalCount);
        Assert.Equal(2, result.Items.Count());

        _patientRepositoryMock.Verify(
            r => r.GetQueryable(),
            Times.Once
        );
    }

    [Fact]
    public async Task GetAllAsync_FiltersBySearch()
    {
        // Arrange
        var filter = new PatientFilter
        {
            Search = "One",
            PageNumber = 1,
            PageSize = 10
        };

        _patientRepositoryMock
            .Setup(r => r.GetQueryable())
            .Returns(_context.Patients.AsQueryable());

        _mapperMock
            .Setup(m => m.Map<IEnumerable<PatientListDto>>(It.IsAny<object>()))
            .Returns(new List<PatientListDto>
            {
                new PatientListDto()
            });

        // Act
        var result = await _service.GetAllAsync(filter);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.TotalCount);
        Assert.Single(result.Items);
    }

    [Fact]
    public async Task GetAllAsync_FiltersByHasInsuranceTrue()
    {
        // Arrange
        var filter = new PatientFilter
        {
            HasInsurance = true,
            PageNumber = 1,
            PageSize = 10
        };

        _patientRepositoryMock
            .Setup(r => r.GetQueryable())
            .Returns(_context.Patients.AsQueryable());

        _mapperMock
            .Setup(m => m.Map<IEnumerable<PatientListDto>>(It.IsAny<object>()))
            .Returns(new List<PatientListDto>
            {
                new PatientListDto()
            });

        // Act
        var result = await _service.GetAllAsync(filter);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.TotalCount);
        Assert.Single(result.Items);
    }

    [Fact]
    public async Task GetAllAsync_FiltersByHasInsuranceFalse()
    {
        // Arrange
        var filter = new PatientFilter
        {
            HasInsurance = false,
            PageNumber = 1,
            PageSize = 10
        };

        _patientRepositoryMock
            .Setup(r => r.GetQueryable())
            .Returns(_context.Patients.AsQueryable());

        _mapperMock
            .Setup(m => m.Map<IEnumerable<PatientListDto>>(It.IsAny<object>()))
            .Returns(new List<PatientListDto>
            {
                new PatientListDto()
            });

        // Act
        var result = await _service.GetAllAsync(filter);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.TotalCount);
        Assert.Single(result.Items);
    }

    [Fact]
    public async Task GetAllAsync_FiltersByIsActive()
    {
        // Arrange
        var filter = new PatientFilter
        {
            IsActive = true,
            PageNumber = 1,
            PageSize = 10
        };

        _patientRepositoryMock
            .Setup(r => r.GetQueryable())
            .Returns(_context.Patients.AsQueryable());

        _mapperMock
            .Setup(m => m.Map<IEnumerable<PatientListDto>>(It.IsAny<object>()))
            .Returns(new List<PatientListDto>
            {
                new PatientListDto()
            });

        // Act
        var result = await _service.GetAllAsync(filter);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.TotalCount);
        Assert.Single(result.Items);
    }

    [Fact]
    public async Task AddAsync_AddsPatient()
    {
        // Arrange
        var dto = new CreatePatientDto();

        var patient = new Patient
        {
            PatientId = 10,
            FullName = "New Patient",
            PhoneNumber = "7777777777",
            Gender = "Female",
            InsuranceId = "INS010",
            IsActive = true,
            CreatedDate = DateTimeOffset.UtcNow
        };

        _mapperMock
            .Setup(m => m.Map<Patient>(dto))
            .Returns(patient);

        _repositoryMock
            .Setup(r => r.AddAsync(patient))
            .Returns(Task.CompletedTask);

        // Act
        await _service.AddAsync(dto);

        // Assert
        _repositoryMock.Verify(
            r => r.AddAsync(patient),
            Times.Once
        );
    }

    [Fact]
    public async Task UpdateAsync_UpdatesPatient_WhenPatientExists()
    {
        // Arrange
        var dto = new UpdatePatientDto();

        var patient = new Patient
        {
            PatientId = 1,
            FullName = "Old Name",
            PhoneNumber = "9999999999",
            IsActive = true
        };

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(patient);

        _mapperMock
            .Setup(m => m.Map(dto, patient))
            .Returns(patient);

        _repositoryMock
            .Setup(r => r.UpdateAsync(patient))
            .Returns(Task.CompletedTask);

        // Act
        await _service.UpdateAsync(1, dto);

        // Assert
        _mapperMock.Verify(
            m => m.Map(dto, patient),
            Times.Once
        );

        _repositoryMock.Verify(
            r => r.UpdateAsync(patient),
            Times.Once
        );
    }

    [Fact]
    public async Task UpdateAsync_Throws_WhenPatientNotFound()
    {
        // Arrange
        var dto = new UpdatePatientDto();

        _repositoryMock
            .Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((Patient?)null);

        // Act
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.UpdateAsync(99, dto));

        // Assert
        Assert.Equal("Patient not found.", exception.Message);

        _repositoryMock.Verify(
            r => r.UpdateAsync(It.IsAny<Patient>()),
            Times.Never
        );
    }

    [Fact]
    public async Task UpdateStatusAsync_UpdatesStatus_WhenPatientExists()
    {
        // Arrange
        var patient = new Patient
        {
            PatientId = 1,
            FullName = "Test Patient",
            IsActive = true
        };

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(patient);

        _repositoryMock
            .Setup(r => r.UpdateAsync(patient))
            .Returns(Task.CompletedTask);

        // Act
        await _service.UpdateStatusAsync(1, false);

        // Assert
        Assert.False(patient.IsActive);

        _repositoryMock.Verify(
            r => r.UpdateAsync(It.Is<Patient>(p =>
                p.PatientId == 1 &&
                p.IsActive == false)),
            Times.Once
        );
    }

    [Fact]
    public async Task UpdateStatusAsync_Throws_WhenPatientNotFound()
    {
        // Arrange
        _repositoryMock
            .Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((Patient?)null);

        // Act
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.UpdateStatusAsync(99, false));

        // Assert
        Assert.Equal("Patient not found.", exception.Message);

        _repositoryMock.Verify(
            r => r.UpdateAsync(It.IsAny<Patient>()),
            Times.Never
        );
    }

    [Fact]
    public async Task DeleteAsync_DeletesPatient_WhenPatientExists()
    {
        // Arrange
        var patient = new Patient
        {
            PatientId = 1,
            FullName = "Test Patient"
        };

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(patient);

        _repositoryMock
            .Setup(r => r.DeleteAsync(1))
            .Returns(Task.CompletedTask);

        // Act
        await _service.DeleteAsync(1);

        // Assert
        _repositoryMock.Verify(
            r => r.DeleteAsync(1),
            Times.Once
        );
    }

    [Fact]
    public async Task DeleteAsync_Throws_WhenPatientNotFound()
    {
        // Arrange
        _repositoryMock
            .Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((Patient?)null);

        // Act
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.DeleteAsync(99));

        // Assert
        Assert.Equal("Patient not found.", exception.Message);

        _repositoryMock.Verify(
            r => r.DeleteAsync(It.IsAny<int>()),
            Times.Never
        );
    }

    [Fact]
    public async Task GetSummaryAsync_ReturnsSummary()
    {
        // Arrange
        var summary = new PatientSummaryDto();

        _patientRepositoryMock
            .Setup(r => r.GetSummaryAsync())
            .ReturnsAsync(summary);

        // Act
        var result = await _service.GetSummaryAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Same(summary, result);

        _patientRepositoryMock.Verify(
            r => r.GetSummaryAsync(),
            Times.Once
        );
    }
}