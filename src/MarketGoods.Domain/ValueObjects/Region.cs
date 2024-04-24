namespace MarketGoods.Domain.ValueObjects
{
    public partial record Region
    {
        public string Code { get; init; }
        public string Name { get; init; }
        private Region (string code, string name)
        {
            Code = code;
            Name = name;
        }

        public static Region? Create(string code, string name)
        {
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(name))
                return null;
            
            return new Region(code, name); 
        }
    }
}
