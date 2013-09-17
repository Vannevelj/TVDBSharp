using System;
using System.Configuration;
using System.Linq;
using TVDBSharp;

namespace Examples {
    public class DisplayEpisodeDetails {
        /// <summary>
        /// This example demonstrates the retrieval and display of an episode.
        /// </summary>
        public DisplayEpisodeDetails() {
            var apikey = ConfigurationManager.AppSettings["apikey"]; // Your own API key
            var seriesid = "76290";

            var tvdb = new TVDB(apikey);
            var result = tvdb.GetShow(seriesid).Episodes.FirstOrDefault(x => x.EpisodeNumber == 8 && x.SeasonNumber == 2);

            Console.WriteLine("{0}:\t{1}", "IMDB ID", result.ImdbID);
            Console.WriteLine("{0}:\t{1}", "ID", result.ID);
            Console.WriteLine("{0}:\t{1}", "Language", result.Language);
            Console.WriteLine("{0}:\t{1}", "Last update", result.LastUpdated);
            Console.WriteLine("{0}:\t{1}", "Title", result.Title);
            Console.WriteLine("{0}:\t{1}", "Rating", result.Rating);
            Console.WriteLine("{0}:\t{1}", "# Votes", result.RatingCount);
            Console.WriteLine("{0}:\t{1}", "Description", result.Description);
            Console.WriteLine("{0}:\t{1}", "Director", result.Director);
            Console.WriteLine("{0}:\t{1}", "EpisodeNumber", result.EpisodeNumber);
            Console.WriteLine("{0}:\t{1}", "SeasonNumber", result.SeasonNumber);
            Console.WriteLine("{0}:\t{1}", "Filename", result.FileName);
            Console.WriteLine("{0}:\t{1}", "Series ID", result.SeriesID);
            Console.WriteLine("{0}:\t{1}", "Season ID", result.SeasonID);
            Console.WriteLine("{0}:\t{1}", "Thumbnail Height", result.ThumbHeight);
            Console.WriteLine("{0}:\t{1}", "Thumbnail Width", result.ThumbHeight);

            Console.Write("Gueststars:\t");
            foreach (var element in result.GuestStars) {
                Console.Write(element);
            }

            Console.Write("Writers:\t");
            foreach (var element in result.Writers) {
                Console.Write(element);
            }

            Console.ReadKey();
        }
    }
}