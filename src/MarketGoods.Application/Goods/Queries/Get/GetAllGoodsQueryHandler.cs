namespace MarketGoods.Application.Goods.Queries.Get
{
    using MarketGoods.Domain.Primitives;
    using MarketGoods.Domain.Goods;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;
    using MarketGoods.Application.Goods.Commons;

    public class GetAllGoodsQueryHandler : IRequestHandler<GetAllGoodsQuery, IList<GetGoodResponse>>
    {
        private readonly IGoodRepository _goodRepository;
        private readonly IMapper _mapper;
        public GetAllGoodsQueryHandler(IGoodRepository goodRepository, IMapper mapper)
        {
            _goodRepository = goodRepository ?? throw new ArgumentException(nameof(goodRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IList<GetGoodResponse>> Handle(GetAllGoodsQuery request, CancellationToken cancellationToken)
        {
            var goods = await _goodRepository.GetAll().ToListAsync(cancellationToken);
            return goods.Select(c => _mapper.Map<GetGoodResponse>(c)).ToList();
        }
    }
}
