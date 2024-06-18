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

app.UseAuthorization();

app.UseExceptionHandler("/error");
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}");

app.Run();
