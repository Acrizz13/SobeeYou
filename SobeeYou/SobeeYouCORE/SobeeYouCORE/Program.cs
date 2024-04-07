using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SobeeYouCORE.Data;
using SobeeYouCORE.Models;
using SobeeYouCORE.Models.DbModels;
using SobeeYouCORE.Models.DbModels.Identity;
using SobeeYouCORE.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Adds Shopping Cart Serivce
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();

//Adds Orders Service
builder.Services.AddScoped<IOrderService, OrderService>();

// Register AppDbContext for database models
builder.Services.AddDbContext<SobeedbContext>(options =>
	options.UseSqlServer(connectionString));


// Register ApplicationDbContext for Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter(); // catches db related errors

// enables use of default Identity UI pages (login, register, manage profile, etc.)
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false) // uses custome ApplicationUser class that inherits Identity User
	.AddRoles<IdentityRole>() // Add this line to enable admin role support
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultTokenProviders();


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

// Enable session middleware
app.UseSession();

// Enable identity authorization
app.UseAuthentication();
app.UseAuthorization();

// Seed the admin role so that admin roles can be used
AdminRoleSeeder.SeedAdminRoleAsync(app.Services).Wait();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

// add this to use default Identtiy UI pages or it wont work
app.MapRazorPages();

app.Run();