using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Appointment;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Api.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class AppointmentAdminController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentAdminController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // Admin - Get all appointments
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] AppointmentFilter filter)
        {
            var result = await _appointmentService.GetAllAsync(filter);

            return Ok(result);
        }

        // Admin - Get daily reports
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet("daily-report")]
        public async Task<IActionResult> GetDailyReport(
    DateOnly startDate,
    DateOnly endDate,
    int pageNumber = 1,
    int pageSize = 6)
        {
            var query = await _appointmentService
                .GetDailyReport(startDate, endDate);

            var totalCount = query.Count();

            var items = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var result = new PagedResult<AppointmentReportDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Ok(result);
        }
    }
}