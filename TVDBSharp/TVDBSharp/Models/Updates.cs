using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVDBSharp.Models
{
    public class Updates
    {
        public List<UpdatedBanner> UpdatedBanners { get; set; }
        public List<UpdatedEpisode> UpdatedEpisodes { get; set; }
        public List<UpdatedSerie> UpdatedSeries { get; set; }
    }

    public class UpdatedSerie
    {
        public int Id { get; set; }
        public int Time { get; set; }
    }

    public class UpdatedEpisode
    {
        public int Id { get; set; }
        public int SerieId { get; set; }
        public int Time { get; set; }
    }

    public class UpdatedBanner
    {
        public int SerieId { get; set; }
        public string Format { get; set; }
        public string Language { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
        public int? SeasonNum { get; set; }
    }
}
