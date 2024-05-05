namespace MarketGoods.Application
{
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

            return services;
        }
    }
}
