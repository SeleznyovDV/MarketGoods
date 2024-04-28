namespace MarketGoods.Application.Data
{
    using MarketGoods.Domain.Users;
    using MarketGoods.Domain.Goods;
    using MarketGoods.Domain.Orders;
    using MarketGoods.Domain.Payments;
    using MarketGoods.Domain.Reviews;
    using Microsoft.EntityFrameworkCore;
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Good> Goods { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Review> Reviews { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
