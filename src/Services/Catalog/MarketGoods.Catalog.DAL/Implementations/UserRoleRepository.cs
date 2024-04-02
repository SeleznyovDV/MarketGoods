using MarketGoods.Catalog.DAL.Abstractions;
using MarketGoods.Catalog.Entities;

namespace MarketGoods.Catalog.DAL.Implementations
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(DBFakeClass context) : base(context) { }
    }
}
