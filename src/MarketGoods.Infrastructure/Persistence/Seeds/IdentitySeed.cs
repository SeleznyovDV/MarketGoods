using MarketGoods.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;

namespace MarketGoods.Infrastructure.Persistence.Seeds
{
    public class IdentitySeed
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole<string>> roleManager)
        {
            var admin = new IdentityRole<string>()
            {
                Id = Guid.NewGuid().ToString(),
                Name = RoleName.Administrator.ToString(),
            };

            var roles = new List<IdentityRole<string>> { admin };
            
            foreach (var role in roles)
                await roleManager.CreateAsync(role);
        }
        public static async Task SeedUsersAsync(UserManager<ApplicationRecipient> userManager)
        {

            var firstUser = new ApplicationRecipient
            {
                FirstName = "Dmitriy",
                LastName = "Seleznyov",
                Email = "selezda@mail.ru",
                UserName = "DmitriySeleznyov",
            };
            var users = new List<ApplicationRecipient> { firstUser };

            foreach (var user in users)
                await userManager.CreateAsync(user);

            firstUser = await userManager.FindByEmailAsync(firstUser.Email);
            if (firstUser is not null)
                await userManager.AddToRoleAsync(firstUser, RoleName.Administrator.ToString());
        }
    }
}
