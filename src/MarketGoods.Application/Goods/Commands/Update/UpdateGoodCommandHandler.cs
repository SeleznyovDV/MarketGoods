namespace MarketGoods.Application.Goods.Commands.Update
{
    using AutoMapper;
    using ErrorOr;
    using MarketGoods.Application.Goods.Commons;
    using MarketGoods.Application.Users.Commands.Create;
    using MarketGoods.Domain.Goods;
    using MarketGoods.Domain.Primitives;
    using MarketGoods.Domain.DomainErrors;
    using MarketGoods.Domain.ValueObjects;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateGoodCommandHandler : IRequestHandler<UpdateGoodCommand, ErrorOr<GoodResponse>>
    {
        private readonly IGoodRepository _goodRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateGoodCommandHandler(IGoodRepository goodRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _goodRepository = goodRepository ?? throw new ArgumentNullException(nameof(goodRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ErrorOr<GoodResponse>> Handle(UpdateGoodCommand request, CancellationToken cancellationToken)
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

                var good = await _goodRepository.GetAsync(new GoodId(request.GoodId));

                if (good is null)
                {
                    return Error.NotFound(typeof(Good).Name);
                }
                
                var price = Money.Create(request.Price, currencyValue);
                var isChanged = good.Name != request.Name || good.Description != request.Description || good.Price != price;

                if (isChanged)
                {
                    good.UpdateGood(request.Name, request.Description, Money.Create(request.Price, currencyValue));
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                }

                return _mapper.Map<GoodResponse>(good);
            }
            catch (Exception ex)
            {
                return Error.Failure($"{nameof(CreateUserCommand)}.Failure occurred error", ex.Message);
            }
        }
    }
}
