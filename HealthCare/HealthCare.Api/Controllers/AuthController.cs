using HealthCare.Api.DTOs.Authentication;
using HealthCare.Api.Models;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthorService service) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto request)
        {
            var (success, message, userId) = await service.Register(request);
            if(!success)
            {
                return BadRequest(new { message });
            }
            return Ok(new { message, userId });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto request)
        {
            var (success, message, token, expiresIn) = await service.Login(request);
            if(!success)
            {
                return Unauthorized(new { message });
            }

            AuthResponse response = new AuthResponse
            {
                AccessToken = token,
                Message = message,
                ExpiresIn = expiresIn
            };
            return Ok(response);

        }
    }
}
