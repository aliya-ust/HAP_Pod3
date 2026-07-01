using HealthCare.Shared.DTOs;
using HealthCare.Shared.DTOs.Doctor;
using HealthCare.Api.Services.Interfaces;
using HealthCare.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Api.Controllers
{
    [Route("api/admin/doctors")]
    [ApiController]
    public class DoctorAdminController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorAdminController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var result = await _doctorService.GetByIdAsync(id);
            return Ok(ApiResponse<DoctorListDto>.Ok(result));
        }

        [HttpGet("")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetAllDoctor([FromQuery] DoctorFilter filter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse.Fail("Invalid filter."));

            var result = await _doctorService.GetAllAsync(filter);
            return Ok(ApiResponse<PagedResult<DoctorListDto>>.Ok(result));
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] UpdateDoctorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse.Fail("Invalid data."));

            await _doctorService.UpdateAsync(id, dto);
            return Ok(ApiResponse.Ok("Doctor updated successfully"));
        }

        [HttpPatch("{id}/status")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> UpdateDoctorStatus(int id, [FromBody] bool isActive)
        {
            await _doctorService.UpdateStatusAsync(id, isActive);
            return Ok(ApiResponse.Ok("Status updated successfully"));
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            await _doctorService.DeleteAsync(id);
            return Ok(ApiResponse.Ok("Doctor deleted successfully"));
        }

        [HttpGet("summary")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetSummary()
        {
            var result = await _doctorService.GetSummaryAsync();
            return Ok(ApiResponse<DoctorSummaryDto>.Ok(result));
        }
    }
}
