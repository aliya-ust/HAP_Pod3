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
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System.Text;
using System.Text.Json;

namespace HealthCare.Api.Tests
{
    public class DoctorServiceTests
    {
        private readonly Mock<IDoctorRepository> _repoMock;
        private readonly Mock<IAppointmentRepository> _appointmentRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<UserManager<User>> _userManagerMock;
        private readonly Mock<IDistributedCache> _cacheMock;
        private readonly Mock<ILogger<DoctorService>> _loggerMock;
        private readonly HealthCareDbContext _context;
        private readonly DoctorService _service;

        public DoctorServiceTests()
        {
            _repoMock = new Mock<IDoctorRepository>();
            _appointmentRepoMock = new Mock<IAppointmentRepository>();
            _mapperMock = new Mock<IMapper>();
            _cacheMock = new Mock<IDistributedCache>();
            _loggerMock = new Mock<ILogger<DoctorService>>();

            _userManagerMock = new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(), null!, null!, null!, null!, null!, null!, null!, null!);

            var options = new DbContextOptionsBuilder<HealthCareDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new HealthCareDbContext(options);

            _service = new DoctorService(
                _repoMock.Object,
                _appointmentRepoMock.Object,
                _mapperMock.Object,
                _userManagerMock.Object,
                _cacheMock.Object,
                _loggerMock.Object,
                5
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

        [Fact]
        public async Task GetAllAsync_ShouldFilterBySearch()
        {
            _context.Set<Doctor>().AddRange(
                new Doctor { FullName = "Alice", Specialisation = "Cardiology", YearsOfExperience = 5, ConsultationFee = 200 },
                new Doctor { FullName = "Bob", Specialisation = "Neurology", YearsOfExperience = 10, ConsultationFee = 300 }
            );
            await _context.SaveChangesAsync();

            _repoMock.Setup(r => r.GetQueryable()).Returns(_context.Set<Doctor>());
            _mapperMock.Setup(m => m.Map<IEnumerable<DoctorListDto>>(It.IsAny<IEnumerable<Doctor>>()))
                .Returns(new List<DoctorListDto> { new DoctorListDto() });

            var result = await _service.GetAllAsync(new DoctorFilter { Search = "Alice" });

            Assert.Equal(1, result.TotalCount);
        }

        [Fact]
        public async Task GetAllAsync_ShouldFilterBySpecialisation()
        {
            _context.Set<Doctor>().AddRange(
                new Doctor { FullName = "Alice", Specialisation = "Cardiology", YearsOfExperience = 5, ConsultationFee = 200 },
                new Doctor { FullName = "Bob", Specialisation = "Neurology", YearsOfExperience = 10, ConsultationFee = 300 }
            );
            await _context.SaveChangesAsync();

            _repoMock.Setup(r => r.GetQueryable()).Returns(_context.Set<Doctor>());
            _mapperMock.Setup(m => m.Map<IEnumerable<DoctorListDto>>(It.IsAny<IEnumerable<Doctor>>()))
                .Returns(new List<DoctorListDto> { new DoctorListDto() });

            var result = await _service.GetAllAsync(new DoctorFilter { Specialisation = "Cardiology" });

            Assert.Equal(1, result.TotalCount);
        }

        [Fact]
        public async Task GetAllAsync_ShouldFilterByIsActive()
        {
            _context.Set<Doctor>().AddRange(
                new Doctor { FullName = "Alice", Specialisation = "Cardiology", YearsOfExperience = 5, ConsultationFee = 200, IsActive = true },
                new Doctor { FullName = "Bob", Specialisation = "Neurology", YearsOfExperience = 10, ConsultationFee = 300, IsActive = false }
            );
            await _context.SaveChangesAsync();

            _repoMock.Setup(r => r.GetQueryable()).Returns(_context.Set<Doctor>());
            _mapperMock.Setup(m => m.Map<IEnumerable<DoctorListDto>>(It.IsAny<IEnumerable<Doctor>>()))
                .Returns(new List<DoctorListDto> { new DoctorListDto() });

            var result = await _service.GetAllAsync(new DoctorFilter { IsActive = true });

            Assert.Equal(1, result.TotalCount);
        }

        [Fact]
        public async Task GetAllAsync_ShouldSortByExperience_Asc()
        {
            _context.Set<Doctor>().AddRange(
                new Doctor { FullName = "Alice", Specialisation = "Cardiology", YearsOfExperience = 5, ConsultationFee = 200 },
                new Doctor { FullName = "Bob", Specialisation = "Neurology", YearsOfExperience = 10, ConsultationFee = 300 }
            );
            await _context.SaveChangesAsync();

            _repoMock.Setup(r => r.GetQueryable()).Returns(_context.Set<Doctor>());
            _mapperMock.Setup(m => m.Map<IEnumerable<DoctorListDto>>(It.IsAny<IEnumerable<Doctor>>()))
                .Returns<IEnumerable<Doctor>>(doctors => doctors.Select(d => new DoctorListDto { FullName = d.FullName, YearsOfExperience = d.YearsOfExperience }).ToList());

            var result = await _service.GetAllAsync(new DoctorFilter { SortBy = "experience", IsDescending = false });

            var items = result.Items.ToList();
            Assert.Equal(2, items.Count);
            Assert.Equal("Alice", items[0].FullName);
        }

        [Fact]
        public async Task GetAllAsync_ShouldSortByExperience_Desc()
        {
            _context.Set<Doctor>().AddRange(
                new Doctor { FullName = "Alice", Specialisation = "Cardiology", YearsOfExperience = 5, ConsultationFee = 200 },
                new Doctor { FullName = "Bob", Specialisation = "Neurology", YearsOfExperience = 10, ConsultationFee = 300 }
            );
            await _context.SaveChangesAsync();

            _repoMock.Setup(r => r.GetQueryable()).Returns(_context.Set<Doctor>());
            _mapperMock.Setup(m => m.Map<IEnumerable<DoctorListDto>>(It.IsAny<IEnumerable<Doctor>>()))
                .Returns<IEnumerable<Doctor>>(doctors => doctors.Select(d => new DoctorListDto { FullName = d.FullName, YearsOfExperience = d.YearsOfExperience }).ToList());

            var result = await _service.GetAllAsync(new DoctorFilter { SortBy = "experience", IsDescending = true });

            var items = result.Items.ToList();
            Assert.Equal(2, items.Count);
            Assert.Equal("Bob", items[0].FullName);
        }

        [Fact]
        public async Task GetAllAsync_ShouldSortByFee_Asc()
        {
            _context.Set<Doctor>().AddRange(
                new Doctor { FullName = "Alice", Specialisation = "Cardiology", YearsOfExperience = 5, ConsultationFee = 300 },
                new Doctor { FullName = "Bob", Specialisation = "Neurology", YearsOfExperience = 10, ConsultationFee = 200 }
            );
            await _context.SaveChangesAsync();

            _repoMock.Setup(r => r.GetQueryable()).Returns(_context.Set<Doctor>());
            _mapperMock.Setup(m => m.Map<IEnumerable<DoctorListDto>>(It.IsAny<IEnumerable<Doctor>>()))
                .Returns<IEnumerable<Doctor>>(doctors => doctors.Select(d => new DoctorListDto { FullName = d.FullName, ConsultationFee = d.ConsultationFee }).ToList());

            var result = await _service.GetAllAsync(new DoctorFilter { SortBy = "fee", IsDescending = false });

            var items = result.Items.ToList();
            Assert.Equal(2, items.Count);
            Assert.Equal("Bob", items[0].FullName);
        }

        [Fact]
        public async Task GetAllAsync_ShouldSortByFee_Desc()
        {
            _context.Set<Doctor>().AddRange(
                new Doctor { FullName = "Alice", Specialisation = "Cardiology", YearsOfExperience = 5, ConsultationFee = 300 },
                new Doctor { FullName = "Bob", Specialisation = "Neurology", YearsOfExperience = 10, ConsultationFee = 200 }
            );
            await _context.SaveChangesAsync();

            _repoMock.Setup(r => r.GetQueryable()).Returns(_context.Set<Doctor>());
            _mapperMock.Setup(m => m.Map<IEnumerable<DoctorListDto>>(It.IsAny<IEnumerable<Doctor>>()))
                .Returns<IEnumerable<Doctor>>(doctors => doctors.Select(d => new DoctorListDto { FullName = d.FullName, ConsultationFee = d.ConsultationFee }).ToList());

            var result = await _service.GetAllAsync(new DoctorFilter { SortBy = "fee", IsDescending = true });

            var items = result.Items.ToList();
            Assert.Equal(2, items.Count);
            Assert.Equal("Alice", items[0].FullName);
        }

        [Fact]
        public async Task GetAllAsync_ShouldUseDefaultSort()
        {
            _context.Set<Doctor>().AddRange(
                new Doctor { FullName = "Alice", Specialisation = "Cardiology", YearsOfExperience = 5, ConsultationFee = 200 },
                new Doctor { FullName = "Bob", Specialisation = "Neurology", YearsOfExperience = 10, ConsultationFee = 300 }
            );
            await _context.SaveChangesAsync();

            _repoMock.Setup(r => r.GetQueryable()).Returns(_context.Set<Doctor>());
            _mapperMock.Setup(m => m.Map<IEnumerable<DoctorListDto>>(It.IsAny<IEnumerable<Doctor>>()))
                .Returns<IEnumerable<Doctor>>(doctors => doctors.Select(d => new DoctorListDto { FullName = d.FullName, YearsOfExperience = d.YearsOfExperience }).ToList());

            var result = await _service.GetAllAsync(new DoctorFilter());

            var items = result.Items.ToList();
            Assert.Equal(2, items.Count);
            Assert.Equal("Bob", items[0].FullName);
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
            _repoMock.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(new Doctor { Specialisation = "Cardiology" });

            await _service.CreateSlots(1, new List<string> { "09:00-10:00" });

            _repoMock.Verify(r => r.CreateSlots(1, It.IsAny<List<string>>()), Times.Once);
        }

        //  CreateLeave - skip duplicate
        [Fact]
        public async Task CreateLeave_ShouldSkipExistingLeave()
        {
            _repoMock.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(new Doctor { Specialisation = "Cardiology" });

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
            _repoMock.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(new Doctor { Specialisation = "Cardiology" });

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
            _cacheMock.Setup(c => c.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((byte[]?)null);

            _repoMock.Setup(r =>
                r.AvailableDoctors("Cardiology", It.IsAny<DateOnly>()))
                .ReturnsAsync(new List<DoctorListDto>
                {
                    new DoctorListDto()
                });

            var result = await _service.AvailableDoctors("Cardiology", DateOnly.FromDateTime(DateTime.Today));

            Assert.NotEmpty(result);
        }

        //  AvailableDoctors - cache hit
        [Fact]
        public async Task AvailableDoctors_ShouldReturnCachedData_WhenCacheHit()
        {
            var doctors = new List<DoctorListDto>
            {
                new DoctorListDto { FullName = "Dr. Cached", Specialisation = "Cardiology" }
            };
            var json = JsonSerializer.Serialize(doctors);

            _cacheMock.SetupSequence(c => c.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Encoding.UTF8.GetBytes("0"))
                .ReturnsAsync(Encoding.UTF8.GetBytes(json));

            var result = await _service.AvailableDoctors("Cardiology", DateOnly.FromDateTime(DateTime.Today));

            Assert.NotEmpty(result);
            Assert.Equal("Dr. Cached", result[0].FullName);
            _repoMock.Verify(r => r.AvailableDoctors(It.IsAny<string>(), It.IsAny<DateOnly>()), Times.Never);
        }

        //  AvailableDoctors - cache fallback
        [Fact]
        public async Task AvailableDoctors_ShouldFallbackToDatabase_WhenCacheFails()
        {
            _cacheMock.Setup(c => c.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Cache unavailable"));

            _repoMock.Setup(r => r.AvailableDoctors("Cardiology", It.IsAny<DateOnly>()))
                .ReturnsAsync(new List<DoctorListDto>
                {
                    new DoctorListDto { FullName = "Dr. Fallback" }
                });

            var result = await _service.AvailableDoctors("Cardiology", DateOnly.FromDateTime(DateTime.Today));

            Assert.NotEmpty(result);
            Assert.Equal("Dr. Fallback", result[0].FullName);
            _repoMock.Verify(r => r.AvailableDoctors("Cardiology", It.IsAny<DateOnly>()), Times.Once);
        }

        //  AvailableDoctors - empty
        [Fact]
        public async Task AvailableDoctors_ShouldReturnEmptyList_WhenNone()
        {
            _cacheMock.Setup(c => c.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((byte[]?)null);

            _repoMock.Setup(r => r.AvailableDoctors("Cardiology", It.IsAny<DateOnly>()))
                .ReturnsAsync(new List<DoctorListDto>());

            var result = await _service.AvailableDoctors("Cardiology", DateOnly.FromDateTime(DateTime.Today));

            Assert.Empty(result);
        }

        //  GetSummaryAsync
        [Fact]
        public async Task GetSummaryAsync_ShouldReturnSummary()
        {
            var summary = new DoctorSummaryDto
            {
                TotalDoctors = 10,
                ActiveDoctors = 7,
                InactiveDoctors = 3
            };

            _repoMock.Setup(r => r.GetSummaryAsync()).ReturnsAsync(summary);

            var result = await _service.GetSummaryAsync();

            Assert.Equal(10, result.TotalDoctors);
            Assert.Equal(7, result.ActiveDoctors);
            Assert.Equal(3, result.InactiveDoctors);
        }

        //  InvalidateDoctorCache
        [Fact]
        public async Task InvalidateDoctorCache_ShouldIncrementCacheVersion()
        {
            var doctor = new Doctor { Specialisation = "Cardiology" };

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(doctor);

            _cacheMock.Setup(c => c.GetAsync("cache_ver:Cardiology", It.IsAny<CancellationToken>()))
                .ReturnsAsync(Encoding.UTF8.GetBytes("5"));

            await _service.InvalidateDoctorCache(1);

            _cacheMock.Verify(c => c.SetAsync(
                "cache_ver:Cardiology",
                It.Is<byte[]>(b => Encoding.UTF8.GetString(b) == "6"),
                It.IsAny<DistributedCacheEntryOptions>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}