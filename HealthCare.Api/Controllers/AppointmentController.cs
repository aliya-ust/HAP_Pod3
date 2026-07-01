using HealthCare.Shared.DTOs.Appointment;
using HealthCare.Api.Services.Interfaces;
using HealthCare.Api.Utilities;
using HealthCare.Shared;
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

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("book")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Patient")]
        public async Task<IActionResult> BookAppointment([FromBody] CreateAppointmentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse.Fail("Invalid data."));

            var patientId = ClaimsHelper.GetPatientId(User);
            await _appointmentService.AddAsync(dto, patientId);
            return Ok(ApiResponse.Ok("Appointment booked successfully"));
        }

        [HttpPut("{id}/status")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        public async Task<IActionResult> UpdateAppointmentStatus(int id, [FromBody] UpdateAppointmentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse.Fail("Invalid data."));

            await _appointmentService.UpdateStatusAsync(id, dto);
            return Ok(ApiResponse.Ok("Status updated successfully"));
        }

        [HttpGet("doctor/schedule")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        public async Task<IActionResult> GetDoctorSchedule([FromQuery] DateOnly date)
        {
            var doctorId = ClaimsHelper.GetDoctorId(User);
            var result = await _appointmentService.GetDoctorSchedule(date, doctorId);
            return Ok(ApiResponse<List<AppointmentListDto>>.Ok(result));
        }

        [HttpGet("patient/schedule")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Patient")]
        public async Task<IActionResult> GetPatientSchedule([FromQuery] DateOnly date)
        {
            var patientId = ClaimsHelper.GetPatientId(User);
            var result = await _appointmentService.GetPatientSchedule(date, patientId);
            return Ok(ApiResponse<List<AppointmentListDto>>.Ok(result));
        }

        [HttpGet("patient/upcoming")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Patient")]
        public async Task<IActionResult> GetAppointmentByPatient()
        {
            var patientId = ClaimsHelper.GetPatientId(User);
            var result = await _appointmentService.GetAppointmentByPatient(patientId);
            return Ok(ApiResponse<List<AppointmentListDto>>.Ok(result));
        }

        [HttpGet("doctor/upcoming")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        public async Task<IActionResult> GetAppointmentByDoctor()
        {
            var doctorId = ClaimsHelper.GetDoctorId(User);
            var result = await _appointmentService.GetAppointmentByDoctor(doctorId);
            return Ok(ApiResponse<List<AppointmentListDto>>.Ok(result));
        }

        [HttpGet("available-slots")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Patient")]
        public async Task<IActionResult> GetAvailableSlots([FromQuery] DateOnly date, [FromQuery] int doctorId)
        {
            var result = await _appointmentService.AvailableTimeSlots(date, doctorId);
            return Ok(ApiResponse<List<string>>.Ok(result));
        }
    }
}
