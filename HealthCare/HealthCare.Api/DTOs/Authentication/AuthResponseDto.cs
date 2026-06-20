namespace HealthCare.Api.DTOs.Auth
{
    public class AuthResponseDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }

        public int ExpiresIn { get; set; }
    }
}