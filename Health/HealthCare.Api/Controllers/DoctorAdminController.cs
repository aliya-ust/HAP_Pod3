using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Api.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class DoctorAdminController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorAdminController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // Search doctor by id
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doctor = await _doctorService.GetByIdAsync(id);
            return Ok(doctor);
        }

        // Get all doctors
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] DoctorFilter filter)
        {
            var doctors = await _doctorService.GetAllAsync(filter);
            return Ok(doctors);
        }

        // Update doctor
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateDoctorDto dto)
        {
            await _doctorService.UpdateAsync(id, dto);

            return Ok(new
            {
                Message = "Doctor updated successfully."
            });
        }

        // Update doctor status
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromQuery] bool isActive)
        {
            await _doctorService.UpdateStatusAsync(id, isActive);

            return Ok(new
            {
                Message = "Doctor status updated successfully."
            });
        }

        // Delete doctor
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _doctorService.DeleteAsync(id);

            return Ok(new
            {
                Message = "Doctor deleted successfully."
            });
        }
    }
}