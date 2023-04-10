using Microsoft.AspNetCore.Mvc;
using Pizza.Store.Core.Interfaces;

namespace Pizza.Store.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase
{
    private readonly IPizzaService _service;

    public PizzaController(IPizzaService pizzaService)
    {
        _service = pizzaService;
    }
    
    [HttpGet]
    public async Task<IActionResult> List()
    {
        return Ok(await _service.GetAllPizzas());
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _service.GetPizzaById(id));
    }
}