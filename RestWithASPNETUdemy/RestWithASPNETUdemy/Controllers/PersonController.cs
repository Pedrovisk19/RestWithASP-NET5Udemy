using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalculatorController : ControllerBase
{

    private readonly ILogger<CalculatorController> _logger;
    private IPersonService _personService;

    public CalculatorController(ILogger<CalculatorController> logger,IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpGet]
    public IActionResult Get()
    { 
        return Ok(_personService.FindAll());
    }
        return BadRequest("Invalid Input");
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        var person = _personService.FindByID(id);
        if(person == null) return NotFound();
        return Ok(person);
    }  

    [HttpPost]
    public IActionResult Post([FromBody] Person person)
    {
        if(person == null) return BadRequest();
        return Ok(_personService.Create(person));
    }

    [HttpPut]
    public IActionResult Put([FromBody] Person person)
    {
        if(person == null) return BadRequest();
        return Ok(_personService.Update(person));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        _personService.Delete(id);
        if (person == null) return NotFound();
        return NoContent();
    }
}
