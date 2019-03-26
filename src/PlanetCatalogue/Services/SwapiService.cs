using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlanetCatalogue.Services
{
    public class SwapiService
    {
        private readonly HttpClient _client;

        public SwapiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<dynamic>> SearchPlanet(string planetName)
        {
            var response = await _client.GetAsync($"/api/planets/?search={planetName}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<dynamic>();

            return result.results;
        }
    }
}
