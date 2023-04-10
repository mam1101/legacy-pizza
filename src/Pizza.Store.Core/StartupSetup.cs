using Microsoft.EntityFrameworkCore;
using Pizza.Store.Core.Contexts;

namespace Pizza.Store.Core;

public static class StartupSetup
{
    public static void AddDbContext(this IServiceCollection services, string connectionString, string migrationAssembly) =>
        services.AddDbContext<PizzaContext>(options =>
            options.UseSqlite(connectionString, b=>b.MigrationsAssembly(migrationAssembly))); // will be created in web project root
}
