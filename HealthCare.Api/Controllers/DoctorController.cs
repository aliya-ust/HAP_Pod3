using HealthCare.Shared.DTOs.Doctor;
using HealthCare.Api.Services.Interfaces;
using HealthCare.Api.Utilities;
using HealthCare.Shared;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        public async Task<IActionResult> GetMyProfile()
        {
            var doctorId = ClaimsHelper.GetDoctorId(User);
            var result = await _doctorService.GetByIdAsync(doctorId);
            return Ok(ApiResponse<DoctorListDto>.Ok(result));
        }

        [HttpPut("profile")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        public async Task<IActionResult> UpdateDoctor([FromBody] UpdateDoctorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse.Fail("Invalid data."));

            var doctorId = ClaimsHelper.GetDoctorId(User);
            await _doctorService.UpdateAsync(doctorId, dto);
            return Ok(ApiResponse.Ok("Profile updated successfully"));
        }

        [HttpGet("available")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Patient")]
        public async Task<IActionResult> GetAvailableDoctors([FromQuery] string specialisation, [FromQuery] DateOnly date)
        {
            var result = await _doctorService.AvailableDoctors(specialisation, date);
            return Ok(ApiResponse<List<DoctorListDto>>.Ok(result));
        }

        [HttpPost("leaves")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        public async Task<IActionResult> AddDoctorLeaves([FromBody] List<CreateLeaveDto> leaves)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse.Fail("Invalid data."));

            var doctorId = ClaimsHelper.GetDoctorId(User);
            var result = await _doctorService.CreateLeave(doctorId, leaves);
            return Ok(ApiResponse<CreateLeaveResultDto>.Ok(result));
        }
    }
}
