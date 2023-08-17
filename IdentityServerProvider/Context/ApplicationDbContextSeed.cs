using IdentityServerProvider.Context;
using IdentityServerProvider.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace IdentityServerProvider.Database
{
    public class ApplicationDbContextSeed
    {
        private readonly IPasswordHasher<IdentityUser<Guid>> _passwordHasher = new PasswordHasher<IdentityUser<Guid>>();

        public async Task SeedAsync(AppDbContext context, IWebHostEnvironment env,
            ILogger<ApplicationDbContextSeed> logger, int? retry = 0)
        {
            if (retry != null)
            {
                int retryForAvailability = retry.Value;

                try
                {

                    if (!context.Users.Any())
                    {
                        context.Users.AddRange(GetDefaultUser());

                        await context.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    if (retryForAvailability < 10)
                    {
                        retryForAvailability++;

                        logger.LogError(ex, "EXCEPTION ERROR while migrating {DbContextName}", nameof(AppDbContext));

                        await SeedAsync(context, env, logger, retryForAvailability);
                    }
                }
            }
        }
        private IEnumerable<IdentityUser<Guid>> GetDefaultUser()
        {
            var user =
            new IdentityUser<Guid>()
            {
                Email = "admin@demo.com",
                Id = Guid.NewGuid(),
                PhoneNumber = "1234567890",
                UserName = "admin",
                NormalizedEmail = "ADMIN@DEMO.COM",
                NormalizedUserName = "ADMIN@DEMO.COM",
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, "Admin@123$");

            return new List<IdentityUser<Guid>>()
            {
                user
            };
        }
    }
}
