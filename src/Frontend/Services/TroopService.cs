using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Frontend.Services
{
    public class TroopService
    {
        private readonly HttpClient _client;

        public TroopService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<dynamic>> GetAllTroops()
        {
            var response = await _client.GetAsync("/api/trooper");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<IEnumerable<dynamic>>();

            return result;
        }

        public async Task<dynamic> GetTrooper(int id)
        {
            var response = await _client.GetAsync($"/api/trooper/{id}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<dynamic>();

            return result;
        }
    }
}