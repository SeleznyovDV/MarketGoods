using MarketGoods.WebAPI;
using MarketGoods.WebAPI.Extensions;
using MarketGoods.Infrastructure;
using MarketGoods.Application;
using MarketGoods.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddPresentation(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddIdentity(builder.Configuration)
    .AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}
app.UseExceptionHandler("/error");

app.UseResponseCompression();

app.UseResponseCaching();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
