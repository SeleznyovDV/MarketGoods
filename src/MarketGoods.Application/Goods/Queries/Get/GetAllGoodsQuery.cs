namespace MarketGoods.Application.Goods.Queries.Get
{
    using MarketGoods.Application.Goods.Commons;
    using MediatR;
    public record GetAllGoodsQuery() : IRequest<IList<GoodResponse>>;
}
