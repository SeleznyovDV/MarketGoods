using MarketGoods.Catalog.DAL.Abstractions;
using MarketGoods.Catalog.Domain.Abstractions;
using MarketGoods.Catalog.Entities;

namespace MarketGoods.Catalog.Domain.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _payments;
        public PaymentService(IPaymentRepository payments)
        {
            _payments = payments;
        }

        /// <summary>
        /// Create a payment for an order.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Payment CreateOrderPayment(Order order)
        {
            var payment = new Payment()
            {
                Id = Guid.NewGuid(),
                Order = order,
                User = order.User,
                Status = PaymentStatus.Created,
                Amount = order.Goods.Select(x => x.Price).Sum()
            };
            _payments.Create(payment);
            return payment;
        }

        /// <summary>
        /// Send the payment to the payment system.
        /// </summary>
        /// <param name="payment">Payment.</param>
        public void SendPayment(Payment payment)
        {
            //TODO: Seleznyov_DV. Send the payment to the payment system.
            
            payment.Status = PaymentStatus.Pending;
            _payments.Update(payment);
        }

        /// <summary>
        /// Send the payment to the payment system.
        /// </summary>
        /// <param name="payment">Payment.</param>
        public void CheckPaymentStatus(Payment payment)
        {
            //TODO: Seleznyov_DV. Check payment status.
        }
        
        /// <summary>
        /// Cancel payment.
        /// </summary>
        /// <param name="payment"></param>
        public void CancelPayment(Payment payment)
        {
            //TODO: Seleznyov_DV. Send cancel message to payment system.

            payment.Status = PaymentStatus.Canceled;
            _payments.Update(payment);
        }
    }
}
