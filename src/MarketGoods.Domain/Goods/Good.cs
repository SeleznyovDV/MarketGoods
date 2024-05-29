namespace MarketGoods.Domain.Goods
{
    using MarketGoods.Domain.ValueObjects;
    public sealed class Good
    {
        public GoodId Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Money Price { get; private set; }
        public Good(GoodId goodId, string name, string description, Money price)
        {
            Id = goodId;
            Name = name;
            Description = description;
            Price = price;
        }
        public Good()
        {
            
        }

        public void UpdateGood(string name, string description, Money price)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidOperationException("Name is empty");
            }

            if (price is null)
            {
                throw new InvalidOperationException("Currency is not valid");
            }

            Name = name;
            Description = description;
            Price = price;
        }
    }
}
