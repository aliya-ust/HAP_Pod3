using Moq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using HealthCare.Api.Services.Implementations;

namespace HealthCare.Api.Tests
{
    public class JwtServiceTests
    {
        private readonly Mock<UserManager<IdentityUser>> _userManagerMock;
        private readonly JwtService _service;

        public JwtServiceTests()
        {
            var store = new Mock<IUserStore<IdentityUser>>();
            _userManagerMock = new Mock<UserManager<IdentityUser>>(
                store.Object, null!, null!, null!, null!, null!, null!, null!, null!
            );

            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string?>
                {
                    { "Jwt:Key", "THIS_IS_A_SUPER_SECRET_KEY_123456789" },
                    { "Jwt:Issuer", "TestIssuer" },
                    { "Jwt:Audience", "TestAudience" },
                    { "Jwt:AccessTokenExpirationMinutes", "60" }
                })
                .Build();

            _service = new JwtService(config, _userManagerMock.Object);
        }

        //  Basic token generation
        [Fact]
        public async Task GenerateToken_ShouldReturnValidToken()
        {
            var user = new IdentityUser { Id = "1", Email = "test@mail.com" };

            _userManagerMock.Setup(u => u.GetRolesAsync(user))
                .ReturnsAsync(new List<string> { "Patient" });

            var token = await _service.GenerateToken(user, patientId: 5);

            Assert.NotNull(token);
            Assert.NotEmpty(token);
        }

        //  Token contains PatientId
        [Fact]
        public async Task GenerateToken_ShouldContainPatientIdClaim()
        {
            var user = new  IdentityUser { Id = "1", Email = "test@mail.com" };

            _userManagerMock.Setup(u => u.GetRolesAsync(user))
                .ReturnsAsync(new List<string> { "Patient" });

            var token = await _service.GenerateToken(user, patientId: 5);

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            var claim = jwt.Claims.FirstOrDefault(c => c.Type == "PatientId");

            Assert.NotNull(claim);
            Assert.Equal("5", claim.Value);
        }

        //  Token contains DoctorId
        [Fact]
        public async Task GenerateToken_ShouldContainDoctorIdClaim()
        {
            var user = new IdentityUser { Id = "1", Email = "doc@mail.com" };

            _userManagerMock.Setup(u => u.GetRolesAsync(user))
                .ReturnsAsync(new List<string> { "Doctor" });

            var token = await _service.GenerateToken(user, doctorId: 10);

            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);

            var claim = jwt.Claims.FirstOrDefault(c => c.Type == "DoctorId");

            Assert.NotNull(claim);
            Assert.Equal("10", claim.Value);
        }

        //  Token contains roles
        [Fact]
        public async Task GenerateToken_ShouldContainRoleClaim()
        {
            var user = new IdentityUser { Id = "1", Email = "test@mail.com" };

            _userManagerMock.Setup(u => u.GetRolesAsync(user))
                .ReturnsAsync(new List<string> { "Admin" });

            var token = await _service.GenerateToken(user);

            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);

            var roleClaim = jwt.Claims.FirstOrDefault(c =>
                c.Type.Contains("role"));

            Assert.NotNull(roleClaim);
            Assert.Equal("Admin", roleClaim.Value);
        }

        //  Token contains email + sub
        [Fact]
        public async Task GenerateToken_ShouldContainStandardClaims()
        {
            var user = new IdentityUser { Id = "123", Email = "user@mail.com" };

            _userManagerMock.Setup(u => u.GetRolesAsync(user))
                .ReturnsAsync(new List<string>());

            var token = await _service.GenerateToken(user);

            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);

            Assert.Contains(jwt.Claims, c => c.Type == JwtRegisteredClaimNames.Sub && c.Value == "123");
            Assert.Contains(jwt.Claims, c => c.Type == JwtRegisteredClaimNames.Email && c.Value == "user@mail.com");
        }

        //  Token expiration exists
        [Fact]
        public async Task GenerateToken_ShouldSetExpiration()
        {
            var user = new IdentityUser { Id = "1", Email = "test@mail.com" };

            _userManagerMock.Setup(u => u.GetRolesAsync(user))
                .ReturnsAsync(new List<string>());

            var token = await _service.GenerateToken(user);

            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);

            Assert.NotEqual(default, jwt.ValidTo); // expiration exists
        }
    }
}