namespace MarketGoods.Application.Users.Queries.Get
{
    using AutoMapper;
    using MarketGoods.Application.Users.Commons;
    using MarketGoods.Domain.Users;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<UserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(new UserId(request.UserId));
            return _mapper.Map<UserResponse>(user);
        }
    }
}
