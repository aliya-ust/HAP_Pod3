using System.ComponentModel.DataAnnotations;

namespace HealthCare.Api.DTOs.Auth
{
    public class LoginDto
    {
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
