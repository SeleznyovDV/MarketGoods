namespace MarketGoods.WebAPI.Extensions
{
    using MarketGoods.Infrastructure.Models;
    using MarketGoods.Infrastructure.Persistence;
    using MarketGoods.Infrastructure.Persistence.Seeds;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public static class MigrationsExtensions
	{
		public static async Task ApplyMigrations(this WebApplication app)
		{
            using var scope = app.Services.CreateScope();
            var logger = scope.ServiceProvider.GetService<ILogger<Program>>();
            try 
			{
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await dbContext.Database.MigrateAsync();

                var identityDbContext = scope.ServiceProvider.GetRequiredService<ApplicationIdentityDbContext>();
                await identityDbContext.Database.MigrateAsync();

                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<string>>>();
                await IdentitySeed.SeedRolesAsync(roleManager);

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationRecipient>>();
                await IdentitySeed.SeedUsersAsync(userManager);
            }
			catch (Exception ex) 
            {
                logger.LogError($"Apply migration error. Message: {ex.Message}, StackTrace: {ex.StackTrace}");
            }
		}
	}
}

