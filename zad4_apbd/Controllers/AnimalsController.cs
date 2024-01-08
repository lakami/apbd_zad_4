using Microsoft.AspNetCore.Mvc;

namespace zad4_apbd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    private readonly ILogger<AnimalsController> _logger;

    public AnimalsController(ILogger<AnimalsController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetAnimals")]
    public IActionResult GetAnimals(string? orderBy = "name")
    {
        if (orderBy != "name"
            && orderBy != "description"
            && orderBy != "category"
            && orderBy != "area")
        {
            return BadRequest("Niepoprawny parametr");
        }
        return Ok($"orderBy={orderBy}");
    }
    
    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        return Ok(animal);
    }
    
    [HttpPut("{idAnimal}")]
    public IActionResult UpdateAnimal(int idAnimal, Animal animal)
    {
        return Ok($"idAnimal={idAnimal}, animal={animal}");
    }
    
    [HttpDelete("{idAnimal}")]
    public IActionResult DeleteAnimal(int idAnimal)
    {
        return Ok($"idAnimal={idAnimal}");
    }
    
}