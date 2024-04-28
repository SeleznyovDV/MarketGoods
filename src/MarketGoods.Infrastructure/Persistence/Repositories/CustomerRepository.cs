namespace MarketGoods.Infrastructure.Persistence.Repositories
{
    using MarketGoods.Application.Data;
    using MarketGoods.Domain.Customers;
    using System.Linq;
    using System.Threading.Tasks;

    public class CustomerRepository : ICustomerRepository
    {
        private readonly IApplicationDbContext _db;

        public CustomerRepository(IApplicationDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task AddAsync(Customer customer)
        {
            await _db.Customers.AddAsync(customer);
        }

        public void Remove(Customer customer)
        {
            _db.Customers.Remove(customer);
        }

        public IQueryable<Customer> GetAll(Func<Customer, bool> filter)
        {
            return _db.Customers.Where(filter).AsQueryable();
        }

        public async Task<Customer?> GetAsync(CustomerId id)
        {
            return await _db.Customers.FindAsync(id);
        }

        public async Task UpdateAsync(Customer customer)
        {
            _db.Customers.Update(customer);
            await _db.SaveChangesAsync();
        }
    }
}
