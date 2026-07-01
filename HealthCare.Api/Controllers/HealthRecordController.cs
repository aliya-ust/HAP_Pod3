using HealthCare.Shared.DTOs.HealthRecord;
using HealthCare.Api.Services.Interfaces;
using HealthCare.Api.Utilities;
using HealthCare.Shared;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        public async Task<IActionResult> CreateHealthRecord([FromBody] CreateHealthRecordDto dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(ApiResponse.Fail("Invalid data.", errors));
            }

            var doctorId = ClaimsHelper.GetDoctorId(User);
            await _healthRecordService.AddAsync(doctorId, dto);
            return Ok(ApiResponse.Ok("Health record created successfully"));
        }

        [HttpGet("by-appointment/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        public async Task<IActionResult> GetHealthRecordByAppointment(int id)
        {
            var result = await _healthRecordService.GetHealthRecordByAppointment(id);
            return Ok(ApiResponse<List<HealthRecordListDto>>.Ok(result));
        }

        [HttpGet("by-patient/{patientId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        public async Task<IActionResult> GetHealthRecordsByPatient(int patientId)
        {
            var result = await _healthRecordService.GetHealthRecordByPatient(patientId);
            return Ok(ApiResponse<List<HealthRecordListDto>>.Ok(result));
        }

        [HttpGet("my-records")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Patient")]
        public async Task<IActionResult> GetHealthRecordByPatient()
        {
            var patientId = ClaimsHelper.GetPatientId(User);
            var result = await _healthRecordService.GetHealthRecordByPatient(patientId);
            return Ok(ApiResponse<List<HealthRecordListDto>>.Ok(result));
        }
    }
}
