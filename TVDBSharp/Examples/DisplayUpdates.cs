using System;
using TVDBSharp.Models;

namespace Examples
{
    public class DisplayUpdates
    {
        public static void Print(Updates updates)
        {
            Console.WriteLine("{0} updated shows (ids) ----", updates.UpdatedSeries.Count);
            foreach (var show in updates.UpdatedSeries)
            {
                Console.WriteLine("show #{0}; {1}", show.Id, show.Timestamp);
            }
            Console.WriteLine();
            Console.WriteLine("{0} updated episodes (ids) ----", updates.UpdatedEpisodes.Count);
            foreach (var episode in updates.UpdatedEpisodes)
            {
                Console.WriteLine("{0} (serie #{1}); {2}", episode.Id, episode.SerieId, episode.Timestamp);
            }
            Console.WriteLine();
            Console.WriteLine("{0} updated banners ----", updates.UpdatedBanners.Count);
            foreach (var banner in updates.UpdatedBanners)
            {
                Console.WriteLine("{0} (serie #{1}) - {2}; {3}", banner.Path, banner.SerieId, banner.Format,
                    banner.Timestamp);
            }
        }
    }
}