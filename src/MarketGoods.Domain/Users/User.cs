namespace MarketGoods.Domain.Users
{
    using MarketGoods.Domain.ValueObjects;
    public sealed class User
    {
        public UserId Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName { get => $"{FirstName} {LastName}"; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Address Address { get; private set; }
        public string Email { get; private set; }
        public UserRole Role { get; private set; }
        public User(UserId id, string firstName, string lastName, string email, Address address, PhoneNumber phoneNumber, UserRole role)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            PhoneNumber = phoneNumber;
            Role = role;
        }
        public User(UserId id, string firstName, string lastName, string email, PhoneNumber phoneNumber, UserRole role)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Role = role;
        }
        private User()
        {
            
        }
    }
}
