namespace MarketGoods.Domain.ValueObjects
{
    public partial record Price
    {
        public decimal Value { get; init; }
        public Currency Currency { get; init; }
        private Price(decimal value, Currency currency)
        {
            Value = value;
            Currency = currency;
        }
        public static Price Create(decimal value, Currency currency)
        {
            if (value < 0)
                return null;

            return new Price(value, currency);
        }
    }
}
