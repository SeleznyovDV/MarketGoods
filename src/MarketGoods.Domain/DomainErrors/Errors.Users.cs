using ErrorOr;

namespace MarketGoods.Domain.DomainErrors
{

    public static partial class Errors
    {
        public static class User
        {
            public static Error PhoneNumberHasIncorrectFormat => Error.Validation("User.PhoneNumber", "PhoneNumber is not valid");
            public static Error RoleHasIncorrectValue => Error.Validation("User.Role", "Role is not valid");
        }
    }
}
