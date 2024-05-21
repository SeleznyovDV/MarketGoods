namespace MarketGoods.Application.Goods.Queries.Get
{
    using AutoMapper;
    using MarketGoods.Application.Goods.Commons;
    using MarketGoods.Domain.Goods;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetGoodQueryHandler : IRequestHandler<GetGoodQuery, GetGoodResponse>
    {
        private readonly IGoodRepository _goodRepository;
        private readonly IMapper _mapper;
        public GetGoodQueryHandler(IGoodRepository goodRepository, IMapper mapper)
        {
            _goodRepository = goodRepository ?? throw new ArgumentNullException(nameof(goodRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }
        public async Task<GetGoodResponse> Handle(GetGoodQuery request, CancellationToken cancellationToken)
        {
            var good = await _goodRepository.GetAsync(new GoodId(request.GoodId));
            return _mapper.Map<GetGoodResponse>(good);
        }
    }
}
