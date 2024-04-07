using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SobeeYouCORE.Models;
using SobeeYouCORE.Models.DbModels.Identity;

public static class AdminRoleSeeder {
    public static async Task SeedAdminRoleAsync(IServiceProvider serviceProvider) {
        using (var scope = serviceProvider.CreateScope()) {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            try {
                // Create the admin role if it doesn't exist
                if (!await roleManager.RoleExistsAsync("Admin")) {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }

                // Assign the admin role to a user (replace with your desired admin user's email)
                var adminUser = await userManager.FindByEmailAsync("admin@example.com");
                if (adminUser != null && !await userManager.IsInRoleAsync(adminUser, "Admin")) {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
            catch (SqlException ex) when (ex.Number == 208 && ex.Message.Contains("Invalid object name 'AspNetRoles'")) {
                // Handle the specific exception when the "AspNetRoles" table is missing
                // You can log the error, display a message, or take any other appropriate action
                Console.WriteLine("The 'AspNetRoles' table is missing in the database. Skipping admin role seeding.");
            }
            catch (Exception ex) {
                // Handle any other exceptions that may occur during role seeding
                Console.WriteLine($"An error occurred while seeding the admin role: {ex.Message}");
            }
        }
    }
}