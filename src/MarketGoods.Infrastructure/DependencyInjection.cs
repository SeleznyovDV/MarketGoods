namespace MarketGoods.Infrastructure
{
    using FluentValidation;
    using MarketGoods.Application;
    using MarketGoods.Application.Data;
    using MarketGoods.Domain.Goods;
    using MarketGoods.Domain.Orders;
    using MarketGoods.Domain.Payments;
    using MarketGoods.Domain.Primitives;
    using MarketGoods.Domain.Reviews;
    using MarketGoods.Domain.Users;
    using MarketGoods.Infrastructure.Auth.Abstractions;
    using MarketGoods.Infrastructure.Auth.Implementations;
    using MarketGoods.Infrastructure.Models;
    using MarketGoods.Infrastructure.Persistence;
    using MarketGoods.Infrastructure.Persistence.Repositories;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("postgres")));

			services.AddScoped<IApplicationDbContext>(options => options.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IUnitOfWork>(options => options.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IJwtGenerator, JwtGenerator>();

            services.AddValidatorsFromAssembly(InfrastructureAssemblyReference.Assembly);
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(InfrastructureAssemblyReference.Assembly);
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGoodRepository, GoodRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();

            return services;
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationIdentityDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("identityConnection")));
            services.AddScoped<IApplicationIdentityDbContext>(options => options.GetRequiredService<ApplicationIdentityDbContext>());

            var identityBuilder = services.AddIdentityCore<Recipient>();
            identityBuilder.AddRoles<IdentityRole<string>>();
            identityBuilder.AddEntityFrameworkStores<ApplicationIdentityDbContext>();
            identityBuilder.AddSignInManager<SignInManager<Recipient>>();

            return services;
        }
    }
}

