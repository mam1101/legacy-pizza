using Pizza.Store.Core.Interfaces;
using Pizza.Store.Core.Services;
using Pizza.Store.Core;

var builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("SqliteConnection");
builder.Services.AddDbContext(connectionString!, "Pizza.Store.API");

builder.Services.AddControllers();
builder.Services.AddScoped<IPizzaService, PizzaService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// builder.Services.AddSqlite<PizzaContext>("Data Source=LegacyPizza.db");

var app = builder.Build();

app.MapControllers();
app.Run();