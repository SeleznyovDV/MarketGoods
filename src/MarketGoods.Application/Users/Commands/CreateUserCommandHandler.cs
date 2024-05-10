namespace MarketGoods.Application.Users.Commands
{
    using MarketGoods.Domain.Primitives;
    using MarketGoods.Domain.Users;
    using MarketGoods.Domain.ValueObjects;
    using MediatR;
    internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository ?? throw new ArgumentException(nameof(userRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            { 
                if (PhoneNumber.Create(request.PhoneNumber) is not PhoneNumber phoneNumber) 
                {
                    return Unit.Value;
                }

                if (!Enum.TryParse<UserRole>(request.Role, out var role))
                {
                    return Unit.Value;
                }

                User user = new User(
                    new UserId(Guid.NewGuid()),
                    request.FirstName,
                    request.LastName,
                    request.Email,
                    phoneNumber,
                    role);

                await _userRepository.AddAsync(user);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.Message);
            }
            return Unit.Value;
        }
    }
}
