namespace MarketGoods.Application.Users.Commands.Create
{
    using FluentValidation;
    using MarketGoods.Domain.Users;
    using MarketGoods.Domain.ValueObjects;
    using Microsoft.EntityFrameworkCore;

    public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidation(IUserRepository userRepository)
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
                .MaximumLength(255)
                .MustAsync(async (email, _) =>
                {
                    return !await userRepository.GetAll().AnyAsync(x => x.Email == email);
                })
                .WithMessage("The email must be unique.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .MaximumLength(50)
                .WithName("Phone Number")
                .MustAsync(async (phone, _) =>
                {
                    return !await userRepository.GetAll().AnyAsync(x => x.PhoneNumber == PhoneNumber.Create(phone));
                })
                .WithMessage("The phone number must be unique.");
        }
    }
}
