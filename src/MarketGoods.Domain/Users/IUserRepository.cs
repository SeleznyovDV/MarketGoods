namespace MarketGoods.Domain.Users
{
    public interface IUserRepository
	{
		Task<User?> GetAsync(UsersId id);
		IQueryable<User> GetAll(Func<User, bool> filter);
		void Update(User user);
		void Remove(User user);
		Task AddAsync(User user);
	}
}

