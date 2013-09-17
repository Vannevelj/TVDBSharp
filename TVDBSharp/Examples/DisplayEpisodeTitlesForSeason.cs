using System;
using System.Configuration;
using System.Linq;
using TVDBSharp;

namespace Examples {
    /// <summary>
    /// This example will demonstrate how to retrieve the titles of every episode in a season.
    /// </summary>
    public class DisplayEpisodeTitlesForSeason {
        public DisplayEpisodeTitlesForSeason() {
            var apikey = ConfigurationManager.AppSettings["apikey"]; // Your own API key
            var seriesid = "76290";

            var tvdb = new TVDB(apikey);
            var result = tvdb.GetShow(seriesid).Episodes.Where(x => x.SeasonNumber == 2).ToList();

            foreach (var episode in result) {
                Console.WriteLine(episode.Title);
            }

            Console.ReadKey();
        }
    }
}