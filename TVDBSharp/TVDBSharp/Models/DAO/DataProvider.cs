using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TVDBSharp.Models.Enums;

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

        public XDocument GetShow(int showID)
        {
            return GetXDocumentFromUrl($"{BaseUrl}/series/{showID}");
        }

        public XDocument GetEpisode(int episodeId, string lang)
        {
            return GetXDocumentFromUrl($"{BaseUrl}/api/{""}/episodes/{episodeId}/{lang}.xml");
        }

        public XDocument GetUpdates(Interval interval)
        {
            return GetXDocumentFromUrl($"{BaseUrl}/api/{""}/updates/updates_{IntervalHelpers.Print(interval)}.xml");
        }

        public XDocument Search(string query)
        {
            return GetXDocumentFromUrl($"{BaseUrl}/api/GetSeries.php?seriesname={query}&language=all");
        }

        private XDocument GetXDocumentFromUrl(string url)
        {
            using (var web = new WebClient())
            {
                web.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {AuthToken}");
                web.Headers.Add(HttpRequestHeader.Accept, "application/vnd.thetvdb.v1");

                var bytes = web.DownloadData(url);
                var json = Encoding.UTF8.GetString(bytes);

                using (var memoryStream = new MemoryStream())
                {
                    return XDocument.Load(memoryStream);
                }
            }
        }
    }
}
