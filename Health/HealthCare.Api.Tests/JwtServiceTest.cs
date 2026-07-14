using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HealthCare.Api.Models;
using HealthCare.Api.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace HealthCare.Tests.Services
{
    public class JwtServiceTests
    {
        private readonly Mock<UserManager<User>> _userManager;
        private readonly IConfiguration _configuration;
        private readonly JwtService _service;
        private readonly Mock<ILogger<JwtService>> _logger = new();

        public JwtServiceTests()
        {
            var store = new Mock<IUserStore<User>>();

            _userManager = new Mock<UserManager<User>>(
                store.Object,
                null!,
                null!,
                null!,
                null!,
                null!,
                null!,
                null!,
                null!);

            var settings = new Dictionary<string, string>
            {
                { "Jwt:Key", "ThisIsASecretKeyForJwtTokenGeneration12345" },
                { "Jwt:Issuer", "TestIssuer" },
                { "Jwt:Audience", "TestAudience" },
                { "Jwt:AccessTokenExpirationMinutes", "60" }
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(settings!)
                .Build();

            _service = new JwtService(_configuration, _userManager.Object, _logger.Object);
        }

        [Fact]
        public async Task GenerateToken_Should_Return_Token()
        {
            var user = new User
            {
                Id = "1",
                Email = "test@test.com"
            };

            _userManager.Setup(x => x.GetRolesAsync(user))
                .ReturnsAsync(new List<string>());

            var token = await _service.GenerateToken(user);

            Assert.False(string.IsNullOrWhiteSpace(token));
        }

        [Fact]
        public async Task GenerateToken_Should_Contain_Email_Claim()
        {
            var user = new User
            {
                Id = "1",
                Email = "abc@test.com"
            };

            _userManager.Setup(x => x.GetRolesAsync(user))
                .ReturnsAsync(new List<string>());

            var token = await _service.GenerateToken(user);

            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);

            Assert.Equal("abc@test.com",
                jwt.Claims.First(x => x.Type == JwtRegisteredClaimNames.Email).Value);
        }

        [Fact]
        public async Task GenerateToken_Should_Contain_PatientId()
        {
            var user = new User { Id = "1", Email = "a@test.com" };

            _userManager.Setup(x => x.GetRolesAsync(user))
                .ReturnsAsync(new List<string>());

            var token = await _service.GenerateToken(user, patientId: 5);

            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);

            Assert.Equal("5",
                jwt.Claims.First(x => x.Type == "PatientId").Value);
        }

        [Fact]
        public async Task GenerateToken_Should_Contain_DoctorId()
        {
            var user = new User { Id = "1", Email = "a@test.com" };

            _userManager.Setup(x => x.GetRolesAsync(user))
                .ReturnsAsync(new List<string>());

            var token = await _service.GenerateToken(user, doctorId: 9);

            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);

            Assert.Equal("9",
                jwt.Claims.First(x => x.Type == "DoctorId").Value);
        }

        [Fact]
        public async Task GenerateToken_Should_Contain_Role()
        {
            var user = new User { Id = "1", Email = "a@test.com" };

            _userManager.Setup(x => x.GetRolesAsync(user))
                .ReturnsAsync(new List<string> { "Doctor" });

            var token = await _service.GenerateToken(user);

            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);

            Assert.Contains(jwt.Claims,
                x => x.Type == ClaimTypes.Role && x.Value == "Doctor");
        }

        [Fact]
        public async Task GenerateToken_Should_Contain_NameIdentifier()
        {
            var user = new User { Id = "25", Email = "a@test.com" };

            _userManager.Setup(x => x.GetRolesAsync(user))
                .ReturnsAsync(new List<string>());

            var token = await _service.GenerateToken(user);

            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);

            Assert.Equal("25",
                jwt.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
        }

        [Fact]
        public async Task GenerateToken_Should_Have_Correct_Issuer()
        {
            var user = new User { Id = "1", Email = "a@test.com" };

            _userManager.Setup(x => x.GetRolesAsync(user))
                .ReturnsAsync(new List<string>());

            var token = await _service.GenerateToken(user);

            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);

            Assert.Equal("TestIssuer", jwt.Issuer);
        }

        [Fact]
        public async Task GenerateToken_Should_Contain_Sub_Claim()
        {
            var user = new User { Id = "50", Email = "a@test.com" };

            _userManager.Setup(x => x.GetRolesAsync(user))
                .ReturnsAsync(new List<string>());

            var token = await _service.GenerateToken(user);

            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);

            Assert.Equal("50",
                jwt.Claims.First(x => x.Type == JwtRegisteredClaimNames.Sub).Value);
        }
    }
}