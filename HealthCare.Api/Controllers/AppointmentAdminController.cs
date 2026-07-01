using HealthCare.Shared.DTOs;
using HealthCare.Shared.DTOs.Appointment;
using HealthCare.Api.Services.Interfaces;
using HealthCare.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Api.Controllers
{
    [Route("api/admin/appointments")]
    [ApiController]
    public class AppointmentAdminController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentAdminController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetAllAppointment([FromQuery] AppointmentFilter filter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse.Fail("Invalid filter."));

            var result = await _appointmentService.GetAllAsync(filter);
            return Ok(ApiResponse<PagedResult<AppointmentListDto>>.Ok(result));
        }

        [HttpGet("report")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetReport([FromQuery] AppointmentReportFilter filter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse.Fail("Invalid filter."));

            var result = await _appointmentService.GetReport(filter);
            return Ok(ApiResponse<List<AppointmentReportDto>>.Ok(result));
        }

        [HttpGet("summary")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetSummary()
        {
            var result = await _appointmentService.GetSummaryAsync();
            return Ok(ApiResponse<AppointmentSummaryDto>.Ok(result));
        }
    }
}
