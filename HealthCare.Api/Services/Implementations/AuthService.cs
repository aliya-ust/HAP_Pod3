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

        public async Task RegisterPatientAsync(CreatePatientDto dto)
        {
            // Check email
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
                throw new Exception("Email already exists");

            // Create Identity user
            var user = new User
            {
                UserName = dto.Email,
                Email = dto.Email
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

            // Assign role
            await _userManager.AddToRoleAsync(user, "Patient");

            // Create Patient entity
            var patient = _mapper.Map<Patient>(dto);
            patient.UserId = user.Id;

            await _patientRepo.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task RegisterDoctorAsync(CreateDoctorDto dto)
        {
            // Check email
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
                throw new Exception("Email already exists");

            // Create Identity user
            var user = new User
            {
                UserName = dto.Email,
                Email = dto.Email
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

            // Assign role
            await _userManager.AddToRoleAsync(user, "Doctor");

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
                throw new Exception("Invalid credentials");

            // Verify password
            var isValid = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!isValid)
                throw new Exception("Invalid credentials");

            // Get roles
            var roles = await _userManager.GetRolesAsync(user);

            // Generate JWT
            var token = _jwtService.GenerateToken(user, roles);

            return new AuthResponseDto
            {
                AccessToken = token,
                Role = roles.FirstOrDefault()
            };
        }
    }
}
