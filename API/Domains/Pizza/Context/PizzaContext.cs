using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace API.Domains.Pizza.Context;

public class PizzaContext : DbContext
{
    public PizzaContext (DbContextOptions<PizzaContext> options): base(options)
    {
    }

    public DbSet<Models.Pizza> Pizzas => Set<Models.Pizza>();
}