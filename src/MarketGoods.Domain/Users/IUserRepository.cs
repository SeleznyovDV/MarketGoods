﻿namespace MarketGoods.Domain.Users
{
    public interface IUserRepository
	{
		Task<User?> GetAsync(UserId id);
		IQueryable<User> GetAll(Func<User, bool> filter = null);
		void Update(User user);
		void Remove(User user);
		Task AddAsync(User user);
	}
}

