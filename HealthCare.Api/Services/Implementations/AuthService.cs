using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.DTOs.Auth;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HealthCare.Api.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepo;
        private readonly IDoctorRepository _doctorRepo;
        private readonly IJwtService _jwtService;
        private readonly HealthCareDbContext _context;

        public AuthService(
            UserManager<User> userManager,
            IMapper mapper,
            IPatientRepository patientRepo,
            IDoctorRepository doctorRepo,
            IJwtService jwtService,
            HealthCareDbContext context)
        {
            _userManager = userManager;
            _mapper = mapper;
            _patientRepo = patientRepo;
            _doctorRepo = doctorRepo;
            _jwtService = jwtService;
            _context = context;
        }

        private async Task<User> CreateUserWithRoleAsync(string email, string password, string role)
        {
            // Check email
            var existingUser = await _userManager.FindByEmailAsync(email);
            if (existingUser != null)
                throw new InvalidOperationException("Email already in use");

            // Create user
            var user = new User
            {
                UserName = email,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
                throw new InvalidOperationException(string.Join(", ", result.Errors.Select(e => e.Description)));

            // Assign role
            await _userManager.AddToRoleAsync(user, role);

            return user;
        }

        public async Task RegisterPatientAsync(CreatePatientDto dto)
        {
            var user = await CreateUserWithRoleAsync(dto.Email, dto.Password, "Patient");

            // Create Patient entity
            var patient = _mapper.Map<Patient>(dto);
            patient.UserId = user.Id;

            await _patientRepo.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task RegisterDoctorAsync(CreateDoctorDto dto)
        {
            var user = await CreateUserWithRoleAsync(dto.Email, dto.Password, "Doctor");

            // Create Patient entity
            var doctor = _mapper.Map<Doctor>(dto);
            doctor.UserId = user.Id;

            await _doctorRepo.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            // Find user
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                throw new InvalidOperationException("Email already in use");

            // Verify password
            var isValid = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!isValid)
                throw new UnauthorizedAccessException("Invalid credentials");

            // Get roles
            var roles = await _userManager.GetRolesAsync(user);
            if (roles == null || !roles.Any())
            {
                throw new InvalidOperationException("Role is not assigned.");
            }

            // Generate JWT
            var token = await _jwtService.GenerateToken(user);

            return new AuthResponseDto
            {
                AccessToken = token,
                Role = roles[0]
            };
        }
    }
}
