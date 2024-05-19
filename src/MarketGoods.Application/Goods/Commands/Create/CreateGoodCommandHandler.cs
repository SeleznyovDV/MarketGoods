namespace MarketGoods.Application.Goods.Commands.Create
{
    using ErrorOr;
    using MarketGoods.Application.Users.Commands;
    using MarketGoods.Domain.DomainErrors;
    using MarketGoods.Domain.Goods;
    using MarketGoods.Domain.Primitives;
    using MarketGoods.Domain.ValueObjects;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateGoodCommandHandler : IRequestHandler<CreateGoodCommand, ErrorOr<Unit>>
    {
        private readonly IGoodRepository _goodRepository;
        private readonly IUnitOfWork _unitOfWork;
        public async Task<ErrorOr<Unit>> Handle(CreateGoodCommand request, CancellationToken cancellationToken)
        {
            try 
            {
                if (request.Price < 0)
                {
                    return Errors.Goods.PriceHasIncorrectValue;
                }

                if (!Enum.TryParse<Currency>(request.Currency, out var currencyValue))
                {
                    return Errors.Goods.CurrencyHasIncorrectValue;
                }

                var good = new Good (
                    new GoodId(Guid.NewGuid()),
                    request.Name, request.Description,
                    Money.Create(request.Price, currencyValue));
                
                await _goodRepository.AddAsync(good);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex) 
            {
              return Error.Failure($"{nameof(CreateGoodCommand)}.Failure occurred error", ex.Message);
            }
        }
    }
}
