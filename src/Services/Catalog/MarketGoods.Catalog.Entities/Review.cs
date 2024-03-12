using MarketGoods.Catalog.Entities.Abstractions;

namespace MarketGoods.Catalog.Entities
{
    public class Review : BaseEntity<Guid>
    {
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public Guid GoodId { get; set; }
        public User User { get; set; }
        public Good Good { get; set; }
        public int Rating { get; set; }
    }
}
