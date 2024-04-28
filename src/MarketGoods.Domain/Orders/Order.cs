namespace MarketGoods.Domain.Orders
{
    using MarketGoods.Domain.Users;
    using MarketGoods.Domain.Goods;
    using MarketGoods.Domain.Payments;

    public sealed class Order
    {
        public OrderId OrderId { get; private set; }
        public IList<Good> Goods { get; private set; }
        public User Customer { get; private set; }
        public Payment Payment { get; private set; }
        public DateTime? Created { get; private set; }
        public Order(OrderId orderId, IList<Good> goods, User customer, Payment payment, DateTime? created)
        {
            OrderId = orderId;
            Goods = goods;
            Customer = customer;
            Payment = payment;
            Created = created;
        }
    }
}
