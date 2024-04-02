using MarketGoods.Catalog.Entities;

namespace MarketGoods.Catalog.Domain.Abstractions
{
    internal interface IGoodService
    {
        /// <summary>
        /// Get goods by filter.
        /// </summary>
        /// <param name="filter">Filter func.</param>
        /// <returns>Goods.</returns>
        IEnumerable<Good> GetGoods(Func<Good, bool> filter);

        /// <summary>
        /// Get good by ID.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <returns>Good.</returns>
        Good GetGood(Guid id);
        
        /// <summary>
        /// Leave a review on your order.
        /// </summary>
        /// <param name="goodId">Good ID.</param>
        /// <param name="userId">User ID.</param>
        /// <param name="raiting">Review raiting.</param>
        /// <param name="text">Review text.</param>
        /// <returns>Result. True - if dare to leave a review, false - if failed.</returns>
        public bool LeaveReviewOnGood(Guid goodId, Guid userId, int raiting, string text);
    }
}
