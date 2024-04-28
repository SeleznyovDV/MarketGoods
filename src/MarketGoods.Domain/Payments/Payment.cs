namespace MarketGoods.Domain.Payments
{
    using MarketGoods.Domain.Users;
    using MarketGoods.Domain.Orders;
    using MarketGoods.Domain.ValueObjects;

    public sealed class Payment
    {
        public PaymentId PaymentId { get; private set; }
        public PaymentAmount Amount { get; private set; }
        public User Customer { get; private set; }
        public Order Order { get; private set; }
        public PaymentStatus Status { get; private set; }

        public Payment(PaymentId paymentId, PaymentAmount amount, User customer, Order order)
        {
            PaymentId = paymentId;
            Amount = amount;
            Customer = customer;
            Order = order;
            Status = PaymentStatus.Created;
        }
    }
}
