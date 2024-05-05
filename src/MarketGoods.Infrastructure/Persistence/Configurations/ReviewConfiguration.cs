namespace MarketGoods.Infrastructure.Persistence.Configurations
{
    using MarketGoods.Domain.Reviews;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(reviewId => reviewId.Value, value => new ReviewId(value));
            builder.HasOne(x => x.User).WithOne();
            builder.HasOne(x => x.Good).WithOne();
            builder.OwnsOne(x => x.Rating, raitingBuilder =>
            {
                raitingBuilder.Property(x => x.Quality).HasColumnName("QualityRaiting");
                raitingBuilder.Property(x => x.Satisfaction).HasColumnName("SatisfactionRaiting");
            });
        }
    }
}
