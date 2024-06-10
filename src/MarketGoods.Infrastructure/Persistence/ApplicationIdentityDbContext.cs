namespace MarketGoods.Infrastructure.Persistence
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using MarketGoods.Application.Data;
    using Microsoft.EntityFrameworkCore;
    using MarketGoods.Infrastructure.Models;
    using MarketGoods.Infrastructure.Persistence.Configurations.Identity;

    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser,
        ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole,
        IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>,
        IApplicationIdentityDbContext
    {
        private const string SCHEMA = "Identity";

        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //order is important
            base.OnModelCreating(builder);
            builder.HasDefaultSchema(SCHEMA);

            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new ApplicationRoleConfiguration());
            builder.ApplyConfiguration(new ApplicationUserRoleConfiguration());
            builder.ApplyConfiguration(new ApplicationUserClaimsConfiguration());
            builder.ApplyConfiguration(new ApplicationRoleClaimsConfiguration());
            builder.ApplyConfiguration(new ApplicationUserLoginsConfiguration());
            builder.ApplyConfiguration(new ApplicationUserTokensConfiguration());
        }
    }
}
