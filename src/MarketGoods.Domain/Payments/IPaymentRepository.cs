namespace MarketGoods.Domain.Payments
{
    public interface IPaymentRepository
	{
		Task<Payment?> GetAsync(PaymentId id);
		IQueryable<Payment> GetAll(Func<Payment, bool> filter);
		Task UpdateAsync(Payment payment);
		void Remove(Payment payment);
		Task AddAsync(Payment payment);
	}
}

