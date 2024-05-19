namespace MarketGoods.Application.Goods.Commands.Create
{
    using ErrorOr;
    using MediatR;
    public record CreateGoodCommand(string Name, string Description, decimal Price, string Currency) : IRequest<ErrorOr<Unit>>;
}
