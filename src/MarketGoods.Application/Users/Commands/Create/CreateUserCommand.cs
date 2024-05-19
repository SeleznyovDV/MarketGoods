using ErrorOr;
using MediatR;

namespace MarketGoods.Application.Users.Commands.Create
{
    public record CreateUserCommand(string FirstName, string LastName, string PhoneNumber, string Email, string Role) : IRequest<ErrorOr<Unit>>;
}
