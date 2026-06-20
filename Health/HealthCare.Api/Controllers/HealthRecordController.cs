using HealthCare.Api.DTOs.HealthRecord;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealthCare.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthRecordController : ControllerBase
    {
        private readonly IHealthRecordService _healthRecordService;

        public HealthRecordController(IHealthRecordService healthRecordService)
        {
            _healthRecordService = healthRecordService;
        }

        private int GetDoctorIdFromClaims()
        {
            var claim = User.FindFirst("DoctorId")
                ?? throw new InvalidOperationException("DoctorId claim not found in token.");

            return int.Parse(claim.Value);
        }

        private int GetPatientIdFromClaims()
        {
            var claim = User.FindFirst("PatientId")
                ?? throw new InvalidOperationException("PatientId claim not found in token.");

            return int.Parse(claim.Value);
        }

        // Doctor - Create health record
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateHealthRecordDto dto)
        {
            var doctorId = GetDoctorIdFromClaims();

            await _healthRecordService.AddAsync(doctorId, dto);

            return Ok(new
            {
                Message = "Health record created successfully."
            });
        }

        // Doctor - Get health record by appointment id
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        [HttpGet("appointment/{appointmentId}")]
        public async Task<IActionResult> GetByAppointment(int appointmentId)
        {
            var records = await _healthRecordService.GetHealthRecordByAppointment(appointmentId);

            return Ok(records);
        }

        // Patient - Get own health records
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Patient")]
        [HttpGet("patient")]
        public async Task<IActionResult> GetByPatient()
        {
            var patientId = GetPatientIdFromClaims();

            var records = await _healthRecordService.GetHealthRecordByPatient(patientId);

            return Ok(records);
        }
    }
}