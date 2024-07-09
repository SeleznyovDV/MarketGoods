namespace MarketGoods.Infrastructure.Persistence.Configurations.Identity
{
    using MarketGoods.Infrastructure.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class ApplicationRecipientLoginsConfiguration : IEntityTypeConfiguration<IdentityUserLogin<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder)
        {
            builder.ToTable("RecipientLogins");
            builder.HasKey(x => new { x.ProviderKey, x.LoginProvider });
        }
    }
}
