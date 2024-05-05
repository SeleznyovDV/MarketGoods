namespace MarketGoods.Infrastructure.Persistence.Configurations
{
    using MarketGoods.Domain.Goods;
    using MarketGoods.Domain.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GoodConfiguration : IEntityTypeConfiguration<Good>
    {
        public void Configure(EntityTypeBuilder<Good> builder)
        {
            builder.ToTable("Goods");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasConversion(goodId => goodId.Value, value => new GoodId(value)!);
            
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.OwnsOne(x => x.Price, priceBuilder =>
            {
                priceBuilder.Property(p => p.Value).HasColumnName("Price").HasDefaultValue(0);
                priceBuilder.Property(p => p.Currency).HasColumnName("Currency").HasConversion<string>();
            });
        }
    }
}
