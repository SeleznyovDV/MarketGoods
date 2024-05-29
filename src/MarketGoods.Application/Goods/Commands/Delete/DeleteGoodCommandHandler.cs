namespace MarketGoods.Application.Goods.Commands.Delete
{
    using ErrorOr;
    using MarketGoods.Domain.Goods;
    using MarketGoods.Domain.Primitives;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteGoodCommandHandler : IRequestHandler<DeleteGoodCommand, ErrorOr<Unit>>
    {
        private readonly IGoodRepository _goodRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteGoodCommandHandler(IGoodRepository goodRepository, IUnitOfWork unitOfWork)
        {
            _goodRepository = goodRepository ?? throw new ArgumentNullException(nameof(goodRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteGoodCommand request, CancellationToken cancellationToken)
        {
            var good = await _goodRepository.GetAsync(new GoodId(request.GoodId));
            if (good is null) 
            {
                return Error.NotFound(typeof(Good).Name);
            }

            _goodRepository.Remove(good);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
