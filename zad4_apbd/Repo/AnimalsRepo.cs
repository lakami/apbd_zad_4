using System.Data.SqlClient;

namespace zad4_apbd.Repo;

public class AnimalsRepo : IAnimalsRepo
{
    
    private readonly string _connectionString = "Data Source=db-mssql;Initial Catalog=s22086;Integrated Security=True";
    public async Task<IEnumerable<Animal>> GetAnimalsAsync(string orderBy)
    {
        var animals = new List<Animal>();

        await using (var connection = new SqlConnection(_connectionString))
        await using(var command = new SqlCommand())
        {
            command.Connection = connection;
            command.CommandText = $"SELECT * FROM Animal ORDER BY {orderBy} ASC";
            // command.Parameters.AddWithValue("orderBy", orderBy);
            await connection.OpenAsync();
            var dataReader = await command.ExecuteReaderAsync();
            while (await dataReader.ReadAsync())
            {
                var animal = new Animal
                {
                    IdAnimal = int.Parse(dataReader["IdAnimal"].ToString()),
                    Name = dataReader["Name"].ToString(),
                    Description = dataReader["Description"].ToString(),
                    Category = dataReader["Category"].ToString(),
                    Area = dataReader["Area"].ToString()
                };
                animals.Add(animal);
            }
        }
        return animals;
    }

    public async Task<bool> CreateAnimalAsync(Animal animal)
    {
        try
        {
            await using (var connection = new SqlConnection(_connectionString))
            await using(var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO Animal VALUES (@id, @name, @description, @category, @area)";
                command.Parameters.AddWithValue("id", animal.IdAnimal);
                command.Parameters.AddWithValue("name", animal.Name);
                command.Parameters.AddWithValue("description", animal.Description ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("category", animal.Category);
                command.Parameters.AddWithValue("area", animal.Area);
                await connection.OpenAsync();
                return await command.ExecuteNonQueryAsync() != 0;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
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