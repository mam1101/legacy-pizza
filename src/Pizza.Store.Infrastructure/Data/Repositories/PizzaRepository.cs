using Pizza.Store.Migrations;

namespace Pizza.Store.Infrastructure.Data.Repositories;

public class PizzaRepository : Repository<Core.Models.Pizza>
{
    public PizzaRepository(PizzaContext dbContext) : base(dbContext)
    {
    }
}