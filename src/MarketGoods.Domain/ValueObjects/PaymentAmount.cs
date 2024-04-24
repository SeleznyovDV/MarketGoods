namespace MarketGoods.Domain.ValueObjects
{
    public partial record PaymentAmount
    {
        public decimal Amount { get; init; }
        private PaymentAmount(decimal amount)
        {
            Amount = amount;
        }
        public static PaymentAmount Create(decimal amount)
        { 
            return new PaymentAmount(amount);
        }
    }
}
