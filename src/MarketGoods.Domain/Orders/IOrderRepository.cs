namespace MarketGoods.Domain.Orders
{
    public interface IOrderRepository
	{
		Task<Order?> GetAsync(OrderId id);
		IQueryable<Order> GetAll(Func<Order, bool> filter);
		void Update(Order order);
		void Remove(Order order);
		Task AddAsync(Order order);
	}
}

