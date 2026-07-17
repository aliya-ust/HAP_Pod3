using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.Exceptions;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Implementations;
using HealthCare.Shared.DTOs;
using HealthCare.Shared.DTOs.Doctor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
using System.Text;
using System.Text.Json;

namespace HealthCare.Api.Tests;

public class DoctorServiceTests
{
    private readonly Mock<IDoctorRepository> _repositoryMock;
    private readonly Mock<IAppointmentRepository> _appointmentRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IDistributedCache> _cacheMock;

    private readonly HealthCareDbContext _context;
    private readonly DoctorService _service;

    public DoctorServiceTests()
    {
        _repositoryMock = new Mock<IDoctorRepository>();
        _appointmentRepositoryMock = new Mock<IAppointmentRepository>();
        _mapperMock = new Mock<IMapper>();
        _cacheMock = new Mock<IDistributedCache>();

        var options = new DbContextOptionsBuilder<HealthCareDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new HealthCareDbContext(options);

        SeedDoctorsAndAppointments();

        _service = new DoctorService(
            _repositoryMock.Object,
            _appointmentRepositoryMock.Object,
            _context,
            _mapperMock.Object,
            _cacheMock.Object
        );
    }

    private void SeedDoctorsAndAppointments()
    {
        _context.Doctors.AddRange(
            new Doctor
            {
                DoctorId = 1,
                FullName = "Dr John",
                Specialisation = "Cardiology",
                YearsOfExperience = 10,
                ConsultationFee = 500,
                IsActive = true,
                UserId = "doctor-user-1"
            },
            new Doctor
            {
                DoctorId = 2,
                FullName = "Dr Smith",
                Specialisation = "Dermatology",
                YearsOfExperience = 5,
                ConsultationFee = 300,
                IsActive = true,
                UserId = "doctor-user-2"
            }
        );

        _context.Appointments.AddRange(
            new Appointment
            {
                AppointmentId = 1,
                DoctorId = 1,
                PatientId = 5,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
                TimeSlot = "09:00",
                Status = "Confirmed"
            },
            new Appointment
            {
                AppointmentId = 2,
                DoctorId = 1,
                PatientId = 6,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-1)),
                TimeSlot = "10:00",
                Status = "Completed"
            },
            new Appointment
            {
                AppointmentId = 3,
                DoctorId = 1,
                PatientId = 7,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today),
                TimeSlot = "11:00",
                Status = "Pending"
            }
        );

        _context.SaveChanges();
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsDoctorDto_WhenDoctorExists()
    {
        // Arrange
        var doctor = new Doctor
        {
            DoctorId = 1,
            FullName = "Dr John",
            Specialisation = "Cardiology",
            YearsOfExperience = 10,
            ConsultationFee = 500,
            IsActive = true
        };

        var doctorDto = new DoctorListDto();

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(doctor);

        _mapperMock
            .Setup(m => m.Map<DoctorListDto>(doctor))
            .Returns(doctorDto);

        // Act
        var result = await _service.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Same(doctorDto, result);

        _repositoryMock.Verify(
            r => r.GetByIdAsync(1),
            Times.Once
        );

        _mapperMock.Verify(
            m => m.Map<DoctorListDto>(doctor),
            Times.Once
        );
    }

    [Fact]
    public async Task GetByIdAsync_ThrowsDoctorNotFoundException_WhenDoctorDoesNotExist()
    {
        // Arrange
        _repositoryMock
            .Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((Doctor?)null);

        // Act and Assert
        await Assert.ThrowsAsync<DoctorNotFoundException>(() =>
            _service.GetByIdAsync(99));

        _repositoryMock.Verify(
            r => r.GetByIdAsync(99),
            Times.Once
        );
    }

    [Fact]
    public async Task AddAsync_AddsDoctorAndCreatesSlots()
    {
        // Arrange
        var dto = new CreateDoctorDto
        {
            TimeSlots = new List<string> { "09:00", "10:00" }
        };

        var doctor = new Doctor
        {
            DoctorId = 10,
            FullName = "Dr New",
            Specialisation = "Neurology",
            YearsOfExperience = 8,
            ConsultationFee = 700,
            IsActive = true
        };

        _mapperMock
            .Setup(m => m.Map<Doctor>(dto))
            .Returns(doctor);

        _repositoryMock
            .Setup(r => r.AddAsync(doctor))
            .Returns(Task.CompletedTask);

        _repositoryMock
            .Setup(r => r.CreateSlots(doctor.DoctorId, dto.TimeSlots))
            .Returns(Task.CompletedTask);

        // Act
        await _service.AddAsync(dto);

        // Assert
        _repositoryMock.Verify(
            r => r.AddAsync(doctor),
            Times.Once
        );

        _repositoryMock.Verify(
            r => r.CreateSlots(doctor.DoctorId, dto.TimeSlots),
            Times.Once
        );
    }

    [Fact]
    public async Task UpdateAsync_UpdatesDoctor_WhenDoctorExists()
    {
        // Arrange
        var dto = new UpdateDoctorDto();

        var doctor = new Doctor
        {
            DoctorId = 1,
            FullName = "Dr John",
            Specialisation = "Cardiology",
            YearsOfExperience = 10,
            ConsultationFee = 500,
            IsActive = true
        };

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(doctor);

        _repositoryMock
            .Setup(r => r.UpdateAsync(doctor))
            .Returns(Task.CompletedTask);

        // Act
        await _service.UpdateAsync(1, dto);

        // Assert
        _mapperMock.Verify(
            m => m.Map(dto, doctor),
            Times.Once
        );

        _repositoryMock.Verify(
            r => r.UpdateAsync(doctor),
            Times.Once
        );
    }

    [Fact]
    public async Task UpdateAsync_Throws_WhenDoctorNotFound()
    {
        // Arrange
        var dto = new UpdateDoctorDto();

        _repositoryMock
            .Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((Doctor?)null);

        // Act
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.UpdateAsync(99, dto));

        // Assert
        Assert.Equal("Doctor not found.", exception.Message);

        _repositoryMock.Verify(
            r => r.UpdateAsync(It.IsAny<Doctor>()),
            Times.Never
        );
    }

    [Fact]
    public async Task UpdateStatusAsync_UpdatesDoctorStatus_WhenDoctorExists()
    {
        // Arrange
        var doctor = new Doctor
        {
            DoctorId = 1,
            FullName = "Dr John",
            IsActive = true
        };

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(doctor);

        _repositoryMock
            .Setup(r => r.UpdateAsync(doctor))
            .Returns(Task.CompletedTask);

        // Act
        await _service.UpdateStatusAsync(1, false);

        // Assert
        Assert.False(doctor.IsActive);

        _repositoryMock.Verify(
            r => r.UpdateAsync(It.Is<Doctor>(d =>
                d.DoctorId == 1 &&
                d.IsActive == false)),
            Times.Once
        );
    }

    [Fact]
    public async Task UpdateStatusAsync_Throws_WhenDoctorNotFound()
    {
        // Arrange
        _repositoryMock
            .Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((Doctor?)null);

        // Act
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.UpdateStatusAsync(99, false));

        // Assert
        Assert.Equal("Doctor not found.", exception.Message);

        _repositoryMock.Verify(
            r => r.UpdateAsync(It.IsAny<Doctor>()),
            Times.Never
        );
    }

    [Fact]
    public async Task DeleteAsync_DeletesDoctor_WhenDoctorExists()
    {
        // Arrange
        var doctor = new Doctor
        {
            DoctorId = 1,
            FullName = "Dr John"
        };

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(doctor);

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
    public async Task DeleteAsync_Throws_WhenDoctorNotFound()
    {
        // Arrange
        _repositoryMock
            .Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((Doctor?)null);

        // Act
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.DeleteAsync(99));

        // Assert
        Assert.Equal("Doctor not found.", exception.Message);

        _repositoryMock.Verify(
            r => r.DeleteAsync(It.IsAny<int>()),
            Times.Never
        );
    }

    [Fact]
    public async Task GetSlots_ReturnsSlots_WhenSlotsExist()
    {
        // Arrange
        var slots = new List<string> { "09:00", "10:00" };

        _repositoryMock
            .Setup(r => r.GetSlots(1))
            .ReturnsAsync(slots);

        // Act
        var result = await _service.GetSlots(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Contains("09:00", result);
        Assert.Contains("10:00", result);
    }

    [Fact]
    public async Task GetSlots_ThrowsNoAvailableSlotsException_WhenNoSlotsExist()
    {
        // Arrange
        _repositoryMock
            .Setup(r => r.GetSlots(1))
            .ReturnsAsync(new List<string>());

        // Act and Assert
        await Assert.ThrowsAsync<NoAvailableSlotsException>(() =>
            _service.GetSlots(1));
    }

    [Fact]
    public async Task CreateSlots_CreatesSlots()
    {
        // Arrange
        var slots = new List<string> { "09:00", "10:00" };

        _repositoryMock
            .Setup(r => r.CreateSlots(1, slots))
            .Returns(Task.CompletedTask);

        // Act
        await _service.CreateSlots(1, slots);

        // Assert
        _repositoryMock.Verify(
            r => r.CreateSlots(1, slots),
            Times.Once
        );
    }

    [Fact]
    public async Task AvailableDoctors_Throws_WhenDateIsPast()
    {
        // Arrange
        var pastDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));

        // Act
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.AvailableDoctors("Cardiology", pastDate));

        // Assert
        Assert.Equal("Cannot check availability for a past date.", exception.Message);

        _repositoryMock.Verify(
            r => r.AvailableDoctors(It.IsAny<string>(), It.IsAny<DateOnly>()),
            Times.Never
        );
    }

    [Fact]
    public async Task AvailableDoctors_ReturnsFromRepository_WhenCacheMiss()
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Today.AddDays(1));
        var specialisation = "Cardiology";

        var doctors = new List<DoctorListDto>
        {
            new DoctorListDto()
        };

        _cacheMock
            .Setup(c => c.GetAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync((byte[]?)null);

        _cacheMock
            .Setup(c => c.SetAsync(
                It.IsAny<string>(),
                It.IsAny<byte[]>(),
                It.IsAny<DistributedCacheEntryOptions>(),
                It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        _repositoryMock
            .Setup(r => r.AvailableDoctors(specialisation, date))
            .ReturnsAsync(doctors);

        // Act
        var result = await _service.AvailableDoctors(specialisation, date);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);

        _repositoryMock.Verify(
            r => r.AvailableDoctors(specialisation, date),
            Times.Once
        );

        _cacheMock.Verify(
            c => c.SetAsync(
                It.IsAny<string>(),
                It.IsAny<byte[]>(),
                It.IsAny<DistributedCacheEntryOptions>(),
                It.IsAny<CancellationToken>()),
            Times.Once
        );
    }

    [Fact]
    public async Task AvailableDoctors_ReturnsFromCache_WhenCacheHit()
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Today.AddDays(1));
        var specialisation = "Cardiology";

        var cachedDoctors = new List<DoctorListDto>
        {
            new DoctorListDto()
        };

        var cachedJson = JsonSerializer.Serialize(cachedDoctors);
        var cachedBytes = Encoding.UTF8.GetBytes(cachedJson);

        _cacheMock
            .Setup(c => c.GetAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(cachedBytes);

        // Act
        var result = await _service.AvailableDoctors(specialisation, date);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);

        _repositoryMock.Verify(
            r => r.AvailableDoctors(It.IsAny<string>(), It.IsAny<DateOnly>()),
            Times.Never
        );

        _cacheMock.Verify(
            c => c.SetAsync(
                It.IsAny<string>(),
                It.IsAny<byte[]>(),
                It.IsAny<DistributedCacheEntryOptions>(),
                It.IsAny<CancellationToken>()),
            Times.Never
        );
    }

    [Fact]
    public async Task GetSummaryAsync_ReturnsSummary()
    {
        // Arrange
        var summary = new DoctorSummaryDto();

        _repositoryMock
            .Setup(r => r.GetSummaryAsync())
            .ReturnsAsync(summary);

        // Act
        var result = await _service.GetSummaryAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Same(summary, result);

        _repositoryMock.Verify(
            r => r.GetSummaryAsync(),
            Times.Once
        );
    }
}