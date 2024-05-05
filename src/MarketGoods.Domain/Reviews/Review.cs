namespace MarketGoods.Domain.Reviews
{
    using MarketGoods.Domain.Users;
    using MarketGoods.Domain.Goods;
    using MarketGoods.Domain.ValueObjects;

    public sealed class Review
    {
        public ReviewId Id { get; private set; }
        public string Text { get; private set; }
        public User User { get; private set; }
        public Good Good { get; private set; }
        public Raiting Rating { get; private set; }
        public Review(ReviewId reviewId, string text, User user, Good good, Raiting raiting)
        {
            Id = reviewId;
            Text = text;
            User = user;
            Good = good;
            Rating = raiting;
        }
    }
}
