namespace MarketGoods.Catalog.DAL
{
    using MarketGoods.Catalog.Entities;
    using MarketGoods.Catalog.Entities.Abstractions;

    public class DBFakeClass
    {
        public ICollection<Good> Goods { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<TEntity> Set<TEntity>() where TEntity : BaseEntity<Guid>
        {
            if (typeof(TEntity) == typeof(Good))
                return Goods as ICollection<TEntity>;
            else if (typeof(TEntity) == typeof(Order))
                return Orders as ICollection<TEntity>;
            else if (typeof(TEntity) == typeof(Payment))
                return Payments as ICollection<TEntity>;
            else if (typeof(TEntity) == typeof(Review))
                return Reviews as ICollection<TEntity>;
            else if (typeof(TEntity) == typeof(User))
                return Users as ICollection<TEntity>;
            else if (typeof(TEntity) == typeof(UserRole))
                return UserRoles as ICollection<TEntity>;

            return default;
        }
    }
}
