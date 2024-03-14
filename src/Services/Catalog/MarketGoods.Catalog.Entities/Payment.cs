using MarketGoods.Catalog.Entities.Abstractions;

namespace MarketGoods.Catalog.Entities
{
    public class Payment : BaseEntity<Guid>
    {
        public decimal Amount { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
