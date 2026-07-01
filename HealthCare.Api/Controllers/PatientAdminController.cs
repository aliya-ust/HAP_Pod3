using HealthCare.Shared.DTOs;
using HealthCare.Shared.DTOs.Patient;
using HealthCare.Api.Services.Interfaces;
using HealthCare.Shared;
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

        public PatientAdminController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var result = await _patientService.GetByIdAsync(id);
            return Ok(ApiResponse<PatientListDto>.Ok(result));
        }

        [HttpGet("")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetAllPatient([FromQuery] PatientFilter filter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse.Fail("Invalid filter."));

            var result = await _patientService.GetAllAsync(filter);
            return Ok(ApiResponse<PagedResult<PatientListDto>>.Ok(result));
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] UpdatePatientDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse.Fail("Invalid data."));

            await _patientService.UpdateAsync(id, dto);
            return Ok(ApiResponse.Ok("Patient updated successfully"));
        }

        [HttpPatch("{id}/status")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> UpdatePatientStatus(int id, [FromBody] bool isActive)
        {
            await _patientService.UpdateStatusAsync(id, isActive);
            return Ok(ApiResponse.Ok("Status updated successfully"));
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            await _patientService.DeleteAsync(id);
            return Ok(ApiResponse.Ok("Patient deleted successfully"));
        }

        [HttpGet("summary")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetSummary()
        {
            var result = await _patientService.GetSummaryAsync();
            return Ok(ApiResponse<PatientSummaryDto>.Ok(result));
        }
    }
}
