using HealthCare.Api.DTOs.Appointment;
using HealthCare.Api.Services.Interfaces;
using HealthCare.Shared.DTOs.Appointment;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Api.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService, IDoctorService doctorService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("book")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> BookAppointment([FromBody] CreateAppointmentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var patientId = GetPatientIdFromClaims();
            await _appointmentService.AddAsync(dto, patientId);
            return Ok(new { message = "Appointment booked Successfully" });
        }

        [HttpPut("{id}/status")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> UpdateAppointmentStatus(int id, [FromBody] UpdateAppointmentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _appointmentService.UpdateStatusAsync(id, dto);
            return Ok();
        }

        [HttpGet("doctor/schedule")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> GetDoctorSchedule([FromQuery] DateOnly date)
        {
            var doctorId = GetDoctorIdFromClaims();
            var result = await _appointmentService.GetDoctorSchedule(date, doctorId);
            return Ok(result);
        }

        [HttpGet("available-slots")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> GetAvailableTimeSlots(
     [FromQuery] DateOnly date,
     [FromQuery] int doctorId)
        {
            try
            {
                var result = await _appointmentService.AvailableTimeSlots(date, doctorId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }


        [HttpGet("patient/schedule")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> GetPatientSchedule([FromQuery] DateOnly date)
        {
            var patientId = GetPatientIdFromClaims();
            var result = await _appointmentService.GetPatientSchedule(date, patientId);
            return Ok(result);
        }

        [HttpGet("patient/upcoming")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> GetAppointmentByPatient()
        {
            var patientId = GetPatientIdFromClaims();
            var result = await _appointmentService.GetAppointmentByPatient(patientId);
            return Ok(result);
        }

        [HttpGet("doctor/upcoming")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

            if (claim == null)
            {
                throw new UnauthorizedAccessException("PatientId claim not found in token.");
            }


            return int.Parse(claim.Value);
        }

        private int GetDoctorIdFromClaims()
        {
            var claim = User.FindFirst("DoctorId")
                ?? throw new InvalidOperationException("DoctorId claim not found in token.");


            if (claim == null)
            {
                throw new UnauthorizedAccessException("DoctorId claim not found in token.");
            }


            return int.Parse(claim.Value);
        }
    }
}
