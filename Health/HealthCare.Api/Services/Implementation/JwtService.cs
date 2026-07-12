using HealthCare.Api.Models;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HealthCare.Api.Services.Implementations
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<JwtService> _logger;

        public JwtService(
            IConfiguration config,
            UserManager<User> userManager,
            ILogger<JwtService> logger)
        {
            _config = config;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<string> GenerateToken(
            User user,
            int? patientId = null,
            int? doctorId = null)
        {
            _logger.LogInformation(
                "Generating JWT token for User {UserId}",
                user.Id);

            var jwtSettings = _config.GetSection("Jwt");

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings["Key"]!));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            if (patientId.HasValue)
            {
                claims.Add(new Claim("PatientId", patientId.Value.ToString()));
            }

            if (doctorId.HasValue)
            {
                claims.Add(new Claim("DoctorId", doctorId.Value.ToString()));
            }

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var expirationMinutes =
                int.Parse(jwtSettings["AccessTokenExpirationMinutes"]!);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
                signingCredentials: credentials
            );

            _logger.LogInformation(
                "JWT token generated successfully for User {UserId}",
                user.Id);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}