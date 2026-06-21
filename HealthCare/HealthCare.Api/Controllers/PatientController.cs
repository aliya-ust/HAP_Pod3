using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Services.Interfaces;
using HealthCare.Api.Exceptions;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> GetMyProfile()
        {
            var patientId = GetPatientIdFromClaims();
            var result = await _patientService.GetByIdAsync(patientId);
            return Ok(result);
        }
          
            
            
        

        [HttpPut("profile")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> UpdatePatient([FromBody] UpdatePatientDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var patientId = GetPatientIdFromClaims();
            await _patientService.UpdateAsync(patientId, dto);
            return Ok();
        }

        private int GetPatientIdFromClaims()
        {
            var claim = User.FindFirst("PatientId")
                ?? throw new InvalidOperationException("PatientId claim not found in token.");

            return int.Parse(claim.Value);
        }
    }
}