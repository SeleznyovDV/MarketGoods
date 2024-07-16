using ErrorOr;

namespace MarketGoods.Domain.DomainErrors
{
    public partial class Errors
    {
        public static class Recipients
        {
            public static Error RecipientUnAuthorized => Error.Unauthorized(nameof(Errors.Recipients.RecipientUnAuthorized));
        }
    }
}
