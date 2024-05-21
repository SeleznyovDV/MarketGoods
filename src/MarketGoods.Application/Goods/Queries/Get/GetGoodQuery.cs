namespace MarketGoods.Application.Goods.Queries.Get
{
    using MarketGoods.Application.Goods.Commons;
    using MediatR;

    public record GetGoodQuery(Guid GoodId) : IRequest<GetGoodResponse>;
}
