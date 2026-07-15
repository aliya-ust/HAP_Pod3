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
using Microsoft.Extensions.Logging;
using Moq;
using System.Text;
using System.Text.Json;

namespace HealthCare.Api.Tests;

public class DoctorServiceTests
{
    private readonly Mock<IDoctorRepository> _doctorRepositoryMock;
    private readonly Mock<IAppointmentRepository> _appointmentRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<HealthCareDbContext> _contextMock;
    private readonly Mock<ILogger<DoctorService>> _loggerMock;
    private readonly Mock<IDistributedCache> _cacheMock;

    private readonly DoctorService _service;

    public DoctorServiceTests()
    {
        _doctorRepositoryMock = new Mock<IDoctorRepository>();
        _appointmentRepositoryMock = new Mock<IAppointmentRepository>();
        _mapperMock = new Mock<IMapper>();
        _loggerMock = new Mock<ILogger<DoctorService>>();
        _cacheMock = new Mock<IDistributedCache>();

        var options = new DbContextOptions<HealthCareDbContext>();

        _contextMock = new Mock<HealthCareDbContext>(options);

        _contextMock
            .Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        _service = new DoctorService(
            _doctorRepositoryMock.Object,
            _appointmentRepositoryMock.Object,
            _contextMock.Object,
            _mapperMock.Object,
            _loggerMock.Object,
            _cacheMock.Object
        );
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnDoctor_WhenDoctorExists()
    {
        var doctor = new Doctor
        {
            DoctorId = 1,
            FullName = "Dr Test"
        };

        var doctorDto = new DoctorListDto
        {
            DoctorId = 1,
            FullName = "Dr Test"
        };

        _doctorRepositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(doctor);

        _mapperMock
            .Setup(m => m.Map<DoctorListDto>(doctor))
            .Returns(doctorDto);

        var result = await _service.GetByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal(1, result.DoctorId);
        Assert.Equal("Dr Test", result.FullName);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldThrow_WhenDoctorNotFound()
    {
        _doctorRepositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync((Doctor?)null);

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.GetByIdAsync(1));
    }

    [Fact]
    public async Task AddAsync_ShouldAddDoctorAndCreateSlots()
    {
        var dto = new CreateDoctorDto
        {
            TimeSlots = new List<string>
            {
                "09:00 AM",
                "10:00 AM"
            }
        };

        var doctor = new Doctor
        {
            DoctorId = 1
        };

        _mapperMock
            .Setup(m => m.Map<Doctor>(dto))
            .Returns(doctor);

        await _service.AddAsync(dto);

        _doctorRepositoryMock.Verify(
            r => r.AddAsync(doctor),
            Times.Once);

        _doctorRepositoryMock.Verify(
            r => r.CreateSlots(doctor.DoctorId, dto.TimeSlots),
            Times.Once);

        _contextMock.Verify(
            c => c.SaveChangesAsync(It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateDoctor_WhenDoctorExists()
    {
        var doctor = new Doctor
        {
            DoctorId = 1
        };

        var dto = new UpdateDoctorDto();

        _doctorRepositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(doctor);

        await _service.UpdateAsync(1, dto);

        _mapperMock.Verify(
            m => m.Map(dto, doctor),
            Times.Once);

        _doctorRepositoryMock.Verify(
            r => r.UpdateAsync(doctor),
            Times.Once);

        _contextMock.Verify(
            c => c.SaveChangesAsync(It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldThrow_WhenDoctorNotFound()
    {
        _doctorRepositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync((Doctor?)null);

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.UpdateAsync(1, new UpdateDoctorDto()));
    }

    [Fact]
    public async Task UpdateStatusAsync_ShouldUpdateDoctorStatus()
    {
        var doctor = new Doctor
        {
            DoctorId = 1,
            IsActive = true
        };

        _doctorRepositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(doctor);

        await _service.UpdateStatusAsync(1, false);

        Assert.False(doctor.IsActive);

        _doctorRepositoryMock.Verify(
            r => r.UpdateAsync(doctor),
            Times.Once);

        _contextMock.Verify(
            c => c.SaveChangesAsync(It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task UpdateStatusAsync_ShouldThrow_WhenDoctorNotFound()
    {
        _doctorRepositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync((Doctor?)null);

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.UpdateStatusAsync(1, false));
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteDoctor_WhenDoctorExists()
    {
        var doctor = new Doctor
        {
            DoctorId = 1
        };

        _doctorRepositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(doctor);

        await _service.DeleteAsync(1);

        _doctorRepositoryMock.Verify(
            r => r.DeleteAsync(1),
            Times.Once);

        _contextMock.Verify(
            c => c.SaveChangesAsync(It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldThrow_WhenDoctorNotFound()
    {
        _doctorRepositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync((Doctor?)null);

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.DeleteAsync(1));
    }

    [Fact]
    public async Task DeleteAsync_ShouldThrowInvalidOperationException_WhenDeleteFails()
    {
        var doctor = new Doctor
        {
            DoctorId = 1
        };

        _doctorRepositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(doctor);

        _doctorRepositoryMock
            .Setup(r => r.DeleteAsync(1))
            .ThrowsAsync(new DbUpdateException());

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.DeleteAsync(1));
    }

    [Fact]
    public async Task GetSlots_ShouldReturnSlots_WhenSlotsExist()
    {
        var slots = new List<string>
        {
            "09:00 AM",
            "10:00 AM"
        };

        _doctorRepositoryMock
            .Setup(r => r.GetSlots(1))
            .ReturnsAsync(slots);

        var result = await _service.GetSlots(1);

        Assert.Equal(2, result.Count);
        Assert.Contains("09:00 AM", result);
        Assert.Contains("10:00 AM", result);
    }

    [Fact]
    public async Task GetSlots_ShouldThrowNoAvailableSlotsException_WhenSlotsAreEmpty()
    {
        _doctorRepositoryMock
            .Setup(r => r.GetSlots(1))
            .ReturnsAsync(new List<string>());

        await Assert.ThrowsAsync<NoAvailableSlotsException>(
            () => _service.GetSlots(1));
    }

    [Fact]
    public async Task CreateSlots_ShouldCreateSlotsAndSaveChanges()
    {
        var slots = new List<string>
        {
            "09:00 AM",
            "10:00 AM"
        };

        await _service.CreateSlots(1, slots);

        _doctorRepositoryMock.Verify(
            r => r.CreateSlots(1, slots),
            Times.Once);

        _contextMock.Verify(
            c => c.SaveChangesAsync(It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task AvailableDoctors_ShouldReturnDoctorsFromCache_WhenCacheHit()
    {
        var date = DateOnly.FromDateTime(DateTime.Today);
        var specialisation = "Cardiology";
        var cacheKey = $"doctors:available:cardiology:{date:yyyy-MM-dd}";

        var cachedDoctors = new List<DoctorListDto>
        {
            new()
            {
                DoctorId = 1,
                FullName = "Cached Doctor",
                Specialisation = "Cardiology",
                IsActive = true
            }
        };

        var cachedBytes = Encoding.UTF8.GetBytes(
            JsonSerializer.Serialize(cachedDoctors));

        _cacheMock
            .Setup(c => c.GetAsync(
                cacheKey,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(cachedBytes);

        var result = await _service.AvailableDoctors(specialisation, date);

        Assert.Single(result);
        Assert.Equal("Cached Doctor", result[0].FullName);

        _doctorRepositoryMock.Verify(
            r => r.AvailableDoctors(
                It.IsAny<string>(),
                It.IsAny<DateOnly>()),
            Times.Never);
    }

    [Fact]
    public async Task AvailableDoctors_ShouldReturnDoctorsFromRepository_WhenCacheMiss()
    {
        var date = DateOnly.FromDateTime(DateTime.Today);
        var specialisation = "Cardiology";
        var cacheKey = $"doctors:available:cardiology:{date:yyyy-MM-dd}";

        var doctors = new List<DoctorListDto>
        {
            new()
            {
                DoctorId = 1,
                FullName = "Dr Repository",
                Specialisation = "Cardiology",
                IsActive = true
            }
        };

        _cacheMock
            .Setup(c => c.GetAsync(
                cacheKey,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync((byte[]?)null);

        _doctorRepositoryMock
            .Setup(r => r.AvailableDoctors(specialisation, date))
            .ReturnsAsync(doctors);

        var result = await _service.AvailableDoctors(specialisation, date);

        Assert.Single(result);
        Assert.Equal("Dr Repository", result[0].FullName);

        _doctorRepositoryMock.Verify(
            r => r.AvailableDoctors(specialisation, date),
            Times.Once);

        _cacheMock.Verify(
            c => c.SetAsync(
                cacheKey,
                It.IsAny<byte[]>(),
                It.IsAny<DistributedCacheEntryOptions>(),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task AvailableDoctors_ShouldThrow_WhenDateIsPast()
    {
        var pastDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.AvailableDoctors("Cardiology", pastDate));
    }

    [Fact]
    public async Task GetSummaryAsync_ShouldReturnSummary()
    {
        var summary = new DoctorSummaryDto
        {
            TotalDoctors = 5,
            ActiveDoctors = 4,
            InactiveDoctors = 1
        };

        _doctorRepositoryMock
            .Setup(r => r.GetSummaryAsync())
            .ReturnsAsync(summary);

        var result = await _service.GetSummaryAsync();

        Assert.Equal(5, result.TotalDoctors);
        Assert.Equal(4, result.ActiveDoctors);
        Assert.Equal(1, result.InactiveDoctors);
    }

    [Fact]
    public async Task CreateLeave_ShouldThrow_WhenLeaveDateIsPast()
    {
        var pastDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));

        var leaves = new List<CreateLeaveDto>
        {
            new()
            {
                LeaveDate = pastDate,
                Reason = "Past leave"
            }
        };

        _doctorRepositoryMock
            .Setup(r => r.GetLeavesByDoctorId(1))
            .ReturnsAsync(new List<DoctorLeaves>());

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.CreateLeave(1, leaves));
    }

    [Fact]
    public async Task CreateLeave_ShouldSkipDuplicateLeaveDate()
    {
        var leaveDate = DateOnly.FromDateTime(DateTime.Today);

        var existingLeaves = new List<DoctorLeaves>
        {
            new()
            {
                LeaveDate = leaveDate
            }
        };

        var leaves = new List<CreateLeaveDto>
        {
            new()
            {
                LeaveDate = leaveDate,
                Reason = "Already exists"
            }
        };

        _doctorRepositoryMock
            .Setup(r => r.GetLeavesByDoctorId(1))
            .ReturnsAsync(existingLeaves);

        var result = await _service.CreateLeave(1, leaves);

        Assert.Contains(leaveDate, result.SkippedDates);

        _doctorRepositoryMock.Verify(
            r => r.CreateLeaves(
                It.IsAny<int>(),
                It.IsAny<List<CreateLeaveDto>>()),
            Times.Never);
    }

    [Fact]
    public async Task CreateLeave_ShouldCreateLeave_WhenNoAppointmentsExist()
    {
        var leaveDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1));

        var leaves = new List<CreateLeaveDto>
        {
            new()
            {
                LeaveDate = leaveDate,
                Reason = "Personal"
            }
        };

        var allSlots = new List<string>
        {
            "09:00 AM",
            "10:00 AM"
        };

        var bookedSlots = new List<string>();

        _doctorRepositoryMock
            .Setup(r => r.GetLeavesByDoctorId(1))
            .ReturnsAsync(new List<DoctorLeaves>());

        _doctorRepositoryMock
            .Setup(r => r.GetSlots(1))
            .ReturnsAsync(allSlots);

        _appointmentRepositoryMock
            .Setup(r => r.BookedTimeSlots(leaveDate, 1))
            .ReturnsAsync(bookedSlots);

        var result = await _service.CreateLeave(1, leaves);

        Assert.Empty(result.SkippedDates);
        Assert.Empty(result.CreatedWithCancelledAppointments);

        _doctorRepositoryMock.Verify(
            r => r.CreateLeaves(1, leaves),
            Times.Once);

        _appointmentRepositoryMock.Verify(
            r => r.CancelAppointmentsByDoctorDate(
                It.IsAny<int>(),
                It.IsAny<DateOnly>()),
            Times.Never);

        _contextMock.Verify(
            c => c.SaveChangesAsync(It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task CreateLeave_ShouldCancelAppointments_WhenBookedSlotsExist()
    {
        var leaveDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1));

        var leaves = new List<CreateLeaveDto>
        {
            new()
            {
                LeaveDate = leaveDate,
                Reason = "Emergency"
            }
        };

        var allSlots = new List<string>
        {
            "09:00 AM",
            "10:00 AM"
        };

        var bookedSlots = new List<string>
        {
            "09:00 AM"
        };

        _doctorRepositoryMock
            .Setup(r => r.GetLeavesByDoctorId(1))
            .ReturnsAsync(new List<DoctorLeaves>());

        _doctorRepositoryMock
            .Setup(r => r.GetSlots(1))
            .ReturnsAsync(allSlots);

        _appointmentRepositoryMock
            .Setup(r => r.BookedTimeSlots(leaveDate, 1))
            .ReturnsAsync(bookedSlots);

        var result = await _service.CreateLeave(1, leaves);

        Assert.Contains(
            leaveDate,
            result.CreatedWithCancelledAppointments);

        _appointmentRepositoryMock.Verify(
            r => r.CancelAppointmentsByDoctorDate(1, leaveDate),
            Times.Once);

        _doctorRepositoryMock.Verify(
            r => r.CreateLeaves(1, leaves),
            Times.Once);

        _contextMock.Verify(
            c => c.SaveChangesAsync(It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task CreateLeave_ShouldThrowNoAvailableSlotsException_WhenDoctorHasNoSlots()
    {
        var leaveDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1));

        var leaves = new List<CreateLeaveDto>
        {
            new()
            {
                LeaveDate = leaveDate,
                Reason = "Personal"
            }
        };

        _doctorRepositoryMock
            .Setup(r => r.GetLeavesByDoctorId(1))
            .ReturnsAsync(new List<DoctorLeaves>());

        _doctorRepositoryMock
            .Setup(r => r.GetSlots(1))
            .ReturnsAsync(new List<string>());

        _appointmentRepositoryMock
            .Setup(r => r.BookedTimeSlots(leaveDate, 1))
            .ReturnsAsync(new List<string>());

        await Assert.ThrowsAsync<NoAvailableSlotsException>(
            () => _service.CreateLeave(1, leaves));
    }
}