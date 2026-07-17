using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs.Appointment;
using HealthCare.Api.Events;
using HealthCare.Api.Exceptions;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Implementations;
using HealthCare.Api.Services.Interfaces;
using HealthCare.Shared.DTOs.Appointment;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace HealthCare.Api.Tests;

public class AppointmentServiceTests
{
    private readonly Mock<IAppointmentRepository> _repositoryMock;
    private readonly Mock<IDoctorService> _doctorServiceMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IPublishEndpoint> _publishEndpointMock;

    private readonly HealthCareDbContext _context;
    private readonly AppointmentService _service;

    public AppointmentServiceTests()
    {
        _repositoryMock = new Mock<IAppointmentRepository>();
        _doctorServiceMock = new Mock<IDoctorService>();
        _mapperMock = new Mock<IMapper>();
        _publishEndpointMock = new Mock<IPublishEndpoint>();

        var options = new DbContextOptionsBuilder<HealthCareDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new HealthCareDbContext(options);

        SeedPatients();

        _service = new AppointmentService(
            _repositoryMock.Object,
            _doctorServiceMock.Object,
            _context,
            _mapperMock.Object,
            _publishEndpointMock.Object
        );
    }

    private void SeedPatients()
    {
        _context.Patients.AddRange(
            new Patient
            {
                PatientId = 5,
                FullName = "Test Patient",
                UserId = "user-5",
                PhoneNumber = "9999999999",
                Gender = "Female",
                InsuranceId = "INS001",
                IsActive = true,
                CreatedDate = DateTimeOffset.UtcNow
            },
            new Patient
            {
                PatientId = 50,
                FullName = "Another Patient",
                UserId = "user-50",
                PhoneNumber = "8888888888",
                Gender = "Female",
                InsuranceId = "INS050",
                IsActive = true,
                CreatedDate = DateTimeOffset.UtcNow
            }
        );

        _context.SaveChanges();
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsAppointmentDto_WhenExists()
    {
        // Arrange
        var appointment = new Appointment
        {
            AppointmentId = 1,
            PatientId = 5,
            DoctorId = 10,
            TimeSlot = "09:00",
            ScheduledDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
            Status = "Pending",
            Patient = new Patient
            {
                PatientId = 5,
                FullName = "Test Patient"
            },
            Doctor = new Doctor
            {
                DoctorId = 10,
                FullName = "Dr Test"
            }
        };

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(appointment);

        // Act
        var result = await _service.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.AppointmentId);
        Assert.Equal(5, result.PatientId);
        Assert.Equal("Test Patient", result.PatientName);
        Assert.Equal("Dr Test", result.DoctorName);
        Assert.Equal("09:00", result.TimeSlot);
        Assert.Equal("Pending", result.Status);
    }

    [Fact]
    public async Task GetByIdAsync_Throws_WhenNotFound()
    {
        // Arrange
        _repositoryMock
            .Setup(r => r.GetByIdAsync(2))
            .ReturnsAsync((Appointment?)null);

        // Act
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.GetByIdAsync(2));

        // Assert
        Assert.Equal("Appointment not found.", exception.Message);
    }

    [Fact]
    public async Task AddAsync_Throws_WhenScheduledDateInPast()
    {
        // Arrange
        var dto = new CreateAppointmentDto
        {
            DoctorId = 1,
            ScheduledDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-1)),
            TimeSlot = "09:00"
        };

        // Act
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.AddAsync(dto, 5));

        // Assert
        Assert.Equal("Cannot book an appointment for a past date.", exception.Message);

        _repositoryMock.Verify(
            r => r.IsAvailable(It.IsAny<DateOnly>(), It.IsAny<int>(), It.IsAny<string>()),
            Times.Never
        );

        _repositoryMock.Verify(
            r => r.AddAsync(It.IsAny<Appointment>()),
            Times.Never
        );

        _publishEndpointMock.Verify(
            p => p.Publish(It.IsAny<AppointmentBookedEvent>(), It.IsAny<CancellationToken>()),
            Times.Never
        );
    }

    [Fact]
    public async Task AddAsync_PublishesEvent_OnSuccess()
    {
        // Arrange
        var dto = new CreateAppointmentDto
        {
            DoctorId = 1,
            ScheduledDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
            TimeSlot = "09:00"
        };

        var appointmentEntity = new Appointment
        {
            AppointmentId = 100,
            DoctorId = dto.DoctorId,
            PatientId = 5,
            ScheduledDate = dto.ScheduledDate,
            TimeSlot = dto.TimeSlot,
            Status = "Pending"
        };

        _repositoryMock
            .Setup(r => r.IsAvailable(dto.ScheduledDate, dto.DoctorId, dto.TimeSlot))
            .ReturnsAsync(true);

        _mapperMock
            .Setup(m => m.Map<Appointment>(dto))
            .Returns(appointmentEntity);

        _repositoryMock
            .Setup(r => r.AddAsync(It.IsAny<Appointment>()))
            .Returns(Task.CompletedTask);

        _publishEndpointMock
            .Setup(p => p.Publish(
                It.IsAny<AppointmentBookedEvent>(),
                It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        // Act
        await _service.AddAsync(dto, 5);

        // Assert
        _repositoryMock.Verify(
            r => r.IsAvailable(dto.ScheduledDate, dto.DoctorId, dto.TimeSlot),
            Times.Once
        );

        _repositoryMock.Verify(
            r => r.AddAsync(It.Is<Appointment>(a =>
                a.PatientId == 5 &&
                a.DoctorId == dto.DoctorId &&
                a.ScheduledDate == dto.ScheduledDate &&
                a.TimeSlot == dto.TimeSlot &&
                a.Status == "Pending")),
            Times.Once
        );

        _publishEndpointMock.Verify(
            p => p.Publish(
                It.Is<AppointmentBookedEvent>(e =>
                    e.AppointmentId == 100 &&
                    e.PatientName == "Test Patient" &&
                    e.DoctorId == dto.DoctorId &&
                    e.ScheduledDate == dto.ScheduledDate &&
                    e.TimeSlot == dto.TimeSlot),
                It.IsAny<CancellationToken>()),
            Times.Once
        );
    }

    [Fact]
    public async Task AvailableTimeSlots_ReturnsFreeSlots()
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Today.AddDays(1));
        var doctorId = 1;

        _doctorServiceMock
            .Setup(d => d.GetSlots(doctorId))
            .ReturnsAsync(new List<string> { "09:00", "10:00" });

        _repositoryMock
            .Setup(r => r.BookedTimeSlots(date, doctorId))
            .ReturnsAsync(new List<string> { "09:00" });

        // Act
        var result = await _service.AvailableTimeSlots(date, doctorId);

        // Assert
        Assert.Single(result);
        Assert.Contains("10:00", result);
        Assert.DoesNotContain("09:00", result);
    }

    [Fact]
    public async Task AvailableTimeSlots_Throws_WhenDateIsPast()
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));
        var doctorId = 1;

        // Act
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.AvailableTimeSlots(date, doctorId));

        // Assert
        Assert.Equal("Cannot check availability for a past date.", exception.Message);

        _doctorServiceMock.Verify(
            d => d.GetSlots(It.IsAny<int>()),
            Times.Never
        );
    }

    [Fact]
    public async Task AvailableTimeSlots_ReturnsEmptyList_WhenDoctorHasNoSlots()
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Today.AddDays(1));
        var doctorId = 1;

        _doctorServiceMock
            .Setup(d => d.GetSlots(doctorId))
            .ReturnsAsync(new List<string>());

        // Act
        var result = await _service.AvailableTimeSlots(date, doctorId);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);

        _repositoryMock.Verify(
            r => r.BookedTimeSlots(It.IsAny<DateOnly>(), It.IsAny<int>()),
            Times.Never
        );
    }

    [Fact]
    public async Task IsAvailable_Throws_WhenUnavailable()
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Today.AddDays(1));
        var doctorId = 1;
        var timeSlot = "09:00";

        _repositoryMock
            .Setup(r => r.IsAvailable(date, doctorId, timeSlot))
            .ReturnsAsync(false);

        // Act
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.IsAvailable(date, doctorId, timeSlot));

        // Assert
        Assert.Equal("This time slot is already booked.", exception.Message);

        _repositoryMock.Verify(
            r => r.IsAvailable(date, doctorId, timeSlot),
            Times.Once
        );
    }

    [Fact]
    public async Task IsAvailable_ReturnsTrue_WhenAvailable()
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Today.AddDays(1));
        var doctorId = 1;
        var timeSlot = "09:00";

        _repositoryMock
            .Setup(r => r.IsAvailable(date, doctorId, timeSlot))
            .ReturnsAsync(true);

        // Act
        var result = await _service.IsAvailable(date, doctorId, timeSlot);

        // Assert
        Assert.True(result);

        _repositoryMock.Verify(
            r => r.IsAvailable(date, doctorId, timeSlot),
            Times.Once
        );
    }

    [Fact]
    public async Task UpdateStatusAsync_UpdatesStatus_WhenAppointmentExists()
    {
        // Arrange
        var appointment = new Appointment
        {
            AppointmentId = 1,
            PatientId = 5,
            DoctorId = 10,
            ScheduledDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
            TimeSlot = "09:00",
            Status = "Pending"
        };

        var dto = new UpdateAppointmentDto
        {
            Status = "Cancelled",
            CancellationReason = "Doctor unavailable"
        };

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(appointment);

        _repositoryMock
            .Setup(r => r.UpdateAsync(It.IsAny<Appointment>()))
            .Returns(Task.CompletedTask);

        // Act
        await _service.UpdateStatusAsync(1, dto);

        // Assert
        Assert.Equal("Cancelled", appointment.Status);
        Assert.Equal("Doctor unavailable", appointment.CancellationReason);

        _repositoryMock.Verify(
            r => r.UpdateAsync(It.Is<Appointment>(a =>
                a.AppointmentId == 1 &&
                a.Status == "Cancelled" &&
                a.CancellationReason == "Doctor unavailable")),
            Times.Once
        );
    }

    [Fact]
    public async Task UpdateStatusAsync_Throws_WhenAppointmentNotFound()
    {
        // Arrange
        var dto = new UpdateAppointmentDto
        {
            Status = "Cancelled",
            CancellationReason = "Patient request"
        };

        _repositoryMock
            .Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((Appointment?)null);

        // Act
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.UpdateStatusAsync(99, dto));

        // Assert
        Assert.Equal("Appointment not found.", exception.Message);

        _repositoryMock.Verify(
            r => r.UpdateAsync(It.IsAny<Appointment>()),
            Times.Never
        );
    }

    [Fact]
    public async Task DeleteAsync_ThrowsAppointmentNotFoundException_WhenAppointmentNotFound()
    {
        // Arrange
        _repositoryMock
            .Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((Appointment?)null);

        // Act and Assert
        await Assert.ThrowsAsync<AppointmentNotFoundException>(() =>
            _service.DeleteAsync(99));

        _repositoryMock.Verify(
            r => r.DeleteAsync(It.IsAny<int>()),
            Times.Never
        );
    }

    [Fact]
    public async Task DeleteAsync_DeletesAppointment_WhenAppointmentExists()
    {
        // Arrange
        var appointment = new Appointment
        {
            AppointmentId = 1,
            PatientId = 5,
            DoctorId = 10,
            ScheduledDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
            TimeSlot = "09:00",
            Status = "Pending"
        };

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(appointment);

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
    public async Task GetReport_ReturnsReport_WhenDataExists()
    {
        // Arrange
        var fromDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-7));
        var toDate = DateOnly.FromDateTime(DateTime.Today);

        var filter = new AppointmentReportFilter
        {
            FromDate = fromDate,
            ToDate = toDate
        };

        var reports = new List<AppointmentReportDto>
        {
            new AppointmentReportDto
            {
                Date = DateOnly.FromDateTime(DateTime.Today),
                PendingCount = 2,
                ConfirmedCount = 3,
                CancelledCount = 1,
                CompletedCount = 4,
                Revenue = 2500
            }
        };

        _repositoryMock
            .Setup(r => r.GetReport(fromDate, toDate))
            .ReturnsAsync(reports);

        // Act
        var result = await _service.GetReport(filter);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(DateOnly.FromDateTime(DateTime.Today), result[0].Date);
        Assert.Equal(2, result[0].PendingCount);
        Assert.Equal(3, result[0].ConfirmedCount);
        Assert.Equal(1, result[0].CancelledCount);
        Assert.Equal(4, result[0].CompletedCount);
        Assert.Equal(2500, result[0].Revenue);

        _repositoryMock.Verify(
            r => r.GetReport(fromDate, toDate),
            Times.Once
        );
    }

    [Fact]
    public async Task GetReport_ReturnsEmptyList_WhenNoDataExists()
    {
        // Arrange
        var fromDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-7));
        var toDate = DateOnly.FromDateTime(DateTime.Today);

        var filter = new AppointmentReportFilter
        {
            FromDate = fromDate,
            ToDate = toDate
        };

        _repositoryMock
            .Setup(r => r.GetReport(fromDate, toDate))
            .ReturnsAsync(new List<AppointmentReportDto>());

        // Act
        var result = await _service.GetReport(filter);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);

        _repositoryMock.Verify(
            r => r.GetReport(fromDate, toDate),
            Times.Once
        );
    }

    [Fact]
    public async Task GetSummaryAsync_ReturnsSummary()
    {
        // Arrange
        var summary = new AppointmentSummaryDto
        {
            PendingCount = 3,
            ConfirmedCount = 4,
            CancelledCount = 1,
            CompletedCount = 2,
            TotalRevenue = 2500
        };

        _repositoryMock
            .Setup(r => r.GetSummaryAsync())
            .ReturnsAsync(summary);

        // Act
        var result = await _service.GetSummaryAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.PendingCount);
        Assert.Equal(4, result.ConfirmedCount);
        Assert.Equal(1, result.CancelledCount);
        Assert.Equal(2, result.CompletedCount);
        Assert.Equal(2500, result.TotalRevenue);

        _repositoryMock.Verify(
            r => r.GetSummaryAsync(),
            Times.Once
        );
    }

    [Fact]
    public async Task GetDashboardSummaryAsync_ReturnsSummary()
    {
        // Arrange
        var summary = new AppointmentSummaryDto
        {
            PendingCount = 5,
            ConfirmedCount = 8,
            CancelledCount = 2,
            CompletedCount = 5,
            TotalRevenue = 5000
        };

        _repositoryMock
            .Setup(r => r.GetDashboardSummaryAsync())
            .ReturnsAsync(summary);

        // Act
        var result = await _service.GetDashboardSummaryAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(5, result.PendingCount);
        Assert.Equal(8, result.ConfirmedCount);
        Assert.Equal(2, result.CancelledCount);
        Assert.Equal(5, result.CompletedCount);
        Assert.Equal(5000, result.TotalRevenue);

        _repositoryMock.Verify(
            r => r.GetDashboardSummaryAsync(),
            Times.Once
        );
    }
}
