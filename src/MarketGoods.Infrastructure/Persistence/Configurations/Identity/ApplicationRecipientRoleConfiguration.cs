namespace MarketGoods.Infrastructure.Persistence.Configurations.Identity
{
    using MarketGoods.Infrastructure.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class ApplicationRecipientRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.ToTable("RecipientRoles");
            builder.HasKey(x => new { x.UserId, x.RoleId });
        }
    }
}
