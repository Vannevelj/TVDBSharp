using System;
using TVDBSharp.Models;

namespace Examples
{
    public class DisplayShowDetails
    {
        /// <summary>
        ///     This example demonstrates the retrieval and display of a show.
        /// </summary>
        public static void Print(Show show)
        {
            Console.WriteLine("{0}:\t{1}", "IMDB ID", show.ImdbId);
            Console.WriteLine("{0}:\t{1}", "ID", show.Id);
            Console.WriteLine("{0}:\t{1}", "Language", show.Language);
            Console.WriteLine("{0}:\t{1}", "Last update", show.LastUpdated);
            Console.WriteLine("{0}:\t{1}", "Name", show.SeriesName);
            Console.WriteLine("{0}:\t{1}", "Network", show.Network);
            Console.WriteLine("{0}:\t{1}", "Poster", show.Poster);
            Console.WriteLine("{0}:\t{1}", "Rating", show.SiteRating);
            Console.WriteLine("{0}:\t{1}", "# Votes", show.SiteRatingCount);
            Console.WriteLine("{0}:\t{1}", "Runtime", show.Runtime);
            Console.WriteLine("{0}:\t{1}", "Status", show.Status);
            Console.WriteLine("{0}:\t{1}", "Zap2it ID", show.Zap2ItID);
            Console.WriteLine("{0}:\t{1}", "Airday", show.AirsDayOfWeek);
            Console.WriteLine("{0}:\t{1}", "AirTime", show.AirsTime);
            Console.WriteLine("{0}:\t{1}", "Banner", show.Banner);
            Console.WriteLine("{0}:\t{1}", "ContentRating", show.Rating);
            Console.WriteLine("{0}:\t{1}", "Description", show.Overview);
            Console.WriteLine("{0}:\t{1}", "Fanart", show.Fanart);
            Console.WriteLine("{0}:\t{1}", "First aired", show.FirstAired);

            Console.Write("Genres:\t");
            foreach (var element in show.Genre)
            {
                Console.Write("{0} | ", element);
            }
        }
    }
}