namespace MarketGoods.Application.Recipients.Commons
{
    public record RecipientResponse(string Email, string Token, string Name, IList<string> Roles);
}
