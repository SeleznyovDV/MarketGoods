
using MarketGoods.Catalog.Entities.Abstractions;

namespace MarketGoods.Catalog.Entities
{
    public class Good : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
