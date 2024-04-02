using MarketGoods.Catalog.DAL.Abstractions;
using MarketGoods.Catalog.Entities;

namespace MarketGoods.Catalog.DAL.Implementations
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(DBFakeClass context) : base(context) { }
    }
}
