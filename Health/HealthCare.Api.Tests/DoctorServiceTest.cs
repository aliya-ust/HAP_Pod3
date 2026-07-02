using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace HealthCare.Tests.Services
{
    public class DoctorServiceTests
    {
        private readonly Mock<IDoctorRepository> _doctorRepo = new();
        private readonly Mock<IAppointmentRepository> _appointmentRepo = new();
        private readonly Mock<IMapper> _mapper = new();

        private readonly HealthCareDbContext _context;
        private readonly DoctorService _service;

        public DoctorServiceTests()
        {
            var options = new DbContextOptionsBuilder<HealthCareDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new HealthCareDbContext(options);

            _service = new DoctorService(
                _doctorRepo.Object,
                _context,
                _mapper.Object,
                _appointmentRepo.Object);
        }

        [Fact]
        public async Task AddAsync_Should_Add_Doctor()
        {
            var dto = new CreateDoctorDto
            {
                FullName = "John",
                TimeSlots = new List<string> { "09:00" }
            };

            var doctor = new Doctor { DoctorId = 1 };

            _mapper.Setup(x => x.Map<Doctor>(dto)).Returns(doctor);

            await _service.AddAsync(dto);

            _doctorRepo.Verify(x => x.AddAsync(It.IsAny<Doctor>()), Times.Once);
            _doctorRepo.Verify(x => x.CreateSlots(doctor.DoctorId, dto.TimeSlots), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_Should_Update_Doctor()
        {
            var doctor = new Doctor { DoctorId = 1 };

            _doctorRepo.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(doctor);

            var dto = new UpdateDoctorDto();

            await _service.UpdateAsync(1, dto);

            _doctorRepo.Verify(x => x.UpdateAsync(doctor), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_Should_Throw_When_Doctor_NotFound()
        {
            _doctorRepo.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync((Doctor)null);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.UpdateAsync(1, new UpdateDoctorDto()));
        }


        [Fact]
        public async Task UpdateStatusAsync_Should_Update_Status()
        {
            var doctor = new Doctor { DoctorId = 1 };

            _doctorRepo.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(doctor);

            await _service.UpdateStatusAsync(1, true);

            Assert.True(doctor.IsActive);

            _doctorRepo.Verify(x => x.UpdateAsync(doctor), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_Should_Delete_Doctor()
        {
            _doctorRepo.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(new Doctor());

            await _service.DeleteAsync(1);

            _doctorRepo.Verify(x => x.DeleteAsync(1), Times.Once);
        }


        [Fact]
        public async Task DeleteAsync_Should_Throw_When_Doctor_NotFound()
        {
            _doctorRepo.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync((Doctor)null);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.DeleteAsync(1));
        }


        [Fact]
        public async Task GetSlots_Should_Return_Slots()
        {
            _doctorRepo.Setup(x => x.GetSlots(1))
                .ReturnsAsync(new List<string>
                {
                    "09:00",
                    "09:30"
                });

            var result = await _service.GetSlots(1);

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetSlots_Should_Throw_When_NoSlots()
        {
            _doctorRepo.Setup(x => x.GetSlots(1))
                .ReturnsAsync(new List<string>());

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.GetSlots(1));
        }


        [Fact]
        public async Task AvailableTimeSlotsCheck_Should_Return_Unbooked_Slots()
        {
            var date = DateOnly.FromDateTime(DateTime.Today);

            _doctorRepo.Setup(x => x.GetSlots(1))
                .ReturnsAsync(new List<string>
                {
                    "09:00",
                    "09:30",
                    "10:00"
                });

            _appointmentRepo.Setup(x => x.BookedTimeSlots(date, 1))
                .ReturnsAsync(new List<string>
                {
                    "09:30"
                });

            var result = await _service.AvailableTimeSlotsCheck(date, 1);

            Assert.Equal(2, result.Count);
            Assert.DoesNotContain("09:30", result);
        }


        [Fact]
        public async Task AvailableDoctors_Should_Return_Doctors()
        {
            var doctors = new List<DoctorListDto>
            {
                new DoctorListDto
                {
                    DoctorId = 1,
                    FullName = "John"
                }
            };

            var date = DateOnly.FromDateTime(DateTime.Today);

            _doctorRepo.Setup(x =>
                    x.AvailableDoctors("Cardiology", date))
                .ReturnsAsync(doctors);

            var result = await _service.AvailableDoctors("Cardiology", date);

            Assert.Single(result);
            Assert.Equal("John", result[0].FullName);
        }
    }
}