﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Frontend.Services
{
    public class PlanetService
    {
        private readonly HttpClient _client;

        public PlanetService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<dynamic>> GetAllPlanets()
        {
            var response = await _client.GetAsync("/api/planet");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<IEnumerable<dynamic>>();

            return result;
        }

        public async Task<dynamic> GetPlanet(int id)
        {
            var response = await _client.GetAsync($"/api/planet/{id}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<dynamic>();

            return result;
        }
    }
}
