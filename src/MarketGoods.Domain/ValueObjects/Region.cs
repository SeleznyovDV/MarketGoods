namespace MarketGoods.Domain.ValueObjects
{
    public partial record Region
    {
        public string Code { get; init; }
        public string Name { get; init; }
        public Region (string code, string name)
        {
            Code = code;
            Name = name;
        }
        
        // HACK: EF HACK.
        private Region()
        {
            
        }

        public static Region? Create(string code, string name)
        {
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(name))
                return null;
            
            return new Region(code, name); 
        }
    }
}
