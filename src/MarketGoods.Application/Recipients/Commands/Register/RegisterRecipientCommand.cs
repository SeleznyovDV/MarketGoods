namespace MarketGoods.Application.Recipients.Commands.Register
{
    using ErrorOr;
    using MarketGoods.Application.Recipients.Commons;
    using MediatR;
    public record RegisterRecipientCommand(string Email, string Password) : IRequest<ErrorOr<RecipientResponse>>;
}
