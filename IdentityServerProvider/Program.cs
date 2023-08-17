using IdentityServerProvider.Configuration;
using IdentityServerProvider.Context;
using IdentityServerProvider.Database;
using IdentityServerProvider.Extensions;
using IdentityServerProvider.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>(options =>
{
    // Default Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddIdentityServer(x =>
{
    x.IssuerUri = "";
    x.Authentication.CookieLifetime = TimeSpan.FromHours(2);
    x.Events.RaiseErrorEvents = true;
    x.Events.RaiseInformationEvents = true;
    x.Events.RaiseFailureEvents = true;
    x.Events.RaiseSuccessEvents = true;
})
.AddInMemoryApiResources(Config.GetApis())
.AddInMemoryApiScopes(Config.GetApiScopes())
.AddInMemoryClients(Config.GetClients())
.AddInMemoryIdentityResources(Config.GetIdentityResource())
.AddDeveloperSigningCredential()
.AddAspNetIdentity<IdentityUser<Guid>>()
.AddProfileService<ProfileService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseRouting();

app.UseStaticFiles();

app.UseIdentityServer();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MigrateDbContext<AppDbContext>((context, services) =>
{
    var env = services.GetService<IWebHostEnvironment>();
    var logger = services.GetService<ILogger<ApplicationDbContextSeed>>();

    new ApplicationDbContextSeed()
        .SeedAsync(context, env, logger)
        .Wait();
}).Run();
