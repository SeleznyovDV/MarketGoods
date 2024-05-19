namespace MarketGoods.Application.Users.Queries.Get
{
    using MarketGoods.Domain.Users;
    using MediatR;
    public record GetAllUsersQuery() : IRequest<IEnumerable<User>>;
}
