namespace MarketGoods.Domain.Goods
{
    using MarketGoods.Domain.ValueObjects;
    public sealed class Good
    {
        public GoodId Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Price Price { get; private set; }
        public Good(GoodId goodId, string name, string description, Price price)
        {
            Id = goodId;
            Name = name;
            Description = description;
            Price = price;
        }
        public Good()
        {
            
        }
    }
}
