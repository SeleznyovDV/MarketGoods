using MarketGoods.Catalog.DAL.Abstractions;
using MarketGoods.Catalog.Entities;
namespace MarketGoods.Catalog.DAL.Implementations
{
    public class Goods : GenericRepository<Good>
    {
        public Goods(DBFakeClass context) : base(context) { }
    }
}
