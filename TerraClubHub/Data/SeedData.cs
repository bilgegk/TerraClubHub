using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace TerraClubHub.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Seed roles
            string[] roleNames = { "Admin", "Member" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Seed a default admin user
            var poweruser = new IdentityUser
            {
                UserName = "admin@example.com",
                Email = "admin@example.com",
                EmailConfirmed = true
            };

            string userPWD = "Admin123*";
            var _user = await userManager.FindByEmailAsync("admin@example.com");

            if (_user == null)
            {
                var createPowerUser = await userManager.CreateAsync(poweruser, userPWD);
                if (createPowerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(poweruser, "Admin");
                }
            }
        }
    }
}