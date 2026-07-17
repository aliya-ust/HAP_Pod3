using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs.HealthRecord;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Implementations;
using HealthCare.Shared.DTOs;
using HealthCare.Shared.DTOs.HealthRecord;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq.Expressions;

namespace HealthCare.Api.Tests;

public class HealthRecordServiceTests
{
    private readonly Mock<IHealthRecordRepository> _repositoryMock;
    private readonly Mock<IMapper> _mapperMock;

    private readonly HealthCareDbContext _context;
    private readonly HealthRecordService _service;

    public HealthRecordServiceTests()
    {
        _repositoryMock = new Mock<IHealthRecordRepository>();
        _mapperMock = new Mock<IMapper>();

        var options = new DbContextOptionsBuilder<HealthCareDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new HealthCareDbContext(options);

        SeedData();

        _service = new HealthRecordService(
            _repositoryMock.Object,
            _context,
            _mapperMock.Object
        );
    }

    private void SeedData()
    {
        _context.Appointments.AddRange(
            new Appointment
            {
                AppointmentId = 1,
                PatientId = 5,
                DoctorId = 10,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today),
                TimeSlot = "09:00",
                Status = "Confirmed"
            },
            new Appointment
            {
                AppointmentId = 2,
                PatientId = 6,
                DoctorId = 20,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today),
                TimeSlot = "10:00",
                Status = "Confirmed"
            },
            new Appointment
            {
                AppointmentId = 3,
                PatientId = 7,
                DoctorId = 10,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today),
                TimeSlot = "11:00",
                Status = "Pending"
            },
            new Appointment
            {
                AppointmentId = 4,
                PatientId = 8,
                DoctorId = 10,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today),
                TimeSlot = "12:00",
                Status = "Confirmed"
            }
        );

        _context.HealthRecords.Add(
            new HealthRecord
            {
                HealthRecordId = 100,
                AppointmentId = 4,
                PatientId = 8,
                DoctorId = 10,
                VisitDate = DateTime.Today,
                Diagnosis = "Existing Diagnosis",
                Prescription = "Existing Prescription",
                Notes = "Existing Notes"
            }
        );

        _context.SaveChanges();
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsHealthRecordDto_WhenRecordExists()
    {
        // Arrange
        var record = new HealthRecord
        {
            HealthRecordId = 1,
            AppointmentId = 1,
            PatientId = 5,
            DoctorId = 10,
            VisitDate = DateTime.Today,
            Diagnosis = "Fever",
            Prescription = "Medicine",
            Notes = "Drink water"
        };

        var dto = new HealthRecordListDto();

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(record);

        _mapperMock
            .Setup(m => m.Map<HealthRecordListDto>(record))
            .Returns(dto);

        // Act
        var result = await _service.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Same(dto, result);

        _repositoryMock.Verify(
            r => r.GetByIdAsync(1),
            Times.Once
        );

        _mapperMock.Verify(
            m => m.Map<HealthRecordListDto>(record),
            Times.Once
        );
    }

    [Fact]
    public async Task GetByIdAsync_Throws_WhenRecordNotFound()
    {
        // Arrange
        _repositoryMock
            .Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((HealthRecord?)null);

        // Act
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.GetByIdAsync(99));

        // Assert
        Assert.Equal("Health Record not found.", exception.Message);

        _mapperMock.Verify(
            m => m.Map<HealthRecordListDto>(It.IsAny<HealthRecord>()),
            Times.Never
        );
    }

    [Fact]
    public async Task GetAllAsync_ReturnsPagedHealthRecords()
    {
        // Arrange
        var filter = new HealthRecordFilter
        {
            PageNumber = 1,
            PageSize = 10
        };

        var records = new List<HealthRecord>
        {
            new HealthRecord
            {
                HealthRecordId = 1,
                AppointmentId = 1,
                PatientId = 5,
                DoctorId = 10,
                VisitDate = DateTime.Today,
                Diagnosis = "Diagnosis 1"
            },
            new HealthRecord
            {
                HealthRecordId = 2,
                AppointmentId = 2,
                PatientId = 6,
                DoctorId = 20,
                VisitDate = DateTime.Today.AddDays(1),
                Diagnosis = "Diagnosis 2"
            }
        };

        var pagedRecords = new PagedResult<HealthRecord>
        {
            Items = records,
            PageNumber = 1,
            PageSize = 10,
            TotalCount = 2
        };

        var mappedDtos = new List<HealthRecordListDto>
        {
            new HealthRecordListDto(),
            new HealthRecordListDto()
        };

        _repositoryMock
            .Setup(r => r.GetAllAsync(
                filter.PageNumber,
                filter.PageSize,
                It.IsAny<Expression<Func<HealthRecord, bool>>?>(),
                It.IsAny<Func<IQueryable<HealthRecord>, IOrderedQueryable<HealthRecord>>>()))
            .ReturnsAsync(pagedRecords);

        _mapperMock
            .Setup(m => m.Map<IEnumerable<HealthRecordListDto>>(records))
            .Returns(mappedDtos);

        // Act
        var result = await _service.GetAllAsync(filter);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.PageNumber);
        Assert.Equal(10, result.PageSize);
        Assert.Equal(2, result.TotalCount);
        Assert.Equal(2, result.Items.Count());

        _repositoryMock.Verify(
            r => r.GetAllAsync(
                filter.PageNumber,
                filter.PageSize,
                It.IsAny<Expression<Func<HealthRecord, bool>>?>(),
                It.IsAny<Func<IQueryable<HealthRecord>, IOrderedQueryable<HealthRecord>>>()),
            Times.Once
        );
    }

    [Fact]
    public async Task GetAllAsync_WithVisitDateFilter_ReturnsPagedHealthRecords()
    {
        // Arrange
        var visitDate = DateOnly.FromDateTime(DateTime.Today);

        var filter = new HealthRecordFilter
        {
            VisitDate = visitDate,
            PageNumber = 1,
            PageSize = 10
        };

        var records = new List<HealthRecord>
        {
            new HealthRecord
            {
                HealthRecordId = 1,
                AppointmentId = 1,
                PatientId = 5,
                DoctorId = 10,
                VisitDate = DateTime.Today,
                Diagnosis = "Diagnosis"
            }
        };

        var pagedRecords = new PagedResult<HealthRecord>
        {
            Items = records,
            PageNumber = 1,
            PageSize = 10,
            TotalCount = 1
        };

        var mappedDtos = new List<HealthRecordListDto>
        {
            new HealthRecordListDto()
        };

        _repositoryMock
            .Setup(r => r.GetAllAsync(
                filter.PageNumber,
                filter.PageSize,
                It.IsAny<Expression<Func<HealthRecord, bool>>?>(),
                It.IsAny<Func<IQueryable<HealthRecord>, IOrderedQueryable<HealthRecord>>>()))
            .ReturnsAsync(pagedRecords);

        _mapperMock
            .Setup(m => m.Map<IEnumerable<HealthRecordListDto>>(records))
            .Returns(mappedDtos);

        // Act
        var result = await _service.GetAllAsync(filter);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result.Items);
        Assert.Equal(1, result.TotalCount);
    }

    [Fact]
    public async Task AddAsync_AddsHealthRecordAndCompletesAppointment_WhenValid()
    {
        // Arrange
        var dto = new CreateHealthRecordDto
        {
            AppointmentId = 1,
            VisitDate = DateTime.Today,
            Diagnosis = "Fever",
            Prescription = "Paracetamol",
            Notes = "Rest required"
        };

        _repositoryMock
            .Setup(r => r.AddAsync(It.IsAny<HealthRecord>()))
            .Returns(Task.CompletedTask);

        // Act
        await _service.AddAsync(doctorId: 10, dto);

        // Assert
        var appointment = await _context.Appointments
            .FirstAsync(a => a.AppointmentId == 1);

        Assert.Equal("Completed", appointment.Status);

        _repositoryMock.Verify(
            r => r.AddAsync(It.Is<HealthRecord>(hr =>
                hr.AppointmentId == dto.AppointmentId &&
                hr.PatientId == 5 &&
                hr.DoctorId == 10 &&
                hr.VisitDate == dto.VisitDate &&
                hr.Diagnosis == dto.Diagnosis &&
                hr.Prescription == dto.Prescription &&
                hr.Notes == dto.Notes)),
            Times.Once
        );
    }

    [Fact]
    public async Task AddAsync_Throws_WhenAppointmentNotFound()
    {
        // Arrange
        var dto = new CreateHealthRecordDto
        {
            AppointmentId = 999,
            VisitDate = DateTime.Today,
            Diagnosis = "Fever",
            Prescription = "Medicine",
            Notes = "Notes"
        };

        // Act
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.AddAsync(doctorId: 10, dto));

        // Assert
        Assert.Equal("Appointment not found.", exception.Message);

        _repositoryMock.Verify(
            r => r.AddAsync(It.IsAny<HealthRecord>()),
            Times.Never
        );
    }

    [Fact]
    public async Task AddAsync_Throws_WhenDoctorDoesNotOwnAppointment()
    {
        // Arrange
        var dto = new CreateHealthRecordDto
        {
            AppointmentId = 2,
            VisitDate = DateTime.Today,
            Diagnosis = "Fever",
            Prescription = "Medicine",
            Notes = "Notes"
        };

        // Appointment 2 belongs to DoctorId 20, not DoctorId 10

        // Act
        var exception = await Assert.ThrowsAsync<UnauthorizedAccessException>(() =>
            _service.AddAsync(doctorId: 10, dto));

        // Assert
        Assert.Equal("You cannot add record for this appointment.", exception.Message);

        _repositoryMock.Verify(
            r => r.AddAsync(It.IsAny<HealthRecord>()),
            Times.Never
        );
    }

    [Fact]
    public async Task AddAsync_Throws_WhenAppointmentIsNotConfirmed()
    {
        // Arrange
        var dto = new CreateHealthRecordDto
        {
            AppointmentId = 3,
            VisitDate = DateTime.Today,
            Diagnosis = "Fever",
            Prescription = "Medicine",
            Notes = "Notes"
        };

        // Appointment 3 status is Pending

        // Act
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.AddAsync(doctorId: 10, dto));

        // Assert
        Assert.Equal("Health record can be added only for confirmed appointments.", exception.Message);

        _repositoryMock.Verify(
            r => r.AddAsync(It.IsAny<HealthRecord>()),
            Times.Never
        );
    }

    [Fact]
    public async Task AddAsync_Throws_WhenHealthRecordAlreadyExistsForAppointment()
    {
        // Arrange
        var dto = new CreateHealthRecordDto
        {
            AppointmentId = 4,
            VisitDate = DateTime.Today,
            Diagnosis = "New Diagnosis",
            Prescription = "New Prescription",
            Notes = "New Notes"
        };

        // Health record already seeded for AppointmentId 4

        // Act
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.AddAsync(doctorId: 10, dto));

        // Assert
        Assert.Equal("Health record already exists for this appointment.", exception.Message);

        _repositoryMock.Verify(
            r => r.AddAsync(It.IsAny<HealthRecord>()),
            Times.Never
        );
    }

    [Fact]
    public async Task UpdateAsync_UpdatesHealthRecord_WhenRecordExists()
    {
        // Arrange
        var dto = new UpdateHealthRecordDto();

        var record = new HealthRecord
        {
            HealthRecordId = 1,
            AppointmentId = 1,
            PatientId = 5,
            DoctorId = 10,
            VisitDate = DateTime.Today,
            Diagnosis = "Old Diagnosis",
            Prescription = "Old Prescription",
            Notes = "Old Notes"
        };

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(record);

        _repositoryMock
            .Setup(r => r.UpdateAsync(record))
            .Returns(Task.CompletedTask);

        // Act
        await _service.UpdateAsync(1, dto);

        // Assert
        _mapperMock.Verify(
            m => m.Map(dto, record),
            Times.Once
        );

        _repositoryMock.Verify(
            r => r.UpdateAsync(record),
            Times.Once
        );
    }

    [Fact]
    public async Task UpdateAsync_Throws_WhenRecordNotFound()
    {
        // Arrange
        var dto = new UpdateHealthRecordDto();

        _repositoryMock
            .Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((HealthRecord?)null);

        // Act
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.UpdateAsync(99, dto));

        // Assert
        Assert.Equal("Health record not found.", exception.Message);

        _repositoryMock.Verify(
            r => r.UpdateAsync(It.IsAny<HealthRecord>()),
            Times.Never
        );
    }

    [Fact]
    public async Task DeleteAsync_DeletesHealthRecord_WhenRecordExists()
    {
        // Arrange
        var record = new HealthRecord
        {
            HealthRecordId = 1,
            AppointmentId = 1,
            PatientId = 5,
            DoctorId = 10,
            VisitDate = DateTime.Today,
            Diagnosis = "Diagnosis"
        };

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(record);

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
    public async Task DeleteAsync_Throws_WhenRecordNotFound()
    {
        // Arrange
        _repositoryMock
            .Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((HealthRecord?)null);

        // Act
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.DeleteAsync(99));

        // Assert
        Assert.Equal("Health record not found.", exception.Message);

        _repositoryMock.Verify(
            r => r.DeleteAsync(It.IsAny<int>()),
            Times.Never
        );
    }

    [Fact]
    public async Task GetHealthRecordByPatient_ReturnsRecords()
    {
        // Arrange
        var records = new List<HealthRecordListDto>
        {
            new HealthRecordListDto(),
            new HealthRecordListDto()
        };

        _repositoryMock
            .Setup(r => r.GetHealthRecordByPatient(5))
            .ReturnsAsync(records);

        // Act
        var result = await _service.GetHealthRecordByPatient(5);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);

        _repositoryMock.Verify(
            r => r.GetHealthRecordByPatient(5),
            Times.Once
        );
    }

    [Fact]
    public async Task GetHealthRecordByAppointment_ReturnsRecords_WhenRecordsExist()
    {
        // Arrange
        var records = new List<HealthRecordListDto>
        {
            new HealthRecordListDto()
        };

        _repositoryMock
            .Setup(r => r.GetHealthRecordByAppointment(1))
            .ReturnsAsync(records);

        // Act
        var result = await _service.GetHealthRecordByAppointment(1);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);

        _repositoryMock.Verify(
            r => r.GetHealthRecordByAppointment(1),
            Times.Once
        );
    }

    [Fact]
    public async Task GetHealthRecordByAppointment_ReturnsEmptyList_WhenNoRecordsExist()
    {
        // Arrange
        _repositoryMock
            .Setup(r => r.GetHealthRecordByAppointment(99))
            .ReturnsAsync(new List<HealthRecordListDto>());

        // Act
        var result = await _service.GetHealthRecordByAppointment(99);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);

        _repositoryMock.Verify(
            r => r.GetHealthRecordByAppointment(99),
            Times.Once
        );
    }
}