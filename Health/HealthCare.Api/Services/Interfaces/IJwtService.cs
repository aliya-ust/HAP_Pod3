using HealthCare.Api.Models;

namespace HealthCare.Api.Services.Interfaces
{
    public interface IJwtService
    {
        Task<string> GenerateToken(User user, int? patientId = null, int? doctorId = null);
    }
}