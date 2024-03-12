namespace MarketGoods.Catalog.Entities.Abstractions
{
    public class BaseEntity<TId> where TId : struct
    {
        public TId Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
