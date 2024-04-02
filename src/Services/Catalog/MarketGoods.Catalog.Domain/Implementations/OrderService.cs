using MarketGoods.Catalog.DAL.Implementations;
using MarketGoods.Catalog.Domain.Abstractions;
using MarketGoods.Catalog.Entities;

namespace MarketGoods.Catalog.Domain.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly Orders _orders;
        private readonly Goods _goods;

        public OrderService(Orders orders, Goods goods)
        {
            _orders = orders;
            _goods = goods;
        }

        public void AddToCart(Guid userId, Guid goodId)
        {
            var good = _goods.Get(goodId);
            var order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = userId
            };
            order.Goods.Add(good);
        }
    }
}
