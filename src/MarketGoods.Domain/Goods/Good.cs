namespace MarketGoods.Domain.Goods
{
    public sealed class Good
    {
        public GoodId GoodId { get; private set; }
        public string Name { get; private set; }
        public string Description { private get; set; }
        public decimal Price { get; private set; }
        public Good(GoodId goodId, string name, string description, decimal price)
        {
            GoodId = goodId;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
