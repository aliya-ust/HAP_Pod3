using HealthCare.Api.DTOs.Auth;
using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            return Ok("Registration successful");
        }

        [HttpPost("register/doctor")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterDoctor(CreateDoctorDto dto)
        {
            await _authService.RegisterDoctorAsync(dto);
            return Ok("Registration successful");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var response = await _authService.LoginAsync(dto);
            return Ok(response);
        }
    }
}
