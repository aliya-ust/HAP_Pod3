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
using Moq;
using Xunit;

namespace HealthCare.Tests.Services
{
    public class AuthServiceTest
    {
        private readonly Mock<UserManager<User>> _userManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IPatientRepository> _patientRepositoryMock;
        private readonly Mock<IDoctorRepository> _doctorRepositoryMock;
        private readonly Mock<IJwtService> _jwtServiceMock;
        private readonly Mock<HealthCareDbContext> _contextMock;

        private readonly AuthService _service;

        public AuthServiceTest()
        {
            var store = new Mock<IUserStore<User>>();

            _userManagerMock = new Mock<UserManager<User>>(
                store.Object,
                null!, null!, null!, null!,
                null!, null!, null!, null!);

            _mapperMock = new Mock<IMapper>();
            _patientRepositoryMock = new Mock<IPatientRepository>();
            _doctorRepositoryMock = new Mock<IDoctorRepository>();
            _jwtServiceMock = new Mock<IJwtService>();

            var options = new DbContextOptions<HealthCareDbContext>();
            _contextMock = new Mock<HealthCareDbContext>(options);

            _service = new AuthService(
                _userManagerMock.Object,
                _mapperMock.Object,
                _patientRepositoryMock.Object,
                _doctorRepositoryMock.Object,
                _jwtServiceMock.Object,
                _contextMock.Object);
        }

        // ---------------- REGISTER PATIENT ----------------

        [Fact]
        public async Task RegisterPatientAsync_ShouldRegisterSuccessfully()
        {
            var dto = new CreatePatientDto
            {
                Email = "patient@test.com",
                Password = "Password123!"
            };

            var patient = new Patient();

            _userManagerMock.Setup(x => x.FindByEmailAsync(dto.Email))
                .ReturnsAsync((User)null!);

            _userManagerMock.Setup(x => x.CreateAsync(It.IsAny<User>(), dto.Password))
                .ReturnsAsync(IdentityResult.Success);

            _userManagerMock.Setup(x => x.AddToRoleAsync(It.IsAny<User>(), "Patient"))
                .ReturnsAsync(IdentityResult.Success);

            _mapperMock.Setup(x => x.Map<Patient>(dto))
                .Returns(patient);

            await _service.RegisterPatientAsync(dto);

            _patientRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Patient>()), Times.Once);
        }

        [Fact]
        public async Task RegisterPatientAsync_ShouldThrow_WhenEmailAlreadyExists()
        {
            var dto = new CreatePatientDto { Email = "existing@test.com" };

            _userManagerMock.Setup(x => x.FindByEmailAsync(dto.Email))
                .ReturnsAsync(new User());

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.RegisterPatientAsync(dto));
        }

        // ---------------- REGISTER DOCTOR ----------------

        [Fact]
        public async Task RegisterDoctorAsync_ShouldRegisterSuccessfully()
        {
            var dto = new CreateDoctorDto
            {
                Email = "doctor@test.com",
                Password = "Password123!",
                TimeSlots = new List<string> { "09:00", "10:00" }
            };

            var doctor = new Doctor { DoctorId = 5 };

            _userManagerMock.Setup(x => x.FindByEmailAsync(dto.Email))
                .ReturnsAsync((User)null!);

            _userManagerMock.Setup(x => x.CreateAsync(It.IsAny<User>(), dto.Password))
                .ReturnsAsync(IdentityResult.Success);

            _userManagerMock.Setup(x => x.AddToRoleAsync(It.IsAny<User>(), "Doctor"))
                .ReturnsAsync(IdentityResult.Success);

            _mapperMock.Setup(x => x.Map<Doctor>(dto))
                .Returns(doctor);

            await _service.RegisterDoctorAsync(dto);

            _doctorRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Doctor>()), Times.Once);

            _doctorRepositoryMock.Verify(
                x => x.CreateSlots(doctor.DoctorId, dto.TimeSlots),
                Times.Once);
        }

        [Fact]
        public async Task RegisterDoctorAsync_ShouldThrow_WhenEmailAlreadyExists()
        {
            var dto = new CreateDoctorDto
            {
                Email = "doctor@test.com",
                Password = "Password123!",
                TimeSlots = new List<string>()
            };

            _userManagerMock.Setup(x => x.FindByEmailAsync(dto.Email))
                .ReturnsAsync(new User());

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.RegisterDoctorAsync(dto));
        }

        // ---------------- LOGIN ----------------

        [Fact]
        public async Task LoginAsync_ShouldReturnPatientToken()
        {
            var user = new User { Id = "user1", Email = "patient@test.com" };
            var patient = new Patient { PatientId = 12 };

            _userManagerMock.Setup(x => x.FindByEmailAsync(user.Email))
                .ReturnsAsync(user);

            _userManagerMock.Setup(x => x.CheckPasswordAsync(user, "Password123"))
                .ReturnsAsync(true);

            _userManagerMock.Setup(x => x.GetRolesAsync(user))
                .ReturnsAsync(new List<string> { "Patient" });

            _patientRepositoryMock.Setup(x => x.GetByUserIdAsync(user.Id))
                .ReturnsAsync(patient);

            _jwtServiceMock.Setup(x => x.GenerateToken(user, patient.PatientId, null))
                .ReturnsAsync("patient-token");

            var result = await _service.LoginAsync(new LoginDto
            {
                Email = user.Email,
                Password = "Password123"
            });

            Assert.Equal("Patient", result.Role);
            Assert.Equal("patient-token", result.AccessToken);
        }

        [Fact]
        public async Task LoginAsync_ShouldThrow_WhenUserNotFound()
        {
            _userManagerMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync((User)null!);

            await Assert.ThrowsAsync<UnauthorizedAccessException>(
                () => _service.LoginAsync(new LoginDto()));
        }

        [Fact]
        public async Task LoginAsync_ShouldThrow_WhenPasswordIncorrect()
        {
            var user = new User();

            _userManagerMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(user);

            _userManagerMock.Setup(x => x.CheckPasswordAsync(user, It.IsAny<string>()))
                .ReturnsAsync(false);

            await Assert.ThrowsAsync<UnauthorizedAccessException>(
                () => _service.LoginAsync(new LoginDto()));
        }

        [Fact]
        public async Task LoginAsync_ShouldThrow_WhenNoRoleAssigned()
        {
            var user = new User { Id = "1", Email = "test@test.com" };

            _userManagerMock.Setup(x => x.FindByEmailAsync(user.Email))
                .ReturnsAsync(user);

            _userManagerMock.Setup(x => x.CheckPasswordAsync(user, "Password123"))
                .ReturnsAsync(true);

            _userManagerMock.Setup(x => x.GetRolesAsync(user))
                .ReturnsAsync(new List<string>());

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.LoginAsync(new LoginDto
                {
                    Email = user.Email,
                    Password = "Password123"
                }));
        }

        [Fact]
        public async Task LoginAsync_ShouldThrow_WhenPatientProfileMissing()
        {
            var user = new User { Id = "1", Email = "patient@test.com" };

            _userManagerMock.Setup(x => x.FindByEmailAsync(user.Email))
                .ReturnsAsync(user);

            _userManagerMock.Setup(x => x.CheckPasswordAsync(user, "Password123"))
                .ReturnsAsync(true);

            _userManagerMock.Setup(x => x.GetRolesAsync(user))
                .ReturnsAsync(new List<string> { "Patient" });

            _patientRepositoryMock.Setup(x => x.GetByUserIdAsync(user.Id))
                .ReturnsAsync((Patient)null!);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.LoginAsync(new LoginDto
                {
                    Email = user.Email,
                    Password = "Password123"
                }));
        }

        // ---------------- CHANGE PASSWORD ----------------

        [Fact]
        public async Task ChangePasswordAsync_ShouldThrow_WhenUserNotFound()
        {
            _userManagerMock.Setup(x => x.FindByIdAsync("123"))
                .ReturnsAsync((User)null!);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.ChangePasswordAsync("123", new ChangePasswordDto()));
        }

        [Fact]
        public async Task ChangePasswordAsync_ShouldSucceed()
        {
            var user = new User { Id = "123" };

            _userManagerMock.Setup(x => x.FindByIdAsync("123"))
                .ReturnsAsync(user);

            _userManagerMock.Setup(x => x.ChangePasswordAsync(
                user,
                "OldPassword",
                "NewPassword"))
                .ReturnsAsync(IdentityResult.Success);

            await _service.ChangePasswordAsync("123", new ChangePasswordDto
            {
                CurrentPassword = "OldPassword",
                NewPassword = "NewPassword"
            });

            _userManagerMock.Verify(x =>
                x.ChangePasswordAsync(user, "OldPassword", "NewPassword"),
                Times.Once);
        }

        [Fact]
        public async Task ChangePasswordAsync_ShouldThrow_WhenPasswordChangeFails()
        {
            var user = new User { Id = "123" };

            _userManagerMock.Setup(x => x.FindByIdAsync("123"))
                .ReturnsAsync(user);

            _userManagerMock.Setup(x => x.ChangePasswordAsync(
                user,
                "OldPassword",
                "NewPassword"))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError
                {
                    Description = "Weak password"
                }));

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.ChangePasswordAsync("123", new ChangePasswordDto
                {
                    CurrentPassword = "OldPassword",
                    NewPassword = "NewPassword"
                }));
        }
    }
}