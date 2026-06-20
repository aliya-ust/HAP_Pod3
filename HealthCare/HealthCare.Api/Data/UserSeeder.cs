using Microsoft.AspNetCore.Identity;

namespace HealthCare.Api.Data
{
    public static class UserSeeder
    {

        public static async Task SeedAdminAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config)
        {
            var adminEmail = config["SeedData:AdminEmail"];
            var adminPassword = config["SeedData:AdminPassword"];

            var existingAdmin = await userManager.FindByEmailAsync(adminEmail!);

            if (existingAdmin == null)
            {
                var admin = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                };

                var result = await userManager.CreateAsync(admin, adminPassword!);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
                else
                {
                    throw new InvalidOperationException("Admin creation failed: " +
                        string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }
        }

    }
}
