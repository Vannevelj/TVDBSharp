using System;
using System.Linq;
using System.Threading.Tasks;
using TVDBSharp;

namespace Examples
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            // Your own API key
            var tvdb = new TVDB("apikey");

            // Retrieve and display Game of Thrones
            await GetSpecificShow(tvdb);

            // Retrieve and display episode titles for Game of Thrones season 2
            await GetEpisodeTitlesForSeason(tvdb);

            // Search for Battlestar Galactica on tvdb
            await SearchShow(tvdb);

            // Get updates of the last 24 hours
            await GetUpdates(tvdb);

            Console.ReadKey();
        }

        private static async Task GetSpecificShow(TVDB tvdb)
        {
            Console.WriteLine("Game of Thrones");
            var got = await tvdb.GetShow(121361);
            DisplayShowDetails.Print(got);

            var eps = await tvdb.GetEpisodes(121361);
            DisplayEpisodeDetails.Print(eps.First());

            Console.WriteLine("-----------");
        }

        private static async Task GetEpisodeTitlesForSeason(TVDB tvdb)
        {
            Console.WriteLine("Episodes of Game of Thrones season 2");
            var episodes = await tvdb.GetEpisodes(121361);
            var season2Episodes = episodes.Where(ep => ep.AiredSeason == 2).ToList();
            DisplayEpisodeTitles.Print(season2Episodes);
            Console.WriteLine("-----------");
        }

        private static async Task SearchShow(TVDB tvdb)
        {
            Console.WriteLine("Search for Battlestar Galactica on tvdb");
            var searchResults = await tvdb.Search("Battlestar Galactica");
            DisplaySearchResult.Print(searchResults);
            Console.WriteLine("-----------");
        }

        private static async Task GetUpdates(TVDB tvdb)
        {
            var beginTime = new DateTime(2019, 12, 10);
            Console.WriteLine($"Updates in the 7 days since {beginTime}");

            var updates = await tvdb.GetUpdates(beginTime);
            DisplayUpdates.Print(updates.Take(20).ToList());
            Console.WriteLine("-----------");
        }
    }
}