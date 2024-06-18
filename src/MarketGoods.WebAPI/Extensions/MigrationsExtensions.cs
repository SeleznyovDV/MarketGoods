namespace MarketGoods.WebAPI.Extensions
{
    using MarketGoods.Infrastructure.Models;
    using MarketGoods.Infrastructure.Persistence;
    using MarketGoods.Infrastructure.Persistence.Seeds;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public static class MigrationsExtensions
	{
		public static async Task ApplyMigrations(this WebApplication app)
		{
			try 
			{
                using var scope = app.Services.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await dbContext.Database.MigrateAsync();

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                await IdentitySeed.SeedDataAsync(userManager);
            }
			catch (Exception ex) { }
		}
	}
}

