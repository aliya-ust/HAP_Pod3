using HealthCare.Api.DTOs.Appointment;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Api.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAppointment([FromQuery] AppointmentFilter filter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _appointmentService.GetAllAsync(filter);
            return Ok(result);
        }

        [HttpPost("book")]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> BookAppointment([FromBody] CreateAppointmentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var patientId = GetPatientIdFromClaims();
            await _appointmentService.AddAsync(dto, patientId);
            return Ok();
        }

        [HttpPut("{id}/status")]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> UpdateAppointmentStatus(int id, [FromBody] UpdateAppointmentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _appointmentService.UpdateStatusAsync(id, dto);
            return Ok();
        }

        [HttpGet("report")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetDailyReport()
        {
            var result = await _appointmentService.GetDailyReport();
            return Ok(result);
        }

        [HttpGet("doctor/schedule")]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> GetDoctorSchedule([FromQuery] DateOnly date)
        {
            var doctorId = GetDoctorIdFromClaims();
            var result = await _appointmentService.GetDoctorSchedule(date, doctorId);
            return Ok(result);
        }

        [HttpGet("patient/schedule")]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> GetPatientSchedule([FromQuery] DateOnly date)
        {
            var patientId = GetPatientIdFromClaims();
            var result = await _appointmentService.GetPatientSchedule(date, patientId);
            return Ok(result);
        }

        [HttpGet("patient/upcoming")]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> GetAppointmentByPatient()
        {
            var patientId = GetPatientIdFromClaims();
            var result = await _appointmentService.GetAppointmentByPatient(patientId);
            return Ok(result);
        }

        [HttpGet("doctor/upcoming")]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> GetAppointmentByDoctor()
        {
            var doctorId = GetDoctorIdFromClaims();
            var result = await _appointmentService.GetAppointmentByDoctor(doctorId);
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
