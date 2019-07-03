using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SocialService.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialService.DataAccess.Service
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager,IConfiguration configuration)
        {
            string adminEmail = configuration["Admin:AdminEmail"];
            string password = configuration["Admin:Password"];
            if (await roleManager.FindByNameAsync(configuration["Roles:Admin"]) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(configuration["Roles:Admin"]));
            }
            if (await roleManager.FindByNameAsync(configuration["Roles:User"]) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(configuration["Roles:User"]));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
