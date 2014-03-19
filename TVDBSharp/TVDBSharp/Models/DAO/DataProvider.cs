using System.Net;
using System.Xml.Linq;

namespace TVDBSharp.Models.DAO {
    /// <summary>
    /// Standard implementation of the <see cref="IDataProvider"/> interface.
    /// </summary>
    public class DataProvider : IDataProvider {
        public string ApiKey { get; set; }

        public XDocument GetShow(string showID) {
            using (var web = new WebClient()) {
                var response = web.DownloadString(string.Format("http://thetvdb.com/api/{0}/series/{1}/all/", ApiKey, showID));
                return XDocument.Parse(response);
            }
        }

        public XDocument Search(string query) {
            using (var web = new WebClient()) {
                var response = web.DownloadString(string.Format("http://thetvdb.com/api/GetSeries.php?seriesname={0}", query));
                return XDocument.Parse(response);
            }
        }
    }
}