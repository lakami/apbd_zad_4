namespace zad4_apbd.Repo;

public interface IAnimalsRepo
{
    Task<IEnumerable<Animal>> GetAnimalsAsync(string orderBy);
    
    Task<bool> CreateAnimalAsync(Animal animal);
    
    Task<bool> UpdateAnimalAsync(int idAnimal, Animal animal);
    
    Task<bool> DeleteAnimalAsync(int idAnimal);
}