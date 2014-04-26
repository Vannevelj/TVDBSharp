using System;
using TVDBSharp.Models;

namespace Examples
{
    public class DisplayEpisodeDetails
    {
        /// <summary>
        ///     This example demonstrates the retrieval and display of an episode.
        /// </summary>
        public static void Print(Episode episode)
        {
            Console.WriteLine("{0}:\t{1}", "IMDB ID", episode.ImdbId);
            Console.WriteLine("{0}:\t{1}", "ID", episode.Id);
            Console.WriteLine("{0}:\t{1}", "Language", episode.Language);
            Console.WriteLine("{0}:\t{1}", "Last update", episode.LastUpdated);
            Console.WriteLine("{0}:\t{1}", "Title", episode.Title);
            Console.WriteLine("{0}:\t{1}", "Rating", episode.Rating);
            Console.WriteLine("{0}:\t{1}", "# Votes", episode.RatingCount);
            Console.WriteLine("{0}:\t{1}", "Description", episode.Description);
            Console.WriteLine("{0}:\t{1}", "Director", episode.Director);
            Console.WriteLine("{0}:\t{1}", "EpisodeNumber", episode.EpisodeNumber);
            Console.WriteLine("{0}:\t{1}", "SeasonNumber", episode.SeasonNumber);
            Console.WriteLine("{0}:\t{1}", "Filename", episode.EpisodeImage);
            Console.WriteLine("{0}:\t{1}", "Series ID", episode.SeriesId);
            Console.WriteLine("{0}:\t{1}", "Season ID", episode.SeasonId);
            Console.WriteLine("{0}:\t{1}", "Thumbnail Height", episode.ThumbHeight);
            Console.WriteLine("{0}:\t{1}", "Thumbnail Width", episode.ThumbHeight);

            Console.Write("Gueststars:\t");
            foreach (var element in episode.GuestStars)
            {
                Console.Write(element);
            }

            Console.Write("Writers:\t");
            foreach (var element in episode.Writers)
            {
                Console.Write(element);
            }
        }
    }
}