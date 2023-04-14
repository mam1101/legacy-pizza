using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pizza.Store.Migrations;

namespace Pizza.Store.Infrastructure;

public static class ServiceExtensions
{
    public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddSqlite<PizzaContext>(configuration.GetConnectionString("SqliteConnection"), (options) =>
        {
            options.MigrationsAssembly("Pizza.Store.Migrations");
        });
    }
}