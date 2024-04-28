namespace MarketGoods.Domain.Reviews
{
    public interface IReviewRepository
	{
		Task<Review?> GetAsync(ReviewId id);
		IQueryable<Review> GetAll(Func<Review, bool> filter);
		void Update(Review review);
		void Remove(Review review);
		Task AddAsync(Review review);
	}
}

