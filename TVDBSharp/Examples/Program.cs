using System.Configuration;
using TVDBSharp;

namespace Examples {
    internal class Program {
        public static void Main(string[] args) {
            //new DisplayShowDetails();

            /*var apikey = ConfigurationManager.AppSettings["apikey"]; // Your own API key
            var seriesid = "76290";

            var tvdb = new TVDB(apikey);
            var result = tvdb.GetShow(seriesid).Episodes.FirstOrDefault(x => x.EpisodeNumber == 8 && x.SeasonNumber == 2);*/
            //new DisplayEpisodeDetails();
            //new DisplayEpisodeTitlesForSeason();
            //new DisplaySearchResult();

            var tvdb = new TVDB(ConfigurationManager.AppSettings["apikey"]);
            var episode = tvdb.GetEpisode(4721938);
            DisplayEpisodeDetails.Print(episode);
        }
    }
}