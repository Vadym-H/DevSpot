using Azure.Identity;
using DevSpot.Const;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace DevSpot.Data
{
    public class UserSeeder
    {
        public static async Task SeedUsersAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            await CreateUserWithRole(userManager, "admin@devspot.com", "Admin123!", Roles.Admin);
            await CreateUserWithRole(userManager, "jobseeker@devspot.com", "Jobseeker123!", Roles.JobSeeker);
            await CreateUserWithRole(userManager, "employer@devspot.com", "Employer123!", Roles.Employer);
        }

        private static async Task CreateUserWithRole(UserManager<IdentityUser> userManager, string email, string password, string role)
        {
            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new IdentityUser()
                {
                    Email = email,
                    EmailConfirmed = false,
                    UserName = email
                };
                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
                else
                {
                    throw new Exception($"Failed creating user with email {user.Email}. Errors: {string.Join(",", result.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}