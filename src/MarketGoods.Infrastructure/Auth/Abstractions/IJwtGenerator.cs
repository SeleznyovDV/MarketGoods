using MarketGoods.Infrastructure.Models;

namespace MarketGoods.Infrastructure.Auth.Abstractions;

public interface IJwtGenerator
{
    string CreateToken(ApplicationUser user);
}