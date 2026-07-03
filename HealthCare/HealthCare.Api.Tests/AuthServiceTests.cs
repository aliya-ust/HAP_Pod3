using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs.Auth;
using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Implementations;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace HealthCare.Api.Tests;

public class AuthServiceTests
{
    private readonly Mock<UserManager<User>> _userManagerMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IPatientRepository> _patientRepoMock;
    private readonly Mock<IDoctorRepository> _doctorRepoMock;
    private readonly Mock<IJwtService> _jwtServiceMock;
    private readonly Mock<HealthCareDbContext> _contextMock;

    private readonly AuthService _service;

    public AuthServiceTests()
    {
        var store = new Mock<IUserStore<User>>();

        _userManagerMock = new Mock<UserManager<User>>(
            store.Object,
            null!,
            null!,
            null!,
            null!,
            null!,
            null!,
            null!,
            null!);

        _mapperMock = new Mock<IMapper>();
        _patientRepoMock = new Mock<IPatientRepository>();
        _doctorRepoMock = new Mock<IDoctorRepository>();
        _jwtServiceMock = new Mock<IJwtService>();

        var options = new DbContextOptions<HealthCareDbContext>();

        _contextMock = new Mock<HealthCareDbContext>(options);

        _service = new AuthService(
            _userManagerMock.Object,
            _mapperMock.Object,
            _patientRepoMock.Object,
            _doctorRepoMock.Object,
            _jwtServiceMock.Object,
            _contextMock.Object);
    }

    [Fact]
    public async Task RegisterPatientAsync_ShouldRegisterPatient()
    {
        var dto = new CreatePatientDto
        {
            Email = "patient@test.com",
            Password = "Password@123"
        };

        var patient = new Patient();

        _userManagerMock
            .Setup(x => x.FindByEmailAsync(dto.Email))
            .ReturnsAsync((User?)null);

        _userManagerMock
            .Setup(x => x.CreateAsync(
                It.IsAny<User>(),
                dto.Password))
            .ReturnsAsync(IdentityResult.Success);

        _userManagerMock
            .Setup(x => x.AddToRoleAsync(
                It.IsAny<User>(),
                "Patient"))
            .ReturnsAsync(IdentityResult.Success);

        _mapperMock
            .Setup(x => x.Map<Patient>(dto))
            .Returns(patient);

        await _service.RegisterPatientAsync(dto);

        _patientRepoMock.Verify(
            x => x.AddAsync(patient),
            Times.Once);
    }

    [Fact]
    public async Task RegisterPatientAsync_ShouldThrow_WhenEmailExists()
    {
        var dto = new CreatePatientDto
        {
            Email = "existing@test.com"
        };

        _userManagerMock
            .Setup(x => x.FindByEmailAsync(dto.Email))
            .ReturnsAsync(new User());

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.RegisterPatientAsync(dto));
    }

    [Fact]
    public async Task RegisterDoctorAsync_ShouldRegisterDoctor()
    {
        var dto = new CreateDoctorDto
        {
            Email = "doctor@test.com",
            Password = "Password@123",
            TimeSlots = new List<string>
            {
                "09:00 AM"
            }
        };

        var doctor = new Doctor
        {
            DoctorId = 1
        };

        _userManagerMock
            .Setup(x => x.FindByEmailAsync(dto.Email))
            .ReturnsAsync((User?)null);

        _userManagerMock
            .Setup(x => x.CreateAsync(
                It.IsAny<User>(),
                dto.Password))
            .ReturnsAsync(IdentityResult.Success);

        _userManagerMock
            .Setup(x => x.AddToRoleAsync(
                It.IsAny<User>(),
                "Doctor"))
            .ReturnsAsync(IdentityResult.Success);

        _mapperMock
            .Setup(x => x.Map<Doctor>(dto))
            .Returns(doctor);

        await _service.RegisterDoctorAsync(dto);

        _doctorRepoMock.Verify(
            x => x.AddAsync(doctor),
            Times.Once);

        _doctorRepoMock.Verify(
            x => x.CreateSlots(
                doctor.DoctorId,
                dto.TimeSlots),
            Times.Once);
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnPatientToken()
    {
        var dto = new LoginDto
        {
            Email = "patient@test.com",
            Password = "password"
        };

        var user = new User
        {
            Id = "1",
            Email = dto.Email
        };

        var patient = new Patient
        {
            PatientId = 10
        };

        _userManagerMock
            .Setup(x => x.FindByEmailAsync(dto.Email))
            .ReturnsAsync(user);

        _userManagerMock
            .Setup(x => x.CheckPasswordAsync(user, dto.Password))
            .ReturnsAsync(true);

        _userManagerMock
            .Setup(x => x.GetRolesAsync(user))
            .ReturnsAsync(new List<string> { "Patient" });

        _patientRepoMock
            .Setup(x => x.GetByUserIdAsync(user.Id))
            .ReturnsAsync(patient);

        _jwtServiceMock
            .Setup(x => x.GenerateToken(user, patient.PatientId, null))
            .ReturnsAsync("patient-token");

        var result = await _service.LoginAsync(dto);

        Assert.Equal("patient-token", result.AccessToken);
        Assert.Equal("Patient", result.Role);
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnDoctorToken()
    {
        var dto = new LoginDto
        {
            Email = "doctor@test.com",
            Password = "password"
        };

        var user = new User
        {
            Id = "1"
        };

        var doctor = new Doctor
        {
            DoctorId = 5
        };

        _userManagerMock
            .Setup(x => x.FindByEmailAsync(dto.Email))
            .ReturnsAsync(user);

        _userManagerMock
            .Setup(x => x.CheckPasswordAsync(user, dto.Password))
            .ReturnsAsync(true);

        _userManagerMock
            .Setup(x => x.GetRolesAsync(user))
            .ReturnsAsync(new List<string> { "Doctor" });

        _doctorRepoMock
            .Setup(x => x.GetByUserIdAsync(user.Id))
            .ReturnsAsync(doctor);

        _jwtServiceMock
            .Setup(x => x.GenerateToken(user, null, doctor.DoctorId))
            .ReturnsAsync("doctor-token");

        var result = await _service.LoginAsync(dto);

        Assert.Equal("doctor-token", result.AccessToken);
        Assert.Equal("Doctor", result.Role);
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnAdminToken()
    {
        var dto = new LoginDto
        {
            Email = "admin@test.com",
            Password = "password"
        };

        var user = new User
        {
            Id = "1"
        };

        _userManagerMock
            .Setup(x => x.FindByEmailAsync(dto.Email))
            .ReturnsAsync(user);

        _userManagerMock
            .Setup(x => x.CheckPasswordAsync(user, dto.Password))
            .ReturnsAsync(true);

        _userManagerMock
            .Setup(x => x.GetRolesAsync(user))
            .ReturnsAsync(new List<string> { "Admin" });

        _jwtServiceMock
            .Setup(x => x.GenerateToken(user, null, null))
            .ReturnsAsync("admin-token");

        var result = await _service.LoginAsync(dto);

        Assert.Equal("Admin", result.Role);
        Assert.Equal("admin-token", result.AccessToken);
    }

    [Fact]
    public async Task LoginAsync_ShouldThrow_WhenUserNotFound()
    {
        var dto = new LoginDto
        {
            Email = "test@test.com"
        };

        _userManagerMock
            .Setup(x => x.FindByEmailAsync(dto.Email))
            .ReturnsAsync((User?)null);

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.LoginAsync(dto));
    }

    [Fact]
    public async Task LoginAsync_ShouldThrow_WhenPasswordInvalid()
    {
        var user = new User();

        _userManagerMock
            .Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(user);

        _userManagerMock
            .Setup(x => x.CheckPasswordAsync(
                user,
                It.IsAny<string>()))
            .ReturnsAsync(false);

        await Assert.ThrowsAsync<UnauthorizedAccessException>(
            () => _service.LoginAsync(new LoginDto()));
    }

    [Fact]
    public async Task LoginAsync_ShouldThrow_WhenRoleMissing()
    {
        var user = new User();

        _userManagerMock
            .Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(user);

        _userManagerMock
            .Setup(x => x.CheckPasswordAsync(
                user,
                It.IsAny<string>()))
            .ReturnsAsync(true);

        _userManagerMock
            .Setup(x => x.GetRolesAsync(user))
            .ReturnsAsync(new List<string>());

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.LoginAsync(new LoginDto()));
    }

    [Fact]
    public async Task LoginAsync_ShouldThrow_WhenPatientRecordMissing()
    {
        var user = new User
        {
            Id = "1"
        };

        _userManagerMock
            .Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(user);

        _userManagerMock
            .Setup(x => x.CheckPasswordAsync(user, It.IsAny<string>()))
            .ReturnsAsync(true);

        _userManagerMock
            .Setup(x => x.GetRolesAsync(user))
            .ReturnsAsync(new List<string> { "Patient" });

        _patientRepoMock
            .Setup(x => x.GetByUserIdAsync(user.Id))
            .ReturnsAsync((Patient?)null);

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.LoginAsync(new LoginDto()));
    }

    [Fact]
    public async Task ChangePasswordAsync_ShouldChangePassword()
    {
        var user = new User
        {
            Id = "1"
        };

        var dto = new ChangePasswordDto
        {
            CurrentPassword = "old",
            NewPassword = "new"
        };

        _userManagerMock
            .Setup(x => x.FindByIdAsync(user.Id))
            .ReturnsAsync(user);

        _userManagerMock
            .Setup(x => x.ChangePasswordAsync(
                user,
                dto.CurrentPassword,
                dto.NewPassword))
            .ReturnsAsync(IdentityResult.Success);

        await _service.ChangePasswordAsync(user.Id, dto);

        _userManagerMock.Verify(
            x => x.ChangePasswordAsync(
                user,
                dto.CurrentPassword,
                dto.NewPassword),
            Times.Once);
    }

    [Fact]
    public async Task ChangePasswordAsync_ShouldThrow_WhenUserNotFound()
    {
        _userManagerMock
            .Setup(x => x.FindByIdAsync("1"))
            .ReturnsAsync((User?)null);

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.ChangePasswordAsync(
                "1",
                new ChangePasswordDto()));
    }

    [Fact]
    public async Task ChangePasswordAsync_ShouldThrow_WhenPasswordChangeFails()
    {
        var user = new User();

        _userManagerMock
            .Setup(x => x.FindByIdAsync("1"))
            .ReturnsAsync(user);

        _userManagerMock
            .Setup(x => x.ChangePasswordAsync(
                user,
                It.IsAny<string>(),
                It.IsAny<string>()))
            .ReturnsAsync(
                IdentityResult.Failed(
                    new IdentityError
                    {
                        Description = "Password error"
                    }));

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.ChangePasswordAsync(
                "1",
                new ChangePasswordDto()));
    }
    [Fact]
    public async Task RegisterDoctorAsync_ShouldThrow_WhenEmailAlreadyExists()
    {
        var dto = new CreateDoctorDto
        {
            Email = "doctor@test.com"
        };

        _userManagerMock
            .Setup(x => x.FindByEmailAsync(dto.Email))
            .ReturnsAsync(new User());

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.RegisterDoctorAsync(dto));
    }

    [Fact]
    public async Task RegisterPatientAsync_ShouldThrow_WhenCreateUserFails()
    {
        var dto = new CreatePatientDto
        {
            Email = "patient@test.com",
            Password = "Password@123"
        };

        _userManagerMock
            .Setup(x => x.FindByEmailAsync(dto.Email))
            .ReturnsAsync((User?)null);

        _userManagerMock
            .Setup(x => x.CreateAsync(
                It.IsAny<User>(),
                dto.Password))
            .ReturnsAsync(
                IdentityResult.Failed(
                    new IdentityError
                    {
                        Description = "Password too weak"
                    }));

        var ex = await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.RegisterPatientAsync(dto));

        Assert.Contains("Password too weak", ex.Message);
    }

    [Fact]
    public async Task RegisterDoctorAsync_ShouldThrow_WhenCreateUserFails()
    {
        var dto = new CreateDoctorDto
        {
            Email = "doctor@test.com",
            Password = "Password@123"
        };

        _userManagerMock
            .Setup(x => x.FindByEmailAsync(dto.Email))
            .ReturnsAsync((User?)null);

        _userManagerMock
            .Setup(x => x.CreateAsync(
                It.IsAny<User>(),
                dto.Password))
            .ReturnsAsync(
                IdentityResult.Failed(
                    new IdentityError
                    {
                        Description = "User creation failed"
                    }));

        var ex = await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.RegisterDoctorAsync(dto));

        Assert.Contains("User creation failed", ex.Message);
    }

    [Fact]
    public async Task LoginAsync_ShouldThrow_WhenDoctorRecordMissing()
    {
        var user = new User
        {
            Id = "1",
            Email = "doctor@test.com"
        };

        _userManagerMock
            .Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(user);

        _userManagerMock
            .Setup(x => x.CheckPasswordAsync(
                user,
                It.IsAny<string>()))
            .ReturnsAsync(true);

        _userManagerMock
            .Setup(x => x.GetRolesAsync(user))
            .ReturnsAsync(new List<string> { "Doctor" });

        _doctorRepoMock
            .Setup(x => x.GetByUserIdAsync(user.Id))
            .ReturnsAsync((Doctor?)null);

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.LoginAsync(new LoginDto()));
    }

    [Fact]
    public async Task LoginAsync_ShouldThrow_WhenRoleIsInvalid()
    {
        var user = new User
        {
            Id = "1",
            Email = "test@test.com"
        };

        _userManagerMock
            .Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(user);

        _userManagerMock
            .Setup(x => x.CheckPasswordAsync(
                user,
                It.IsAny<string>()))
            .ReturnsAsync(true);

        _userManagerMock
            .Setup(x => x.GetRolesAsync(user))
            .ReturnsAsync(new List<string> { "SuperUser" });

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.LoginAsync(new LoginDto()));
    }

    [Fact]
    public async Task ChangePasswordAsync_ShouldIncludeIdentityErrorsInException()
    {
        var user = new User
        {
            Id = "1"
        };

        var dto = new ChangePasswordDto
        {
            CurrentPassword = "Old123",
            NewPassword = "New123"
        };

        _userManagerMock
            .Setup(x => x.FindByIdAsync("1"))
            .ReturnsAsync(user);

        _userManagerMock
            .Setup(x => x.ChangePasswordAsync(
                user,
                dto.CurrentPassword,
                dto.NewPassword))
            .ReturnsAsync(
                IdentityResult.Failed(
                    new IdentityError
                    {
                        Description = "Password must contain a special character"
                    },
                    new IdentityError
                    {
                        Description = "Password must contain a number"
                    }));

        var ex = await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.ChangePasswordAsync("1", dto));

        Assert.Contains(
            "Password must contain a special character",
            ex.Message);

        Assert.Contains(
            "Password must contain a number",
            ex.Message);
    }

    [Fact]
    public async Task RegisterPatientAsync_ShouldAssignPatientRole()
    {
        var dto = new CreatePatientDto
        {
            Email = "patient@test.com",
            Password = "Password@123"
        };

        _userManagerMock
            .Setup(x => x.FindByEmailAsync(dto.Email))
            .ReturnsAsync((User?)null);

        _userManagerMock
            .Setup(x => x.CreateAsync(
                It.IsAny<User>(),
                dto.Password))
            .ReturnsAsync(IdentityResult.Success);

        _userManagerMock
            .Setup(x => x.AddToRoleAsync(
                It.IsAny<User>(),
                "Patient"))
            .ReturnsAsync(IdentityResult.Success);

        _mapperMock
            .Setup(x => x.Map<Patient>(dto))
            .Returns(new Patient());

        await _service.RegisterPatientAsync(dto);

        _userManagerMock.Verify(
            x => x.AddToRoleAsync(
                It.IsAny<User>(),
                "Patient"),
            Times.Once);
    }

    [Fact]
    public async Task RegisterDoctorAsync_ShouldAssignDoctorRole()
    {
        var dto = new CreateDoctorDto
        {
            Email = "doctor@test.com",
            Password = "Password@123",
            TimeSlots = new List<string>()
        };

        _userManagerMock
            .Setup(x => x.FindByEmailAsync(dto.Email))
            .ReturnsAsync((User?)null);

        _userManagerMock
            .Setup(x => x.CreateAsync(
                It.IsAny<User>(),
                dto.Password))
            .ReturnsAsync(IdentityResult.Success);

        _userManagerMock
            .Setup(x => x.AddToRoleAsync(
                It.IsAny<User>(),
                "Doctor"))
            .ReturnsAsync(IdentityResult.Success);

        _mapperMock
            .Setup(x => x.Map<Doctor>(dto))
            .Returns(new Doctor());

        await _service.RegisterDoctorAsync(dto);

        _userManagerMock.Verify(
            x => x.AddToRoleAsync(
                It.IsAny<User>(),
                "Doctor"),
            Times.Once);
    }

    [Fact]
    public async Task LoginAsync_ShouldThrow_WhenPatientRoleButPatientNotFound()
    {
        var user = new User
        {
            Id = "1"
        };

        _userManagerMock
            .Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(user);

        _userManagerMock
            .Setup(x => x.CheckPasswordAsync(user, It.IsAny<string>()))
            .ReturnsAsync(true);

        _userManagerMock
            .Setup(x => x.GetRolesAsync(user))
            .ReturnsAsync(new List<string> { "Patient" });

        _patientRepoMock
            .Setup(x => x.GetByUserIdAsync(user.Id))
            .ReturnsAsync((Patient?)null);

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => _service.LoginAsync(new LoginDto()));
    }

    [Fact]
    public async Task LoginAsync_ShouldGenerateAdminToken()
    {
        var user = new User
        {
            Id = "1",
            Email = "admin@test.com"
        };

        _userManagerMock
            .Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(user);

        _userManagerMock
            .Setup(x => x.CheckPasswordAsync(user, It.IsAny<string>()))
            .ReturnsAsync(true);

        _userManagerMock
            .Setup(x => x.GetRolesAsync(user))
            .ReturnsAsync(new List<string> { "Admin" });

        _jwtServiceMock
            .Setup(x => x.GenerateToken(user, null, null))
            .ReturnsAsync("admin-token");

        var result = await _service.LoginAsync(new LoginDto());

        Assert.Equal("admin-token", result.AccessToken);
        Assert.Equal("Admin", result.Role);
    }
}