using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Auth;
using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace HealthCare.Api.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IJwtService _jwtService;
        private readonly HealthCareDbContext _context;
        private readonly ILogger<AuthService> _logger;
        private readonly IDoctorAvailabilityCacheService _doctorCache;

        public AuthService(
            UserManager<User> userManager,
            IMapper mapper,
            IPatientRepository patientRepository,
            IDoctorRepository doctorRepository,
            IJwtService jwtService,
            HealthCareDbContext context,
            ILogger<AuthService> logger,
            IDoctorAvailabilityCacheService doctorCache)
        {
            _userManager = userManager;
            _mapper = mapper;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _jwtService = jwtService;
            _context = context;
            _logger = logger;
            _doctorCache = doctorCache;
        }

        private async Task<User> CreateUserWithRoleAsync(
            string email,
            string password,
            string role)
        {
            _logger.LogInformation("Creating new user with email {Email} and role {Role}", email, role);

            var existingUser = await _userManager.FindByEmailAsync(email);

            if (existingUser != null)
            {
                _logger.LogWarning("Registration failed. Email {Email} is already registered.", email);
                throw new InvalidOperationException("Email is already registered.");
            }

            var user = new User
            {
                UserName = email,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));

                _logger.LogWarning(
                    "Failed to create user {Email}. Errors: {Errors}",
                    email,
                    errors);

                throw new InvalidOperationException(errors);
            }

            await _userManager.AddToRoleAsync(user, role);

            _logger.LogInformation(
                "User {Email} created successfully with role {Role}",
                email,
                role);

            return user;
        }

        public async Task RegisterPatientAsync(CreatePatientDto dto)
        {
            _logger.LogInformation(
                "Registering patient with email {Email}",
                dto.Email);

            var user = await CreateUserWithRoleAsync(
                dto.Email,
                dto.Password,
                "Patient");

            var patient = _mapper.Map<Patient>(dto);
            patient.UserId = user.Id;

            await _patientRepository.AddAsync(patient);
            await _context.SaveChangesAsync();

            _logger.LogInformation(
                "Patient registered successfully. PatientId: {PatientId}",
                patient.PatientId);
        }

        public async Task RegisterDoctorAsync(CreateDoctorDto dto)
        {
            _logger.LogInformation(
                "Registering doctor with email {Email}",
                dto.Email);

            var user = await CreateUserWithRoleAsync(
                dto.Email,
                dto.Password,
                "Doctor");

            var doctor = _mapper.Map<Doctor>(dto);
            doctor.UserId = user.Id;

            await _doctorRepository.AddAsync(doctor);
            await _context.SaveChangesAsync();

            await _doctorRepository.CreateSlots(
                doctor.DoctorId,
                dto.TimeSlots);

            await _context.SaveChangesAsync();

            await _doctorCache.RefreshSpecializationAsync(doctor.Specialisation);

            _logger.LogInformation(
                "Doctor registered successfully. DoctorId: {DoctorId}",
                doctor.DoctorId);
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            _logger.LogInformation(
                "Login attempt for email {Email}",
                dto.Email);

            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null)
            {
                _logger.LogWarning(
                    "Login failed. User not found for email {Email}",
                    dto.Email);

                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            var passwordValid =
                await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!passwordValid)
            {
                _logger.LogWarning(
                    "Login failed. Invalid password for email {Email}",
                    dto.Email);

                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Count == 0)
            {
                _logger.LogWarning(
                    "User {Email} has no role assigned",
                    dto.Email);

                throw new InvalidOperationException("No role assigned.");
            }

            var role = roles[0];
            string token;

            switch (role)
            {
                case "Patient":

                    var patient = await _patientRepository.GetByUserIdAsync(user.Id);

                    if (patient == null)
                    {
                        _logger.LogWarning(
                            "Patient profile not found for user {Email}",
                            dto.Email);

                        throw new InvalidOperationException("Patient profile not found.");
                    }

                    token = await _jwtService.GenerateToken(
                        user,
                        patientId: patient.PatientId);

                    break;

                case "Doctor":

                    var doctor = await _doctorRepository.GetByUserIdAsync(user.Id);

                    if (doctor == null)
                    {
                        _logger.LogWarning(
                            "Doctor profile not found for user {Email}",
                            dto.Email);

                        throw new InvalidOperationException("Doctor profile not found.");
                    }

                    token = await _jwtService.GenerateToken(
                        user,
                        doctorId: doctor.DoctorId);

                    break;

                case "Admin":

                    token = await _jwtService.GenerateToken(user);
                    break;

                default:

                    _logger.LogWarning(
                        "Invalid role {Role} for user {Email}",
                        role,
                        dto.Email);

                    throw new InvalidOperationException("Invalid role.");
            }

            _logger.LogInformation(
                "User {Email} logged in successfully as {Role}",
                dto.Email,
                role);

            return new AuthResponseDto
            {
                AccessToken = token,
                Role = role
            };
        }

        public async Task ChangePasswordAsync(
            string userId,
            ChangePasswordDto dto)
        {
            _logger.LogInformation(
                "Password change requested for UserId {UserId}",
                userId);

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                _logger.LogWarning(
                    "Password change failed. User {UserId} not found",
                    userId);

                throw new InvalidOperationException("User not found");
            }

            var result = await _userManager.ChangePasswordAsync(
                user,
                dto.CurrentPassword,
                dto.NewPassword);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));

                _logger.LogWarning(
                    "Password change failed for UserId {UserId}. Errors: {Errors}",
                    userId,
                    errors);

                throw new InvalidOperationException(errors);
            }

            _logger.LogInformation(
                "Password changed successfully for UserId {UserId}",
                userId);
        }
    }
}