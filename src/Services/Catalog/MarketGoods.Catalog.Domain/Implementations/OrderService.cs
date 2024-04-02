using MarketGoods.Catalog.Domain.Abstractions;
using MarketGoods.Catalog.DAL.Abstractions;
using MarketGoods.Catalog.Entities;

namespace MarketGoods.Catalog.Domain.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orders;
        private readonly IGoodRepository _goods;
        private readonly IReviewRepository _reviews;
        private readonly IPaymentService _paymentService;

        public OrderService(IOrderRepository orders, IGoodRepository goods, IReviewRepository reviews, IPaymentService paymentService)
        {
            _orders = orders;
            _goods = goods;
            _paymentService = paymentService;
            _reviews = reviews;
        }

        /// <summary>
        /// Create user's order.
        /// </summary>
        /// <param name="userId">User ID.</param>
        public Order CreateOrder(Guid userId)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = userId
            };
            _orders.Create(order);
            return order;
        }

        /// <summary>
        /// Add good to new user's cart.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="goodId">Good ID.</param>
        public void AddToCart(Guid userId, Guid goodId)
        {
            var order = CreateOrder(userId);
            AddToCart(goodId, order);
        }

        /// <summary>
        /// Add good to user's cart.
        /// </summary>
        /// <param name="goodId">Good ID.</param>
        /// <param name="order">Order.</param>
        public void AddToCart(Guid goodId, Order order)
        {
            var good = _goods.Get(goodId);
            order.Goods.Add(good);
            _orders.Create(order);
        }

        /// <summary>
        /// Remove good from user's cart.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="goodId">Good ID.</param>
        /// <param name="order">Exsisting order.</param>
        public void RemoveFromCart(Guid userId, Guid goodId, Guid orderId) 
        {
            var order = _orders.Get(orderId);
            var good = _goods.Get(goodId);
            if (order != null) 
            {
                order.Goods.Remove(good);
            }
            
        }

        /// <summary>
        /// Place an order.
        /// </summary>
        public void PlaceOrder(Guid orderId)
        {
            var order = _orders.Get(orderId);
            var payment = _paymentService.CreateOrderPayment(order);
            order.Payment = payment;
            _orders.Update(order);
        }
        
        /// <summary>
        /// Confirm order.
        /// </summary>
        /// <param name="orderId"></param>
        public void ConfirmOrder(Guid orderId)
        {
            var order = _orders.Get(orderId);
            _paymentService.SendPayment(order.Payment);
        }

        /// <summary>
        /// Cancel order.
        /// </summary>
        /// <param name="orderId"></param>
        public void CancelOrder(Guid orderId)
        {
            var order = _orders.Get(orderId);
            _paymentService.CancelPayment(order.Payment);
        }
        
        /// <summary>
        /// Get orders by filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<Order> GetOrders(Func<Order, bool> filter)
        {
            return _orders.GetAll(filter);
        }

        /// <summary>
        /// Get order by ID.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Order GetOrders(Guid order)
        {
            return _orders.Get(order);
        }
    }
}
