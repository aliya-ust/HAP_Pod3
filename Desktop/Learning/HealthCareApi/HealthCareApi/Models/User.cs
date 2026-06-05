using HealthCareApi.Models;

namespace HealthCareApi.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }          // "Patient", "Doctor", "Admin"

        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}