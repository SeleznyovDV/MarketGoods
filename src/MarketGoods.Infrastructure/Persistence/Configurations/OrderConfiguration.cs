namespace MarketGoods.Infrastructure.Persistence.Configurations
{
    using MarketGoods.Domain.Orders;
    using MarketGoods.Domain.Users;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(orderId => orderId.Value, value => new OrderId(value));

            builder
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder.HasOne(x => x.Payment)
                .WithMany()
                .HasForeignKey(x => x.PaymentId)
                .IsRequired(false);

            builder.HasMany(x => x.Goods)
                .WithMany();
        }
    }
}
