using HealthCare.Shared.DTOs.Auth;
using HealthCare.Shared.DTOs.Doctor;
using HealthCare.Shared.DTOs.Patient;
using HealthCare.Api.Services.Interfaces;
using HealthCare.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealthCare.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register/patient")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterPatient(CreatePatientDto dto)
        {
            await _authService.RegisterPatientAsync(dto);
            return Ok(ApiResponse.Ok("Registration successful"));
        }

        [HttpPost("register/doctor")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> RegisterDoctor(CreateDoctorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse.Fail("Validation failed."));

            await _authService.RegisterDoctorAsync(dto);
            return Ok(ApiResponse.Ok("Registration successful"));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var response = await _authService.LoginAsync(dto);
            return Ok(ApiResponse<AuthResponseDto>.Ok(response));
        }

        [HttpPost("change-password")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
                return BadRequest(ApiResponse.Fail("User ID claim not found."));

            await _authService.ChangePasswordAsync(userId, dto);

            return Ok(ApiResponse.Ok("Password changed successfully"));
        }

    }
}
