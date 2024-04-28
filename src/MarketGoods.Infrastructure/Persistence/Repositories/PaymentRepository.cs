namespace MarketGoods.Infrastructure.Persistence.Repositories
{
    using MarketGoods.Application.Data;
    using MarketGoods.Domain.Payments;
    using System.Linq;
    using System.Threading.Tasks;

    public class PaymentRepository : IPaymentRepository
    {
        private readonly IApplicationDbContext _db;

        public PaymentRepository(IApplicationDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task AddAsync(Payment payment)
        {
            await _db.Payments.AddAsync(payment);
        }

        public void Remove(Payment payment)
        {
            _db.Payments.Remove(payment);
        }

        public IQueryable<Payment> GetAll(Func<Payment, bool> filter)
        {
            return _db.Payments.Where(filter).AsQueryable();
        }

        public async Task<Payment?> GetAsync(PaymentId id)
        {
            return await _db.Payments.FindAsync(id);
        }

        public void Update(Payment payment)
        {
            _db.Payments.Update(payment);
        }

    }
}
