using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TVDBSharp.Models.Deserialization;
using TVDBSharp.Utilities;

namespace TVDBSharp.Models.DAO
{
    /// <summary>
    ///     Standard implementation of the <see cref="IDataProvider" /> interface.
    /// </summary>
    public class DataProvider : IDataProvider
    {
        private const string BaseUrl = "https://api.thetvdb.com";
        private readonly string _apiKey;
        private string _authToken;
        
        public DataProvider(string apiKey)
        {
            _apiKey = apiKey;
        }

        private async Task<string> GetJwtToken(string apiKey)
        {
            using (var client = new HttpClient()) 
            {
                var response = await client.PostAsync($"{BaseUrl}/login", new StringContent($"{{ \"apikey\": \"{apiKey}\" }}", Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                dynamic item = JsonConvert.DeserializeObject<object>(content);
                var token = item["token"];
                return token;
            }

            throw new InvalidOperationException("Unable to retrieve the authentication token");
        }

        public async Task<Show> GetShow(int showID) => await GetResponse<Show>($"{BaseUrl}/series/{showID}");

        public async Task<List<Episode>> GetEpisodes(int showId, int page) => await GetResponse<List<Episode>>($"{BaseUrl}/series/{showId}/episodes?page={page}");

        public async Task<List<UpdateTimestamp>> GetUpdates(DateTime from, DateTime to) => await GetResponse<List<UpdateTimestamp>>($"{BaseUrl}/updated/query?fromTime={from.ToEpoch()}&toTime={to.ToEpoch()}");

        public async Task<List<Show>> Search(string query) => await GetResponse<List<Show>>($"{BaseUrl}/search/series?name={query}");

        private async Task<T> GetResponse<T>(string url)
        {
            if (string.IsNullOrWhiteSpace(_authToken))
            {
                _authToken = await GetJwtToken(_apiKey);
            }

            using (var web = new HttpClient())
            {
                web.DefaultRequestHeaders.Add("Authorization", $"Bearer {_authToken}");
                web.DefaultRequestHeaders.Add("Accept", "application/vnd.thetvdb.v3");

                var json = await web.GetAsync(url);
                var content = await json.Content.ReadAsStringAsync();

                var root = JsonConvert.DeserializeObject<Root<T>>(content);
                return root.Data;
            }
        }
    }
}
