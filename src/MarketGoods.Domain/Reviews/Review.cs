namespace MarketGoods.Domain.Reviews
{
    using MarketGoods.Domain.Users;
    using MarketGoods.Domain.Goods;
    using MarketGoods.Domain.ValueObjects;

    public sealed class Review
    {
        public ReviewId ReviewId { get; private set; }
        public string Text { get; private set; }
        public User Customer { get; private set; }
        public Good Good { get; private set; }
        public Raiting Rating { get; private set; }
        public Review(ReviewId reviewId, string text, User customer, Good good, Raiting raiting)
        {
            ReviewId = reviewId;
            Text = text;
            Customer = customer;
            Good = good;
            Rating = raiting;
        }
    }
}
