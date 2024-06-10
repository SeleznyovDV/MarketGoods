namespace MarketGoods.Infrastructure.Models
{
    using Microsoft.AspNetCore.Identity;
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }

        public string FirstName { get; set; }

        public string LastNameName { get; set; }

        public virtual ICollection<ApplicationUserRole> Roles { get; } = new List<ApplicationUserRole>();
    }
}
