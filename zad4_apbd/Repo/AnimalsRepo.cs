namespace zad4_apbd.Repo;

public class AnimalsRepo : IAnimalsRepo
{
    public async Task<IEnumerable<Animal>> GetAnimalsAsync(string orderBy)
    {
        throw new NotImplementedException();
    }

    public async Task CreateAnimalAsync(Animal animal)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAnimalAsync(int idAnimal, Animal animal)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAnimalAsync(int idAnimal)
    {
        throw new NotImplementedException();
    }
}