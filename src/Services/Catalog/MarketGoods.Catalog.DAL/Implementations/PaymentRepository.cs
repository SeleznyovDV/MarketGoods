using MarketGoods.Catalog.DAL.Abstractions;
using MarketGoods.Catalog.Entities;

namespace MarketGoods.Catalog.DAL.Implementations
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(DBFakeClass context) : base(context) { }
    }
}
