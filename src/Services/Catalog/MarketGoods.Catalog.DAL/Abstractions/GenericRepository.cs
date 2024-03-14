using MarketGoods.Catalog.Entities.Abstractions;

namespace MarketGoods.Catalog.DAL.Abstractions
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity<Guid>
    {
        internal DBFakeClass context;
        internal ICollection<TEntity> entities;

        public GenericRepository(DBFakeClass context)
        {
            this.context = context;
            entities = context.Set<TEntity>();
        }

        public void Create(TEntity entity) 
        {
            entities.Add(entity);
        }

        public void Update(TEntity newEntity) 
        {
            var oldEntity = entities.Where(x => x.Id == newEntity.Id).FirstOrDefault();
            if (oldEntity != null)
            {
                entities.Remove(oldEntity);
                entities.Add(oldEntity);
            }
        }
        public void Delete(TEntity entity) 
        {  
            if (entities.Any(x => x.Id == entity.Id))
                entities.Remove(entity);
        }
        public TEntity Get(Guid id) 
        { 
            return entities.FirstOrDefault(x => x.Id == id); 
        }
        public IEnumerable<TEntity> GetAll(Func<TEntity,bool> filter = null) 
        {  
            return entities.Where(filter); 
        }
    }
}
