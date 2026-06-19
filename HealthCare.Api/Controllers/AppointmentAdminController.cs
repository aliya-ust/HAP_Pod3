using HealthCare.Api.DTOs.Appointment;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAppointment([FromQuery] AppointmentFilter filter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _appointmentService.GetAllAsync(filter);
            return Ok(result);
        }

        [HttpGet("report")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetDailyReport()
        {
            var result = await _appointmentService.GetDailyReport();
            return Ok(result);
        }
    }
}
