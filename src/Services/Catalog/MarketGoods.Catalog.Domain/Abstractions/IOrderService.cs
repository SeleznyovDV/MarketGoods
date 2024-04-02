using MarketGoods.Catalog.Entities;

namespace MarketGoods.Catalog.Domain.Abstractions
{
    public interface IOrderService
    {
        /// <summary>
        /// Create user's order.
        /// </summary>
        /// <param name="userId">User ID.</param>
        public Order CreateOrder(Guid userId);
        
        /// <summary>
        /// Add good to new user's cart.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="goodId">Good ID.</param>
        public void AddToCart(Guid userId, Guid goodId);

        /// <summary>
        /// Add good to user's cart.
        /// </summary>
        /// <param name="goodId">Good ID.</param>
        /// <param name="order">Order.</param>
        public void AddToCart(Guid goodId, Order order);
        
        /// <summary>
        /// Remove good from user's cart.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="goodId">Good ID.</param>
        /// <param name="order">Exsisting order.</param>
        public void RemoveFromCart(Guid userId, Guid goodId, Guid orderId);

        /// <summary>
        /// Place an order.
        /// </summary>
        public void PlaceOrder(Guid orderId);

        /// <summary>
        /// Confirm order.
        /// </summary>
        /// <param name="orderId"></param>
        public void ConfirmOrder(Guid orderId);

        /// <summary>
        /// Cancel order.
        /// </summary>
        /// <param name="orderId"></param>
        public void CancelOrder(Guid orderId);

        /// <summary>
        /// Get orders by filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<Order> GetOrders(Func<Order, bool> filter);

        /// <summary>
        /// Get order by ID.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Order GetOrders(Guid order);

    }
}
