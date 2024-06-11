namespace MarketGoods.Infrastructure.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Users", Schema = "Identity")]
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<ApplicationUserRole> Roles { get; } = new List<ApplicationUserRole>();
    }
}
