using System.Configuration;
using Pizza.Store.Infrastructure;
using Pizza.Store.Migrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDatabaseContext(builder.Configuration);

// builder.Services.AddSqlite<PizzaContext>("Data Source=LegacyPizza.db");

var app = builder.Build();

app.MapControllers();
app.Run();