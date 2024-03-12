namespace MarketGoods.Catalog.Entities
{
    using MarketGoods.Catalog.Entities.Abstractions;
    public class User : BaseEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => $"{FirstName} {LastName}";}
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid UserRoleId { get; set; }
        public UserRole Role { get; set; }
    }
}
