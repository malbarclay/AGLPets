using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AGL.Pets.Repository;

namespace AGL.Pets.Data
{
    public class DataContext : IDataContext
    {
        private static readonly HttpClient Client = new HttpClient();

        public const string PetOwnerUrl = "http://agl-developer-test.azurewebsites.net/people.json";

        public List<Owner> GetPetOwners()
        {
            var task = LoadDataAsync<List<Owner>>(PetOwnerUrl);
            return task.Result;
        }

        public async Task<T> LoadDataAsync<T>(string url)
        {
           HttpResponseMessage response = await Client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            else
            {
                throw new Exception("Unable to load data");
            }
         }
    }
}