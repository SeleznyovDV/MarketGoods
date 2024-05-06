namespace MarketGoods.Domain.ValueObjects
{
    public partial record Money
    {
        public decimal Value { get; init; }
        public Currency Currency { get; init; }
        private Money(decimal value, Currency currency)
        {
            Value = value;
            Currency = currency;
        }
        public static Money Create(decimal value, Currency currency)
        {
            if (value < 0)
                return null;

            return new Money(value, currency);
        }
    }
}
