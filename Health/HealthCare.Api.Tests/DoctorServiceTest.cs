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
    public class DoctorServiceTest
    {
        private readonly Mock<IDoctorRepository> _doctorRepository;
        private readonly Mock<IAppointmentRepository> _appointmentRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<HealthCareDbContext> _context;
        private readonly DoctorService _service;

        public DoctorServiceTest()
        {
            _doctorRepository = new Mock<IDoctorRepository>();
            _appointmentRepository = new Mock<IAppointmentRepository>();
            _mapper = new Mock<IMapper>();

            var options = new DbContextOptions<HealthCareDbContext>();
            _context = new Mock<HealthCareDbContext>(options);

            _service = new DoctorService(
                _doctorRepository.Object,
                _context.Object,
                _mapper.Object,
                _appointmentRepository.Object);
        }

        // ================= GET BY ID =================

        [Fact]
        public async Task GetByIdAsync_ShouldReturnDoctor()
        {
            var doctor = new Doctor { DoctorId = 1 };
            var dto = new DoctorListDto();

            _doctorRepository.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(doctor);

            _mapper.Setup(x => x.Map<DoctorListDto?>(doctor))
                .Returns(dto);

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldThrow_WhenDoctorNotFound()
        {
            _doctorRepository.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync((Doctor?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.GetByIdAsync(1));
        }

        // ================= ADD =================

        [Fact]
        public async Task AddAsync_ShouldAddDoctor_AndCreateSlots()
        {
            var dto = new CreateDoctorDto
            {
                TimeSlots = new List<string> { "09:00", "10:00" }
            };

            var doctor = new Doctor { DoctorId = 5 };

            _mapper.Setup(x => x.Map<Doctor>(dto)).Returns(doctor);

            _doctorRepository.Setup(x => x.AddAsync(doctor))
                .Returns(Task.CompletedTask);

            _doctorRepository.Setup(x => x.CreateSlots(5, dto.TimeSlots))
                .Returns(Task.CompletedTask);

            await _service.AddAsync(dto);

            _doctorRepository.Verify(x => x.AddAsync(doctor), Times.Once);
            _doctorRepository.Verify(x => x.CreateSlots(5, dto.TimeSlots), Times.Once);
        }

        // ================= UPDATE =================

        [Fact]
        public async Task UpdateAsync_ShouldUpdateDoctor()
        {
            var doctor = new Doctor { DoctorId = 1 };
            var dto = new UpdateDoctorDto();

            _doctorRepository.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(doctor);

            await _service.UpdateAsync(1, dto);

            _mapper.Verify(x => x.Map(dto, doctor), Times.Once);
            _doctorRepository.Verify(x => x.UpdateAsync(doctor), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrow_WhenDoctorMissing()
        {
            _doctorRepository.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync((Doctor?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.UpdateAsync(1, new UpdateDoctorDto()));
        }

        [Fact]
        public async Task UpdateStatusAsync_ShouldUpdateStatus()
        {
            var doctor = new Doctor { DoctorId = 1, IsActive = false };

            _doctorRepository.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(doctor);

            await _service.UpdateStatusAsync(1, true);

            Assert.True(doctor.IsActive);
            _doctorRepository.Verify(x => x.UpdateAsync(doctor), Times.Once);
        }

        [Fact]
        public async Task UpdateStatus_ShouldAllowFalseToFalse()
        {
            var doctor = new Doctor { DoctorId = 1, IsActive = false };

            _doctorRepository.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(doctor);

            await _service.UpdateStatusAsync(1, false);

            Assert.False(doctor.IsActive);
        }

        // ================= DELETE =================

        [Fact]
        public async Task DeleteAsync_ShouldDeleteDoctor()
        {
            var doctor = new Doctor { DoctorId = 1 };

            _doctorRepository.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(doctor);

            await _service.DeleteAsync(1);

            _doctorRepository.Verify(x => x.DeleteAsync(1), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrow_WhenDoctorMissing()
        {
            _doctorRepository.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync((Doctor?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.DeleteAsync(1));
        }

        // ================= SLOTS =================

        [Fact]
        public async Task GetSlots_ShouldReturnSlots()
        {
            _doctorRepository.Setup(x => x.GetSlots(1))
                .ReturnsAsync(new List<string> { "09:00", "10:00" });

            var result = await _service.GetSlots(1);

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetSlots_ShouldThrow_WhenNoSlotsExist()
        {
            _doctorRepository.Setup(x => x.GetSlots(1))
                .ReturnsAsync(new List<string>());

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.GetSlots(1));
        }

        // ================= AVAILABILITY =================

        [Fact]
        public async Task AvailableTimeSlotsCheck_ShouldReturnOnlyAvailableSlots()
        {
            var date = new DateOnly(2025, 6, 20);

            _doctorRepository.Setup(x => x.GetSlots(1))
                .ReturnsAsync(new List<string> { "09:00", "10:00", "11:00" });

            _appointmentRepository.Setup(x => x.BookedTimeSlots(date, 1))
                .ReturnsAsync(new List<string> { "10:00" });

            var result = await _service.AvailableTimeSlotsCheck(date, 1);

            Assert.Equal(2, result.Count);
            Assert.DoesNotContain("10:00", result);
        }

        // ================= LEAVE =================

        [Fact]
        public async Task CreateLeave_ShouldSkipDuplicateDates()
        {
            var date = new DateOnly(2025, 6, 25);

            _doctorRepository.Setup(x => x.GetLeavesByDoctorId(1))
                .ReturnsAsync(new List<DoctorLeaves>
                {
                    new DoctorLeaves { LeaveDate = date }
                });

            var result = await _service.CreateLeave(
                1,
                new List<CreateLeaveDto>
                {
                    new CreateLeaveDto { LeaveDate = date }
                });

            Assert.Single(result.SkippedDates);
        }

        // ================= AVAILABLE DOCTORS =================

        [Fact]
        public async Task AvailableDoctors_ShouldReturnDoctors()
        {
            var doctors = new List<DoctorListDto>
            {
                new DoctorListDto(),
                new DoctorListDto()
            };

            _doctorRepository.Setup(x =>
                    x.AvailableDoctors("Cardiology", It.IsAny<DateOnly>()))
                .ReturnsAsync(doctors);

            var result = await _service.AvailableDoctors(
                "Cardiology",
                new DateOnly(2025, 6, 20));

            Assert.Equal(2, result.Count);
        }

        // ================= NEW SAFE TESTS =================

        [Fact]
        public async Task AddAsync_ShouldCallMapperAndRepository()
        {
            var dto = new CreateDoctorDto { TimeSlots = new List<string> { "09:00" } };
            var doctor = new Doctor { DoctorId = 10 };

            _mapper.Setup(x => x.Map<Doctor>(dto)).Returns(doctor);
            _doctorRepository.Setup(x => x.AddAsync(doctor)).Returns(Task.CompletedTask);
            _doctorRepository.Setup(x => x.CreateSlots(10, dto.TimeSlots)).Returns(Task.CompletedTask);

            await _service.AddAsync(dto);

            _mapper.Verify(x => x.Map<Doctor>(dto), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrow_WhenDoctorNotFound()
        {
            _doctorRepository.Setup(x => x.GetByIdAsync(99))
                .ReturnsAsync((Doctor?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.UpdateAsync(99, new UpdateDoctorDto()));
        }
    }
}