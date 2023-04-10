using Microsoft.AspNetCore.Mvc;

namespace Pizza.Store.Core.Interfaces;

public interface IPizzaService
{
    public Task<List<Models.Pizza>> GetAllPizzas();

    public Task<Models.Pizza> GetPizzaById(int id);
}