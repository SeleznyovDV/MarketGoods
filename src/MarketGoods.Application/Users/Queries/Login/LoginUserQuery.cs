namespace MarketGoods.Application.Users.Queries.Login
{
    using ErrorOr;
    using MarketGoods.Application.Users.Commons;
    using MediatR;
    public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<UserResponse>>;
}
