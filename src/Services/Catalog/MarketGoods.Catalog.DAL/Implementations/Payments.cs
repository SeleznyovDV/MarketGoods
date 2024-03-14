using MarketGoods.Catalog.DAL.Abstractions;
using MarketGoods.Catalog.Entities;

namespace MarketGoods.Catalog.DAL.Implementations
{
    public class Payments : GenericRepository<Payment>
    {
        public Payments(DBFakeClass context) : base(context) { }
    }
}
