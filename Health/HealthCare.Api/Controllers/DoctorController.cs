using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealthCare.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        private int GetDoctorIdFromClaims()
        {
            var claim = User.FindFirst("DoctorId")
                ?? throw new InvalidOperationException("DoctorId claim not found in token.");

            return int.Parse(claim.Value);
        }

        // View own profile
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var doctorId = GetDoctorIdFromClaims();
            var doctor = await _doctorService.GetByIdAsync(doctorId);
            return Ok(doctor);
        }

        // Edit own profile
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile(UpdateDoctorDto dto)
        {
            var doctorId = GetDoctorIdFromClaims();

            await _doctorService.UpdateAsync(doctorId, dto);

            return Ok(new
            {
                Message = "Profile updated successfully."
            });
        }

        // Add doctor leaves
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        [HttpPost("leave")]
        public async Task<IActionResult> CreateLeave([FromBody] List<CreateLeaveDto> leaves)
        {
            var doctorId = GetDoctorIdFromClaims();

            var result = await _doctorService.CreateLeave(doctorId, leaves);

            return Ok(result);
        }

        // Get available doctors (for patients)
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Patient")]
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableDoctors(
            [FromQuery] string specialisation,
            [FromQuery] DateOnly date)
        {
            var doctors = await _doctorService.AvailableDoctors(specialisation, date);

            return Ok(doctors);
        }
    }
}