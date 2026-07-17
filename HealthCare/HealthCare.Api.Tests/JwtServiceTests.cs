using HealthCare.Api.Models;
using HealthCare.Api.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HealthCare.Api.Tests;

public class JwtServiceTests
{
    private readonly Mock<UserManager<User>> _userManagerMock;
    private readonly IConfiguration _configuration;
    private readonly JwtService _service;

    public JwtServiceTests()
    {
        _userManagerMock = CreateUserManagerMock();

        var settings = new Dictionary<string, string?>
        {
            // Key should be long enough for HmacSha256
            { "Jwt:Key", "ThisIsASecretKeyForJwtTokenTesting12345" },
            { "Jwt:Issuer", "HealthCareTestIssuer" },
            { "Jwt:Audience", "HealthCareTestAudience" },
            { "Jwt:AccessTokenExpirationMinutes", "60" }
        };

        _configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(settings)
            .Build();

        _service = new JwtService(
            _configuration,
            _userManagerMock.Object
        );
    }

    private static Mock<UserManager<User>> CreateUserManagerMock()
    {
        var store = new Mock<IUserStore<User>>();
        var options = new Mock<IOptions<IdentityOptions>>();
        var passwordHasher = new Mock<IPasswordHasher<User>>();
        var userValidators = new List<IUserValidator<User>>();
        var passwordValidators = new List<IPasswordValidator<User>>();
        var keyNormalizer = new Mock<ILookupNormalizer>();
        var errors = new IdentityErrorDescriber();
        var services = new Mock<IServiceProvider>();
        var logger = new Mock<ILogger<UserManager<User>>>();

        return new Mock<UserManager<User>>(
            store.Object,
            options.Object,
            passwordHasher.Object,
            userValidators,
            passwordValidators,
            keyNormalizer.Object,
            errors,
            services.Object,
            logger.Object
        );
    }

    [Fact]
    public async Task GenerateToken_ReturnsJwtToken_WithBasicClaimsAndRole()
    {
        // Arrange
        var user = new User
        {
            Id = "user-1",
            Email = "testuser@test.com",
            UserName = "testuser@test.com"
        };

        _userManagerMock
            .Setup(u => u.GetRolesAsync(user))
            .ReturnsAsync(new List<string> { "Patient" });

        // Act
        var tokenString = await _service.GenerateToken(user);

        // Assert
        Assert.False(string.IsNullOrWhiteSpace(tokenString));

        var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenString);

        Assert.Equal("HealthCareTestIssuer", token.Issuer);
        Assert.Contains("HealthCareTestAudience", token.Audiences);

        Assert.Contains(token.Claims, c =>
            c.Type == JwtRegisteredClaimNames.Sub &&
            c.Value == "user-1");

        Assert.Contains(token.Claims, c =>
            c.Type == JwtRegisteredClaimNames.Email &&
            c.Value == "testuser@test.com");

        Assert.Contains(token.Claims, c =>
            c.Type == JwtRegisteredClaimNames.Jti &&
            !string.IsNullOrWhiteSpace(c.Value));

        Assert.Contains(token.Claims, c =>
            (c.Type == ClaimTypes.NameIdentifier || c.Type == "nameid") &&
            c.Value == "user-1");

        Assert.Contains(token.Claims, c =>
            (c.Type == ClaimTypes.Role || c.Type == "role") &&
            c.Value == "Patient");

        _userManagerMock.Verify(
            u => u.GetRolesAsync(user),
            Times.Once
        );
    }

    [Fact]
    public async Task GenerateToken_IncludesPatientId_WhenPatientIdIsProvided()
    {
        // Arrange
        var user = new User
        {
            Id = "patient-user-1",
            Email = "patient@test.com",
            UserName = "patient@test.com"
        };

        _userManagerMock
            .Setup(u => u.GetRolesAsync(user))
            .ReturnsAsync(new List<string> { "Patient" });

        // Act
        var tokenString = await _service.GenerateToken(user, patientId: 5);

        // Assert
        var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenString);

        Assert.Contains(token.Claims, c =>
            c.Type == "PatientId" &&
            c.Value == "5");

        Assert.DoesNotContain(token.Claims, c =>
            c.Type == "DoctorId");

        Assert.Contains(token.Claims, c =>
            (c.Type == ClaimTypes.Role || c.Type == "role") &&
            c.Value == "Patient");
    }

    [Fact]
    public async Task GenerateToken_IncludesDoctorId_WhenDoctorIdIsProvided()
    {
        // Arrange
        var user = new User
        {
            Id = "doctor-user-1",
            Email = "doctor@test.com",
            UserName = "doctor@test.com"
        };

        _userManagerMock
            .Setup(u => u.GetRolesAsync(user))
            .ReturnsAsync(new List<string> { "Doctor" });

        // Act
        var tokenString = await _service.GenerateToken(user, doctorId: 10);

        // Assert
        var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenString);

        Assert.Contains(token.Claims, c =>
            c.Type == "DoctorId" &&
            c.Value == "10");

        Assert.DoesNotContain(token.Claims, c =>
            c.Type == "PatientId");

        Assert.Contains(token.Claims, c =>
            (c.Type == ClaimTypes.Role || c.Type == "role") &&
            c.Value == "Doctor");
    }

    [Fact]
    public async Task GenerateToken_IncludesNoPatientOrDoctorId_WhenIdsAreNotProvided()
    {
        // Arrange
        var user = new User
        {
            Id = "admin-user-1",
            Email = "admin@test.com",
            UserName = "admin@test.com"
        };

        _userManagerMock
            .Setup(u => u.GetRolesAsync(user))
            .ReturnsAsync(new List<string> { "Admin" });

        // Act
        var tokenString = await _service.GenerateToken(user);

        // Assert
        var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenString);

        Assert.DoesNotContain(token.Claims, c =>
            c.Type == "PatientId");

        Assert.DoesNotContain(token.Claims, c =>
            c.Type == "DoctorId");

        Assert.Contains(token.Claims, c =>
            (c.Type == ClaimTypes.Role || c.Type == "role") &&
            c.Value == "Admin");
    }

    [Fact]
    public async Task GenerateToken_SetsExpiryBasedOnConfiguration()
    {
        // Arrange
        var user = new User
        {
            Id = "user-1",
            Email = "user@test.com",
            UserName = "user@test.com"
        };

        _userManagerMock
            .Setup(u => u.GetRolesAsync(user))
            .ReturnsAsync(new List<string> { "Patient" });

        var beforeTokenCreated = DateTime.UtcNow;

        // Act
        var tokenString = await _service.GenerateToken(user);

        var afterTokenCreated = DateTime.UtcNow;

        // Assert
        var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenString);

        Assert.True(token.ValidTo >= beforeTokenCreated.AddMinutes(59));
        Assert.True(token.ValidTo <= afterTokenCreated.AddMinutes(61));
    }

    [Fact]
    public async Task GenerateToken_IncludesMultipleRoles_WhenUserHasMultipleRoles()
    {
        // Arrange
        var user = new User
        {
            Id = "multi-role-user",
            Email = "multi@test.com",
            UserName = "multi@test.com"
        };

        _userManagerMock
            .Setup(u => u.GetRolesAsync(user))
            .ReturnsAsync(new List<string> { "Doctor", "Admin" });

        // Act
        var tokenString = await _service.GenerateToken(user);

        // Assert
        var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenString);

        Assert.Contains(token.Claims, c =>
            (c.Type == ClaimTypes.Role || c.Type == "role") &&
            c.Value == "Doctor");

        Assert.Contains(token.Claims, c =>
            (c.Type == ClaimTypes.Role || c.Type == "role") &&
            c.Value == "Admin");
    }
}