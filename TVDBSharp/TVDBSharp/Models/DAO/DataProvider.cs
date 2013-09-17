using System.Net;
using System.Text;
using System.Xml.Linq;

namespace TVDBSharp.Models.DAO {
    /// <summary>
    /// Standard implementation of the <see cref="IDataProvider"/> interface.
    /// </summary>
    public class DataProvider : IDataProvider {
        public string ApiKey { get; set; }

        public XDocument GetShow(string showID) {
            var web = new WebClient();
            var response = web.DownloadString(new StringBuilder("http://thetvdb.com/api/").Append(ApiKey).Append("/series/").Append(showID).Append("/all/").ToString());
            return XDocument.Parse(response);
        }

        public XDocument Search(string query) {
            var web = new WebClient();
            var response = web.DownloadString(new StringBuilder("http://thetvdb.com/api/GetSeries.php?seriesname=").Append(query).ToString());
            return XDocument.Parse(response);
        }
    }
}