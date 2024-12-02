using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace School.DataBase.Extension;

public static class RoleInitializer
{
    public static async Task SeedRoles(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

        string[] roles = { "Admin", "Teacher", "Student" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole<int>(role));
                Console.WriteLine($"Role {role} created successfully.");
            }
            else
            {
                Console.WriteLine($"Role {role} already exists.");
            }
        }
    }
}