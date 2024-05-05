﻿namespace MarketGoods.Infrastructure.Persistence.Configurations
{
    using MarketGoods.Domain.Orders;
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
            builder.HasOne(x => x.User).WithOne();
            builder.HasOne(x => x.Payment).WithOne();
            builder.HasMany(x => x.Goods).WithOne();
        }
    }
}
