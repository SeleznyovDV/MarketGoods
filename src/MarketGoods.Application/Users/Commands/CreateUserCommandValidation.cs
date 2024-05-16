namespace MarketGoods.Application.Users.Commands
{
    using FluentValidation;
    using MarketGoods.Domain.Users;
    using MarketGoods.Domain.ValueObjects;
    using MediatR;
    using System.Data;

    public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidation()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(255);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .MaximumLength(50)
                .WithName("Phone Number");
        }
    }
}
