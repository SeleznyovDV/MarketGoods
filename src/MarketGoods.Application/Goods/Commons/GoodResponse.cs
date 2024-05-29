namespace MarketGoods.Application.Goods.Commons
{
    public record GoodResponse(Guid GoodId, string Name, string Description, decimal Price, string Currency);
}
