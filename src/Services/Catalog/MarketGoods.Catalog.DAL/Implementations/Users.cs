using MarketGoods.Catalog.DAL.Abstractions;
using MarketGoods.Catalog.Entities;

namespace MarketGoods.Catalog.DAL.Implementations
{
    public class Users : GenericRepository<User>
    {
        public Users(DBFakeClass context) : base(context) { }
    }
}
