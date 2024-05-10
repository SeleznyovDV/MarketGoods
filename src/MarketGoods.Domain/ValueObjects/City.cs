namespace MarketGoods.Domain.ValueObjects
{
    public partial record City
    {
        public string Name { get; init; }
        public Region Region { get; init; }
        public City(string name, Region region)
        {
            Name = name;
            Region = region;
        }
        // HACK: EF core.
        private City()
        {
                
        }
        public static City? Create(string name, Region region) 
        {
            if (region == null || string.IsNullOrEmpty(name))
                return null;

            return new City(name, region);
        }
    }
}
