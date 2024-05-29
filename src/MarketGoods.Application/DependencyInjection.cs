namespace MarketGoods.Application
{
    using ErrorOr;
    using FluentValidation;
    using MarketGoods.Application.Abstractions.Behaviors;
    using MarketGoods.Application.Profiles;
    using MediatR;
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
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

            return services;
        }
    }
}
