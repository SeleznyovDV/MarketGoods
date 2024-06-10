namespace MarketGoods.Infrastructure.Persistence.Configurations.Identity
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class ApplicationUserLoginsConfiguration
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder)
        {
            builder.ToTable("ApplicationUserLogins");
        }
    }
}
