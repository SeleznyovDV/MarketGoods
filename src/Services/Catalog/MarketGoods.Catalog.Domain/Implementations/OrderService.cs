using MarketGoods.Catalog.Domain.Abstractions;
using MarketGoods.Catalog.DAL.Abstractions;
using MarketGoods.Catalog.Entities;

namespace MarketGoods.Catalog.Domain.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orders;
        private readonly IGoodRepository _goods;

        public OrderService(IOrderRepository orders, IGoodRepository goods)
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
