using Backoffice.Domain.Entities;
using Microsoft.AspNetCore.Identity;

public static class AdminUserInitializer
{
    public static async Task InitializeAsync(UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        string adminRole = Roles.administrador.ToString();
        const string adminEmail = "admin@example.com";
        const string adminPassword = "Admin@123";
        const string userName = "admin";

        if (await roleManager.FindByNameAsync(adminRole) is null)
        {
            await roleManager.CreateAsync(new IdentityRole(adminRole));
        }

        if (await userManager.FindByNameAsync(adminEmail) is null)
        {
            IdentityUser admin = new IdentityUser { Email = adminEmail, UserName = userName, EmailConfirmed = true };
            IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, adminRole);
            }
        }
    }
}