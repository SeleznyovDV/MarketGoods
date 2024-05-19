namespace MarketGoods.Application.Goods.Queries.Get
{
    using MarketGoods.Domain.Primitives;
    using MarketGoods.Domain.Goods;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class GetAllGoodsQueryHandler : IRequestHandler<GetAllGoodsQuery, IEnumerable<Good>>
    {
        private readonly IGoodRepository _goodRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GetAllGoodsQueryHandler(IGoodRepository goodRepository, IUnitOfWork unitOfWork)
        {
            _goodRepository = goodRepository ?? throw new ArgumentException(nameof(goodRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<Good>> Handle(GetAllGoodsQuery request, CancellationToken cancellationToken)
        {
            return await _goodRepository.GetAll().ToListAsync(cancellationToken);
        }
    }
}
