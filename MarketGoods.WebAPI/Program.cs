using MarketGoods.WebAPI;
using MarketGoods.WebAPI.Extensions;
using MarketGoods.Infrastructure;
using MarketGoods.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddPresentation()
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
