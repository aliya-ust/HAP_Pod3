using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Api.Controllers
{
    [ApiController]
    [Route("api/patient")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Patient")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // Get PatientId from JWT claims
        private int GetPatientIdFromClaims()
        {
            var claim = User.FindFirst("PatientId")
                ?? throw new InvalidOperationException("PatientId claim not found in token.");

            return int.Parse(claim.Value);
        }

        // Patient - Get own profile
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var patientId = GetPatientIdFromClaims();

            var result = await _patientService.GetByIdAsync(patientId);

            return Ok(result);
        }

        // Patient - Update own profile
        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile(UpdatePatientDto dto)
        {
            var patientId = GetPatientIdFromClaims();

            await _patientService.UpdateAsync(patientId, dto);

            return Ok(new { message = "Profile updated successfully." });
        }
    }
}