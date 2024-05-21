namespace MarketGoods.Application.Users.Queries.Get
{
    using MarketGoods.Application.Users.Commons;
    using MediatR;
    public record GetAllUsersQuery() : IRequest<IList<GetUserResponse>>;
}
