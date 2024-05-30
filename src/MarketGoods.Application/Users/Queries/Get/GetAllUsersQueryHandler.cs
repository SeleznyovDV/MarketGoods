namespace MarketGoods.Application.Users.Queries.Get
{
    using AutoMapper;
    using MarketGoods.Application.Users.Commons;
    using MarketGoods.Domain.Users;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IList<UserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IList<UserResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll().ToListAsync(cancellationToken);
            return users.Select(x => _mapper.Map<UserResponse>(x)).ToList();
        }
    }
}
