namespace MarketGoods.Domain.Customers
{
    public interface ICustomerRepository
	{
		Task<Customer?> GetAsync(CustomerId id);
		IQueryable<Customer> GetAll(Func<Customer, bool> filter);
		Task UpdateAsync(Customer customer);
		void Remove(Customer customer);
		Task AddAsync(Customer customer);
	}
}

