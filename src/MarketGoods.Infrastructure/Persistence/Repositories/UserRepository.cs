﻿namespace MarketGoods.Infrastructure.Persistence.Repositories
{
    using MarketGoods.Application.Data;
    using MarketGoods.Domain.Users;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserRepository : IUserRepository
    {
        private readonly IApplicationDbContext _db;

        public UserRepository(IApplicationDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task AddAsync(User user)
        {
            await _db.Users.AddAsync(user);
        }

        public void Remove(User user)
        {
            _db.Users.Remove(user);
        }

        public IQueryable<User> GetAll(Func<User, bool> filter)
        {
            return _db.Users.Where(filter).AsQueryable();
        }

        public async Task<User?> GetAsync(UsersId id)
        {
            return await _db.Users.FindAsync(id);
        }

        public void Update(User customer)
        {
            _db.Users.Update(customer);
        }
    }
}
