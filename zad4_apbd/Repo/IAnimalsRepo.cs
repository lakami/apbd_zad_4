namespace zad4_apbd.Repo;

public interface IAnimalsRepo
{
    Task<IEnumerable<Animal>> GetAnimalsAsync(string orderBy);
    
    Task CreateAnimalAsync(Animal animal);
    
    Task UpdateAnimalAsync(int idAnimal, Animal animal);
    
    Task DeleteAnimalAsync(int idAnimal);
}