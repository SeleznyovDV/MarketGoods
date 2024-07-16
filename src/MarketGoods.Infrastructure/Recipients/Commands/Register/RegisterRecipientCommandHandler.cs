using AutoMapper;
using ErrorOr;
using MarketGoods.Application.Recipients.Commons;
using MarketGoods.Application.Users.Commands.Create;
using MarketGoods.Domain.Users;
using MarketGoods.Domain.ValueObjects;
using MarketGoods.Infrastructure.Auth.Abstractions;
using MarketGoods.Infrastructure.Models;
using MarketGoods.Infrastructure.Persistence.Seeds;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace MarketGoods.Application.Recipients.Commands.Register
{
    public class RegisterRecipientCommandHandler : IRequestHandler<RegisterRecipientCommand, ErrorOr<RecipientResponse>>
    {
        private readonly UserManager<Recipient> _userManager;
        private readonly SignInManager<Recipient> _signInManager;
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;
        private readonly IJwtGenerator _jwtGenerator;
        public RegisterRecipientCommandHandler(UserManager<Recipient> userManager, IMapper mapper,
            SignInManager<Recipient> signInManager, IUserRepository userRepository, IMediator mediator, IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
            _mediator = mediator;
            _jwtGenerator = jwtGenerator;

        }
        public async Task<ErrorOr<RecipientResponse>> Handle(RegisterRecipientCommand request, CancellationToken cancellationToken)
        {
            var customerRoleName = RoleName.Customer.ToString();
            
            if (PhoneNumber.Create(request.PhoneNumber) is not PhoneNumber phoneNumber)
            {
                return Domain.DomainErrors.Errors.User.PhoneNumberHasIncorrectFormat;
            }

            var recipient = new Recipient { Email = request.Email,
                UserName = request.Email,
                PhoneNumber = request.PhoneNumber,
                FirstName = request.FirstName,
                LastName = request.LastName 
            };

            var registerResult = await _userManager.CreateAsync(recipient, request.Password);
            if (registerResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(recipient, customerRoleName);
                var createUserCommand = new CreateUserCommand(request.FirstName, request.LastName, request.PhoneNumber, request.Email, customerRoleName);
                var userResponse = await _mediator.Send(createUserCommand);

                return new RecipientResponse(userResponse.Value.FirstName, userResponse.Value.LastName, userResponse.Value.Email,
                    _jwtGenerator.CreateToken(recipient));
            }
            else 
            {
                return Error.Failure($"{nameof(RegisterRecipientCommand)}.Failure occurred error", string.Join(". ",
                    registerResult.Errors.Select(e => $"Code: {e.Code}, Description: {e.Description}")));
            }
        }
    }
}
