namespace MarketGoods.Infrastructure.Persistence.Repositories
{
    using MarketGoods.Application.Data;
    using MarketGoods.Domain.Reviews;
    using System.Linq;
    using System.Threading.Tasks;

    public class ReviewRepository : IReviewRepository
    {
        private readonly IApplicationDbContext _db;

        public ReviewRepository(IApplicationDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task AddAsync(Review review)
        {
            await _db.Reviews.AddAsync(review);
        }

        public void Remove(Review review)
        {
            _db.Reviews.Remove(review);
        }

        public IQueryable<Review> GetAll(Func<Review, bool> filter)
        {
            return _db.Reviews.Where(filter).AsQueryable();
        }

        public async Task<Review?> GetAsync(ReviewId id)
        {
            return await _db.Reviews.FindAsync(id);
        }

        public void Update(Review review)
        {
            _db.Reviews.Update(review);
        }
    }
}
