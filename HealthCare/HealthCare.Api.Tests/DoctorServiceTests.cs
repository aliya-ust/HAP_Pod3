//using AutoMapper;
//using HealthCare.Api.Data;
//using HealthCare.Api.DTOs.Doctor;
//using HealthCare.Api.Models;
//using HealthCare.Api.Repositories.Interfaces;
//using HealthCare.Api.Services.Implementations;
//using HealthCare.Shared.DTOs;
//using HealthCare.Shared.DTOs.Doctor;
//using Microsoft.EntityFrameworkCore;
//using Moq;

//namespace HealthCare.Api.Tests;

//public class DoctorServiceTests
//{
//    private readonly Mock<IDoctorRepository> _doctorRepositoryMock;
//    private readonly Mock<IAppointmentRepository> _appointmentRepositoryMock;
//    private readonly Mock<IMapper> _mapperMock;
//    private readonly Mock<HealthCareDbContext> _contextMock;

//    private readonly DoctorService _service;

//    public DoctorServiceTests()
//    {
//        _doctorRepositoryMock = new Mock<IDoctorRepository>();
//        _appointmentRepositoryMock = new Mock<IAppointmentRepository>();
//        _mapperMock = new Mock<IMapper>();

//        var options = new DbContextOptions<HealthCareDbContext>();

//        _contextMock = new Mock<HealthCareDbContext>(options);

//        _service = new DoctorService(
//            _doctorRepositoryMock.Object,
//            _appointmentRepositoryMock.Object,
//            _contextMock.Object,
//            _mapperMock.Object);
//    }

//    [Fact]
//    public async Task GetByIdAsync_ShouldReturnDoctor_WhenExists()
//    {
//        var doctor = new Doctor
//        {
//            DoctorId = 1
//        };

//        var dto = new DoctorListDto();

//        _doctorRepositoryMock
//            .Setup(r => r.GetByIdAsync(1))
//            .ReturnsAsync(doctor);

//        _mapperMock
//            .Setup(m => m.Map<DoctorListDto>(doctor))
//            .Returns(dto);

//        var result = await _service.GetByIdAsync(1);

//        Assert.NotNull(result);
//    }

//    [Fact]
//    public async Task GetByIdAsync_ShouldThrow_WhenDoctorNotFound()
//    {
//        _doctorRepositoryMock
//            .Setup(r => r.GetByIdAsync(1))
//            .ReturnsAsync((Doctor?)null);

//        await Assert.ThrowsAsync<InvalidOperationException>(
//            () => _service.GetByIdAsync(1));
//    }

   
//    [Fact]
//    public async Task AddAsync_ShouldAddDoctor()
//    {
//        var dto = new CreateDoctorDto
//        {
//            TimeSlots = new List<string>
//            {
//                "09:00 AM"
//            }
//        };

//        var doctor = new Doctor
//        {
//            DoctorId = 1
//        };

//        _mapperMock
//            .Setup(m => m.Map<Doctor>(dto))
//            .Returns(doctor);

//        await _service.AddAsync(dto);

//        _doctorRepositoryMock.Verify(
//            r => r.AddAsync(doctor),
//            Times.Once);

//        _doctorRepositoryMock.Verify(
//            r => r.CreateSlots(
//                doctor.DoctorId,
//                dto.TimeSlots),
//            Times.Once);
//    }

//    [Fact]
//    public async Task UpdateAsync_ShouldUpdateDoctor()
//    {
//        var doctor = new Doctor();

//        var dto = new UpdateDoctorDto();

//        _doctorRepositoryMock
//            .Setup(r => r.GetByIdAsync(1))
//            .ReturnsAsync(doctor);

//        await _service.UpdateAsync(1, dto);

//        _mapperMock.Verify(
//            m => m.Map(dto, doctor),
//            Times.Once);

//        _doctorRepositoryMock.Verify(
//            r => r.UpdateAsync(doctor),
//            Times.Once);
//    }

//    [Fact]
//    public async Task UpdateAsync_ShouldThrow_WhenDoctorNotFound()
//    {
//        _doctorRepositoryMock
//            .Setup(r => r.GetByIdAsync(1))
//            .ReturnsAsync((Doctor?)null);

//        await Assert.ThrowsAsync<InvalidOperationException>(
//            () => _service.UpdateAsync(1, new UpdateDoctorDto()));
//    }

//    [Fact]
//    public async Task UpdateStatusAsync_ShouldUpdateStatus()
//    {
//        var doctor = new Doctor
//        {
//            IsActive = true
//        };

//        _doctorRepositoryMock
//            .Setup(r => r.GetByIdAsync(1))
//            .ReturnsAsync(doctor);

//        await _service.UpdateStatusAsync(1, false);

//        Assert.False(doctor.IsActive);

//        _doctorRepositoryMock.Verify(
//            r => r.UpdateAsync(doctor),
//            Times.Once);
//    }

//    [Fact]
//    public async Task UpdateStatusAsync_ShouldThrow_WhenDoctorNotFound()
//    {
//        _doctorRepositoryMock
//            .Setup(r => r.GetByIdAsync(1))
//            .ReturnsAsync((Doctor?)null);

//        await Assert.ThrowsAsync<InvalidOperationException>(
//            () => _service.UpdateStatusAsync(1, false));
//    }

//    [Fact]
//    public async Task DeleteAsync_ShouldDeleteDoctor()
//    {
//        var doctor = new Doctor();

//        _doctorRepositoryMock
//            .Setup(r => r.GetByIdAsync(1))
//            .ReturnsAsync(doctor);

//        await _service.DeleteAsync(1);

//        _doctorRepositoryMock.Verify(
//            r => r.DeleteAsync(1),
//            Times.Once);
//    }

//    [Fact]
//    public async Task DeleteAsync_ShouldThrow_WhenDoctorNotFound()
//    {
//        _doctorRepositoryMock
//            .Setup(r => r.GetByIdAsync(1))
//            .ReturnsAsync((Doctor?)null);

//        await Assert.ThrowsAsync<InvalidOperationException>(
//            () => _service.DeleteAsync(1));
//    }

//    [Fact]
//    public async Task DeleteAsync_ShouldThrow_WhenDeleteFails()
//    {
//        var doctor = new Doctor();

//        _doctorRepositoryMock
//            .Setup(r => r.GetByIdAsync(1))
//            .ReturnsAsync(doctor);

//        _doctorRepositoryMock
//            .Setup(r => r.DeleteAsync(1))
//            .ThrowsAsync(new DbUpdateException());

//        await Assert.ThrowsAsync<InvalidOperationException>(
//            () => _service.DeleteAsync(1));
//    }

//    [Fact]
//    public async Task GetSlots_ShouldReturnSlots()
//    {
//        var slots = new List<string>
//        {
//            "09:00 AM",
//            "10:00 AM"
//        };

//        _doctorRepositoryMock
//            .Setup(r => r.GetSlots(1))
//            .ReturnsAsync(slots);

//        var result = await _service.GetSlots(1);

//        Assert.Equal(2, result.Count);
//    }

//    [Fact]
//    public async Task GetSlots_ShouldThrow_WhenNoSlotsExist()
//    {
//        _doctorRepositoryMock
//            .Setup(r => r.GetSlots(1))
//            .ReturnsAsync(new List<string>());

//        await Assert.ThrowsAsync<InvalidOperationException>(
//            () => _service.GetSlots(1));
//    }

//    [Fact]
//    public async Task CreateSlots_ShouldCallRepository()
//    {
//        var slots = new List<string>
//        {
//            "09:00 AM",
//            "10:00 AM"
//        };

//        await _service.CreateSlots(1, slots);

//        _doctorRepositoryMock.Verify(
//            r => r.CreateSlots(1, slots),
//            Times.Once);
//    }

//    [Fact]
//    public async Task AvailableDoctors_ShouldReturnDoctors()
//    {
//        var doctors = new List<DoctorListDto>
//        {
//            new()
//        };

//        _doctorRepositoryMock
//            .Setup(r => r.AvailableDoctors(
//                "Cardiology",
//                It.IsAny<DateOnly>()))
//            .ReturnsAsync(doctors);

//        var result = await _service.AvailableDoctors(
//            "Cardiology",
//            DateOnly.FromDateTime(DateTime.Today));

//        Assert.Single(result);
//    }

//    [Fact]
//    public async Task GetSummaryAsync_ShouldReturnSummary()
//    {
//        var summary = new DoctorSummaryDto
//        {
//            TotalDoctors = 5
//        };

//        _doctorRepositoryMock
//            .Setup(r => r.GetSummaryAsync())
//            .ReturnsAsync(summary);

//        var result = await _service.GetSummaryAsync();

//        Assert.Equal(5, result.TotalDoctors);
//    }

//    [Fact]
//    public async Task CreateLeave_ShouldSkipDuplicateLeaveDates()
//    {
//        var existingLeaves = new List<DoctorLeaves>
//        {
//            new()
//            {
//                LeaveDate = DateOnly.FromDateTime(DateTime.Today)
//            }
//        };

//        _doctorRepositoryMock
//            .Setup(r => r.GetLeavesByDoctorId(1))
//            .ReturnsAsync(existingLeaves);

//        var leaveDate = DateOnly.FromDateTime(DateTime.Today);

//        var result = await _service.CreateLeave(
//            1,
//            new List<CreateLeaveDto>
//            {
//                new()
//                {
//                    LeaveDate = leaveDate
//                }
//            });

//        Assert.Contains(
//            leaveDate,
//            result.SkippedDates);
//    }
//}