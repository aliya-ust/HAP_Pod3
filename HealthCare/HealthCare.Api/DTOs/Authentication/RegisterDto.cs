using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HealthCare.Api.DTOs.Authentication
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "User";

    }
}
