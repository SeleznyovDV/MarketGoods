namespace MarketGoods.Domain.Reviews
{
    using MarketGoods.Domain.Customers;
    using MarketGoods.Domain.Goods;
    using MarketGoods.Domain.ValueObjects;

    public sealed class Review
    {
        public ReviewId ReviewId { get; private set; }
        public string Text { get; set; }
        public Customer Customer { get; set; }
        public Good Good { get; set; }
        public Raiting Rating { get; set; }
        public Review(ReviewId reviewId, string text, Customer customer, Good good, Raiting raiting)
        {
            ReviewId = reviewId;
            Text = text;
            Customer = customer;
            Good = good;
            Rating = raiting;
        }
    }
}
