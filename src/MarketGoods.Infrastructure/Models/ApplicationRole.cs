namespace MarketGoods.Infrastructure.Models
{
    using Microsoft.AspNetCore.Identity;
    public class ApplicationRole : IdentityRole
    {
        ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
