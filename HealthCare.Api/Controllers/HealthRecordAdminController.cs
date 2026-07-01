using HealthCare.Api.Services.Interfaces;
using HealthCare.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Api.Controllers
{
    [Route("api/admin/health-records")]
    [ApiController]
    public class HealthRecordAdminController : ControllerBase
    {
        private readonly IHealthRecordService _healthRecordService;

        public HealthRecordAdminController(IHealthRecordService healthRecordService)
        {
            _healthRecordService = healthRecordService;
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> DeleteHealthRecord(int id)
        {
            await _healthRecordService.DeleteAsync(id);
            return Ok(ApiResponse.Ok("Health record deleted successfully"));
        }

    }
}
