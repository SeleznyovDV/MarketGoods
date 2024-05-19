namespace MarketGoods.Domain.DomainErrors
{
    using ErrorOr;
    public static partial class Errors
    {
        public static class Goods
        {
            public static Error PriceHasIncorrectValue => Error.Validation("Good.Price.Value", "Price value is not valid");
            public static Error CurrencyHasIncorrectValue => Error.Validation("Good.Price.Currency", "Currency is not valid");
        }
    }
}
