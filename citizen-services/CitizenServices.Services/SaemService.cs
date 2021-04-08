using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CitizenServices.Entities.Services.Saem;

namespace CitizenServices.Services
{
    public class SaemService : ISaemService
    {
        private readonly HttpClient _httpClient;

        public SaemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<School>> GetNearbySchoolsAsync()
        {
            var response = await _httpClient.GetAsync("schools");
            response.EnsureSuccessStatusCode();

            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                return await JsonSerializer.DeserializeAsync<IEnumerable<School>>(responseStream);
            }
        }
    }
}
