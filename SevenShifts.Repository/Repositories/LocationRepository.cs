using Newtonsoft.Json;
using SevenShifts.Domain.Contracts;
using SevenShifts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SevenShifts.Repository.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly string _locationAPI;

        public LocationRepository(string locationAPIUrl)
        {
            _locationAPI = locationAPIUrl;
        }

        private async Task<IEnumerable<Location>> GetFromAPI()
        {
            var locations = new List<Location>();

            using (var httpClient = new HttpClient())
            {
                var httpResponse = await httpClient.GetAsync(_locationAPI);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var jsonContent = await httpResponse.Content.ReadAsStringAsync();

                    locations = (JsonConvert.DeserializeObject<Dictionary<string, Domain.Entities.Location>>(jsonContent)).Select(w => w.Value).ToList();
                }
            }

            return locations;
        }

        public async Task<IEnumerable<Location>> GetLocations()
        {
            return await GetFromAPI();
        }

        public async Task<Domain.Entities.Location> GetLocationById(long id)
        {
            return (await GetFromAPI()).FirstOrDefault(x => x.Id == id);
        }
    }
}
