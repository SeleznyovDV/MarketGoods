namespace MarketGoods.Application.Users.Commons
{
    public record GetUserResponse(Guid UserId, string FirstName, string LastName, string PhoneNumber, string Email, string Role);
}
