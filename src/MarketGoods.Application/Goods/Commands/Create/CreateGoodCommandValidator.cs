namespace MarketGoods.Application.Goods.Commands.Create
{
    using FluentValidation;
    using MarketGoods.Domain.ValueObjects;

    public class CreateGoodCommandValidator : AbstractValidator<CreateGoodCommand>
    {
        public CreateGoodCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.Price)
                .Must(x => x >= 0);

            RuleFor(x => x.Currency)
                .Must(x => Enum.TryParse<Currency>(x, out var test) || !x.All(x => char.IsNumber(x)));
        }
    }
}
