using System;
using System.Configuration;
using TVDBSharp;

namespace Examples {
    public class DisplaySearchResult {
        public DisplaySearchResult() {
            var apikey = ConfigurationManager.AppSettings["apikey"]; // Your own API key
            var series = "Battlestar Galactica";

            var tvdb = new TVDB(apikey);
            var result = tvdb.Search(series);

            foreach (var show in result) {
                Console.WriteLine(show.Name);
            }

            Console.ReadKey();
        }
    }
}