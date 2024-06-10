namespace MarketGoods.Infrastructure.Persistence.Configurations.Identity
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class ApplicationUserTokensConfiguration
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
        {
            builder.ToTable("ApplicationUserTokens");
        }
    }
}
