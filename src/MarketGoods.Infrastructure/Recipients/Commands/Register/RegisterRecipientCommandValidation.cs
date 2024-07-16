using FluentValidation;
using MarketGoods.Application.Recipients.Commands.Register;
using MarketGoods.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketGoods.Infrastructure.Recipients.Commands.Register
{
    public class RegisterRecipientCommandValidation : AbstractValidator<RegisterRecipientCommand>
    {
        public RegisterRecipientCommandValidation()
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
