using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HealthCare.Api.Models;
using HealthCare.Api.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace HealthCare.Tests.Services
{
    public class JwtServiceTest
    {
        private readonly Mock<UserManager<User>> _userManagerMock;
        private readonly IConfiguration _configuration;
        private readonly JwtService _service;

        public JwtServiceTest()
        {
            var configData = new Dictionary<string, string?>
            {
                { "Jwt:Key", "ThisIsASecretKeyForJwtTesting123456789" },
                { "Jwt:Issuer", "TestIssuer" },
                { "Jwt:Audience", "TestAudience" },
                { "Jwt:AccessTokenExpirationMinutes", "60" }
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configData)
                .Build();

            var store = new Mock<IUserStore<User>>();

            _userManagerMock = new Mock<UserManager<User>>(
                store.Object,
                null!, null!, null!, null!,
                null!, null!, null!, null!);

            _service = new JwtService(_configuration, _userManagerMock.Object);
        }

        [Fact]
        public async Task GenerateToken_ShouldReturnValidJwt_ForPatient()
        {
            var user = new User { Id = "user123", Email = "patient@test.com" };

            _userManagerMock.Setup(x => x.GetRolesAsync(It.IsAny<User>()))
                .ReturnsAsync(new List<string> { "Patient" });

            var tokenString = await _service.GenerateToken(user, patientId: 10);

            var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenString);

            Assert.Equal("TestIssuer", token.Issuer);
            Assert.Contains(token.Audiences, a => a == "TestAudience");

            Assert.Contains(token.Claims, c => c.Type == "PatientId" && c.Value == "10");
        }

        [Fact]
        public async Task GenerateToken_ShouldIncludeDoctorId_WhenProvided()
        {
            var user = new User { Id = "doctor1", Email = "doctor@test.com" };

            _userManagerMock.Setup(x => x.GetRolesAsync(It.IsAny<User>()))
                .ReturnsAsync(new List<string> { "Doctor" });

            var tokenString = await _service.GenerateToken(user, doctorId: 25);

            var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenString);

            Assert.Contains(token.Claims, c => c.Type == "DoctorId" && c.Value == "25");
        }

        [Fact]
        public async Task GenerateToken_ShouldNotIncludePatientOrDoctor_WhenNotProvided()
        {
            var user = new User { Id = "admin1", Email = "admin@test.com" };

            _userManagerMock.Setup(x => x.GetRolesAsync(It.IsAny<User>()))
                .ReturnsAsync(new List<string> { "Admin" });

            var tokenString = await _service.GenerateToken(user);

            var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenString);

            Assert.DoesNotContain(token.Claims, c => c.Type == "PatientId");
            Assert.DoesNotContain(token.Claims, c => c.Type == "DoctorId");
        }

        [Fact]
        public async Task GenerateToken_ShouldIncludeMultipleRoles()
        {
            var user = new User { Id = "user456", Email = "multi@test.com" };

            _userManagerMock.Setup(x => x.GetRolesAsync(It.IsAny<User>()))
                .ReturnsAsync(new List<string> { "Admin", "Doctor" });

            var tokenString = await _service.GenerateToken(user);

            var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenString);

            Assert.Contains(token.Claims, c => c.Type == ClaimTypes.Role && c.Value == "Admin");
            Assert.Contains(token.Claims, c => c.Type == ClaimTypes.Role && c.Value == "Doctor");
        }

        [Fact]
        public async Task GenerateToken_ShouldIncludeSubAndNameIdentifier()
        {
            var user = new User { Id = "abc123", Email = "test@test.com" };

            _userManagerMock.Setup(x => x.GetRolesAsync(It.IsAny<User>()))
                .ReturnsAsync(new List<string> { "Patient" });

            var tokenString = await _service.GenerateToken(user);

            var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenString);

            Assert.Contains(token.Claims, c => c.Type == JwtRegisteredClaimNames.Sub && c.Value == "abc123");
            Assert.Contains(token.Claims, c => c.Type == ClaimTypes.NameIdentifier && c.Value == "abc123");
        }

        [Fact]
        public async Task GenerateToken_ShouldIncludeEmailClaim()
        {
            var user = new User { Id = "u1", Email = "email@test.com" };

            _userManagerMock.Setup(x => x.GetRolesAsync(It.IsAny<User>()))
                .ReturnsAsync(new List<string> { "Patient" });

            var tokenString = await _service.GenerateToken(user);

            var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenString);

            Assert.Contains(token.Claims, c => c.Type == JwtRegisteredClaimNames.Email && c.Value == "email@test.com");
        }

        [Fact]
        public async Task GenerateToken_ShouldIncludeJtiClaim()
        {
            var user = new User { Id = "u2", Email = "jti@test.com" };

            _userManagerMock.Setup(x => x.GetRolesAsync(It.IsAny<User>()))
                .ReturnsAsync(new List<string> { "Admin" });

            var tokenString = await _service.GenerateToken(user);

            var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenString);

            Assert.Contains(token.Claims, c => c.Type == JwtRegisteredClaimNames.Jti);
        }

        [Fact]
        public async Task GenerateToken_ShouldHandleEmptyEmail()
        {
            var user = new User { Id = "u3", Email = null };

            _userManagerMock.Setup(x => x.GetRolesAsync(It.IsAny<User>()))
                .ReturnsAsync(new List<string> { "Admin" });

            var tokenString = await _service.GenerateToken(user);

            var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenString);

            Assert.Contains(token.Claims, c => c.Type == JwtRegisteredClaimNames.Email && c.Value == "");
        }

        [Fact]
        public async Task GenerateToken_ShouldReturnNonEmptyString()
        {
            var user = new User { Id = "u4", Email = "test@test.com" };

            _userManagerMock.Setup(x => x.GetRolesAsync(It.IsAny<User>()))
                .ReturnsAsync(new List<string> { "Admin" });

            var tokenString = await _service.GenerateToken(user);

            Assert.False(string.IsNullOrWhiteSpace(tokenString));
        }

        [Fact]
        public async Task GenerateToken_ShouldIncludeOnlyOneJtiPerToken()
        {
            var user = new User { Id = "u5", Email = "test@test.com" };

            _userManagerMock.Setup(x => x.GetRolesAsync(It.IsAny<User>()))
                .ReturnsAsync(new List<string> { "Admin" });

            var tokenString = await _service.GenerateToken(user);

            var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenString);

            var jtiCount = token.Claims.Count(c => c.Type == JwtRegisteredClaimNames.Jti);

            Assert.Equal(1, jtiCount);
        }
    }
}