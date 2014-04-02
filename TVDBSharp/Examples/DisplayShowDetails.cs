using System;
using System.Configuration;
using TVDBSharp;
using TVDBSharp.Models;

namespace Examples {
    public class DisplayShowDetails {
        /// <summary>
        /// This example demonstrates the retrieval and display of a show.
        /// </summary>
        public static void Print(Show show) {
            Console.WriteLine("{0}:\t{1}", "IMDB ID", show.ImdbID);
            Console.WriteLine("{0}:\t{1}", "ID", show.ID);
            Console.WriteLine("{0}:\t{1}", "Language", show.Language);
            Console.WriteLine("{0}:\t{1}", "Last update", show.LastUpdated);
            Console.WriteLine("{0}:\t{1}", "Name", show.Name);
            Console.WriteLine("{0}:\t{1}", "Network", show.Network);
            Console.WriteLine("{0}:\t{1}", "Poster", show.Poster);
            Console.WriteLine("{0}:\t{1}", "Rating", show.Rating);
            Console.WriteLine("{0}:\t{1}", "# Votes", show.RatingCount);
            Console.WriteLine("{0}:\t{1}", "Runtime", show.Runtime);
            Console.WriteLine("{0}:\t{1}", "Status", show.Status);
            Console.WriteLine("{0}:\t{1}", "Zap2it ID", show.Zap2ItID);
            Console.WriteLine("{0}:\t{1}", "Airday", show.AirDay);
            Console.WriteLine("{0}:\t{1}", "AirTime", show.AirTime);
            Console.WriteLine("{0}:\t{1}", "Banner", show.Banner);
            Console.WriteLine("{0}:\t{1}", "ContentRating", show.ContentRating);
            Console.WriteLine("{0}:\t{1}", "Description", show.Description);
            Console.WriteLine("{0}:\t{1}", "Fanart", show.Fanart);
            Console.WriteLine("{0}:\t{1}", "First aired", show.FirstAired);

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