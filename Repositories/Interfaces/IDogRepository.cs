using BL.Models;


namespace BL.Repositories.Interfaces
{
    public interface IDogRepository
    {
        Task<DogsSearch> GetDogs(
            string name,
            string status,
            int offset,
            int limit
        );
        Task<Dog> GetDog(Guid id);
        Task<Dog> InsertDog(Dog dog);
        Task<Dog> UpdateDog(Guid id, Dog dog);
        Task<Dog> DeleteDog(Guid id);
    }
}