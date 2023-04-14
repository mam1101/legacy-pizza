using Microsoft.AspNetCore.Mvc;
using Pizza.Store.Core.Interfaces;

namespace Pizza.Store.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase
{
    private readonly IPizzaRepsitory _pizzaRepsitory;

    public PizzaController(IPizzaRepsitory pizzaRepsitory)
    {
        _pizzaRepsitory = pizzaRepsitory;
    }
    
    // [HttpGet]
    // public async Task<IActionResult> List()
    // {
    //     return Ok();
    // }
    //
    // [HttpGet]
    // [Route("{id}")]
    // public async Task<IActionResult> Get(int id)
    // {
    //     return Ok();
    // }
}