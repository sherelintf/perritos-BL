using BL.Repositories.Interfaces;
using Newtonsoft.Json;
using System.Text;
using BL.Models;


namespace BL.Repositories.Implementations
{
    public class DogRepository : IDogRepository
    {
        private IConfiguration configuration;

        public DogRepository(IConfiguration config)
        {
            configuration = config;
        }


        public async Task<DogsSearch> GetDogs(
            string name,
            string status,
            int offset,
            int limit
        )
        {
            name ??= "";
            status ??= "";

            try
            {
                DogsSearch dogs = new DogsSearch();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(configuration.GetSection("CRUD_Url").Value + "/Dogs" + "?name=" + name + "&status=" + status + "&offset=" + offset + "&limit=" + limit))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        dogs = JsonConvert.DeserializeObject<DogsSearch>(apiResponse);
                    }
                }
                return dogs;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Dog> GetDog(Guid id)
        {
            try
            {
                Dog dog = new Dog();
                using (var httpClient = new HttpClient())
                {
                    using (
                        var response = await httpClient.GetAsync(configuration.GetSection("CRUD_Url").Value + "/Dogs/" + id)
                    )
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        dog = JsonConvert.DeserializeObject<Dog>(apiResponse);
                    }
                }
                return dog;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Dog> InsertDog(Dog dog)
        {
            try
            {
                Dog dogInserted = new Dog();
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(dog), Encoding.UTF8, "application/json");

                    using (
                        var response = await httpClient.PostAsync(configuration.GetSection("CRUD_Url").Value + "/Dogs", content)
                    )
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        dogInserted = JsonConvert.DeserializeObject<Dog>(apiResponse);
                    }
                }
                return dogInserted;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Dog> UpdateDog(Guid id, Dog dog)
        {
            try
            {
                Dog dogUpdated = new Dog();
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(dog), Encoding.UTF8, "application/json");

                    using (
                        var response = await httpClient.PutAsync(configuration.GetSection("CRUD_Url").Value + "/Dogs/" + id, content)
                    )
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        dogUpdated = JsonConvert.DeserializeObject<Dog>(apiResponse);
                    }
                }
                return dogUpdated;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Dog> DeleteDog(Guid id)
        {
            try
            {
                Dog dogDeleted = new Dog();
                using (var httpClient = new HttpClient())
                {
                    using (
                        var response = await httpClient.DeleteAsync(configuration.GetSection("CRUD_Url").Value + "/Dogs/" + id)
                    )
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        dogDeleted = JsonConvert.DeserializeObject<Dog>(apiResponse);
                    }
                }
                return dogDeleted;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



    }

}