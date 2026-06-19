using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // Register Patient
        [HttpPost("register/patient")]
        public async Task<IActionResult> RegisterPatient([FromBody] CreatePatientDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _authService.RegisterPatientAsync(dto);

            return Ok(new
            {
                message = "Patient registered successfully."
            });
        }

        // Register Doctor
        [HttpPost("register/doctor")]
        public async Task<IActionResult> RegisterDoctor([FromBody] CreateDoctorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _authService.RegisterDoctorAsync(dto);

            return Ok(new
            {
                message = "Doctor registered successfully."
            });
        }

        // Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _authService.LoginAsync(dto);

            return Ok(response);
        }
    }
}