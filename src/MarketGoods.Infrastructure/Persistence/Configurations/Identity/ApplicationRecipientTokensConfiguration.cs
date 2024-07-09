namespace MarketGoods.Infrastructure.Persistence.Configurations.Identity
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class ApplicationRecipientTokensConfiguration : IEntityTypeConfiguration<IdentityUserToken<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
        {
            builder.ToTable("RecipientTokens");
            // HACK: Identity Primary Key bug fix.
            builder.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
        }
    }
}
