using HealthCare.Shared.DTOs.Doctor;
using HealthCare.Shared.DTOs.Patient;
using HealthCare.Shared.DTOs.Authentication;

namespace HealthCare.Api.Services.Interfaces
{
    public interface IAuthService
    {
        Task RegisterPatientAsync(CreatePatientDto dto);
        Task RegisterDoctorAsync(CreateDoctorDto dto);
        Task<AuthResponseDto> LoginAsync(LoginDto dto);
        Task ChangePasswordAsync(string userId, ChangePasswordDto dto);
        Task UpdatePatientEmailAsync(string userId, string newEmail);
    }
}