using System.Data.Entity.ModelConfiguration;
using HealthCareApi.Models;

namespace HealthCareApi.Data.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users");

            HasKey(u => u.UserId);

            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.PasswordHash)
                .HasMaxLength(256);

            Property(u => u.Role)
                .HasMaxLength(20);

            // Unique Email
            HasIndex(u => u.Email).IsUnique();

            // Relationship: User ↔ Patient (Optional 1–1)
            HasOptional(u => u.Patient)
                .WithOptionalPrincipal(p => p.User);

            // Relationship: User ↔ Doctor (Optional 1–1)
            HasOptional(u => u.Doctor)
                .WithOptionalPrincipal(d => d.User);
        }
    }
}