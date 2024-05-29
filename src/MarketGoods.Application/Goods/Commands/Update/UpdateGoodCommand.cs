namespace MarketGoods.Application.Goods.Commands.Update
{
    using ErrorOr;
    using MarketGoods.Application.Goods.Commons;
    using MediatR;
    public record UpdateGoodCommand(Guid GoodId, string Name, string Description, decimal Price, string Currency) : IRequest<ErrorOr<GoodResponse>>;
}
