using MarketGoods.Catalog.DAL.Implementations;
using MarketGoods.Catalog.Domain.Abstractions;
using MarketGoods.Catalog.Entities;

namespace MarketGoods.Catalog.Domain.Implementations
{
    public class GoodService : IGoodService
    {
        private readonly Goods _goods;
        public GoodService(Goods goods)
        {
            _goods = goods;
        }

        public Good GetGood(Guid id)
        {
            return _goods.Get(id);
        }

        public IEnumerable<Good> GetGoods(Func<Good, bool> filter)
        {
            return _goods.GetAll(filter);
        }
    }
}
