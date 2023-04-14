using Microsoft.AspNetCore.Mvc;
using Pizza.Store.Core.Interfaces;

namespace Pizza.Store.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase
{
    private readonly IRepository<Core.Models.Pizza> _pizzaRepository;

    public PizzaController(IRepository<Core.Models.Pizza> pizzaRepository)
    {
        _pizzaRepository = pizzaRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> List()
    {
        return Ok(_pizzaRepository.List());
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(_pizzaRepository.GetById(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(Core.Models.Pizza pizza)
    {
        _pizzaRepository.Add(pizza);
        return Ok(pizza);
    }
}