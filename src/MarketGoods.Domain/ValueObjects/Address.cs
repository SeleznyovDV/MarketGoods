namespace MarketGoods.Domain.ValueObjects
{
    public partial record Address
    {
        public Region Region { get; init; }
        public City City { get; init; }
        public string Street { get; init; }
        public string HouseNumber { get; init; }
        public string? Entrance { get; init; }
        public int? Floor { get; init; }
        public string Flat { get; init; }
        public string? IntercomCode { get; init; }
        public string PostalCode { get; init; }

        private Address(City city, string street, string houseNumber, string? entrance, int? floor, string? intercomCode, string flat, string postalCode)
        {
            Region = city.Region;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            Entrance = entrance;
            IntercomCode = intercomCode;
            Floor = floor;
            Flat = flat;
            PostalCode = postalCode;
        }

        public static Address? Create(City city, string street, string houseNumber, string? entrance, int? floor, string? intercomCode, string flat, string postalCode)
        {
            if (city == null ||
                string.IsNullOrEmpty(street) ||
                string.IsNullOrEmpty(houseNumber) ||
                string.IsNullOrEmpty(flat) ||
                string.IsNullOrEmpty(postalCode))
            {
                return null;
            }

            return new Address(city, street, houseNumber, entrance, floor, intercomCode, flat, postalCode);
        }
    }
}

