using Microsoft.EntityFrameworkCore;

namespace Pizza.Store.Migrations;

public class PizzaContext : DbContext
{
    public PizzaContext (DbContextOptions<PizzaContext> options): base(options)
    {
    }

    public DbSet<Core.Models.Pizza> Pizzas => Set<Core.Models.Pizza>();
}