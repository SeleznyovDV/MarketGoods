namespace MarketGoods.Catalog.Entities
{
    using MarketGoods.Catalog.Entities.Abstractions;
    public class Order : BaseEntity<Guid>
    {
        public IEnumerable<Good> Goods { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
