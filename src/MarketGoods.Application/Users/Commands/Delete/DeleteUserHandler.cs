namespace MarketGoods.Application.Users.Commands.Delete
{
    using ErrorOr;
    using MarketGoods.Domain.Primitives;
    using MarketGoods.Domain.Users;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ErrorOr<Unit>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }
        public async Task<ErrorOr<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(new UserId(request.UserId));
            if (user == null) 
            {
                return Error.NotFound(typeof(User).Name);
            }
            _userRepository.Remove(user);
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
