using HealthCare.Api.DTOs.Auth;

namespace HealthCare.Api.Services.Interfaces
{
    public interface IAuthService
    {

        Task<(bool success, string Message, string UserId)> RegisterAsync(RegisterDto request);


        Task<(bool Success, string Message, string AccessToken, int ExpiresIn)> LoginAsync(LoginDto request);

 
    }
}
