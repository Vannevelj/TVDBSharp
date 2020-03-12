using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TVDBSharp.Models.Deserialization;
using TVDBSharp.Models.Enums;
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
            using (var web = new WebClient())
            {
                web.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {AuthToken}");
                web.Headers.Add(HttpRequestHeader.Accept, "application/vnd.thetvdb.v3");

                var bytes = web.DownloadData(url);
                var json = Encoding.UTF8.GetString(bytes);

                var root = JsonConvert.DeserializeObject<Root<T>>(json);
                return root.Data;
            }
        }
    }
}
