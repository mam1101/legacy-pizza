using Microsoft.EntityFrameworkCore;

namespace Pizza.Store.Core.Contexts;

public class PizzaContext : DbContext
{
    public PizzaContext (DbContextOptions<PizzaContext> options): base(options)
    {
    }

    public DbSet<Models.Pizza> Pizzas => Set<Models.Pizza>();
}