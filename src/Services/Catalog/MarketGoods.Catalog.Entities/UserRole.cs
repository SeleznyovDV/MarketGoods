using MarketGoods.Catalog.Entities.Abstractions;

namespace MarketGoods.Catalog.Entities
{
    public class UserRole : BaseEntity<Guid>
    {
       public string Name { get; set; }
    }
}
