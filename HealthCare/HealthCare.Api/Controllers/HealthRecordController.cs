using HealthCare.Api.DTOs.HealthRecord;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Api.Controllers
{
    [Route("api/records")]
    [ApiController]
    public class HealthRecordController : ControllerBase
    {
        private readonly IHealthRecordService _healthRecordService;

        public HealthRecordController(IHealthRecordService healthRecordService)
        {
            _healthRecordService = healthRecordService;
        }

        [HttpPost("create")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> CreateHealthRecord([FromBody] CreateHealthRecordDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var doctorId = GetDoctorIdFromClaims();
            await _healthRecordService.AddAsync(doctorId, dto);
            return Ok();
        }

        [HttpGet("by-patient/{patientId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> GetHealthRecordOfPatient(int patientId)
        {
            var result = await _healthRecordService.GetHealthRecordByPatient(patientId);
            return Ok(result);
        }

        [HttpGet("my-records")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> GetHealthRecordByPatient()
        {
            var patientId = GetPatientIdFromClaims();
            var result = await _healthRecordService.GetHealthRecordByPatient(patientId);
            return Ok(result);
        }

        private int GetPatientIdFromClaims()
        {
            var claim = User.FindFirst("PatientId")
                ?? throw new InvalidOperationException("PatientId claim not found in token.");

            return int.Parse(claim.Value);
        }

        private int GetDoctorIdFromClaims()
        {
            var claim = User.FindFirst("DoctorId")
                ?? throw new InvalidOperationException("DoctorId claim not found in token.");

            return int.Parse(claim.Value);
        }
    }
}