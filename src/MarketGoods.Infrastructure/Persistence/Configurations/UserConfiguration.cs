namespace MarketGoods.Infrastructure.Persistence.Configurations
{
    using MarketGoods.Domain.Users;
    using MarketGoods.Domain.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(userId => userId.Value, value => new UserId(value));

            builder.Property(c => c.FirstName).HasMaxLength(50);
            builder.Property(c => c.LastName).HasMaxLength(50);
            builder.Property(c => c.Role).HasConversion<string>();

            builder.Ignore(c => c.FullName);
            builder.Property(c => c.PhoneNumber)
                .HasConversion(phoneNumber => phoneNumber.Value, value => PhoneNumber.Create(value)!)
                .HasMaxLength(12);

            builder.HasIndex(x => x.PhoneNumber).IsUnique();

            // Обсудить конфигурацию сложных ValueObjects.
            builder.OwnsOne(c => c.Address, addressBuilder =>
            {
                addressBuilder.OwnsOne(a => a.City, cityBuilder =>
                {
                    cityBuilder.OwnsOne(c => c.Region, regionBuilder =>
                    {
                        regionBuilder.Property(r => r.Code).HasColumnName("RegionCode").HasMaxLength(2).IsRequired(false);
                        regionBuilder.Property(r => r.Name).HasColumnName("Region").HasMaxLength(100).IsRequired(false);
                    });
                    cityBuilder.Property(c => c.Name).HasColumnName("City").HasMaxLength(100).IsRequired(false);
                });

                addressBuilder.Property(a => a.Street).HasMaxLength(500).IsRequired(false);
                addressBuilder.Property(a => a.HouseNumber).HasMaxLength(10).IsRequired(false);
                addressBuilder.Property(a => a.Entrance).HasMaxLength(3).IsRequired(false);
                addressBuilder.Property(a => a.Floor).HasMaxLength(4).IsRequired(false);
                addressBuilder.Property(a => a.Flat).HasMaxLength(10).IsRequired(false);
                addressBuilder.Property(a => a.IntercomCode).HasMaxLength(50).IsRequired(false);
                addressBuilder.Property(a => a.PostalCode).HasMaxLength(10).IsRequired(false);
            });

        }
    }
}
