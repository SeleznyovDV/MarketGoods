namespace MarketGoods.Infrastructure.Persistence.Configurations.Identity
{
    using MarketGoods.Infrastructure.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class ApplicationUserRoleConfiguration
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            builder.ToTable("ApplicationUserRoles");
        }
    }
}
