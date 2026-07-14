using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Auth;
using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Implementation;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace HealthCare.Tests.Services
{
    public class AuthServiceTests
    {
        private readonly Mock<UserManager<User>> _userManager;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IPatientRepository> _patientRepo;
        private readonly Mock<IDoctorRepository> _doctorRepo;
        private readonly Mock<IJwtService> _jwtService;
        private readonly HealthCareDbContext _context;
        private readonly AuthService _service;
        private readonly Mock<ILogger<AuthService>> _loggerMock;
        private readonly Mock<IDoctorAvailabilityCacheService> _doctorCacheMock;

        public AuthServiceTests()
        {
            var store = new Mock<IUserStore<User>>();

            _userManager = new Mock<UserManager<User>>(
                store.Object,
                null!,
                null!,
                null!,
                null!,
                null!,
                null!,
                null!,
                null!);

            _mapper = new Mock<IMapper>();
            _patientRepo = new Mock<IPatientRepository>();
            _doctorRepo = new Mock<IDoctorRepository>();
            _jwtService = new Mock<IJwtService>();

            var options = new DbContextOptionsBuilder<HealthCareDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new HealthCareDbContext(options);

            _loggerMock = new Mock<ILogger<AuthService>>();
            _doctorCacheMock = new Mock<IDoctorAvailabilityCacheService>();

            _service = new AuthService(
                _userManager.Object,
                _mapper.Object,
                _patientRepo.Object,
                _doctorRepo.Object,
                _jwtService.Object,
                _context,
                _loggerMock.Object,
                _doctorCacheMock.Object);
        }

        [Fact]
        public async Task RegisterPatientAsync_ShouldRegisterPatientSuccessfully()
        {
            var dto = new CreatePatientDto { Email = "a@test.com", Password = "Password@123" };

            _userManager.Setup(x => x.FindByEmailAsync(dto.Email)).ReturnsAsync((User)null!);
            _userManager.Setup(x => x.CreateAsync(It.IsAny<User>(), dto.Password)).ReturnsAsync(IdentityResult.Success);
            _userManager.Setup(x => x.AddToRoleAsync(It.IsAny<User>(), "Patient")).ReturnsAsync(IdentityResult.Success);
            _mapper.Setup(x => x.Map<Patient>(dto)).Returns(new Patient());

            await _service.RegisterPatientAsync(dto);

            _patientRepo.Verify(x => x.AddAsync(It.IsAny<Patient>()), Times.Once);
        }

        [Fact]
        public async Task RegisterPatientAsync_ShouldThrow_WhenEmailExists()
        {
            var dto = new CreatePatientDto { Email = "a@test.com", Password = "123" };

            _userManager.Setup(x => x.FindByEmailAsync(dto.Email))
                .ReturnsAsync(new User());

            await Assert.ThrowsAsync<InvalidOperationException>(() => _service.RegisterPatientAsync(dto));
        }

        [Fact]
        public async Task RegisterDoctorAsync_ShouldRegisterDoctorSuccessfully()
        {
            var dto = new CreateDoctorDto
            {
                Email = "doctor@test.com",
                Password = "Password@123",
                TimeSlots = new List<string>()
            };

            _userManager.Setup(x => x.FindByEmailAsync(dto.Email))
                .ReturnsAsync((User)null!);

            _userManager.Setup(x => x.CreateAsync(It.IsAny<User>(), dto.Password))
                .ReturnsAsync(IdentityResult.Success);

            _userManager.Setup(x => x.AddToRoleAsync(It.IsAny<User>(), "Doctor"))
                .ReturnsAsync(IdentityResult.Success);

            var doctor = new Doctor
            {
                DoctorId = 1,
                Specialisation = "Cardiology"
            };

            _mapper.Setup(x => x.Map<Doctor>(dto))
                .Returns(doctor);

            await _service.RegisterDoctorAsync(dto);

            _doctorRepo.Verify(x =>
                x.AddAsync(It.IsAny<Doctor>()),
                Times.Once);

            _doctorRepo.Verify(x =>
                x.CreateSlots(doctor.DoctorId, dto.TimeSlots),
                Times.Once);

            _doctorCacheMock.Verify(x =>
                x.RefreshSpecializationAsync("Cardiology"),
                Times.Once);
        }

        [Fact]
        public async Task RegisterDoctorAsync_ShouldThrow_WhenEmailAlreadyExists()
        {
            var dto = new CreateDoctorDto { Email = "doctor@test.com", Password = "123" };

            _userManager.Setup(x => x.FindByEmailAsync(dto.Email))
                .ReturnsAsync(new User());

            await Assert.ThrowsAsync<InvalidOperationException>(() => _service.RegisterDoctorAsync(dto));
        }

        [Fact]
        public async Task LoginAsync_ShouldReturnToken_ForPatient()
        {
            var dto = new LoginDto { Email = "patient@test.com", Password = "123" };

            var user = new User { Id = "1", Email = dto.Email };

            _userManager.Setup(x => x.FindByEmailAsync(dto.Email)).ReturnsAsync(user);
            _userManager.Setup(x => x.CheckPasswordAsync(user, dto.Password)).ReturnsAsync(true);
            _userManager.Setup(x => x.GetRolesAsync(user)).ReturnsAsync(new List<string> { "Patient" });

            _patientRepo.Setup(x => x.GetByUserIdAsync("1"))
                .ReturnsAsync(new Patient { PatientId = 10 });

            _jwtService.Setup(x => x.GenerateToken(user, 10, null))
                .ReturnsAsync("token");

            var result = await _service.LoginAsync(dto);

            Assert.Equal("token", result.AccessToken);
            Assert.Equal("Patient", result.Role);
        }

        [Fact]
        public async Task LoginAsync_ShouldReturnToken_ForDoctor()
        {
            var dto = new LoginDto { Email = "doctor@test.com", Password = "123" };

            var user = new User { Id = "2" };

            _userManager.Setup(x => x.FindByEmailAsync(dto.Email)).ReturnsAsync(user);
            _userManager.Setup(x => x.CheckPasswordAsync(user, dto.Password)).ReturnsAsync(true);
            _userManager.Setup(x => x.GetRolesAsync(user)).ReturnsAsync(new List<string> { "Doctor" });

            _doctorRepo.Setup(x => x.GetByUserIdAsync("2"))
                .ReturnsAsync(new Doctor { DoctorId = 20 });

            _jwtService.Setup(x => x.GenerateToken(user, null, 20))
                .ReturnsAsync("doctorToken");

            var result = await _service.LoginAsync(dto);

            Assert.Equal("Doctor", result.Role);
        }

        [Fact]
        public async Task LoginAsync_ShouldReturnToken_ForAdmin()
        {
            var dto = new LoginDto { Email = "admin@test.com", Password = "123" };

            var user = new User();

            _userManager.Setup(x => x.FindByEmailAsync(dto.Email)).ReturnsAsync(user);
            _userManager.Setup(x => x.CheckPasswordAsync(user, dto.Password)).ReturnsAsync(true);
            _userManager.Setup(x => x.GetRolesAsync(user)).ReturnsAsync(new List<string> { "Admin" });

            _jwtService.Setup(x => x.GenerateToken(user, null, null))
                .ReturnsAsync("adminToken");

            var result = await _service.LoginAsync(dto);

            Assert.Equal("Admin", result.Role);
        }

        [Fact]
        public async Task LoginAsync_ShouldThrow_WhenUserNotFound()
        {
            var dto = new LoginDto { Email = "abc@test.com", Password = "123" };

            _userManager.Setup(x => x.FindByEmailAsync(dto.Email))
                .ReturnsAsync((User)null!);

            await Assert.ThrowsAsync<UnauthorizedAccessException>(() => _service.LoginAsync(dto));
        }

        [Fact]
        public async Task LoginAsync_ShouldThrow_WhenPasswordInvalid()
        {
            var user = new User();

            _userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(user);

            _userManager.Setup(x => x.CheckPasswordAsync(user, It.IsAny<string>()))
                .ReturnsAsync(false);

            await Assert.ThrowsAsync<UnauthorizedAccessException>(() => _service.LoginAsync(new LoginDto()));
        }

        [Fact]
        public async Task LoginAsync_ShouldThrow_WhenRoleMissing()
        {
            var user = new User();

            _userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(user);

            _userManager.Setup(x => x.CheckPasswordAsync(user, It.IsAny<string>()))
                .ReturnsAsync(true);

            _userManager.Setup(x => x.GetRolesAsync(user))
                .ReturnsAsync(new List<string>());

            await Assert.ThrowsAsync<InvalidOperationException>(() => _service.LoginAsync(new LoginDto()));
        }

        [Fact]
        public async Task LoginAsync_ShouldThrow_WhenPatientProfileMissing()
        {
            var user = new User { Id = "1" };

            _userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManager.Setup(x => x.CheckPasswordAsync(user, It.IsAny<string>())).ReturnsAsync(true);
            _userManager.Setup(x => x.GetRolesAsync(user)).ReturnsAsync(new List<string> { "Patient" });

            _patientRepo.Setup(x => x.GetByUserIdAsync("1"))
                .ReturnsAsync((Patient)null!);

            await Assert.ThrowsAsync<InvalidOperationException>(() => _service.LoginAsync(new LoginDto()));
        }

        [Fact]
        public async Task LoginAsync_ShouldThrow_WhenDoctorProfileMissing()
        {
            var user = new User { Id = "2" };

            _userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(user);
            _userManager.Setup(x => x.CheckPasswordAsync(user, It.IsAny<string>())).ReturnsAsync(true);
            _userManager.Setup(x => x.GetRolesAsync(user)).ReturnsAsync(new List<string> { "Doctor" });

            _doctorRepo.Setup(x => x.GetByUserIdAsync("2"))
                .ReturnsAsync((Doctor)null!);

            await Assert.ThrowsAsync<InvalidOperationException>(() => _service.LoginAsync(new LoginDto()));
        }

        [Fact]
        public async Task ChangePasswordAsync_ShouldChangePasswordSuccessfully()
        {
            var user = new User { Id = "1" };

            var dto = new ChangePasswordDto
            {
                CurrentPassword = "Old@123",
                NewPassword = "New@123"
            };

            _userManager.Setup(x => x.FindByIdAsync("1")).ReturnsAsync(user);

            _userManager.Setup(x => x.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword))
                .ReturnsAsync(IdentityResult.Success);

            await _service.ChangePasswordAsync("1", dto);

            Assert.True(true);
        }

        [Fact]
        public async Task ChangePasswordAsync_ShouldThrow_WhenUserNotFound()
        {
            _userManager.Setup(x => x.FindByIdAsync("1"))
                .ReturnsAsync((User)null!);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.ChangePasswordAsync("1", new ChangePasswordDto()));
        }

        [Fact]
        public async Task ChangePasswordAsync_ShouldThrow_WhenPasswordChangeFails()
        {
            var user = new User { Id = "1" };

            _userManager.Setup(x => x.FindByIdAsync("1"))
                .ReturnsAsync(user);

            _userManager.Setup(x => x.ChangePasswordAsync(user, It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError
                {
                    Description = "Password change failed"
                }));

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.ChangePasswordAsync("1", new ChangePasswordDto()));
        }

        [Fact]
        public async Task RegisterDoctorAsync_ShouldThrow_WhenIdentityCreateFails()
        {
            // Arrange
            var dto = new CreateDoctorDto
            {
                Email = "doctor@test.com",
                Password = "Password@123",
                TimeSlots = new List<string>()
            };

            _userManager.Setup(x => x.FindByEmailAsync(dto.Email))
                .ReturnsAsync((User)null!);

            _userManager.Setup(x => x.CreateAsync(It.IsAny<User>(), dto.Password))
                .ReturnsAsync(IdentityResult.Failed(
                    new IdentityError
                    {
                        Description = "Password is too weak"
                    }));

            // Act & Assert
            var ex = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.RegisterDoctorAsync(dto));

            Assert.Equal("Password is too weak", ex.Message);

            _doctorRepo.Verify(x => x.AddAsync(It.IsAny<Doctor>()), Times.Never);
            _doctorRepo.Verify(x => x.CreateSlots(It.IsAny<int>(), It.IsAny<List<string>>()), Times.Never);
            _doctorCacheMock.Verify(x => x.RefreshSpecializationAsync(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task RegisterPatientAsync_ShouldThrow_WhenIdentityCreateFails()
        {
            // Arrange
            var dto = new CreatePatientDto
            {
                Email = "patient@test.com",
                Password = "Password@123"
            };

            _userManager.Setup(x => x.FindByEmailAsync(dto.Email))
                .ReturnsAsync((User)null!);

            _userManager.Setup(x => x.CreateAsync(It.IsAny<User>(), dto.Password))
                .ReturnsAsync(IdentityResult.Failed(
                    new IdentityError
                    {
                        Description = "Password is too weak"
                    }));

            // Act & Assert
            var ex = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.RegisterPatientAsync(dto));

            Assert.Equal("Password is too weak", ex.Message);

            _patientRepo.Verify(x => x.AddAsync(It.IsAny<Patient>()), Times.Never);
        }
    }
}