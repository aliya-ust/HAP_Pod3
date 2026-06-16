using Microsoft.AspNetCore.Identity;

namespace HealthCare.Api.Services.Interfaces
{
    public interface IJwtService
    {
        Task<string> GenerateToken(IdentityUser user);
    }
}
