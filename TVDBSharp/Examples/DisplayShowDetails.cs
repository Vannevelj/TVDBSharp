using System;
using System.Configuration;
using TVDBSharp;
using TVDBSharp.Models;

namespace Examples {
    public class DisplayShowDetails {
        /// <summary>
        /// This example demonstrates the retrieval and display of a show.
        /// </summary>
        public DisplayShowDetails() {
            var apikey = ConfigurationManager.AppSettings["apikey"]; // Your own API key
            var seriesid = "76290";

            var tvdb = new TVDB(apikey);
            var result = tvdb.GetShow(seriesid);

            Console.WriteLine("{0}:\t{1}", "IMDB ID", result.ImdbID);
            Console.WriteLine("{0}:\t{1}", "ID", result.ID);
            Console.WriteLine("{0}:\t{1}", "Language", result.Language);
            Console.WriteLine("{0}:\t{1}", "Last update", result.LastUpdated);
            Console.WriteLine("{0}:\t{1}", "Name", result.Name);
            Console.WriteLine("{0}:\t{1}", "Network", result.Network);
            Console.WriteLine("{0}:\t{1}", "Poster", result.Poster);
            Console.WriteLine("{0}:\t{1}", "Rating", result.Rating);
            Console.WriteLine("{0}:\t{1}", "# Votes", result.RatingCount);
            Console.WriteLine("{0}:\t{1}", "Runtime", result.Runtime);
            Console.WriteLine("{0}:\t{1}", "Status", result.Status);
            Console.WriteLine("{0}:\t{1}", "Zap2it ID", result.Zap2ItID);
            Console.WriteLine("{0}:\t{1}", "Airday", result.AirDay);
            Console.WriteLine("{0}:\t{1}", "AirTime", result.AirTime);
            Console.WriteLine("{0}:\t{1}", "Banner", result.Banner);
            Console.WriteLine("{0}:\t{1}", "ContentRating", result.ContentRating);
            Console.WriteLine("{0}:\t{1}", "Description", result.Description);
            Console.WriteLine("{0}:\t{1}", "Fanart", result.Fanart);
            Console.WriteLine("{0}:\t{1}", "First aired", result.FirstAired);

            Console.Write("Actors:\t");
            foreach (var element in show.Actors) {
                Console.Write("{0} | ", element);
            }

            Console.Write("Genres:\t");
            foreach (var element in show.Genres) {
                Console.Write("{0} | ", element);
            }

            Console.Write("Episodes:");
            foreach (var element in show.Episodes) {
                Console.WriteLine(element.Title);
            }
        }
    }
}