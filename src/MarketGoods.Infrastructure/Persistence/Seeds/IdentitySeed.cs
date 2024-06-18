using MarketGoods.Application.Data;
using MarketGoods.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;

namespace MarketGoods.Infrastructure.Persistence.Seeds
{
    public class IdentitySeed
    {
        public static async Task SeedDataAsync(UserManager<ApplicationUser> userManager)
        {
            var users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    FirstName = "Dmitriy",
                    LastName = "Seleznyov",
                    Email = "selezda@mail.ru",
                    UserName = "DmitriySeleznyov"
                }
            };

            foreach (var user in users)
            {
                await userManager.CreateAsync(user);
            }
        }
    }
}
