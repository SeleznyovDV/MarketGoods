namespace MarketGoods.Infrastructure.Persistence.Configurations.Identity
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    public class ApplicationUserClaimsConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            builder.ToTable("ApplicationUserClaims");
        }
    }
}
