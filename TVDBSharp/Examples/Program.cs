using System;
using System.Configuration;
using System.Linq;
using TVDBSharp;

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

            Console.ReadKey();
        }
    }
}