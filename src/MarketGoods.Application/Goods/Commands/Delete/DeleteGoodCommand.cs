namespace MarketGoods.Application.Goods.Commands.Delete
{
    using ErrorOr;
    using MediatR;
    public record DeleteGoodCommand(Guid GoodId) : IRequest<ErrorOr<Unit>>;
}
