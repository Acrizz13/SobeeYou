using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using sobee_core.Controllers;
using sobee_core.Data;
using sobee_core.Models.AzureModels;
using sobee_core.Models;
using sobee_core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<SobeecoredbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


// Adds Shopping Cart Serivce
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();

//Adds Orders Service
builder.Services.AddScoped<IOrderService, OrderService>();


builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
        .AddRoles<IdentityRole>() // Add this line to enable admin role support
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

// Unhashses password, overrides Hash class for identtiy with the one i made
builder.Services.AddScoped<IPasswordHasher<ApplicationUser>, CustomPasswordHasher>();

// Configure session services
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set the session timeout as needed (minutes)
    options.Cookie.HttpOnly = true; // Set other session cookie options as required
    options.Cookie.IsEssential = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseMigrationsEndPoint();
}
else {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable identity authorization
app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

// Seed the admin role so that admin roles can be used
AdminRoleSeeder.SeedAdminRoleAsync(app.Services).Wait();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
