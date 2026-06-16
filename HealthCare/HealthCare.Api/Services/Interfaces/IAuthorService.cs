using HealthCare.Api.DTOs.Authentication;

namespace HealthCare.Api.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<(bool Success, string Message, string UserId)> Register(RegisterDto request);
        Task<(bool Success, string Message, string token, int ExpiresIn)> Login(LoginDto request);

    }
}
