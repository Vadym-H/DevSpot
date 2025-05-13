using DevSpot.Const;
using Microsoft.AspNetCore.Identity;

namespace DevSpot.Data
{
    public class RoleSeeder
    {
        public static async Task SeedRoleAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await CreteRoles(roleManager, Roles.Admin);
            await CreteRoles(roleManager, Roles.JobSeeker);
            await CreteRoles(roleManager, Roles.Employer);
        }
        private static async Task CreteRoles(RoleManager<IdentityRole> roleManager, string role)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}