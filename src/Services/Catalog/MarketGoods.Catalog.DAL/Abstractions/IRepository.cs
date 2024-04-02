using MarketGoods.Catalog.Entities.Abstractions;

namespace MarketGoods.Catalog.DAL.Abstractions
{
    public interface IRepository<TEntity> where TEntity : BaseEntity<Guid>
    {
        IEnumerable<TEntity> GetAll(Func<TEntity, bool> filter = null);
        void Create(TEntity entity);
        void Update(TEntity newEntity);
        void Delete(TEntity entity);
        TEntity Get(Guid id);
    }
}
