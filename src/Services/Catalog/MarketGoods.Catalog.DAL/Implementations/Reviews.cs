using MarketGoods.Catalog.DAL.Abstractions;
using MarketGoods.Catalog.Entities;

namespace MarketGoods.Catalog.DAL.Implementations
{
    public class Reviews : GenericRepository<Review>
    {
        public Reviews(DBFakeClass context) : base(context) { }
    }
}
