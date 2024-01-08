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
    public async Task<IActionResult> UpdateAnimal(int idAnimal, Animal animal)
    {
        if (await _animalsRepo.UpdateAnimalAsync(idAnimal, animal))
        {
            return Ok("Zaktualizowano zwierzę");
        }
        return BadRequest("Nie udało się zaktualizować zwierzęcia");
    }
    
    [HttpDelete("{idAnimal}")]
    public async Task<IActionResult> DeleteAnimal(int idAnimal)
    {
        if (await _animalsRepo.DeleteAnimalAsync(idAnimal))
        {
            return Ok("Usunięto zwierzę");
        }
        return BadRequest("Nie udało się usunąć zwierzęcia");
    }
    
}