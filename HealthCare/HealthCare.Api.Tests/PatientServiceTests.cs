using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Implementations;
using HealthCare.Shared.DTOs;
using HealthCare.Shared.DTOs.Patient;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq.Expressions;

namespace HealthCare.Api.Tests;

public class PatientServiceTests
{
    private readonly Mock<IRepository<Patient>> _repositoryMock;
    private readonly Mock<IPatientRepository> _patientRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<HealthCareDbContext> _contextMock;

    private readonly PatientService _service;

    public PatientServiceTests()
    {
        _repositoryMock = new Mock<IRepository<Patient>>();
        _patientRepositoryMock = new Mock<IPatientRepository>();
        _mapperMock = new Mock<IMapper>();

        var options = new DbContextOptions<HealthCareDbContext>();

        _contextMock = new Mock<HealthCareDbContext>(options);

        _service = new PatientService(
            _repositoryMock.Object,
            _patientRepositoryMock.Object,
            _contextMock.Object,
            _mapperMock.Object);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnPatient_WhenExists()
    {
        var patient = new Patient
        {
            PatientId = 1
        };

        var dto = new PatientListDto();

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(patient);

        _mapperMock
            .Setup(m => m.Map<PatientListDto>(patient))
            .Returns(dto);

        var result = await _service.GetByIdAsync(1);

        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldThrow_WhenPatientNotFound()
    {
        _repositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync((Patient?)null);

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.GetByIdAsync(1));
    }

   

    [Fact]
    public async Task AddAsync_ShouldAddPatient()
    {
        var dto = new CreatePatientDto
        {
            FullName = "Test User"
        };

        var patient = new Patient
        {
            FullName = "Test User"
        };

        _mapperMock
            .Setup(m => m.Map<Patient>(dto))
            .Returns(patient);

        await _service.AddAsync(dto);

        _repositoryMock.Verify(
            r => r.AddAsync(patient),
            Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdatePatient()
    {
        var patient = new Patient
        {
            PatientId = 1
        };

        var dto = new UpdatePatientDto();

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(patient);

        await _service.UpdateAsync(1, dto);

        _mapperMock.Verify(
            m => m.Map(dto, patient),
            Times.Once);

        _repositoryMock.Verify(
            r => r.UpdateAsync(patient),
            Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldThrow_WhenPatientNotFound()
    {
        _repositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync((Patient?)null);

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.UpdateAsync(1, new UpdatePatientDto()));
    }

    [Fact]
    public async Task UpdateStatusAsync_ShouldUpdateStatus()
    {
        var patient = new Patient
        {
            PatientId = 1,
            IsActive = true
        };

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(patient);

        await _service.UpdateStatusAsync(1, false);

        Assert.False(patient.IsActive);

        _repositoryMock.Verify(
            r => r.UpdateAsync(patient),
            Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeletePatient()
    {
        var patient = new Patient
        {
            PatientId = 1
        };

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(patient);

        await _service.DeleteAsync(1);

        _repositoryMock.Verify(
            r => r.DeleteAsync(1),
            Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldThrow_WhenPatientNotFound()
    {
        _repositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync((Patient?)null);

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.DeleteAsync(1));
    }

    [Fact]
    public async Task DeleteAsync_ShouldThrow_WhenDeleteFails()
    {
        var patient = new Patient();

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(patient);

        _repositoryMock
            .Setup(r => r.DeleteAsync(1))
            .ThrowsAsync(new DbUpdateException());

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.DeleteAsync(1));
    }

    [Fact]
    public async Task GetSummaryAsync_ShouldReturnSummary()
    {
        var summary = new PatientSummaryDto
        {
            TotalPatients = 10
        };

        _patientRepositoryMock
            .Setup(r => r.GetSummaryAsync())
            .ReturnsAsync(summary);

        var result = await _service.GetSummaryAsync();

        Assert.NotNull(result);
        Assert.Equal(10, result.TotalPatients);
    }
}