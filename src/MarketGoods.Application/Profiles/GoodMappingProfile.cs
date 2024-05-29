namespace MarketGoods.Application.Profiles
{
    using AutoMapper;
    using MarketGoods.Application.Goods.Commons;
    using MarketGoods.Domain.Goods;

    public class GoodMappingProfile : Profile
    {
        public GoodMappingProfile()
        {
            CreateMap<Good, GoodResponse>()
                .ConstructUsing(x => new GoodResponse(x.Id.Value, x.Name, x.Description, x.Price.Value, x.Price.Currency.ToString()))
                .ForMember(dest => dest.Price, opt => opt.Ignore());
        }
    }
}
