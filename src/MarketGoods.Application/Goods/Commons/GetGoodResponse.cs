namespace MarketGoods.Application.Goods.Commons
{
    public record GetGoodResponse(Guid GoodId, string Name, string Description, decimal Price, string Currency);
}
