using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/dashboard")]
public class DashboardController : ControllerBase
{
    private readonly IDashboardService _dashboardService;

    public DashboardController(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }
    private int GetPatientId()
    {
        return int.Parse(User.FindFirst("PatientId")!.Value);
    }

    private int GetDoctorId()
    {
        return int.Parse(User.FindFirst("DoctorId")!.Value);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Patient")]
    [HttpGet("patient")]
    public async Task<IActionResult> GetPatientDashboard()
    {
        var patientId = GetPatientId();

        var result = await _dashboardService
            .GetPatientDashboardSummaryAsync(patientId);

        return Ok(result);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
    [HttpGet("doctor")]
    public async Task<IActionResult> GetDoctorDashboard()
    {
        var doctorId = GetDoctorId();

        var result = await _dashboardService
            .GetDoctorDashboardSummaryAsync(doctorId);

        return Ok(result);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetDashboard()
    {
        var result = await _dashboardService.GetDashboardSummaryAsync();
        return Ok(result);
    }
}