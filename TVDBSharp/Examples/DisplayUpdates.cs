using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                Console.WriteLine(show.Id);
            }
            Console.WriteLine();
            Console.WriteLine("{0} updated episodes (ids) ----", updates.UpdatedEpisodes.Count);
            foreach (var episode in updates.UpdatedEpisodes)
            {
                Console.WriteLine("{0} (serie #{1})", episode.Id, episode.SerieId);
            }
            Console.WriteLine();
            Console.WriteLine("{0} updated banners ----", updates.UpdatedBanners.Count);
            foreach (var banner in updates.UpdatedBanners)
            {
                Console.WriteLine("{0} (serie #{1}) - {2}", banner.Path, banner.SerieId, banner.Format);
            }
        }
    }
}
