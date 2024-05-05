namespace MarketGoods.Infrastructure.Persistence.Configurations
{
    using MarketGoods.Domain.Payments;
    using MarketGoods.Domain.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(paymentId => paymentId.Value, value => new PaymentId(value));
            builder.Property(x => x.Amount).HasConversion(amount => amount.Amount, value => PaymentAmount.Create(value)!);
            builder.Property(x => x.Status).HasConversion<string>();
        }
    }
}
