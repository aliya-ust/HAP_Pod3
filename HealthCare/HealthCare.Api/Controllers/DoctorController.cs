using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Api.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("profile")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> GetMyProfile()
        {
            var doctorId = GetDoctorIdFromClaims();

            var result = await _doctorService.GetMyProfileAsync(doctorId);

            if (result == null)
            {
                return NotFound("Doctor profile not found.");
            }

            return Ok(result);
        } 

        [HttpPut("profile")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> UpdateDoctor([FromBody] UpdateDoctorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var doctorId = GetDoctorIdFromClaims();
            await _doctorService.UpdateAsync(doctorId, dto);
            return Ok();
        }

        [HttpGet("available")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> GetAvailableDoctors([FromQuery] string specialisation, [FromQuery] DateOnly date)
        {
            var result = await _doctorService.AvailableDoctors(specialisation, date);
            return Ok(result);
        }

        [HttpPost("leaves")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> AddDoctorLeaves([FromBody] List<CreateLeaveDto> leaves)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var doctorId = GetDoctorIdFromClaims();
            var result = await _doctorService.CreateLeave(doctorId, leaves);
            return Ok(result);
        }

        [HttpGet("summary")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> GetDoctorSummary()
        {
            var result = await _doctorService.GetSummaryAsync();
            return Ok(result);
        }

        private int GetDoctorIdFromClaims()
        {
            var claim = User.FindFirst("DoctorId")
                ?? throw new InvalidOperationException("DoctorId claim not found in token.");

            return int.Parse(claim.Value);
        }
        [HttpGet("dashboard-summary")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> GetDashboardSummary()
        {
            var doctorId = GetDoctorIdFromClaims();

            var result = await _doctorService.GetDashboardSummaryAsync(doctorId);

            return Ok(result); 
        }
    }
}