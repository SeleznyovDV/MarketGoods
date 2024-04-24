namespace MarketGoodsDDD.Domain.Customers
{
    using MarketGoods.Domain.Customers;
    public interface ICustomerRepository
	{
		Task<Customer?> GetAsync(CustomerId id);
		Task AddAsync(Customer customer);
	}
}

