using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
        private string AuthToken { get; }
        private const string BaseUrl = "https://api.thetvdb.com";

        public DataProvider(string apiKey)
        {
            AuthToken = GetJwtToken(apiKey).GetAwaiter().GetResult();
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

        public Show GetShow(int showID) => GetResponse<Show>($"{BaseUrl}/series/{showID}");

        public List<Episode> GetEpisodes(int showId, int page) => GetResponse<List<Episode>>($"{BaseUrl}/series/{showId}/episodes?page={page}");

        public List<UpdateTimestamp> GetUpdates(DateTime from, DateTime to) => GetResponse<List<UpdateTimestamp>>($"{BaseUrl}/updated/query?fromTime={from.ToEpoch()}&toTime={to.ToEpoch()}");

        public List<Show> Search(string query) => GetResponse<List<Show>>($"{BaseUrl}/search/series?name={query}");

        private T GetResponse<T>(string url)
        {
            using (var web = new HttpClient())
            {
                web.DefaultRequestHeaders.Add("Authorization", $"Bearer {AuthToken}");
                web.DefaultRequestHeaders.Add("Accept", "application/vnd.thetvdb.v3");

                var json = web.GetAsync(url).Result;
                var content = json.Content.ReadAsStringAsync().Result;

                var root = JsonConvert.DeserializeObject<Root<T>>(content);
                return root.Data;
            }
        }
    }
}
