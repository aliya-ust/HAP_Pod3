using HealthCare.Api.Services.Interfaces;
using HealthCare.Api.Utilities;
using HealthCare.Shared;
using HealthCare.Shared.DTOs.Notification;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Api.Controllers
{
    [Route("api/notifications")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        public async Task<IActionResult> GetNotifications()
        {
            var doctorId = ClaimsHelper.GetDoctorId(User);
            var result = await _notificationService.GetNotificationsForDoctor(doctorId);
            return Ok(ApiResponse<List<NotificationListDto>>.Ok(result));
        }

        [HttpPut("{id}/read")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            var doctorId = ClaimsHelper.GetDoctorId(User);
            await _notificationService.MarkAsRead(id, doctorId);
            return Ok(ApiResponse.Ok("Notification marked as read."));
        }

        [HttpPut("read-all")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        public async Task<IActionResult> MarkAllAsRead()
        {
            var doctorId = ClaimsHelper.GetDoctorId(User);
            await _notificationService.MarkAllAsRead(doctorId);
            return Ok(ApiResponse.Ok("All notifications marked as read."));
        }
    }
}
