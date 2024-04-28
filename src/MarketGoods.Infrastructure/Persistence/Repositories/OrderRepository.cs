namespace MarketGoods.Infrastructure.Persistence.Repositories
{
    using MarketGoods.Application.Data;
    using MarketGoods.Domain.Orders;
    using System.Linq;
    using System.Threading.Tasks;

    public class OrderRepository : IOrderRepository
    {
        private readonly IApplicationDbContext _db;

        public OrderRepository(IApplicationDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task AddAsync(Order order)
        {
            await _db.Orders.AddAsync(order);
        }

        public void Remove(Order order)
        {
            _db.Orders.Remove(order);
        }

        public IQueryable<Order> GetAll(Func<Order, bool> filter)
        {
            return _db.Orders.Where(filter).AsQueryable();
        }

        public async Task<Order?> GetAsync(OrderId id)
        {
            return await _db.Orders.FindAsync(id);
        }

        public void Update(Order order)
        {
            _db.Orders.Update(order);
        }
    }
}
