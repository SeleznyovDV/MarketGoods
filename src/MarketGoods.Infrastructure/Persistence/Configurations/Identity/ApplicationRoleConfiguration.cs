using MarketGoods.Infrastructure.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MarketGoods.Infrastructure.Persistence.Configurations.Identity
{
    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<IdentityRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<string>> builder)
        {
            builder.ToTable("Roles");
        }
    }
}
