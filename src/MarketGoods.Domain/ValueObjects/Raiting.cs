namespace MarketGoods.Domain.ValueObjects
{
    public partial record Raiting
    {
        private const int _minValue = 0;
        private const int _maxValue = 5;
        public int Quality { get; init; }
        public int Satisfaction { get; init; }

        private Raiting(int quality, int satisfaction)
        {
            Quality = quality;
            Satisfaction = satisfaction;
        }

        public static Raiting? Create(int quality, int satisfaction) 
        {
            if (quality < _minValue || _maxValue < quality ||
                satisfaction < _minValue || _maxValue < satisfaction)
                return null;
            
            return new Raiting(quality, satisfaction);
        }
    }
}
