using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var result = await _doctorService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllDoctor([FromQuery] DoctorFilter filter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _doctorService.GetAllAsync(filter);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] UpdateDoctorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _doctorService.UpdateAsync(id, dto);
            return Ok();
        }

        [HttpPatch("{id}/status")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateDoctorStatus(int id, [FromBody] bool isActive)
        {
            await _doctorService.UpdateStatusAsync(id, isActive);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            await _doctorService.DeleteAsync(id);
            return Ok();
        }
    }
}
