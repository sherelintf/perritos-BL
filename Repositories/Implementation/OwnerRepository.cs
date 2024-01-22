using BL.Repositories.Interfaces;
using Newtonsoft.Json;
using System.Text;
using BL.Models;

namespace BL.Repositories.Implementations
{
    public class OwnerRepository : IOwnerRepository
    {
        private IConfiguration configuration;

        public OwnerRepository(IConfiguration config)
        {
            configuration = config;
        }

        public async Task<List<Owner>> GetOwners()
        {
            try
            {
                List<Owner> owners = new List<Owner>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(configuration.GetSection("CRUD_Url").Value + "/Owners"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        owners = JsonConvert.DeserializeObject<List<Owner>>(apiResponse);
                    }
                }
                return owners;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Owner> GetOwner(Guid id)
        {
            try
            {
                Owner owner = new Owner();
                using (var httpClient = new HttpClient())
                {
                    using (
                        var response = await httpClient.GetAsync(configuration.GetSection("CRUD_Url").Value + "/Owners/" + id)
                    )
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        owner = JsonConvert.DeserializeObject<Owner>(apiResponse);
                    }
                }
                return  owner;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Owner> InsertOwner(Owner owner)
        {
            try
            {
                Owner insertedOwner = new Owner();
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(owner), Encoding.UTF8, "application/json");

                    using (
                        var response = await httpClient.PostAsync(configuration.GetSection("CRUD_Url").Value + "/Owners", content)
                    )
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        insertedOwner = JsonConvert.DeserializeObject<Owner>(apiResponse);
                    }
                }
                return insertedOwner;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Owner> UpdateOwner(Guid id, Owner owner)
        {
            try
            {
                Owner updatedOwner = new Owner();
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(owner), Encoding.UTF8, "application/json");

                    using (
                        var response = await httpClient.PutAsync(configuration.GetSection("CRUD_Url").Value + "/Owners/" + id, content)
                    )
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        updatedOwner = JsonConvert.DeserializeObject<Owner>(apiResponse);
                    }
                }
                return updatedOwner;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Owner> DeleteOwner(Guid id)
        {
            try
            {
                Owner deletedOwner = new Owner();
                using (var httpClient = new HttpClient())
                {
                    using (
                        var response = await httpClient.DeleteAsync(configuration.GetSection("CRUD_Url").Value + "/Owners/" + id)
                    )
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        deletedOwner = JsonConvert.DeserializeObject<Owner>(apiResponse);
                    }
                }
                return deletedOwner;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}