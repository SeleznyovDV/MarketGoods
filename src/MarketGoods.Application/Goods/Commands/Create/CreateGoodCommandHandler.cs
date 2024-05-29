namespace MarketGoods.Application.Goods.Commands.Create
{
    using AutoMapper;
    using ErrorOr;
    using MarketGoods.Application.Goods.Commons;
    using MarketGoods.Domain.DomainErrors;
    using MarketGoods.Domain.Goods;
    using MarketGoods.Domain.Primitives;
    using MarketGoods.Domain.ValueObjects;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateGoodCommandHandler : IRequestHandler<CreateGoodCommand, ErrorOr<GoodResponse>>
    {
        private readonly IGoodRepository _goodRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateGoodCommandHandler(IGoodRepository goodRepositor, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _goodRepository = goodRepositor ?? throw new ArgumentNullException(nameof(goodRepositor));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(_unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<ErrorOr<GoodResponse>> Handle(CreateGoodCommand request, CancellationToken cancellationToken)
        {
            try 
            {
                if (request.Price < 0)
                {
                    return Errors.Goods.PriceHasIncorrectValue;
                }

                if (!Enum.TryParse<Currency>(request.Currency, out var currencyValue) || request.Currency.All(x => char.IsNumber(x)))
                {
                    return Errors.Goods.CurrencyHasIncorrectValue;
                }

                var good = new Good (
                    new GoodId(Guid.NewGuid()),
                    request.Name, request.Description,
                    Money.Create(request.Price, currencyValue));
                
                await _goodRepository.AddAsync(good);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return _mapper.Map<GoodResponse>(good);
            }
            catch (Exception ex) 
            {
              return Error.Failure($"{nameof(CreateGoodCommand)}.Failure occurred error", ex.Message);
            }
        }
    }
}
