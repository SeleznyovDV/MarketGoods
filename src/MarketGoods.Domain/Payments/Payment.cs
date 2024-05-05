namespace MarketGoods.Domain.Payments
{
    using MarketGoods.Domain.Users;
    using MarketGoods.Domain.Orders;
    using MarketGoods.Domain.ValueObjects;

    public sealed class Payment
    {
        public PaymentId Id { get; private set; }
        public PaymentAmount Amount { get; private set; }
        public PaymentStatus Status { get; private set; }

        public Payment(PaymentId paymentId, PaymentAmount amount)
        {
            Id = paymentId;
            Amount = amount;
            Status = PaymentStatus.Created;
        }

        public Payment()
        {
            
        }
    }
}
