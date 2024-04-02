using MarketGoods.Catalog.DAL.Abstractions;
using MarketGoods.Catalog.Domain.Abstractions;
using MarketGoods.Catalog.Entities;

namespace MarketGoods.Catalog.Domain.Implementations
{
    public class GoodService : IGoodService
    {
        private readonly IGoodRepository _goods;
        private readonly IReviewRepository _reviews;
        public GoodService(IGoodRepository goods, IReviewRepository reviews)
        {
            _goods = goods;
            _reviews = reviews;
        }

        /// <summary>
        /// Get good by ID.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <returns>Good.</returns>
        public Good GetGood(Guid id)
        {
            return _goods.Get(id);
        }

       /// <summary>
       /// Get goods by filter.
       /// </summary>
       /// <param name="filter">Filter func.</param>
       /// <returns>Goods.</returns>
        public IEnumerable<Good> GetGoods(Func<Good, bool> filter)
        {
            return _goods.GetAll(filter);
        }

        /// <summary>
        /// Leave a review on your order.
        /// </summary>
        /// <param name="goodId">Good ID.</param>
        /// <param name="userId">User ID.</param>
        /// <param name="raiting">Review raiting.</param>
        /// <param name="text">Review text.</param>
        /// <returns>Result. True - if dare to leave a review, false - if failed.</returns>
        public bool LeaveReviewOnGood(Guid goodId, Guid userId, int raiting, string text)
        {
            // Check for user review on the good.
            if (_reviews.GetAll().Any(x => x.GoodId == goodId && x.UserId == userId))
                return false;
            
            var review = new Review() { 
                Id = Guid.NewGuid(),
                GoodId = goodId,
                UserId = userId,
                Rating = raiting,
                Text = text
            };
            _reviews.Create(review);
            return true;
        }

    }
}
