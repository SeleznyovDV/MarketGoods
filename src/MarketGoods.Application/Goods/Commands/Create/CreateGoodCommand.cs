namespace MarketGoods.Application.Goods.Commands.Create
{
    using ErrorOr;
    using MarketGoods.Application.Goods.Commons;
    using MediatR;
    public record CreateGoodCommand(string Name, string Description, decimal Price, string Currency) : IRequest<ErrorOr<GoodResponse>>;
}
