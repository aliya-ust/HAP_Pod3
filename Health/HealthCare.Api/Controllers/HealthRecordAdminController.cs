using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Api.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class HealthRecordAdminController : ControllerBase
    {
        private readonly IHealthRecordService _healthRecordService;

        public HealthRecordAdminController(IHealthRecordService healthRecordService)
        {
            _healthRecordService = healthRecordService;
        }

        // Admin - Delete health record
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _healthRecordService.DeleteAsync(id);

            return Ok(new
            {
                Message = "Health record deleted successfully."
            });
        }
    }
}