using HealthCare.Api.DTOs.Patient;

namespace HealthCare.Api.Services.Interfaces
{
    public interface IAuthService
    {
        Task RegisterPatientAsync(CreatePatientDto dto);
        Task<AuthResponseDto> LoginAsync(LoginDto dto);
    }
}
