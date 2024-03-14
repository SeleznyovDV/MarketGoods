using MarketGoods.Catalog.DAL.Abstractions;
using MarketGoods.Catalog.Entities;

namespace MarketGoods.Catalog.DAL.Implementations
{
    public class UserRoles : GenericRepository<UserRole>
    {
        public UserRoles(DBFakeClass context) : base(context) { }
    }
}
