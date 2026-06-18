using HealthCare.Api.DTOs.HealthRecord;
using HealthCare.Api.Services.Interfaces;
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
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> CreateHealthRecord([FromBody] CreateHealthRecordDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _healthRecordService.AddAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteHealthRecord(int id)
        {
            await _healthRecordService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("by-appointment/{id}")]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> GetHealthRecordByAppointment(int id)
        {
            var result = await _healthRecordService.GetHealthRecordByAppointment(id);
            return Ok(result);
        }

        [HttpGet("my-records")]
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
    }
}
