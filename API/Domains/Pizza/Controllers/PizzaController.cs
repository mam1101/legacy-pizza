using API.Domains.Pizza.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Domains.Pizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController: ControllerBase
{
    private PizzaService _service;

    public PizzaController(PizzaService _pizzaService)
    {
        _service = _pizzaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPizza()
    {
        return Ok(await _service.GetAllPizza());
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePizza(Models.Pizza pizza)
    {
        await _service.CreatePizza(pizza);
        return Ok(pizza);
    }
}