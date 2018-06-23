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
    public class UserRepository : IUserRepository
    {
        private readonly string _userAPIUrl;

        public UserRepository(string userAPIUrl)
        {
            _userAPIUrl = userAPIUrl;
        }


        private async Task<IEnumerable<User>> GetFromAPI()
        {
            var userList = new List<User>();

            using (var httpClient = new HttpClient())
            {
                var httpResponse = await httpClient.GetAsync(_userAPIUrl);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var jsonContent = await httpResponse.Content.ReadAsStringAsync();

                    userList = (JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Domain.Entities.User>>>(jsonContent)).Select(w => w.Value)
                                                                                                                                      .FirstOrDefault()?.Select(q => q.Value).ToList();
                }
            }

            return userList;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await GetFromAPI();
        }

        public async Task<User> GetByUserId(int id)
        {
            return (await GetFromAPI()).FirstOrDefault(x => x.Id == id);
        }
    }
}
