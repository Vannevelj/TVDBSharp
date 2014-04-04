using System;
using System.Configuration;
using System.Linq;
using TVDBSharp;
using TVDBSharp.Models.Enums;

namespace Examples {
    internal class Program {
        public static void Main(string[] args) {
            
            // Your own API key
            var tvdb = new TVDB(ConfigurationManager.AppSettings["apikey"]);

            // Retrieve and display Game of Thrones
            Console.WriteLine("Game of Thrones");
            var got = tvdb.GetShow(121361);
            DisplayShowDetails.Print(got);
            Console.WriteLine("-----------");

            // Retrieve and display Game of Thrones s04e01
            Console.WriteLine("Game of Thrones s04e01");
            var episode = tvdb.GetEpisode(4721938);
            DisplayEpisodeDetails.Print(episode);
            Console.WriteLine("-----------");

            // Retrieve and display episode titles for Game of Thrones season 2
            Console.WriteLine("Episodes of Game of Thrones season 2");
            var show = tvdb.GetShow(121361);
            var season2Episodes = show.Episodes.Where(ep => ep.SeasonNumber == 2).ToList();
            DisplayEpisodeTitles.Print(season2Episodes);
            Console.WriteLine("-----------");

            // Search for Battlestar Galactica on tvdb
            Console.WriteLine("Search for Battlestar Galactica on tvdb");
            var searchResults = tvdb.Search("Battlestar Galactica");
            DisplaySearchResult.Print(searchResults);
            Console.WriteLine("-----------");

            // Get updates of the last 24 hours
            var updates = tvdb.GetUpdates(Interval.Day);
            Console.WriteLine("Updates during the last 24 hours on thetvdb, since {0}", updates.Timestamp);
            DisplayUpdates.Print(updates);

            Console.ReadKey();
        }
    }
}