using Microsoft.AspNetCore.Identity;

namespace HealthCare.Api.Data
{

    public static class RoleSeeder

    {

        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)

        {

            // Define roles to create 

            string[] roles = { "Admin", "Patient" ,"Doctor"};



            // Create each role if it doesn't exist 

            foreach (var role in roles)

            {

                // Check if role already exists 

                if (!await roleManager.RoleExistsAsync(role))

                {

                    // Create the role 

                    await roleManager.CreateAsync(new IdentityRole(role));

                }

            }
        }
    }
}
    

        

    


