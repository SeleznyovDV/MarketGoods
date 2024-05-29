namespace MarketGoods.Application.Users.Commands.Create
{
    using ErrorOr;
    using MarketGoods.Domain.DomainErrors;
    using MarketGoods.Domain.Primitives;
    using MarketGoods.Domain.Users;
    using MarketGoods.Domain.ValueObjects;
    using MediatR;
    public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ErrorOr<Unit>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository ?? throw new ArgumentException(nameof(userRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (PhoneNumber.Create(request.PhoneNumber) is not PhoneNumber phoneNumber)
                {
                    return Errors.User.PhoneNumberHasIncorrectFormat;
                }

                if (!Enum.TryParse<UserRole>(request.Role, out var role) || request.Role.All(x => char.IsNumber(x)))
                {
                    return Errors.User.RoleHasIncorrectValue;
                }

                User user = new User(
                    new UserId(Guid.NewGuid()),
                    request.FirstName,
                    request.LastName,
                    request.Email,
                    phoneNumber,
                    role);

                await _userRepository.AddAsync(user);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                return Error.Failure($"{nameof(CreateUserCommand)}.Failure occurred error", ex.Message);
            }
        }
    }
}
