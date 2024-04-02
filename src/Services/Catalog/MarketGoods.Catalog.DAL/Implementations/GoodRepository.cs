using MarketGoods.Catalog.DAL.Abstractions;
using MarketGoods.Catalog.Entities;
namespace MarketGoods.Catalog.DAL.Implementations
{
    public class GoodRepository : GenericRepository<Good>, IGoodRepository
    {
        public GoodRepository(DBFakeClass context) : base(context) { }
    }
}
