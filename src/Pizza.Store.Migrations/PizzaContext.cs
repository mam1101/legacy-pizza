using Microsoft.EntityFrameworkCore;

namespace Pizza.Store.Migrations;

public class PizzaContext : DbContext
{
    public PizzaContext ()
    {
    }

    public virtual DbSet<Core.Models.Pizza> Pizzas { get; set; }
}