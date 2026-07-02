using HealthCare.Api.DTOs.Appointment;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealthCare.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        private int GetPatientIdFromClaims()
        {
            var claim = User.FindFirst("PatientId")
                ?? throw new InvalidOperationException("PatientId claim not found.");

            return int.Parse(claim.Value);
        }

        private int GetDoctorIdFromClaims()
        {
            var claim = User.FindFirst("DoctorId")
                ?? throw new InvalidOperationException("DoctorId claim not found.");

            return int.Parse(claim.Value);
        }

        // Get available doctors for a specific date and specialization
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Patient")]
        [HttpGet("available-doctors")]
        public async Task<IActionResult> GetAvailableDoctors(DateOnly date,string specialization)
        {
            return Ok(await _appointmentService
                .GetAvailableDoctorsAsync(date, specialization));
        }

        // Get available time slots for a specific doctor on a specific date
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Patient")]
        [HttpGet("available-slots")]
        public async Task<IActionResult> GetAvailableSlots(int doctorId, DateOnly date)
        {
            return Ok(await _appointmentService
                .GetAvailableSlotsAsync(doctorId, date));
        }

        // Patient - Book appointment
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Patient")]
        [HttpPost]
        public async Task<IActionResult> BookAppointment(CreateAppointmentDto dto)
        {
            var patientId = GetPatientIdFromClaims();

            await _appointmentService.AddAsync(dto, patientId);

            return Ok(new { Message = "Appointment booked successfully." });
        }

        // Patient - Get today's/future schedule
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Patient")]
        [HttpGet("patient/schedule")]
        public async Task<IActionResult> GetPatientSchedule([FromQuery] DateOnly date)
        {
            var patientId = GetPatientIdFromClaims();

            var result = await _appointmentService.GetPatientSchedule(date, patientId);

            return Ok(result);
        }

        // Patient - Get own appointments
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Patient")]
        [HttpGet("patient")]
        public async Task<IActionResult> GetAppointmentsByPatient()
        {
            var patientId = GetPatientIdFromClaims();

            var result = await _appointmentService.GetAppointmentByPatient(patientId);

            return Ok(result);
        }

        // Doctor - Update appointment status
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateAppointmentStatus(
            int id,
            UpdateAppointmentDto dto)
        {
            await _appointmentService.UpdateStatusAsync(id, dto);

            return Ok(new { Message = "Appointment status updated successfully." });
        }

        // Doctor - Get schedule
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        [HttpGet("doctor/schedule")]
        public async Task<IActionResult> GetDoctorSchedule([FromQuery] DateOnly date)
        {
            var doctorId = GetDoctorIdFromClaims();

            var result = await _appointmentService.GetDoctorSchedule(date, doctorId);

            return Ok(result);
        }

        // Doctor - Get own appointments
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        [HttpGet("doctor")]
        public async Task<IActionResult> GetAppointmentsByDoctor()
        {
            var doctorId = GetDoctorIdFromClaims();

            var result = await _appointmentService.GetAppointmentByDoctor(doctorId);

            return Ok(result);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        [HttpPut("{id}/confirm")]
        public async Task<IActionResult> ConfirmAppointment(int id)
        {
            await _appointmentService.ConfirmAppointment(id);

            return Ok();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelAppointment(int id)
        {
            await _appointmentService.CancelAppointment(id);

            return Ok();
        }
    }
}