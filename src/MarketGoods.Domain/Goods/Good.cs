namespace MarketGoods.Domain.Goods
{
    using MarketGoods.Domain.ValueObjects;
    using System.Diagnostics;
    using System.Xml.Linq;

    public sealed class Good
    {
        public GoodId Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Money Price { get; private set; }
        public Good(GoodId goodId, string name, string description, Money price)
        {
            Validate(name, price);
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

            Validate(name, price);
            Name = name;
            Description = description;
            Price = price;
        }

        private void Validate(string name, Money price)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidOperationException("Name is empty");
            }

            if (price is null)
            {
                throw new InvalidOperationException("Currency is not valid");
            }
        }
    }
}
