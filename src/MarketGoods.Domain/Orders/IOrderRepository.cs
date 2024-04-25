﻿namespace MarketGoods.Domain.Orders
{
    public interface IOrderRepository
	{
		Task<Order?> GetAsync(OrderId id);
		IQueryable<Order> GetAll(Func<Order, bool> filter);
		Task UpdateAsync(Order order);
		void Remove(Order order);
		Task AddAsync(Order order);
	}
}

