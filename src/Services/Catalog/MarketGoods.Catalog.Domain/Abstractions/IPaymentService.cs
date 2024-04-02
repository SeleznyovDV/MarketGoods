using MarketGoods.Catalog.Entities;

namespace MarketGoods.Catalog.Domain.Abstractions
{
    public interface IPaymentService
    {
        /// <summary>
        /// Create a payment for an order.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Payment CreateOrderPayment(Order order);

        /// <summary>
        /// Send the payment to the payment system.
        /// </summary>
        /// <param name="payment">Payment.</param>
        public void SendPayment(Payment payment);

        /// <summary>
        /// Send the payment to the payment system.
        /// </summary>
        /// <param name="payment">Payment.</param>
        public void CheckPaymentStatus(Payment payment);
        
        /// <summary>
        /// Cancel payment.
        /// </summary>
        /// <param name="payment"></param>
        public void CancelPayment(Payment payment);
    }
}
