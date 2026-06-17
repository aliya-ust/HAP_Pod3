using HealthCare.Api.DTOs.Auth;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using HealthCare.Api.Models;

namespace HealthCare.Api.Controllers
{

    [ApiController]

    [Route("api/[controller]")]

    public class AuthController(IAuthService authService) : ControllerBase

    {

        [HttpPost("register")]

        public async Task<IActionResult> Register(RegisterDto request)

        {

            // Call service to register user 

            var (success, message, userId) = await authService.RegisterAsync(request);



            // Return 400 Bad Request if registration failed 

            if (!success)

            {

                return BadRequest(new { message });

            }



            // Return 200 OK with success message and user ID 

            return Ok(new { message, userId });

        }



        [HttpPost("login")]

        public async Task<IActionResult> Login(LoginDto request)

        {

            // Call service to authenticate user 

            var (success, message, accessToken, expiresIn) = await authService.LoginAsync(request);



            // Return 401 Unauthorized if login failed 

            if (!success)

            {

                return Unauthorized(new { message });

            }



            // Return 200 OK with token and expiration 

            return Ok(new AuthResponse

            {

                AccessToken = accessToken,

                ExpiresIn = expiresIn,

                Message = message

            });

        }

    }
}

