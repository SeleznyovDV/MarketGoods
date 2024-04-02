using MarketGoods.Catalog.Entities;

namespace MarketGoods.Catalog.Domain.Abstractions
{
    public interface IOrderService
    {
        void AddToCart(Guid userId, Guid good);
    }
}
