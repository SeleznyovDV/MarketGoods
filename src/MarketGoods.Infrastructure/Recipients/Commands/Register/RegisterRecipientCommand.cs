namespace MarketGoods.Application.Recipients.Commands.Register
{
    using ErrorOr;
    using MarketGoods.Application.Recipients.Commons;
    using MediatR;
    public record RegisterRecipientCommand(string FirstName, string LastName, string Email, string Password, string PhoneNumber) : IRequest<ErrorOr<RecipientResponse>>;
}
