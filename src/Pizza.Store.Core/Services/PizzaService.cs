using Microsoft.EntityFrameworkCore;
using Pizza.Store.Core.Contexts;
using Pizza.Store.Core.Interfaces;

namespace Pizza.Store.Core.Services;

public class PizzaService : IPizzaService
{
    private PizzaContext db;

    public PizzaService(DbContextOptions<PizzaContext> options)
    {
        db = new PizzaContext(options);
    }
    
    public Task<List<Models.Pizza>> GetAllPizzas()
    {
        return db.Pizzas.ToListAsync();
    }

    public Task<Models.Pizza> GetPizzaById(int id)
    {
        return db.Pizzas.FirstAsync(p=> p.Id == id);
    }
}