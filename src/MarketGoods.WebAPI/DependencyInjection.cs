namespace MarketGoods.WebAPI
{
    using MarketGoods.WebAPI.Caching;
    using MarketGoods.WebAPI.Middlewares;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.ResponseCompression;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using System.Text;

    public static class DependencyInjection
	{
		public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
		{
            services.AddControllers(
                options =>
                {
                    options.CacheProfiles.Add(DefaultCacheProfiles.Default1, new CacheProfile()
                    {
                        Duration = 1,
                        Location = ResponseCacheLocation.Any
                    });
                    options.CacheProfiles.Add(DefaultCacheProfiles.Default5, new CacheProfile()
                    {
                        Duration = 5,
                        Location = ResponseCacheLocation.Any
                    });
                    options.CacheProfiles.Add(DefaultCacheProfiles.Default30, new CacheProfile()
                    {
                        Duration = 30,
                        Location = ResponseCacheLocation.Any
                    });
                    options.CacheProfiles.Add(DefaultCacheProfiles.Default60, new CacheProfile()
                    {
                        Duration = 60,
                        Location = ResponseCacheLocation.Any
                    });
                    options.CacheProfiles.Add(DefaultCacheProfiles.Default90, new CacheProfile()
                    {
                        Duration = 90,
                        Location = ResponseCacheLocation.Any
                    });
                });

            #region Response Compression
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
            });

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = System.IO.Compression.CompressionLevel.Optimal;
            });
            #endregion

            #region JWT swagger configuration
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(setup =>
            {
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Put only you JWT bearer token on text box below",
                    Reference = new OpenApiReference()
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>()}
                });
            });
            #endregion

            services.AddTransient<ExceptionHandlingMiddleware>();
      
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"])),
                        ValidateAudience = false,
                        ValidateIssuer = false
                    };
                });

            services.AddAuthorization(options =>
            {
                //options.FallbackPolicy = new AuthorizationPolicyBuilder()
                //    .RequireAuthenticatedUser()
                //    .Build();
            });

            return services;
        }
	}
}

