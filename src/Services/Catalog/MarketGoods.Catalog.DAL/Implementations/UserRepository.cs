using MarketGoods.Catalog.DAL.Abstractions;
using MarketGoods.Catalog.Entities;

namespace MarketGoods.Catalog.DAL.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DBFakeClass context) : base(context) { }
    }
}
