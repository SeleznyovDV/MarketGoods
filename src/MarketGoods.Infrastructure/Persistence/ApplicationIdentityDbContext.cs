namespace MarketGoods.Infrastructure.Persistence
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using MarketGoods.Application.Data;
    using Microsoft.EntityFrameworkCore;
    using MarketGoods.Infrastructure.Models;
    using MarketGoods.Infrastructure.Persistence.Configurations.Identity;

    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationRecipient,
        IdentityRole<string>, string, IdentityUserClaim<string>, IdentityUserRole<string>,
        IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>,
        IApplicationIdentityDbContext
    {
        private const string SCHEMA = "identity";

        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema(SCHEMA);
            builder.ApplyConfiguration(new ApplicationRecipientConfiguration());
            builder.ApplyConfiguration(new ApplicationRoleConfiguration());
            builder.ApplyConfiguration(new ApplicationRecipientRoleConfiguration());
            builder.ApplyConfiguration(new ApplicationRecipientClaimsConfiguration());
            builder.ApplyConfiguration(new ApplicationRoleClaimsConfiguration());
            builder.ApplyConfiguration(new ApplicationRecipientLoginsConfiguration());
            builder.ApplyConfiguration(new ApplicationRecipientTokensConfiguration());
        }
    }
}
