using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HealthCare.Api.Models;
using HealthCare.Api.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;

namespace HealthCare.Api.Tests;

public class JwtServiceTests
{
    private readonly Mock<IConfiguration> _configMock;
    private readonly Mock<IConfigurationSection> _jwtSectionMock;
    private readonly Mock<UserManager<User>> _userManagerMock;

    private readonly JwtService _service;

    public JwtServiceTests()
    {
        _configMock = new Mock<IConfiguration>();
        _jwtSectionMock = new Mock<IConfigurationSection>();

        var store = new Mock<IUserStore<User>>();

        _userManagerMock = new Mock<UserManager<User>>(
            store.Object,
            null!,
            null!,
            null!,
            null!,
            null!,
            null!,
            null!,
            null!);

        _configMock
            .Setup(c => c.GetSection("Jwt"))
            .Returns(_jwtSectionMock.Object);

        _jwtSectionMock
            .Setup(s => s["Key"])
            .Returns("ThisIsAVeryStrongSecretKeyForJwtTesting12345");

        _jwtSectionMock
            .Setup(s => s["Issuer"])
            .Returns("TestIssuer");

        _jwtSectionMock
            .Setup(s => s["Audience"])
            .Returns("TestAudience");

        _jwtSectionMock
            .Setup(s => s["AccessTokenExpirationMinutes"])
            .Returns("60");

        _service = new JwtService(
            _configMock.Object,
            _userManagerMock.Object);
    }

    [Fact]
    public async Task GenerateToken_ShouldReturnToken()
    {
        var user = new User
        {
            Id = "user1",
            Email = "test@test.com"
        };

        _userManagerMock
            .Setup(u => u.GetRolesAsync(user))
            .ReturnsAsync(new List<string>());

        var token = await _service.GenerateToken(user);

        Assert.False(string.IsNullOrWhiteSpace(token));
    }

    [Fact]
    public async Task GenerateToken_ShouldContainEmailClaim()
    {
        var user = new User
        {
            Id = "user1",
            Email = "test@test.com"
        };

        _userManagerMock
            .Setup(u => u.GetRolesAsync(user))
            .ReturnsAsync(new List<string>());

        var tokenString = await _service.GenerateToken(user);

        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(tokenString);

        Assert.Contains(
            token.Claims,
            c => c.Type == JwtRegisteredClaimNames.Email &&
                 c.Value == "test@test.com");
    }

    [Fact]
    public async Task GenerateToken_ShouldContainPatientIdClaim()
    {
        var user = new User
        {
            Id = "user1",
            Email = "test@test.com"
        };

        _userManagerMock
            .Setup(u => u.GetRolesAsync(user))
            .ReturnsAsync(new List<string>());

        var tokenString = await _service.GenerateToken(
            user,
            patientId: 10);

        var token = new JwtSecurityTokenHandler()
            .ReadJwtToken(tokenString);

        Assert.Contains(
            token.Claims,
            c => c.Type == "PatientId" &&
                 c.Value == "10");
    }

    [Fact]
    public async Task GenerateToken_ShouldContainDoctorIdClaim()
    {
        var user = new User
        {
            Id = "user1",
            Email = "test@test.com"
        };

        _userManagerMock
            .Setup(u => u.GetRolesAsync(user))
            .ReturnsAsync(new List<string>());

        var tokenString = await _service.GenerateToken(
            user,
            doctorId: 20);

        var token = new JwtSecurityTokenHandler()
            .ReadJwtToken(tokenString);

        Assert.Contains(
            token.Claims,
            c => c.Type == "DoctorId" &&
                 c.Value == "20");
    }

    [Fact]
    public async Task GenerateToken_ShouldContainRoleClaims()
    {
        var user = new User
        {
            Id = "user1",
            Email = "test@test.com"
        };

        _userManagerMock
            .Setup(u => u.GetRolesAsync(user))
            .ReturnsAsync(new List<string>
            {
                "Admin",
                "Doctor"
            });

        var tokenString = await _service.GenerateToken(user);

        var token = new JwtSecurityTokenHandler()
            .ReadJwtToken(tokenString);

        Assert.Contains(
            token.Claims,
            c => c.Type == ClaimTypes.Role &&
                 c.Value == "Admin");

        Assert.Contains(
            token.Claims,
            c => c.Type == ClaimTypes.Role &&
                 c.Value == "Doctor");
    }

    [Fact]
    public async Task GenerateToken_ShouldContainNameIdentifier()
    {
        var user = new User
        {
            Id = "user1",
            Email = "test@test.com"
        };

        _userManagerMock
            .Setup(u => u.GetRolesAsync(user))
            .ReturnsAsync(new List<string>());

        var tokenString = await _service.GenerateToken(user);

        var token = new JwtSecurityTokenHandler()
            .ReadJwtToken(tokenString);

        Assert.Contains(
            token.Claims,
            c => c.Type == ClaimTypes.NameIdentifier &&
                 c.Value == "user1");
    }

    [Fact]
    public async Task GenerateToken_ShouldContainSubClaim()
    {
        var user = new User
        {
            Id = "user1",
            Email = "test@test.com"
        };

        _userManagerMock
            .Setup(u => u.GetRolesAsync(user))
            .ReturnsAsync(new List<string>());

        var tokenString = await _service.GenerateToken(user);

        var token = new JwtSecurityTokenHandler()
            .ReadJwtToken(tokenString);

        Assert.Contains(
            token.Claims,
            c => c.Type == JwtRegisteredClaimNames.Sub &&
                 c.Value == "user1");
    }

    [Fact]
    public async Task GenerateToken_ShouldContainExpiration()
    {
        var user = new User
        {
            Id = "user1",
            Email = "test@test.com"
        };

        _userManagerMock
            .Setup(u => u.GetRolesAsync(user))
            .ReturnsAsync(new List<string>());

        var tokenString = await _service.GenerateToken(user);

        var token = new JwtSecurityTokenHandler()
            .ReadJwtToken(tokenString);

        Assert.True(token.ValidTo > DateTime.UtcNow);
    }
}