using HealthCare.Shared.DTOs.Patient;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Api.Controllers
{
    [Route("api/admin/patients")]
    [ApiController]
    public class PatientAdminController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientAdminController(IPatientService patientService, IAuthService authService)
        {
            _patientService = patientService;
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var result = await _patientService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllPatient([FromQuery] PatientFilter filter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _patientService.GetAllAsync(filter);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] UpdatePatientDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var patient = await _patientService.GetByIdAsync(id);

            if (patient == null)
                return NotFound("Patient not found");

            await _patientService.UpdateAsync(id, dto);

            return Ok(new { message = "Patient updated successfully" });
        }

        [HttpPatch("{id}/status")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePatientStatus(int id, [FromBody] bool isActive)
        {
            await _patientService.UpdateStatusAsync(id, isActive);
            return Ok(new { message = "Patient status updated successfully" });
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            await _patientService.DeleteAsync(id);
            return Ok(new { message = "Patient deleted successfully" });
        }


        [HttpGet("count/recent")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetRecentPatientCount()
        {
            var result = await _patientService.GetRecentPatientCount();
            return Ok(result);
        }
    }
}