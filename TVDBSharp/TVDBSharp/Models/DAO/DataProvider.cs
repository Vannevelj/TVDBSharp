using System.IO;
using System.Net;
using System.Xml.Linq;
using TVDBSharp.Models.Enums;

namespace TVDBSharp.Models.DAO
{
    /// <summary>
    ///     Standard implementation of the <see cref="IDataProvider" /> interface.
    /// </summary>
    public class DataProvider : IDataProvider
    {
        public string ApiKey { get; set; }
        private const string BaseUrl = "http://thetvdb.com";

        public XDocument GetShow(int showID)
        {
            using (var web = new WebClient())
            {
                var response = web.DownloadData(string.Format("{0}/api/{1}/series/{2}/all/", BaseUrl, ApiKey, showID));
                using (var memoryStream = new MemoryStream(response))
                    return XDocument.Load(memoryStream);
            }
        }

        public XDocument GetEpisode(int episodeId, string lang)
        {
            using (var web = new WebClient())
            {
                var response =
                    web.DownloadString(string.Format("{0}/api/{1}/episodes/{2}/{3}.xml", BaseUrl, ApiKey, episodeId,
                        lang));
                return XDocument.Parse(response);
            }
        }

        public XDocument GetUpdates(Interval interval)
        {
            using (var web = new WebClient())
            {
                var response = web.DownloadString(string.Format("{0}/api/{1}/updates/updates_{2}.xml",
                    BaseUrl, ApiKey, IntervalHelpers.Print(interval)));
                return XDocument.Parse(response);
            }
        }

        public XDocument Search(string query)
        {
            using (var web = new WebClient())
            {
                var response = web.DownloadString(string.Format("{0}/api/GetSeries.php?seriesname={1}", BaseUrl, query));
                return XDocument.Parse(response);
            }
        }
    }
}