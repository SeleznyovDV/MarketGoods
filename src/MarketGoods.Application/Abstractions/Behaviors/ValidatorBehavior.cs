namespace MarketGoods.Application.Abstractions.Behaviors
{
    using ErrorOr;
    using FluentValidation;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class ValidatorBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidatorBehavior(IValidator<TRequest> validator)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validator is null)
            {
                return await next();
            }

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid)
            {
                return await next();
            }

            var errors = validationResult.Errors
                .ConvertAll(validation => Error.Validation(validation.PropertyName, validation.ErrorMessage));

            return (dynamic)errors;
        }
    }
}
