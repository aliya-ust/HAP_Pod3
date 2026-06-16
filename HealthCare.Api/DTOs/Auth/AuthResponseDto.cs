namespace HealthCare.Api.DTOs.Auth
{
    public class AuthResponseDto
    {
        public string AccessToken { get; set; }
        public string Message { get; set; }
        public string Role { get; set; }
        public int ExpiresIn { get; set; }
    }
}
