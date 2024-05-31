using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TerraClubHub.Data;  // Ensure this namespace points to where your ClubHubContext is located.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Using the default connection string for Identity
var defaultConnectionString = builder.Configuration.GetConnectionString("ClubHubConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(defaultConnectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Using the ClubHub connection string for your application-specific data
var clubHubConnectionString = builder.Configuration.GetConnectionString("ClubHubConnection") ?? throw new InvalidOperationException("Connection string 'ClubHubConnection' not found.");
builder.Services.AddDbContext<ClubHubContext>(options =>
    options.UseSqlServer(clubHubConnectionString));  // This uses your ClubHubDb

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
