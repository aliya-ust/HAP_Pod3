using HealthCare.Shared.DTOs.Patient;
using HealthCare.Api.Services.Interfaces;
using HealthCare.Api.Utilities;
using HealthCare.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Api.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("profile")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Patient")]
        public async Task<IActionResult> GetMyProfile()
        {
            var patientId = ClaimsHelper.GetPatientId(User);
            var result = await _patientService.GetByIdAsync(patientId);
            return Ok(ApiResponse<PatientListDto>.Ok(result));
        }

        [HttpPut("profile")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Patient")]
        public async Task<IActionResult> UpdatePatient([FromBody] UpdatePatientDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse.Fail("Invalid data."));

            var patientId = ClaimsHelper.GetPatientId(User);
            await _patientService.UpdateAsync(patientId, dto);
            return Ok(ApiResponse.Ok("Profile updated successfully"));
        }
    }
}
