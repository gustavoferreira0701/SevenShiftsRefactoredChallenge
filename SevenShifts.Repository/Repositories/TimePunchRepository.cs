using Newtonsoft.Json;
using SevenShifts.Domain.Contracts;
using SevenShifts.Domain.Entities;
using SevenShifts.Repository.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SevenShifts.Repository.Repositories
{
    public class TimePunchRepository : ITimePunchRepository
    {
        private readonly string _timePunchApiUrl;

        public TimePunchRepository(string timePunchApiUrl)
        {
            _timePunchApiUrl = timePunchApiUrl;
        }

        private async Task<IEnumerable<Domain.Entities.TimePunch>> GetFromAPI()
        {
            var timePunches = new List<Domain.Entities.TimePunch>();

            using (var httpClient = new HttpClient())
            {
                var httpResponse = await httpClient.GetAsync(_timePunchApiUrl);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var jsonContent = (await httpResponse.Content.ReadAsStringAsync()).FixWrongDateTimeValue();

                    timePunches = (JsonConvert.DeserializeObject<Dictionary<string, Domain.Entities.TimePunch>>(jsonContent)).Select(w => w.Value).ToList();
                }
            }

            return timePunches;
        }

        public async Task<IEnumerable<Domain.Entities.TimePunch>> GetTimePunches()
        {
            return await GetFromAPI();
        }

        public async Task<IEnumerable<Domain.Entities.TimePunch>> GetTimePunchesByUserId(long id)
        {
            return (await GetFromAPI()).Where(x => x.UserId == id);
        }
    }
}
