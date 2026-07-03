using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Auth;
using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Implementation;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Numerics;

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

        public AuthService(
            UserManager<User> userManager,
            IMapper mapper,
            IPatientRepository patientRepository,
            IDoctorRepository doctorRepository,
            IJwtService jwtService,
            HealthCareDbContext context)
        {
            _userManager = userManager;
            _mapper = mapper;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _jwtService = jwtService;
            _context = context;
        }

        private async Task<User> CreateUserWithRoleAsync(
            string email,
            string password,
            string role)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);

            if (existingUser != null)
                throw new InvalidOperationException("Email is already registered.");

            var user = new User
            {
                UserName = email,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException(
                    string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            await _userManager.AddToRoleAsync(user, role);

            return user;
        }

        public async Task RegisterPatientAsync(CreatePatientDto dto)
        {
            var user = await CreateUserWithRoleAsync(
                dto.Email,
                dto.Password,
                "Patient");

            var patient = _mapper.Map<Patient>(dto);
            patient.UserId = user.Id;

            await _patientRepository.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task RegisterDoctorAsync(CreateDoctorDto dto)
        {
            var user = await CreateUserWithRoleAsync(
                dto.Email,
                dto.Password,
                "Doctor");

            var doctor = _mapper.Map<Doctor>(dto);
            doctor.UserId = user.Id;

            await _doctorRepository.AddAsync(doctor);
            await _context.SaveChangesAsync();
            await _doctorRepository.CreateSlots(doctor.DoctorId, dto.TimeSlots);
            await _context.SaveChangesAsync();
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null)
                throw new UnauthorizedAccessException("Invalid credentials.");

            var passwordValid =
                await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!passwordValid)
                throw new UnauthorizedAccessException("Invalid credentials.");

            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Count == 0)
                throw new InvalidOperationException("No role assigned.");

            var role = roles[0];
            string token;

            switch (role)
            {
                case "Patient":
                    var patient = await _patientRepository.GetByUserIdAsync(user.Id);

                    if (patient == null)
                        throw new InvalidOperationException("Patient profile not found.");

                    token = await _jwtService.GenerateToken(
                        user,
                        patientId: patient.PatientId);

                    break;

                case "Doctor":
                    var doctor = await _doctorRepository.GetByUserIdAsync(user.Id);

                    if (doctor == null)
                        throw new InvalidOperationException("Doctor profile not found.");

                    token = await _jwtService.GenerateToken(
                        user,
                        doctorId: doctor.DoctorId);

                    break;

                case "Admin":
                    token = await _jwtService.GenerateToken(user);
                    break;

                default:
                    throw new InvalidOperationException("Invalid role.");
            }

            return new AuthResponseDto
            {
                AccessToken = token,
                Role = role
            };
        }

        public async Task ChangePasswordAsync(string userId, ChangePasswordDto dto)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                throw new InvalidOperationException("User not found");

            var result = await _userManager.ChangePasswordAsync(
                user,
                dto.CurrentPassword,
                dto.NewPassword
            );

            if (!result.Succeeded)
                throw new InvalidOperationException(
                    string.Join(", ", result.Errors.Select(e => e.Description))
                );
        }

    }
}