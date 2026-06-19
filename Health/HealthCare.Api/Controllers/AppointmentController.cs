using HealthCare.Api.DTOs.Appointment;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Api.Controllers
{
    [Route("api/appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromQuery] AppointmentFilter filter)
        {
            var result = await _service.GetAllAsync(filter);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
            Roles = "Patient")]
        public async Task<IActionResult> Create([FromBody] CreateAppointmentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var patientIdClaim = User.FindFirst("PatientId")?.Value;

            if (string.IsNullOrEmpty(patientIdClaim))
            {
                return Unauthorized();
            }

            int patientId = int.Parse(patientIdClaim);

            await _service.AddAsync(dto, patientId);

            return Ok(new
            {
                message = "Appointment booked successfully."
            });
        }

        [HttpPut("{id:int}")]
        [Authorize(
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
            Roles = "Admin,Doctor")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAppointmentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.UpdateAsync(id, dto);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [Authorize(
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
            Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("available-slots")]
        [AllowAnonymous]
        public async Task<IActionResult> AvailableTimeSlots(
            [FromQuery] DateOnly date,
            [FromQuery] int doctorId)
        {
            var result = await _service.AvailableTimeSlots(date, doctorId);
            return Ok(result);
        }

        [HttpGet("is-available")]
        [AllowAnonymous]
        public async Task<IActionResult> IsAvailable(
            [FromQuery] DateOnly date,
            [FromQuery] int doctorId,
            [FromQuery] string timeSlot)
        {
            var result = await _service.IsAvailable(date, doctorId, timeSlot);
            return Ok(result);
        }

        [HttpGet("daily-report")]
        [Authorize(
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
            Roles = "Admin")]
        public async Task<IActionResult> GetDailyReport()
        {
            var result = await _service.GetDailyReport();
            return Ok(result);
        }

        [HttpGet("doctor-schedule")]
        [Authorize(
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
            Roles = "Admin,Doctor")]
        public async Task<IActionResult> GetDoctorSchedule(
            [FromQuery] DateOnly date,
            [FromQuery] int doctorId)
        {
            var result = await _service.GetDoctorSchedule(date, doctorId);
            return Ok(result);
        }

        [HttpGet("patient-schedule")]
        [Authorize(
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
            Roles = "Admin,Patient")]
        public async Task<IActionResult> GetPatientSchedule(
            [FromQuery] DateOnly date,
            [FromQuery] int patientId)
        {
            var result = await _service.GetPatientSchedule(date, patientId);
            return Ok(result);
        }

        [HttpGet("patient/{patientId:int}")]
        [Authorize(
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
            Roles = "Admin,Patient")]
        public async Task<IActionResult> GetAppointmentByPatient(int patientId)
        {
            var result = await _service.GetAppointmentByPatient(patientId);
            return Ok(result);
        }

        [HttpGet("doctor/{doctorId:int}")]
        [Authorize(
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
            Roles = "Admin,Doctor")]
        public async Task<IActionResult> GetAppointmentByDoctor(int doctorId)
        {
            var result = await _service.GetAppointmentByDoctor(doctorId);
            return Ok(result);
        }
    }
}
