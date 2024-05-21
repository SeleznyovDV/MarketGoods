namespace MarketGoods.Application
{
    using FluentValidation;
    using MarketGoods.Application.Profiles;
    using Microsoft.Extensions.DependencyInjection;
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // MediatR
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(ApplicationAssemblyReference.Assembly);
            });
            
            services.AddValidatorsFromAssembly(ApplicationAssemblyReference.Assembly);
            services.AddAutoMapper(ApplicationAssemblyReference.Assembly);

            return services;
        }
    }
}
