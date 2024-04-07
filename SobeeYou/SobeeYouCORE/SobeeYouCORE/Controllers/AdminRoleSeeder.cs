using Microsoft.AspNetCore.Identity;
using SobeeYouCORE.Models;
using SobeeYouCORE.Models.DbModels.Identity;

public static class AdminRoleSeeder {
    public static async Task SeedAdminRoleAsync(IServiceProvider serviceProvider) {
        using (var scope = serviceProvider.CreateScope()) {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>(); // gets role manager service for identity roles
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>(); // gets user manager service for identtity user methods 

            // Create the admin role if it doesn't exist
            if (!await roleManager.RoleExistsAsync("Admin")) {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Assign the admin role to a user (replace with your desired admin user's email) 
            // gotta add the functionality to add admin priveleges to an account
            var adminUser = await userManager.FindByEmailAsync("admin@example.com");
            if (adminUser != null && !await userManager.IsInRoleAsync(adminUser, "Admin")) {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}