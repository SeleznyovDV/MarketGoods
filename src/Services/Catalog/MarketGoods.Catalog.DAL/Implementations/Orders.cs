using MarketGoods.Catalog.DAL.Abstractions;
using MarketGoods.Catalog.Entities;

namespace MarketGoods.Catalog.DAL.Implementations
{
    public class Orders : GenericRepository<Order>
    {
        public Orders(DBFakeClass context) : base(context) { }
    }
}
