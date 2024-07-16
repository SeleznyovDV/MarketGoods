using FluentValidation;
using MarketGoods.Application.Recipients.Queries.Login;

namespace MarketGoods.Infrastructure.Recipients.Queries.Login
{
    public class LoginRecipientQueryValidation : AbstractValidator<LoginRecipientQuery>
    {
        public LoginRecipientQueryValidation()
        {
             RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(255);
        }
    }
}
