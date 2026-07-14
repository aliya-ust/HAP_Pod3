using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Moq;
using Microsoft.Extensions.Logging;
using HealthCare.Api.Services.Interfaces;
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
        private readonly Mock<ILogger<DoctorService>> _logger = new();
        private readonly Mock<IDoctorAvailabilityCacheService> _doctorCache = new();

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
                        _appointmentRepo.Object,
                        _logger.Object,
                        _doctorCache.Object);
        }

        //[Fact]
        //public async Task AddAsync_Should_Add_Doctor()
        //{
        //    var dto = new CreateDoctorDto
        //    {
        //        FullName = "John",
        //        Specialisation = "Cardiology",
        //        TimeSlots = new List<string> { "09:00" }
        //    };

        //    var doctor = new Doctor
        //    {
        //        DoctorId = 1,
        //        Specialisation = "Cardiology"
        //    };

        //    _mapper.Setup(x => x.Map<Doctor>(dto))
        //        .Returns(doctor);

        //    await _service.AddAsync(dto);

        //    _doctorRepo.Verify(x =>
        //        x.AddAsync(It.IsAny<Doctor>()), Times.Once);

        //    _doctorRepo.Verify(x =>
        //        x.CreateSlots(1, dto.TimeSlots), Times.Once);

        //    _doctorCache.Verify(x =>
        //        x.RefreshSpecializationAsync("Cardiology"),
        //        Times.Once);
        //}

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
        public async Task UpdateStatusAsync_Should_Throw_When_Doctor_NotFound()
        {
            _doctorRepo.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync((Doctor)null!);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.UpdateStatusAsync(1, true));
        }


        [Fact]
        public async Task UpdateStatusAsync_Should_Update_Status()
        {
            var doctor = new Doctor
            {
                DoctorId = 1,
                Specialisation = "Cardiology"
            };

            _doctorRepo.Setup(x =>
                x.GetByIdAsync(1))
                .ReturnsAsync(doctor);

            await _service.UpdateStatusAsync(1, true);

            Assert.True(doctor.IsActive);

            _doctorRepo.Verify(x =>
                x.UpdateAsync(doctor),
                Times.Once);

            _doctorCache.Verify(x =>
                x.RefreshSpecializationAsync("Cardiology"),
                Times.Once);
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
                .ReturnsAsync((Doctor)null!);

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

            _doctorCache.Setup(x =>
                x.GetAsync("Cardiology", date))
                .ReturnsAsync((List<DoctorListDto>)null!);

            _doctorRepo.Setup(x =>
                x.AvailableDoctors("Cardiology", date))
                .ReturnsAsync(doctors);

            var result = await _service.AvailableDoctors("Cardiology", date);

            Assert.Single(result);

            _doctorCache.Verify(x =>
                x.SetAsync("Cardiology", date, doctors),
                Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_Should_Throw_When_NotFound()
        {
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.GetByIdAsync(100));
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_All_Doctors()
        {
            _context.Doctors.AddRange(
                new Doctor
                {
                    DoctorId = 1,
                    FullName = "John",
                    Specialisation = "Cardiology",
                    YearsOfExperience = 5
                },
                new Doctor
                {
                    DoctorId = 2,
                    FullName = "David",
                    Specialisation = "Neurology",
                    YearsOfExperience = 8
                });

            await _context.SaveChangesAsync();

            _mapper.Setup(x =>
                x.Map<IEnumerable<DoctorListDto>>(It.IsAny<IEnumerable<Doctor>>()))
                .Returns(new List<DoctorListDto>
                {
            new(),
            new()
                });

            var result = await _service.GetAllAsync(new DoctorFilter());

            Assert.Equal(2, result.TotalCount);
        }

        [Fact]
        public async Task GetAllAsync_Should_Filter_By_Name()
        {
            _context.Doctors.Add(new Doctor
            {
                DoctorId = 1,
                FullName = "John",
                Specialisation = "Cardiology"
            });

            await _context.SaveChangesAsync();

            _mapper.Setup(x =>
                x.Map<IEnumerable<DoctorListDto>>(It.IsAny<IEnumerable<Doctor>>()))
                .Returns(new List<DoctorListDto>
                {
            new()
                });

            var result = await _service.GetAllAsync(new DoctorFilter
            {
                FullName = "John"
            });

            Assert.Single(result.Items);
        }

        [Fact]
        public async Task GetAllAsync_Should_Filter_By_Specialisation()
        {
            _context.Doctors.Add(new Doctor
            {
                DoctorId = 1,
                FullName = "John",
                Specialisation = "Cardiology"
            });

            await _context.SaveChangesAsync();

            _mapper.Setup(x =>
                x.Map<IEnumerable<DoctorListDto>>(It.IsAny<IEnumerable<Doctor>>()))
                .Returns(new List<DoctorListDto>
                {
            new()
                });

            var result = await _service.GetAllAsync(new DoctorFilter
            {
                Specialisation = "Cardiology"
            });

            Assert.Single(result.Items);
        }

        [Fact]
        public async Task GetAllAsync_Should_Filter_Active_Doctors()
        {
            _context.Doctors.Add(new Doctor
            {
                DoctorId = 1,
                FullName = "John",
                IsActive = true
            });

            await _context.SaveChangesAsync();

            _mapper.Setup(x =>
                x.Map<IEnumerable<DoctorListDto>>(It.IsAny<IEnumerable<Doctor>>()))
                .Returns(new List<DoctorListDto>
                {
            new()
                });

            var result = await _service.GetAllAsync(new DoctorFilter
            {
                Status = "Active"
            });

            Assert.Single(result.Items);
        }

        [Fact]
        public async Task CreateSlots_Should_Call_Repository()
        {
            var slots = new List<string>
               {
            "09:00",
            "09:30"
               };

            await _service.CreateSlots(1, slots);

            _doctorRepo.Verify(x =>
                x.CreateSlots(1, slots),
                Times.Once);
        }

        [Fact]
        public async Task CreateLeave_Should_Skip_Existing_Date()
        {
            var date = DateOnly.FromDateTime(DateTime.Today);

            _doctorRepo.Setup(x =>
                x.GetLeavesByDoctorId(1))
                .ReturnsAsync(new List<DoctorLeaves>
                {
            new()
            {
                LeaveDate = date
            }
                });

            var result = await _service.CreateLeave(1,
                new List<CreateLeaveDto>
                {
            new()
            {
                LeaveDate = date
            }
                });

            Assert.Single(result.SkippedDates);
        }

        [Fact]
        public async Task CreateLeave_Should_Cancel_Appointments()
        {
            var date = DateOnly.FromDateTime(DateTime.Today);

            // Seed doctor into database
            _context.Doctors.Add(new Doctor
            {
                DoctorId = 1,
                FullName = "John",
                Specialisation = "Cardiology",
                ConsultationFee = 500,
                YearsOfExperience = 5,
                IsActive = true
            });

            await _context.SaveChangesAsync();

            _doctorRepo.Setup(x => x.GetLeavesByDoctorId(1))
                .ReturnsAsync(new List<DoctorLeaves>());

            _doctorRepo.Setup(x => x.GetSlots(1))
                .ReturnsAsync(new List<string>
                {
            "09:00",
            "10:00"
                });

            _appointmentRepo.Setup(x => x.BookedTimeSlots(date, 1))
                .ReturnsAsync(new List<string>
                {
            "09:00"
                });

            var leaves = new List<CreateLeaveDto>
    {
        new CreateLeaveDto
        {
            LeaveDate = date
        }
    };

            var result = await _service.CreateLeave(1, leaves);

            _appointmentRepo.Verify(x =>
                x.CancelAppointmentsByDoctorDate(1, date),
                Times.Once);

            _doctorRepo.Verify(x =>
                x.CreateLeaves(1, It.IsAny<List<CreateLeaveDto>>()),
                Times.Once);

            _doctorCache.Verify(x =>
                x.RefreshAsync("Cardiology", date),
                Times.Once);
        }

        [Fact]
        public async Task CreateLeave_Should_Create_Leave_When_No_Appointments()
        {
            var date = DateOnly.FromDateTime(DateTime.Today);

            // Seed doctor into database
            _context.Doctors.Add(new Doctor
            {
                DoctorId = 1,
                FullName = "John",
                Specialisation = "Cardiology",
                ConsultationFee = 500,
                YearsOfExperience = 5,
                IsActive = true
            });

            await _context.SaveChangesAsync();

            _doctorRepo.Setup(x => x.GetLeavesByDoctorId(1))
                .ReturnsAsync(new List<DoctorLeaves>());

            _doctorRepo.Setup(x => x.GetSlots(1))
                .ReturnsAsync(new List<string>
                {
            "09:00"
                });

            _appointmentRepo.Setup(x => x.BookedTimeSlots(date, 1))
                .ReturnsAsync(new List<string>());

            var leaves = new List<CreateLeaveDto>
    {
        new CreateLeaveDto
        {
            LeaveDate = date
        }
    };

            var result = await _service.CreateLeave(1, leaves);

            _doctorRepo.Verify(x =>
                x.CreateLeaves(1, It.IsAny<List<CreateLeaveDto>>()),
                Times.Once);

            _appointmentRepo.Verify(x =>
                x.CancelAppointmentsByDoctorDate(It.IsAny<int>(), It.IsAny<DateOnly>()),
                Times.Never);

            _doctorCache.Verify(x =>
                x.RefreshAsync("Cardiology", date),
                Times.Once);
        }

        [Fact]
        public async Task CreateLeave_Should_Not_Create_When_All_Dates_Exist()
        {
            var date = DateOnly.FromDateTime(DateTime.Today);

            _doctorRepo.Setup(x => x.GetLeavesByDoctorId(1))
                .ReturnsAsync(new List<DoctorLeaves>
                {
            new()
            {
                LeaveDate = date
            }
                });

            await _service.CreateLeave(1,
                new List<CreateLeaveDto>
                {
            new()
            {
                LeaveDate = date
            }
                });

            _doctorRepo.Verify(x =>
                x.CreateLeaves(It.IsAny<int>(),
                It.IsAny<List<CreateLeaveDto>>()),
                Times.Never);
        }

        [Fact]
        public async Task AvailableDoctors_Should_Return_FromCache()
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

            _doctorCache.Setup(x =>
                x.GetAsync("Cardiology", date))
                .ReturnsAsync(doctors);

            var result = await _service.AvailableDoctors("Cardiology", date);

            Assert.Single(result);

            _doctorRepo.Verify(x =>
                x.AvailableDoctors(It.IsAny<string>(), It.IsAny<DateOnly>()),
                Times.Never);
        }
    }
}