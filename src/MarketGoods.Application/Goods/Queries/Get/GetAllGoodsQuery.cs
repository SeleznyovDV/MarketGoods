namespace MarketGoods.Application.Goods.Queries.Get
{
    using MarketGoods.Domain.Goods;
    using MediatR;
    public record GetAllGoodsQuery() : IRequest<IEnumerable<Good>>;
}
