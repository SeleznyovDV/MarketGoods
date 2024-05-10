namespace MarketGoods.Domain.Orders
{
    using MarketGoods.Domain.Users;
    using MarketGoods.Domain.Goods;
    using MarketGoods.Domain.Payments;

    public sealed class Order
    {
        public OrderId Id { get; private set; }
        public IList<Good> Goods { get; private set; }
        public User User { get; private set; }
        public UserId UserId { get; private set; }
        public Payment Payment { get; private set; }
        public PaymentId PaymentId { get; private set; }
        public DateTime? Created { get; private set; }
        public Order(OrderId orderId, IList<Good> goods, User user, Payment payment)
        {
            Id = orderId;
            Goods = goods;
            User = user;
            Payment = payment;
            Created = DateTime.Now;
        }
        public Order()
        {
            
        }
    }
}
