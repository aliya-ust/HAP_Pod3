using AutoMapper;
using Moq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HealthCare.Api.Data;
using HealthCare.Api.Exceptions;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Implementations;
using HealthCare.Api.Services.Interfaces;
using HealthCare.Shared.DTOs.Auth;
using HealthCare.Shared.DTOs.Patient;
using HealthCare.Shared.DTOs.Doctor;

namespace HealthCare.Api.Tests
{
    public class AuthServiceTests
    {
        private readonly Mock<UserManager<User>> _userManagerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IPatientRepository> _patientRepoMock;
        private readonly Mock<IDoctorRepository> _doctorRepoMock;
        private readonly Mock<IJwtService> _jwtServiceMock;
        private readonly HealthCareDbContext _context;
        private readonly AuthService _service;

        public AuthServiceTests()
        {
            var store = new Mock<IUserStore<User>>();
            _userManagerMock = new Mock<UserManager<User>>(
                store.Object, null!, null!, null!, null!, null!, null!, null!, null!
            );

            _mapperMock = new Mock<IMapper>();
            _patientRepoMock = new Mock<IPatientRepository>();
            _doctorRepoMock = new Mock<IDoctorRepository>();
            _jwtServiceMock = new Mock<IJwtService>();

            var options = new DbContextOptionsBuilder<HealthCareDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new HealthCareDbContext(options);

            _service = new AuthService(
                _userManagerMock.Object,
                _mapperMock.Object,
                _patientRepoMock.Object,
                _doctorRepoMock.Object,
                _jwtServiceMock.Object,
                _context
            );
        }

        //  Register Patient
        [Fact]
        public async Task RegisterPatientAsync_ShouldCreateUserAndPatient()
        {
            var dto = new CreatePatientDto { Email = "test@mail.com", Password = "Password123!" };
            var user = new User();

            _userManagerMock.Setup(u => u.FindByEmailAsync(dto.Email))
                .ReturnsAsync((User?)null);

            _userManagerMock.Setup(u => u.CreateAsync(It.IsAny<User>(), dto.Password))
                .ReturnsAsync(IdentityResult.Success);

            _userManagerMock.Setup(u => u.AddToRoleAsync(It.IsAny<User>(), "Patient"))
                .ReturnsAsync(IdentityResult.Success);

            _mapperMock.Setup(m => m.Map<Patient>(dto)).Returns(new Patient());

            await _service.RegisterPatientAsync(dto);

            _patientRepoMock.Verify(r => r.AddAsync(It.IsAny<Patient>()), Times.Once);
        }

        //  Register Doctor
        [Fact]
        public async Task RegisterDoctorAsync_ShouldCreateDoctorAndSlots()
        {
            var dto = new CreateDoctorDto
            {
                Email = "doc@mail.com",
                Password = "Password123!",
                TimeSlots = new List<string> { "09:00-10:00" }
            };

            _userManagerMock.Setup(u => u.FindByEmailAsync(dto.Email))
                .ReturnsAsync((User?)null);

            _userManagerMock.Setup(u => u.CreateAsync(It.IsAny<User>(), dto.Password))
                .ReturnsAsync(IdentityResult.Success);

            _userManagerMock.Setup(u => u.AddToRoleAsync(It.IsAny<User>(), "Doctor"))
                .ReturnsAsync(IdentityResult.Success);

            var doctor = new Doctor { DoctorId = 1 };

            _mapperMock.Setup(m => m.Map<Doctor>(dto)).Returns(doctor);

            await _service.RegisterDoctorAsync(dto);

            _doctorRepoMock.Verify(r => r.AddAsync(doctor), Times.Once);
            _doctorRepoMock.Verify(r => r.CreateSlots(doctor.DoctorId, dto.TimeSlots), Times.Once);
        }

        //  Login - patient
        [Fact]
        public async Task LoginAsync_ShouldReturnToken_ForPatient()
        {
            var user = new User { Id = "1", Email = "test@mail.com" };

            _userManagerMock.Setup(u => u.FindByEmailAsync(user.Email))
                .ReturnsAsync(user);

            _userManagerMock.Setup(u => u.CheckPasswordAsync(user, "Password123!"))
                .ReturnsAsync(true);

            _userManagerMock.Setup(u => u.GetRolesAsync(user))
                .ReturnsAsync(new List<string> { "Patient" });

            _patientRepoMock.Setup(r => r.GetByUserIdAsync(user.Id))
                .ReturnsAsync(new Patient { PatientId = 5 });

            _jwtServiceMock.Setup(j => j.GenerateToken(user, 5, null))
                .ReturnsAsync("token");

            var result = await _service.LoginAsync(new LoginDto
            {
                Email = user.Email,
                Password = "Password123!"
            });

            Assert.Equal("token", result.AccessToken);
            Assert.Equal("Patient", result.Role);
        }

        //  Login - doctor
        [Fact]
        public async Task LoginAsync_ShouldReturnToken_ForDoctor()
        {
            var user = new User { Id = "1", Email = "doc@mail.com" };

            _userManagerMock.Setup(u => u.FindByEmailAsync(user.Email))
                .ReturnsAsync(user);

            _userManagerMock.Setup(u => u.CheckPasswordAsync(user, "Password123!"))
                .ReturnsAsync(true);

            _userManagerMock.Setup(u => u.GetRolesAsync(user))
                .ReturnsAsync(new List<string> { "Doctor" });

            _doctorRepoMock.Setup(r => r.GetByUserIdAsync(user.Id))
                .ReturnsAsync(new Doctor { DoctorId = 3 });

            _jwtServiceMock.Setup(j => j.GenerateToken(user, null, 3))
                .ReturnsAsync("token");

            var result = await _service.LoginAsync(new LoginDto
            {
                Email = user.Email,
                Password = "Password123!"
            });

            Assert.Equal("token", result.AccessToken);
            Assert.Equal("Doctor", result.Role);
        }

        //  Login - invalid password
        [Fact]
        public async Task LoginAsync_ShouldThrow_WhenPasswordInvalid()
        {
            var user = new User { Email = "test@mail.com" };

            _userManagerMock.Setup(u => u.FindByEmailAsync(user.Email))
                .ReturnsAsync(user);

            _userManagerMock.Setup(u => u.CheckPasswordAsync(user, "wrong"))
                .ReturnsAsync(false);

            await Assert.ThrowsAsync<InvalidLoginException>(() =>
                _service.LoginAsync(new LoginDto { Email = user.Email, Password = "wrong" }));
        }

        //  Login - user not found
        [Fact]
        public async Task LoginAsync_ShouldThrow_WhenUserNotFound()
        {
            _userManagerMock.Setup(u => u.FindByEmailAsync("test@mail.com"))
                .ReturnsAsync((User?)null);

            await Assert.ThrowsAsync<InvalidLoginException>(() =>
                _service.LoginAsync(new LoginDto { Email = "test@mail.com", Password = "pass" }));
        }

        //  ChangePassword
        [Fact]
        public async Task ChangePasswordAsync_ShouldChangePassword()
        {
            var user = new User { Id = "1" };

            _userManagerMock.Setup(u => u.FindByIdAsync("1"))
                .ReturnsAsync(user);

            _userManagerMock.Setup(u => u.ChangePasswordAsync(user, "old", "new"))
                .ReturnsAsync(IdentityResult.Success);

            await _service.ChangePasswordAsync("1", new ChangePasswordDto
            {
                CurrentPassword = "old",
                NewPassword = "new"
            });


            _userManagerMock.Verify(u => u.FindByIdAsync("1"), Times.Once);

            _userManagerMock.Verify(u =>
                u.ChangePasswordAsync(user, "old", "new"), Times.Once);

        }

        //  ChangePassword - failure
        [Fact]
        public async Task ChangePasswordAsync_ShouldThrow_WhenFails()
        {
            var user = new User { Id = "1" };

            _userManagerMock.Setup(u => u.FindByIdAsync("1"))
                .ReturnsAsync(user);

            _userManagerMock.Setup(u => u.ChangePasswordAsync(user, "old", "new"))
                .ReturnsAsync(IdentityResult.Failed(
                    new IdentityError { Description = "Error" }
                ));

            await Assert.ThrowsAsync<IdentityOperationException>(() =>
                _service.ChangePasswordAsync("1", new ChangePasswordDto
                {
                    CurrentPassword = "old",
                    NewPassword = "new"
                }));
        }

        //  RegisterPatient - email in use
        [Fact]
        public async Task RegisterPatientAsync_ShouldThrow_WhenEmailInUse()
        {
            var dto = new CreatePatientDto { Email = "test@mail.com", Password = "Password123!" };

            _userManagerMock.Setup(u => u.FindByEmailAsync(dto.Email))
                .ReturnsAsync(new User());

            await Assert.ThrowsAsync<EmailAlreadyInUseException>(() =>
                _service.RegisterPatientAsync(dto));
        }

        //  RegisterPatient - identity failure
        [Fact]
        public async Task RegisterPatientAsync_ShouldThrow_WhenCreateFails()
        {
            var dto = new CreatePatientDto { Email = "test@mail.com", Password = "Password123!" };

            _userManagerMock.Setup(u => u.FindByEmailAsync(dto.Email))
                .ReturnsAsync((User?)null);

            _userManagerMock.Setup(u => u.CreateAsync(It.IsAny<User>(), dto.Password))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Create failed" }));

            await Assert.ThrowsAsync<IdentityOperationException>(() =>
                _service.RegisterPatientAsync(dto));
        }

        //  RegisterDoctor - email in use
        [Fact]
        public async Task RegisterDoctorAsync_ShouldThrow_WhenEmailInUse()
        {
            var dto = new CreateDoctorDto { Email = "doc@mail.com", Password = "Password123!" };

            _userManagerMock.Setup(u => u.FindByEmailAsync(dto.Email))
                .ReturnsAsync(new User());

            await Assert.ThrowsAsync<EmailAlreadyInUseException>(() =>
                _service.RegisterDoctorAsync(dto));
        }

        //  RegisterDoctor - identity failure
        [Fact]
        public async Task RegisterDoctorAsync_ShouldThrow_WhenCreateFails()
        {
            var dto = new CreateDoctorDto { Email = "doc@mail.com", Password = "Password123!" };

            _userManagerMock.Setup(u => u.FindByEmailAsync(dto.Email))
                .ReturnsAsync((User?)null);

            _userManagerMock.Setup(u => u.CreateAsync(It.IsAny<User>(), dto.Password))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Create failed" }));

            await Assert.ThrowsAsync<IdentityOperationException>(() =>
                _service.RegisterDoctorAsync(dto));
        }

        //  Login - admin
        [Fact]
        public async Task LoginAsync_ShouldReturnToken_ForAdmin()
        {
            var user = new User { Id = "1", Email = "admin@mail.com" };

            _userManagerMock.Setup(u => u.FindByEmailAsync(user.Email))
                .ReturnsAsync(user);

            _userManagerMock.Setup(u => u.CheckPasswordAsync(user, "Password123!"))
                .ReturnsAsync(true);

            _userManagerMock.Setup(u => u.GetRolesAsync(user))
                .ReturnsAsync(new List<string> { "Admin" });

            _jwtServiceMock.Setup(j => j.GenerateToken(user, null, null))
                .ReturnsAsync("admin-token");

            var result = await _service.LoginAsync(new LoginDto
            {
                Email = user.Email,
                Password = "Password123!"
            });

            Assert.Equal("admin-token", result.AccessToken);
            Assert.Equal("Admin", result.Role);
        }

        //  Login - patient not found
        [Fact]
        public async Task LoginAsync_ShouldThrow_WhenPatientNotFound()
        {
            var user = new User { Id = "1", Email = "test@mail.com" };

            _userManagerMock.Setup(u => u.FindByEmailAsync(user.Email))
                .ReturnsAsync(user);

            _userManagerMock.Setup(u => u.CheckPasswordAsync(user, "Password123!"))
                .ReturnsAsync(true);

            _userManagerMock.Setup(u => u.GetRolesAsync(user))
                .ReturnsAsync(new List<string> { "Patient" });

            _patientRepoMock.Setup(r => r.GetByUserIdAsync(user.Id))
                .ReturnsAsync((Patient?)null);

            await Assert.ThrowsAsync<PatientNotFoundException>(() =>
                _service.LoginAsync(new LoginDto { Email = user.Email, Password = "Password123!" }));
        }

        //  Login - doctor not found
        [Fact]
        public async Task LoginAsync_ShouldThrow_WhenDoctorNotFound()
        {
            var user = new User { Id = "1", Email = "doc@mail.com" };

            _userManagerMock.Setup(u => u.FindByEmailAsync(user.Email))
                .ReturnsAsync(user);

            _userManagerMock.Setup(u => u.CheckPasswordAsync(user, "Password123!"))
                .ReturnsAsync(true);

            _userManagerMock.Setup(u => u.GetRolesAsync(user))
                .ReturnsAsync(new List<string> { "Doctor" });

            _doctorRepoMock.Setup(r => r.GetByUserIdAsync(user.Id))
                .ReturnsAsync((Doctor?)null);

            await Assert.ThrowsAsync<DoctorNotFoundException>(() =>
                _service.LoginAsync(new LoginDto { Email = user.Email, Password = "Password123!" }));
        }

        //  Login - no roles
        [Fact]
        public async Task LoginAsync_ShouldThrow_WhenNoRoles()
        {
            var user = new User { Id = "1", Email = "test@mail.com" };

            _userManagerMock.Setup(u => u.FindByEmailAsync(user.Email))
                .ReturnsAsync(user);

            _userManagerMock.Setup(u => u.CheckPasswordAsync(user, "Password123!"))
                .ReturnsAsync(true);

            _userManagerMock.Setup(u => u.GetRolesAsync(user))
                .ReturnsAsync(new List<string>());

            await Assert.ThrowsAsync<RoleNotAssignedException>(() =>
                _service.LoginAsync(new LoginDto { Email = user.Email, Password = "Password123!" }));
        }

        //  Login - invalid role
        [Fact]
        public async Task LoginAsync_ShouldThrow_WhenInvalidRole()
        {
            var user = new User { Id = "1", Email = "test@mail.com" };

            _userManagerMock.Setup(u => u.FindByEmailAsync(user.Email))
                .ReturnsAsync(user);

            _userManagerMock.Setup(u => u.CheckPasswordAsync(user, "Password123!"))
                .ReturnsAsync(true);

            _userManagerMock.Setup(u => u.GetRolesAsync(user))
                .ReturnsAsync(new List<string> { "SomeInvalidRole" });

            await Assert.ThrowsAsync<InvalidRoleException>(() =>
                _service.LoginAsync(new LoginDto { Email = user.Email, Password = "Password123!" }));
        }

        //  ChangePassword - user not found
        [Fact]
        public async Task ChangePasswordAsync_ShouldThrow_WhenUserNotFound()
        {
            _userManagerMock.Setup(u => u.FindByIdAsync("nonexistent"))
                .ReturnsAsync((User?)null);

            await Assert.ThrowsAsync<UserNotFoundException>(() =>
                _service.ChangePasswordAsync("nonexistent", new ChangePasswordDto
                {
                    CurrentPassword = "old",
                    NewPassword = "new"
                }));
        }
    }
}