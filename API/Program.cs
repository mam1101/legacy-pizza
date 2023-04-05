using API.Domains.Pizza.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlite<PizzaContext>("Data Source=LegacyPizza.db");

var app = builder.Build();

app.Run();