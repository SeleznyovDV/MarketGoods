namespace MarketGoods.WebAPI.Extensions
{
    using MarketGoods.Infrastructure.Persistence;
    using Microsoft.EntityFrameworkCore;

    public static class MigrationsExtensions
	{
		public static void ApplyMigrations(this WebApplication app)
		{
			using var scope = app.Services.CreateScope();
			var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
			dbContext.Database.Migrate();
		}
	}
}

