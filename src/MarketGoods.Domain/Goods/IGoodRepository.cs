namespace MarketGoods.Domain.Goods
{
    public interface IGoodRepository
	{
		Task<Good?> GetAsync(GoodId id);
		IQueryable<Good> GetAll(Func<Good, bool>? filter = null);
        void Update(Good good);
		void Remove(Good good);
		Task AddAsync(Good good);
	}
}

