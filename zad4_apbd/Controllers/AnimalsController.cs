using Microsoft.AspNetCore.Mvc;
using zad4_apbd.Repo;

namespace zad4_apbd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    private readonly ILogger<AnimalsController> _logger;
    
    private readonly IAnimalsRepo _animalsRepo;

    public AnimalsController(ILogger<AnimalsController> logger, IAnimalsRepo animalsRepo)
    {
        _logger = logger;
        _animalsRepo = animalsRepo;
    }

    [HttpGet(Name = "GetAnimals")]
    public async Task<IActionResult> GetAnimals(string? orderBy = "name")
    {
        if (orderBy != "name"
            && orderBy != "description"
            && orderBy != "category"
            && orderBy != "area")
        {
            return BadRequest("Niepoprawny parametr");
        }
        return Ok(await _animalsRepo.GetAnimalsAsync(orderBy));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAnimal(Animal animal)
    {
        if (await _animalsRepo.CreateAnimalAsync(animal))
        {
            return Ok("Dodano zwierzę");
        }
        return BadRequest("Nie udało się dodać zwierzęcia");
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