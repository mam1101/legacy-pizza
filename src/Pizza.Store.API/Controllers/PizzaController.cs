using Microsoft.AspNetCore.Mvc;
using Pizza.Store.API.Requests;
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
    public async Task<IActionResult> Get(GetPizzaRequest pizzaRequest)
    {
        return Ok(_pizzaRepository.GetById(pizzaRequest.Id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePizzaRequest pizzaRequest)
    {
        _pizzaRepository.Add(pizzaRequest);
        return Ok(pizzaRequest);
    }
}