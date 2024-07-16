namespace MarketGoods.Infrastructure.Recipients.Queries.Login
{
    using ErrorOr;
    using MarketGoods.Application.Recipients.Commons;
    using MarketGoods.Application.Recipients.Queries.Login;
    using MarketGoods.Domain.DomainErrors;
    using MarketGoods.Infrastructure.Auth.Abstractions;
    using MarketGoods.Infrastructure.Models;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using System.Threading;
    using System.Threading.Tasks;

    public class LoginRecipientQueryHandler : IRequestHandler<LoginRecipientQuery, ErrorOr<RecipientResponse>>
    {
        private readonly UserManager<Recipient> _userManager;
        private readonly SignInManager<Recipient> _signInManager;
        private readonly IJwtGenerator _jwtGenerator;
        public LoginRecipientQueryHandler(UserManager<Recipient> userManager, SignInManager<Recipient> signInManager, IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGenerator = jwtGenerator;
        }
        public async Task<ErrorOr<RecipientResponse>> Handle(LoginRecipientQuery request, CancellationToken cancellationToken)
        {
            var recipient = await _userManager.FindByEmailAsync(request.Email);
            if (recipient == null)
            {
                return Errors.Recipients.RecipientUnAuthorized;
            }

            var loginResult = await _signInManager.CheckPasswordSignInAsync(recipient, request.Password, false);

            if (loginResult.Succeeded)
            {
                return new RecipientResponse(recipient.FirstName, recipient.LastName, recipient.Email, _jwtGenerator.CreateToken(recipient));
            }

            return Errors.Recipients.RecipientUnAuthorized;
        }
    }
}
