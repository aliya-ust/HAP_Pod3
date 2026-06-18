using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> GetMyProfile()
        {
            var doctorId = GetDoctorIdFromClaims();
            var result = await _doctorService.GetByIdAsync(doctorId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var result = await _doctorService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllDoctor([FromQuery] DoctorFilter filter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _doctorService.GetAllAsync(filter);
            return Ok(result);
        }

        [HttpPut("profile")]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> UpdateDoctor([FromBody] UpdateDoctorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var doctorId = GetDoctorIdFromClaims();
            await _doctorService.UpdateAsync(doctorId, dto);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] UpdateDoctorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _doctorService.UpdateAsync(id, dto);
            return Ok();
        }

        [HttpPatch("{id}/status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePatientStatus(int id, [FromBody] bool isActive)
        {
            await _doctorService.UpdateStatusAsync(id, isActive);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            await _doctorService.DeleteAsync(id);
            return Ok();
        }

        private int GetDoctorIdFromClaims()
        {
            var claim = User.FindFirst("DoctorId")
                ?? throw new InvalidOperationException("DoctorId claim not found in token.");

            return int.Parse(claim.Value);
        }
    }
}
