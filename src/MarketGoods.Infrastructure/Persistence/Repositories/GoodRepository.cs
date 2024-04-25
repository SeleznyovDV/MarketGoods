namespace MarketGoods.Infrastructure.Persistence.Repositories
{
    using MarketGoods.Application.Data;
    using MarketGoods.Domain.Goods;
    using System.Linq;
    using System.Threading.Tasks;

    public class GoodRepository : IGoodRepository
    {
        private readonly IApplicationDbContext _db;

        public GoodRepository(IApplicationDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task AddAsync(Good good)
        {
            await _db.Goods.AddAsync(good);
            await _db.SaveChangesAsync();
        }

        public void Remove(Good good)
        {
            _db.Goods.Remove(good);
        }

        public IQueryable<Good> GetAll(Func<Good, bool> filter)
        {
            return _db.Goods.Where(filter).AsQueryable();
        }

        public async Task<Good?> GetAsync(GoodId id)
        {
            return await _db.Goods.FindAsync(id);
        }

        public async Task UpdateAsync(Good good)
        {
            _db.Goods.Update(good);
            await _db.SaveChangesAsync();
        }
    }
}
