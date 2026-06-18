using HealthCare.Api.DTOs.Appointment;
using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Services.Implementations;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Api.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly IAppointmentService _appointmentService;
        private readonly IHealthRecordService _healthRecordService;

        public AdminController(IPatientService patientService, IDoctorService doctorService, IAppointmentService appointmentService, IHealthRecordService healthRecordService)
        {
            _patientService = patientService;
            _doctorService = doctorService;
            _appointmentService = appointmentService;
            _healthRecordService = healthRecordService;
        }

        // Patient admin endpoints

        [HttpGet("/patients/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var result = await _patientService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("/patients")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllPatient([FromQuery] PatientFilter filter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _patientService.GetAllAsync(filter);
            return Ok(result);
        }

        [HttpPut("/patients/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] UpdatePatientDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _patientService.UpdateAsync(id, dto);
            return Ok();
        }

        [HttpPatch("/patients/{id}/status")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePatientStatus(int id, [FromBody] bool isActive)
        {
            await _patientService.UpdateStatusAsync(id, isActive);
            return Ok();
        }

        [HttpDelete("/patients/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            await _patientService.DeleteAsync(id);
            return Ok();
        }

        // Doctor admin endpoints

        [HttpGet("/doctors/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var result = await _doctorService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("/doctors")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllDoctor([FromQuery] DoctorFilter filter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _doctorService.GetAllAsync(filter);
            return Ok(result);
        }

        [HttpPut("/doctors/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] UpdateDoctorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _doctorService.UpdateAsync(id, dto);
            return Ok();
        }

        [HttpPatch("/doctors/{id}/status")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateDoctorStatus(int id, [FromBody] bool isActive)
        {
            await _doctorService.UpdateStatusAsync(id, isActive);
            return Ok();
        }

        [HttpDelete("/doctors/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            await _doctorService.DeleteAsync(id);
            return Ok();
        }

        // Appointment admin endpoints

        [HttpGet("/appointments")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAppointment([FromQuery] AppointmentFilter filter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _appointmentService.GetAllAsync(filter);
            return Ok(result);
        }

        [HttpGet("/appointments/report")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetDailyReport()
        {
            var result = await _appointmentService.GetDailyReport();
            return Ok(result);
        }

        // Health record admin endpoints

        [HttpDelete("/records/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteHealthRecord(int id)
        {
            await _healthRecordService.DeleteAsync(id);
            return Ok();
        }
    }
}
