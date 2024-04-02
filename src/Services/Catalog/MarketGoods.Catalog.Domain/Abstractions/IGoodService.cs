using MarketGoods.Catalog.Entities;

namespace MarketGoods.Catalog.Domain.Abstractions
{
    internal interface IGoodService
    {
        IEnumerable<Good> GetGoods(Func<Good, bool> filter);
        Good GetGood(Guid id);
    }
}
