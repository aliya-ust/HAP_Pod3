using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.Exceptions;
using HealthCare.Shared.DTOs;
using HealthCare.Shared.DTOs.Doctor;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace HealthCare.Api.Tests
{
    public class DoctorServiceTests
    {
        private readonly Mock<IDoctorRepository> _repoMock;
        private readonly Mock<IAppointmentRepository> _appointmentRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<UserManager<User>> _userManagerMock;
        private readonly HealthCareDbContext _context;
        private readonly DoctorService _service;

        public DoctorServiceTests()
        {
            _repoMock = new Mock<IDoctorRepository>();
            _appointmentRepoMock = new Mock<IAppointmentRepository>();
            _mapperMock = new Mock<IMapper>();

            _userManagerMock = new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);

            var options = new DbContextOptionsBuilder<HealthCareDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new HealthCareDbContext(options);

            _service = new DoctorService(
                _repoMock.Object,
                _appointmentRepoMock.Object,
                _context,
                _mapperMock.Object,
                _userManagerMock.Object
            );
        }

        //  GetById
        [Fact]
        public async Task GetByIdAsync_ShouldReturnDoctor()
        {
            var doctor = new Doctor();
            var dto = new DoctorListDto();

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(doctor);
            _mapperMock.Setup(m => m.Map<DoctorListDto>(doctor)).Returns(dto);

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldThrow_WhenNotFound()
        {
            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Doctor?)null);

            await Assert.ThrowsAsync<DoctorNotFoundException>(() => _service.GetByIdAsync(1));
        }

        //  GetAll
        [Fact]
        public async Task GetAllAsync_ShouldReturnPagedResult()
        {
            _context.Set<Doctor>().Add(new Doctor
            {
                FullName = "Test Doctor",
                Specialisation = "Cardiology"
            });
            await _context.SaveChangesAsync();

            _repoMock.Setup(r => r.GetQueryable())
                .Returns(_context.Set<Doctor>());

            _mapperMock.Setup(m => m.Map<IEnumerable<DoctorListDto>>(It.IsAny<IEnumerable<Doctor>>()))
                .Returns(new List<DoctorListDto> { new DoctorListDto() });

            var result = await _service.GetAllAsync(new DoctorFilter());

            Assert.Equal(1, result.TotalCount);
        }

        //  AddAsync
        [Fact]
        public async Task AddAsync_ShouldCreateDoctorAndSlots()
        {
            var dto = new CreateDoctorDto
            {
                TimeSlots = new List<string> { "09:00-10:00" }
            };

            var doctor = new Doctor { DoctorId = 1 };

            _mapperMock.Setup(m => m.Map<Doctor>(dto)).Returns(doctor);

            await _service.AddAsync(dto);

            _repoMock.Verify(r => r.AddAsync(doctor), Times.Once);
            _repoMock.Verify(r => r.CreateSlots(doctor.DoctorId, dto.TimeSlots), Times.Once);
        }

        //  UpdateAsync
        [Fact]
        public async Task UpdateAsync_ShouldUpdateDoctor()
        {
            var doctor = new Doctor();

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(doctor);

            await _service.UpdateAsync(1, new UpdateDoctorDto());

            _repoMock.Verify(r => r.UpdateAsync(doctor), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrow_WhenNotFound()
        {
            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Doctor?)null);

            await Assert.ThrowsAsync<DoctorNotFoundException>(() => _service.UpdateAsync(1, new UpdateDoctorDto()));
        }

        //  UpdateStatus
        [Fact]
        public async Task UpdateStatusAsync_ShouldChangeStatus()
        {
            var doctor = new Doctor { IsActive = true };

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(doctor);

            await _service.UpdateStatusAsync(1, false);

            Assert.False(doctor.IsActive);
        }

        //  Delete
        [Fact]
        public async Task DeleteAsync_ShouldDeleteDoctor()
        {
            var doctor = new Doctor();

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(doctor);

            await _service.DeleteAsync(1);

            _repoMock.Verify(r => r.DeleteAsync(1), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrow_WhenNotFound()
        {
            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Doctor?)null);

            await Assert.ThrowsAsync<DoctorNotFoundException>(() => _service.DeleteAsync(1));
        }

        //  GetSlots
        [Fact]
        public async Task GetSlots_ShouldReturnSlots()
        {
            _repoMock.Setup(r => r.GetSlots(1))
                .ReturnsAsync(new List<string> { "09:00-10:00" });

            var result = await _service.GetSlots(1);

            Assert.Single(result);
        }

        [Fact]
        public async Task GetSlots_ShouldThrow_WhenEmpty()
        {
            _repoMock.Setup(r => r.GetSlots(1))
                .ReturnsAsync(new List<string>());

            await Assert.ThrowsAsync<NoAvailableSlotsException>(() => _service.GetSlots(1));
        }

        //  CreateSlots
        [Fact]
        public async Task CreateSlots_ShouldCallRepository()
        {
            await _service.CreateSlots(1, new List<string> { "09:00-10:00" });

            _repoMock.Verify(r => r.CreateSlots(1, It.IsAny<List<string>>()), Times.Once);
        }

        //  CreateLeave - skip duplicate
        [Fact]
        public async Task CreateLeave_ShouldSkipExistingLeave()
        {
            _repoMock.Setup(r => r.GetLeavesByDoctorId(1))
                .ReturnsAsync(new List<DoctorLeaves>
                {
                    new DoctorLeaves { LeaveDate = new DateOnly(2026,7,1) }
                });

            var result = await _service.CreateLeave(1,
                new List<CreateLeaveDto>
                {
                    new CreateLeaveDto { LeaveDate = new DateOnly(2026,7,1) }
                });

            Assert.Single(result.SkippedDates);
        }

        //  CreateLeave - cancel appointments when conflict
        [Fact]
        public async Task CreateLeave_ShouldCancelAppointments_WhenSlotsMismatch()
        {
            _repoMock.Setup(r => r.GetLeavesByDoctorId(1))
                .ReturnsAsync(new List<DoctorLeaves>());

            _repoMock.Setup(r => r.GetSlots(1))
                .ReturnsAsync(new List<string> { "09:00-10:00", "10:00-11:00" });

            _appointmentRepoMock.Setup(r => r.BookedTimeSlots(It.IsAny<DateOnly>(), 1))
                .ReturnsAsync(new List<string> { "09:00-10:00" });

            var leaves = new List<CreateLeaveDto>
            {
                new CreateLeaveDto { LeaveDate = new DateOnly(2026,7,2) }
            };

            var result = await _service.CreateLeave(1, leaves);

            _appointmentRepoMock.Verify(r =>
                r.CancelAppointmentsByDoctorDate(1, It.IsAny<DateOnly>()),
                Times.Once);

            Assert.Single(result.CreatedWithCancelledAppointments);
        }

        //  AvailableDoctors
        [Fact]
        public async Task AvailableDoctors_ShouldReturnDoctors()
        {
            _repoMock.Setup(r =>
                r.AvailableDoctors("Cardiology", It.IsAny<DateOnly>()))
                .ReturnsAsync(new List<DoctorListDto>
                {
                    new DoctorListDto()
                });

            var result = await _service.AvailableDoctors("Cardiology", DateOnly.FromDateTime(DateTime.Today));

            Assert.NotEmpty(result);
        }
    }
}