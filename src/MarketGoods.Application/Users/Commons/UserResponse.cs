namespace MarketGoods.Application.Users.Commons
{
    public record UserResponse(Guid UserId, string FirstName, string LastName, string PhoneNumber, string Email, string Role);
}
