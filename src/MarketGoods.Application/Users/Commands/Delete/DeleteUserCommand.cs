namespace MarketGoods.Application.Users.Commands.Delete
{
    using ErrorOr;
    using MediatR;
    public record DeleteUserCommand(Guid UserId) : IRequest<ErrorOr<Unit>>;
}
