namespace MarketGoods.Application.Recipients.Queries.Login
{
    using ErrorOr;
    using MarketGoods.Application.Recipients.Commons;
    using MediatR;
    public record LoginRecipientQuery(string Email, string Password) : IRequest<ErrorOr<RecipientResponse>>;
}
