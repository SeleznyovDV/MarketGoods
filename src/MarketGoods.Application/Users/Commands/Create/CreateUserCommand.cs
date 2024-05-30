namespace MarketGoods.Application.Users.Commands.Create
{
    using ErrorOr;
    using MarketGoods.Application.Users.Commons;
    using MediatR;
    public record CreateUserCommand(string FirstName, string LastName, string PhoneNumber, string Email, string Role) : IRequest<ErrorOr<UserResponse>>;
}
