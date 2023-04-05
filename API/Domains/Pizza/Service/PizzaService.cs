using System.Data.Entity;
using API.Domains.Pizza.Context;

namespace API.Domains.Pizza.Service;

public class PizzaService
{
    private PizzaContext _pizzaContext;

    public PizzaService(PizzaContext pizzaContext)
    {
        _pizzaContext = pizzaContext;
    }
    
    public Task<List<Models.Pizza>> GetAllPizza()
    {
        return _pizzaContext.Pizzas.ToListAsync();
    }

    public Task CreatePizza(Models.Pizza pizza)
    {
        _pizzaContext.Pizzas.Add(pizza);
        return _pizzaContext.SaveChangesAsync();
    }
}