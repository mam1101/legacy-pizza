using System.Configuration;
using Pizza.Store.Core.Interfaces;
using Pizza.Store.Infrastructure;
using Pizza.Store.Infrastructure.Data.Repositories;
using Pizza.Store.Migrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDatabaseContext(builder.Configuration);
builder.Services.AddScoped<IRepository<Pizza.Store.Core.Models.Pizza>, PizzaRepository>();

// builder.Services.AddSqlite<PizzaContext>("Data Source=LegacyPizza.db");

var app = builder.Build();

app.MapControllers();
app.Run();